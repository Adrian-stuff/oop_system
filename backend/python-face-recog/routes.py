import os
import base64
import json
from typing import Union

from flask import Blueprint, request, current_app, jsonify
from PIL import Image
from io import BytesIO
import numpy as np

from deepface import DeepFace
import service
from deepface.commons import image_utils
from deepface.commons.logger import Logger

logger = Logger()

blueprint = Blueprint("routes", __name__)

# pylint: disable=no-else-return, broad-except


def extract_image_from_request(img_key: str) -> Union[str, np.ndarray]:
    """
    Extracts an image from the request either from json or a multipart/form-data file.

    Args:
        img_key (str): The key used to retrieve the image data
            from the request (e.g., 'img1').

    Returns:
        img (str or np.ndarray): Given image detail (base64 encoded string, image path or url)
            or the decoded image as a numpy array.
    """

    if request.files:
        file = request.files.get(img_key)

        if file is None:
            raise ValueError(f"Request form data doesn't have {img_key}")

        if file.filename == "":
            raise ValueError(f"No file uploaded for '{img_key}'")

        img = image_utils.load_image_from_file_storage(file)

        return img
    elif request.is_json or request.form:
        input_args = request.get_json() or request.form.to_dict()

        if input_args is None:
            raise ValueError("empty input set passed")

        img = input_args.get(img_key)

        if not img:
            raise ValueError(
                f"'{img_key}' not found in either json or form data request"
            )

        return img

    raise ValueError(f"'{img_key}' not found in request in either json or form data")


@blueprint.route("/addFace", methods=["POST"])
def addFace():
    input_args = (request.is_json and request.get_json()) or (
        request.form and request.form.to_dict()
    )

    face_id = request.args.get("id") or (input_args and input_args.get("id"))

    if not face_id:
        return jsonify({"error": "Missing 'id' parameter"}), 400

    try:
        img1_data = extract_image_from_request("img")
        image_to_save = None

        if isinstance(img1_data, np.ndarray):
            img1_data_rgb = img1_data[:, :, ::-1]
            image_to_save = Image.fromarray(img1_data_rgb.astype("uint8"))
        elif isinstance(img1_data, str):
            if "," in img1_data:
                img1_data = img1_data.split(",")[1]

            img_bytes = base64.b64decode(img1_data)
            image_to_save = Image.open(BytesIO(img_bytes))

        else:
            raise TypeError(
                "Unsupported image data format returned by extract_image_from_request."
            )

    except Exception as err:
        return jsonify({"exception": str(err)}), 400

    database_dir = os.path.join(current_app.root_path, "database")
    target_dir = os.path.join(database_dir, str(face_id))

    if os.path.exists(target_dir):
        count = len(
            [
                name
                for name in os.listdir(target_dir)
                if os.path.isfile(os.path.join(target_dir, name))
            ]
        )
    else:
        count = 0

    filename = f"{count + 1}.png"
    target_path = os.path.join(target_dir, filename)

    try:
        os.makedirs(target_dir, exist_ok=True)
    except OSError as err:
        return jsonify({"error": f"Failed to create directory: {str(err)}"}), 500

    try:
        image_to_save.save(target_path, format="PNG")
        return jsonify({"success": True, "path": f"/database/{face_id}/{filename}"}), 200
    except Exception as err:
        return jsonify({"error": f"Failed to save image: {str(err)}"}), 500


@blueprint.route("/verify", methods=["POST"])
def verify():
    input_args = (request.is_json and request.get_json()) or (
        request.form and request.form.to_dict()
    )

    try:
        img = extract_image_from_request("img")
    except Exception as err:
        return jsonify({"exception": str(err)}), 400

    try:
        df = service.verify(
            img_path=img,
            model_name=input_args.get("model_name", "VGG-Face") ,
            detector_backend=input_args.get("detector_backend", "ssd") ,
            distance_metric=input_args.get("distance_metric", "euclidean_l2") ,
            align=input_args.get("align", True) ,
            enforce_detection=input_args.get("enforce_detection", True) ,
            anti_spoofing=input_args.get("anti_spoofing", False) 
        )
    except ValueError as e:
        error_msg = str(e)
        if "Face could not be detected" in error_msg or "could not be detected" in error_msg.lower():
            return jsonify({
                "verified": False,
                "id": None,
                "reason": "No face detected in the input image. Please ensure the photo contains a clear face.",
            }), 200
        if "Length of values" in error_msg or "does not match length" in error_msg or "confidence" in error_msg.lower():
            logger.error(f"DeepFace internal error (known bug with multiple images in database): {error_msg}")
            return jsonify({
                "verified": False,
                "id": None,
                "reason": "Face recognition service encountered an internal error. This may occur when there are multiple images stored for a person in the database. Please contact support.",
            }), 200
        logger.error(f"DeepFace ValueError: {error_msg}")
        return jsonify({
            "verified": False,
            "id": None,
            "reason": f"Image processing error: {error_msg}"
        }), 200
    except Exception as e:
        error_msg = str(e)
        if "Face could not be detected" in error_msg or "could not be detected" in error_msg.lower():
            return jsonify({
                "verified": False,
                "id": None,
                "reason": "No face detected in the input image. Please ensure the photo contains a clear face.",
            }), 200
        if "Length of values" in error_msg or "does not match length" in error_msg or "confidence" in error_msg.lower():
            logger.error(f"DeepFace internal error (known bug with multiple images in database): {error_msg}")
            return jsonify({
                "verified": False,
                "id": None,
                "reason": "Face recognition service encountered an internal error. This may occur when there are multiple images stored for a person in the database. Please contact support.",
            }), 200
        logger.error(f"DeepFace service error: {error_msg}")
        return jsonify({
            "verified": False,
            "id": None,
            "reason": f"Internal verification service error: {error_msg}"
        }), 200

    if not df or len(df) == 0:
        return jsonify({
            "verified": False,
            "id": None,
            "reason": "No matching face found in database.",
        }), 200

    result_df = df[0]

    if result_df.empty:
        return jsonify({
            "verified": False,
            "id": None,
            "reason": "No matching face found in database.",
        }), 200

    def extract_id(path):
        if isinstance(path, str):
            parts = path.split(os.sep)
            if len(parts) >= 2:
                return parts[-2]
        return None

    result_df["id"] = result_df["identity"].apply(extract_id)
    result_df = result_df.drop(columns=["identity"])

    result_df["verified"] = True

    logger.debug(result_df)

    result_json = result_df.to_json(orient="records")
    return jsonify(json.loads(result_json)), 200
