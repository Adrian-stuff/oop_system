namespace frontend

{

    partial class FaceRecognitionForm

    {

        /// <summary>

        /// Required designer variable.

        /// </summary>

        private System.ComponentModel.IContainer components = null;



        /// <summary>

        /// Clean up any resources being used.

        /// </summary>

        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        protected override void Dispose(bool disposing)

        {

            if (disposing && (components != null))

            {

                components.Dispose();

            }

            base.Dispose(disposing);

        }



        #region Windows Form Designer generated code



        /// <summary>

        /// Required method for Designer support - do not modify

        /// the contents of this method with the code editor.

        /// </summary>

        private void InitializeComponent()

        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaceRecognitionForm));
            cameraView = new PictureBox();
            capturedFaceView = new PictureBox();
            modeLabel = new Label();
            modeComboBox = new ComboBox();
            statusLabel = new Label();
            loadingLabel = new Label();
            startButton = new Button();
            stopButton = new Button();
            registerButton = new Button();
            frameTimer = new System.Windows.Forms.Timer(components);
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)cameraView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)capturedFaceView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // cameraView
            // 
            cameraView.BackColor = Color.Black;
            cameraView.BorderStyle = BorderStyle.FixedSingle;
            cameraView.Location = new Point(70, 51);
            cameraView.Name = "cameraView";
            cameraView.Size = new Size(304, 213);
            cameraView.SizeMode = PictureBoxSizeMode.Zoom;
            cameraView.TabIndex = 0;
            cameraView.TabStop = false;
            // 
            // capturedFaceView
            // 
            capturedFaceView.BackColor = Color.Black;
            capturedFaceView.BorderStyle = BorderStyle.FixedSingle;
            capturedFaceView.Location = new Point(482, 26);
            capturedFaceView.Name = "capturedFaceView";
            capturedFaceView.Size = new Size(128, 112);
            capturedFaceView.SizeMode = PictureBoxSizeMode.Zoom;
            capturedFaceView.TabIndex = 8;
            capturedFaceView.TabStop = false;
            // 
            // modeLabel
            // 
            modeLabel.AutoSize = true;
            modeLabel.Font = new Font("Bruno Ace SC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            modeLabel.ForeColor = SystemColors.ButtonFace;
            modeLabel.Location = new Point(26, 333);
            modeLabel.Name = "modeLabel";
            modeLabel.Size = new Size(65, 19);
            modeLabel.TabIndex = 1;
            modeLabel.Text = "Mode:";
            // 
            // modeComboBox
            // 
            modeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            modeComboBox.Font = new Font("Bruno Ace SC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            modeComboBox.FormattingEnabled = true;
            modeComboBox.Items.AddRange(new object[] { "Time In", "Time Out" });
            modeComboBox.Location = new Point(99, 330);
            modeComboBox.Name = "modeComboBox";
            modeComboBox.Size = new Size(150, 27);
            modeComboBox.TabIndex = 2;
            modeComboBox.SelectedIndexChanged += modeComboBox_SelectedIndexChanged;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Font = new Font("Bruno Ace SC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusLabel.ForeColor = SystemColors.ButtonHighlight;
            statusLabel.Location = new Point(26, 300);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(150, 19);
            statusLabel.TabIndex = 3;
            statusLabel.Text = "Status: Ready";
            // 
            // loadingLabel
            // 
            loadingLabel.AutoSize = true;
            loadingLabel.Font = new Font("Arial", 9F, FontStyle.Bold);
            loadingLabel.ForeColor = Color.Blue;
            loadingLabel.Location = new Point(10, 410);
            loadingLabel.Name = "loadingLabel";
            loadingLabel.Size = new Size(0, 15);
            loadingLabel.TabIndex = 4;
            // 
            // startButton
            // 
            startButton.Anchor = AnchorStyles.Top;
            startButton.BackColor = Color.FromArgb(1, 252, 46);
            startButton.FlatStyle = FlatStyle.Popup;
            startButton.Font = new Font("Bruno Ace SC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            startButton.Location = new Point(10, 394);
            startButton.Name = "startButton";
            startButton.Size = new Size(100, 30);
            startButton.TabIndex = 5;
            startButton.Text = "Start Camera";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += StartButton_Click;
            // 
            // stopButton
            // 
            stopButton.BackColor = Color.FromArgb(198, 62, 62);
            stopButton.Enabled = false;
            stopButton.FlatStyle = FlatStyle.Popup;
            stopButton.Font = new Font("Bruno Ace SC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stopButton.Location = new Point(149, 394);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(100, 30);
            stopButton.TabIndex = 6;
            stopButton.Text = "Stop Camera";
            stopButton.UseVisualStyleBackColor = false;
            stopButton.Click += StopButton_Click;
            // 
            // registerButton
            // 
            registerButton.BackColor = Color.FromArgb(222, 248, 22);
            registerButton.FlatStyle = FlatStyle.Popup;
            registerButton.Font = new Font("Bruno Ace SC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            registerButton.Location = new Point(497, 395);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(113, 30);
            registerButton.TabIndex = 7;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = false;
            registerButton.Click += RegisterButton_Click;
            // 
            // frameTimer
            // 
            frameTimer.Interval = 33;
            frameTimer.Tick += FrameTimer_Tick;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(36, 38, 58);
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(26, 26);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(393, 271);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // FaceRecognitionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(36, 38, 58);
            ClientSize = new Size(640, 480);
            Controls.Add(capturedFaceView);
            Controls.Add(registerButton);
            Controls.Add(stopButton);
            Controls.Add(startButton);
            Controls.Add(loadingLabel);
            Controls.Add(statusLabel);
            Controls.Add(modeComboBox);
            Controls.Add(modeLabel);
            Controls.Add(cameraView);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FaceRecognitionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Face Recognition Attendance";
            ((System.ComponentModel.ISupportInitialize)cameraView).EndInit();
            ((System.ComponentModel.ISupportInitialize)capturedFaceView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }



        #endregion



        private System.Windows.Forms.PictureBox cameraView;

        private System.Windows.Forms.PictureBox capturedFaceView;

        private System.Windows.Forms.Label modeLabel;

        private System.Windows.Forms.ComboBox modeComboBox;

        private System.Windows.Forms.Label statusLabel;

        private System.Windows.Forms.Label loadingLabel;

        private System.Windows.Forms.Button startButton;

        private System.Windows.Forms.Button stopButton;

        private System.Windows.Forms.Button registerButton;

        private System.Windows.Forms.Timer frameTimer;
        private PictureBox pictureBox2;
    }

}