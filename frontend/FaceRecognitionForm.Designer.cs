namespace frontend
{
    partial class FaceRecognitionForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
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
            ((System.ComponentModel.ISupportInitialize)cameraView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)capturedFaceView).BeginInit();
            SuspendLayout();
            // 
            // cameraView
            // 
            cameraView.BackColor = Color.Black;
            cameraView.BorderStyle = BorderStyle.FixedSingle;
            cameraView.Location = new Point(11, 13);
            cameraView.Margin = new Padding(3, 4, 3, 4);
            cameraView.Name = "cameraView";
            cameraView.Size = new Size(503, 439);
            cameraView.SizeMode = PictureBoxSizeMode.Zoom;
            cameraView.TabIndex = 0;
            cameraView.TabStop = false;
            // 
            // capturedFaceView
            // 
            capturedFaceView.BackColor = Color.Black;
            capturedFaceView.BorderStyle = BorderStyle.FixedSingle;
            capturedFaceView.Location = new Point(520, 13);
            capturedFaceView.Margin = new Padding(3, 4, 3, 4);
            capturedFaceView.Name = "capturedFaceView";
            capturedFaceView.Size = new Size(200, 200);
            capturedFaceView.SizeMode = PictureBoxSizeMode.Zoom;
            capturedFaceView.TabIndex = 8;
            capturedFaceView.TabStop = false;
            // 
            // modeLabel
            // 
            modeLabel.AutoSize = true;
            modeLabel.Location = new Point(11, 467);
            modeLabel.Name = "modeLabel";
            modeLabel.Size = new Size(51, 20);
            modeLabel.TabIndex = 1;
            modeLabel.Text = "Mode:";
            // 
            // modeComboBox
            // 
            modeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            modeComboBox.FormattingEnabled = true;
            modeComboBox.Items.AddRange(new object[] { "Time In", "Time Out" });
            modeComboBox.Location = new Point(80, 463);
            modeComboBox.Margin = new Padding(3, 4, 3, 4);
            modeComboBox.Name = "modeComboBox";
            modeComboBox.Size = new Size(171, 28);
            modeComboBox.TabIndex = 2;
            modeComboBox.SelectedIndexChanged += modeComboBox_SelectedIndexChanged;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(11, 507);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(97, 20);
            statusLabel.TabIndex = 3;
            statusLabel.Text = "Status: Ready";
            // 
            // loadingLabel
            // 
            loadingLabel.AutoSize = true;
            loadingLabel.Font = new Font("Arial", 9F, FontStyle.Bold);
            loadingLabel.ForeColor = Color.Blue;
            loadingLabel.Location = new Point(11, 547);
            loadingLabel.Name = "loadingLabel";
            loadingLabel.Size = new Size(0, 18);
            loadingLabel.TabIndex = 4;
            // 
            // startButton
            // 
            startButton.Location = new Point(11, 587);
            startButton.Margin = new Padding(3, 4, 3, 4);
            startButton.Name = "startButton";
            startButton.Size = new Size(114, 40);
            startButton.TabIndex = 5;
            startButton.Text = "Start Camera";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += StartButton_Click;
            // 
            // stopButton
            // 
            stopButton.Enabled = false;
            stopButton.Location = new Point(137, 587);
            stopButton.Margin = new Padding(3, 4, 3, 4);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(114, 40);
            stopButton.TabIndex = 6;
            stopButton.Text = "Stop Camera";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += StopButton_Click;
            // 
            // registerButton
            // 
            registerButton.Location = new Point(257, 587);
            registerButton.Margin = new Padding(3, 4, 3, 4);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(114, 40);
            registerButton.TabIndex = 7;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += RegisterButton_Click;
            // 
            // frameTimer
            // 
            frameTimer.Interval = 33;
            frameTimer.Tick += FrameTimer_Tick;
            // 
            // FaceRecognitionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 640);
            Controls.Add(capturedFaceView);
            Controls.Add(registerButton);
            Controls.Add(stopButton);
            Controls.Add(startButton);
            Controls.Add(loadingLabel);
            Controls.Add(statusLabel);
            Controls.Add(modeComboBox);
            Controls.Add(modeLabel);
            Controls.Add(cameraView);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FaceRecognitionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Face Recognition Attendance";
            ((System.ComponentModel.ISupportInitialize)cameraView).EndInit();
            ((System.ComponentModel.ISupportInitialize)capturedFaceView).EndInit();
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
    }
}

