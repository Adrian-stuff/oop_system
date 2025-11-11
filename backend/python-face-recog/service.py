# built-in dependencies
import traceback
from typing import Optional, Union
import os
from flask import current_app

# 3rd party dependencies
import numpy as np

# project dependencies
from deepface import DeepFace
from deepface.commons.logger import Logger

logger = Logger()


# pylint: disable=broad-except


def verify(
    img_path: Union[str, np.ndarray],
    model_name: str,
    detector_backend: str,
    distance_metric: str,
    enforce_detection: bool,
    align: bool,
    anti_spoofing: bool,
):
    try:
        database_dir = os.path.join(current_app.root_path, "database")

        # Try to use find with silent=True to avoid some internal errors
        try:
            obj = DeepFace.find(
                img_path=img_path,
                db_path=database_dir,
                model_name=model_name,
                detector_backend=detector_backend,
                distance_metric=distance_metric,
                align=align,
                enforce_detection=enforce_detection,
                anti_spoofing=anti_spoofing,
            )
            return obj
        except (ValueError, KeyError) as ve:
            # Catch the "Length of values" error which is a DeepFace bug
            # This can happen when there are multiple images in database folders
            error_msg = str(ve)
            if "Length of values" in error_msg or "does not match length" in error_msg or "confidence" in error_msg.lower():
                logger.warning(f"DeepFace find() encountered internal error (likely due to multiple images per person): {error_msg}")
                # Re-raise with a clearer message that will be caught by routes.py
                raise ValueError(f"DeepFace internal error: {error_msg}. This may occur when there are multiple images in database folders.")
            raise
    except Exception as err:
        tb_str = traceback.format_exc()
        logger.error(str(err))
        logger.error(tb_str)
        raise
