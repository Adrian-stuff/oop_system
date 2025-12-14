using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Drawing.Drawing2D;

namespace frontend
{
    public partial class RegisterForm : Form
    {
        private VideoCapture? _camera;
        private CascadeClassifier? _faceCascade;
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://localhost:5207/api/UserDatas";
        private bool _isProcessing = false;

        public RegisterForm()
        {
            InitializeComponent();
            _httpClient = new HttpClient();

            // Timer setup
            frameTimer.Interval = 33;
            frameTimer.Tick += FrameTimer_Tick;

            LoadFaceCascade();

            // --- CIRCLE CAMERA SETUP ---

            // 1. Essential: Stretch the image so the square video fills the circle
            cameraView.SizeMode = PictureBoxSizeMode.StretchImage;

            // 2. Make it circular
            MakeControlCircular(cameraView);

            // 3. Ensure it stays circular even if the layout changes
            cameraView.SizeChanged += (s, e) => MakeControlCircular(cameraView);


            // --- CURVED BOX SETUP (Your existing code) ---
            int cornerRadius = 30;
            GraphicsPath path1 = new GraphicsPath();
            int diameter = cornerRadius * 2;
            int w = picturebox2.Width;
            int h = picturebox2.Height;

            path1.AddArc(0, 0, diameter, diameter, 180, 90);
            path1.AddArc(w - diameter, 0, diameter, diameter, 270, 90);
            path1.AddArc(w - diameter, h - diameter, diameter, diameter, 0, 90);
            path1.AddArc(0, h - diameter, diameter, diameter, 90, 90);

            path1.CloseFigure();
            picturebox2.Region = new Region(path1);
        }

        private void MakeControlCircular(Control control)
        {
            using GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, control.Width, control.Height);
            control.Region = new Region(path);
        }

        private void Box3_Paint(object sender, PaintEventArgs e)
        {
            // Get the dimensions of the PictureBox
            PictureBox pb = (PictureBox)sender;

            // Ensure the width and height are equal (or close) for a perfect circle/ellipse
            int radius = Math.Min(pb.Width, pb.Height);

            // Create a GraphicsPath object
            using (GraphicsPath path = new GraphicsPath())
            {
                // Define an ellipse that fits within the PictureBox's bounds
                // The 0,0 starts at the top-left corner of the PictureBox
                path.AddEllipse(0, 0, radius, radius);

                // Set the control's drawing region to the newly created path (the circle)
                pb.Region = new Region(path);
            }
        }

        private void LoadFaceCascade()
        {
            try
            {
                string[] possiblePaths = new[]
                {
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "haarcascade_frontalface_default.xml"),
                    Path.Combine(Environment.CurrentDirectory, "haarcascade_frontalface_default.xml"),
                    "haarcascade_frontalface_default.xml"
                };

                string? cascadePath = null;
                foreach (var path in possiblePaths)
                {
                    string fullPath = Path.IsPathRooted(path) ? path : Path.GetFullPath(path);
                    if (File.Exists(fullPath))
                    {
                        cascadePath = fullPath;
                        break;
                    }
                }

                if (cascadePath != null)
                {
                    _faceCascade = new CascadeClassifier(cascadePath);
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"Error loading face detector: {ex.Message}";
            }
        }

        private void RegisterForm_Load(object? sender, EventArgs e)
        {
            StartCamera();
        }

        private void StartCamera()
        {
            try
            {
                _camera = new VideoCapture(0);
                if (!_camera.IsOpened)
                {
                    MessageBox.Show("Failed to open camera.", "Camera Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                frameTimer.Start();
                statusLabel.Text = "Camera started. Position your face in the frame.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting camera: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrameTimer_Tick(object? sender, EventArgs e)
        {
            if (_camera == null || !_camera.IsOpened)
                return;

            try
            {
                using Mat frame = new Mat();
                if (!_camera.Read(frame) || frame.IsEmpty)
                    return;

                // 1. CROP TO SQUARE: Logic to center-crop the video feed
                int size = Math.Min(frame.Width, frame.Height); // Get the smallest side
                int x = (frame.Width - size) / 2; // Calculate center offset X
                int y = (frame.Height - size) / 2; // Calculate center offset Y
                Rectangle cropRect = new Rectangle(x, y, size, size);

                // Create the square frame from the raw frame
                using Mat squareFrame = new Mat(frame, cropRect);

                // 2. Convert to RGB for display (Using the SQUARE frame now)
                using Mat rgbFrame = new Mat();
                CvInvoke.CvtColor(squareFrame, rgbFrame, ColorConversion.Bgr2Rgb);

                // 3. Detect faces (Using the SQUARE frame)
                Rectangle[] faces = DetectFaces(squareFrame);

                // Draw bounding boxes
                if (faces.Length > 0)
                {
                    foreach (var face in faces)
                    {
                        CvInvoke.Rectangle(rgbFrame, face, new MCvScalar(0, 255, 0), 2);
                    }
                    captureButton.Enabled = true;
                }
                else
                {
                    captureButton.Enabled = false;
                }

                // Display frame
                Bitmap bitmap = MatToBitmapRgb(rgbFrame);
                var oldImage = cameraView.Image;
                cameraView.Image = bitmap;
                oldImage?.Dispose();
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"Error processing frame: {ex.Message}";
            }
        }

        private Rectangle[] DetectFaces(Mat frame)
        {
            if (_faceCascade == null)
                return Array.Empty<Rectangle>();

            try
            {
                using Mat gray = new Mat();
                CvInvoke.CvtColor(frame, gray, ColorConversion.Bgr2Gray);
                CvInvoke.EqualizeHist(gray, gray);

                Rectangle[] faces = _faceCascade.DetectMultiScale(
                    gray,
                    1.1,
                    3,
                    new Size(30, 30),
                    Size.Empty
                );

                return faces;
            }
            catch
            {
                return Array.Empty<Rectangle>();
            }
        }

        private Bitmap MatToBitmapRgb(Mat mat)
        {
            using Image<Rgb, byte> image = mat.ToImage<Rgb, byte>();
            return image.AsBitmap();
        }

        private string BitmapToBase64(Bitmap bitmap)
        {
            using MemoryStream ms = new MemoryStream();
            var jpegEncoder = ImageCodecInfo.GetImageEncoders().FirstOrDefault(codec => codec.FormatID == ImageFormat.Jpeg.Guid);
            if (jpegEncoder != null)
            {
                var encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)90);
                bitmap.Save(ms, jpegEncoder, encoderParams);
            }
            else
            {
                bitmap.Save(ms, ImageFormat.Jpeg);
            }
            byte[] imageBytes = ms.ToArray();
            return Convert.ToBase64String(imageBytes);
        }

        private async void CaptureButton_Click(object? sender, EventArgs e)
        {
            if (_isProcessing || _camera == null || !_camera.IsOpened)
                return;

            // Validate form fields
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text))
            {
                MessageBox.Show("Please enter your first name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(lastNameTextBox.Text))
            {
                MessageBox.Show("Please enter your last name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(emailTextBox.Text) || !emailTextBox.Text.Contains("@"))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (birthDatePicker.Value == null || birthDatePicker.Value > DateTime.Now.AddYears(-10))
            {
                MessageBox.Show("Please enter a valid birth date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isProcessing = true;
            captureButton.Enabled = false;
            statusLabel.Text = "Capturing face...";

            try
            {
                using Mat frame = new Mat();
                if (!_camera.Read(frame) || frame.IsEmpty)
                {
                    statusLabel.Text = "Failed to capture frame.";
                    _isProcessing = false;
                    captureButton.Enabled = true;
                    return;
                }

                // Detect face and crop
                Rectangle[] faces = DetectFaces(frame);
                if (faces.Length == 0)
                {
                    MessageBox.Show("No face detected. Please position your face in the camera view.", "No Face Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    statusLabel.Text = "No face detected. Please try again.";
                    _isProcessing = false;
                    captureButton.Enabled = true;
                    return;
                }

                // Crop the first detected face
                Rectangle faceRect = faces[0];
                int padding = 50;
                int x = Math.Max(0, faceRect.X - padding);
                int y = Math.Max(0, faceRect.Y - padding);
                int width = Math.Min(frame.Width - x, faceRect.Width + padding * 2);
                int height = Math.Min(frame.Height - y, faceRect.Height + padding * 2);

                using Mat croppedFace = new Mat(frame, new Rectangle(x, y, width, height));
                using Bitmap faceBitmap = MatToBitmap(croppedFace);

                // Prepare multipart/form-data
                using var formData = new MultipartFormDataContent();

                // Convert bitmap to byte array
                byte[] imageBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    var jpegEncoder = ImageCodecInfo.GetImageEncoders().FirstOrDefault(codec => codec.FormatID == ImageFormat.Jpeg.Guid);
                    if (jpegEncoder != null)
                    {
                        var encoderParams = new EncoderParameters(1);
                        encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)90);
                        faceBitmap.Save(ms, jpegEncoder, encoderParams);
                    }
                    else
                    {
                        faceBitmap.Save(ms, ImageFormat.Jpeg);
                    }
                    imageBytes = ms.ToArray();
                }

                // Add image file
                var imageContent = new ByteArrayContent(imageBytes);
                imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                formData.Add(imageContent, "Photo", "face.jpg");

                // Add form fields
                formData.Add(new StringContent(firstNameTextBox.Text.Trim()), "FirstName");
                formData.Add(new StringContent(lastNameTextBox.Text.Trim()), "LastName");
                formData.Add(new StringContent(emailTextBox.Text.Trim()), "Email");
                formData.Add(new StringContent(birthDatePicker.Value.ToString("yyyy-MM-dd")), "BirthDate");
                // StudentNumber is optional - backend will use Email as fallback if not provided
                formData.Add(new StringContent(""), "StudentNumber");

                statusLabel.Text = "Registering user...";
                var response = await _httpClient.PostAsync(_apiBaseUrl, formData);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("User registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    statusLabel.Text = "Registration successful!";

                    // Clear form
                    firstNameTextBox.Clear();
                    lastNameTextBox.Clear();
                    emailTextBox.Clear();
                    birthDatePicker.Value = DateTime.Now.AddYears(-25);
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Registration failed: {errorContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = $"Registration failed: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during registration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = $"Error: {ex.Message}";
            }
            finally
            {
                _isProcessing = false;
                captureButton.Enabled = true;
            }
        }

        private Bitmap MatToBitmap(Mat mat)
        {
            using Image<Bgr, byte> image = mat.ToImage<Bgr, byte>();
            return image.AsBitmap();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            frameTimer?.Stop();
            if (_camera != null)
            {
                _camera.Dispose();
                _camera = null;
            }
            _faceCascade?.Dispose();
            _httpClient?.Dispose();
            base.OnFormClosing(e);
        }

        private void cameraView_Click(object sender, EventArgs e)
        {

        }
    }
}
