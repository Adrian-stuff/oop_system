namespace frontend
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            cameraView = new PictureBox();
            firstNameLabel = new Label();
            firstNameTextBox = new TextBox();
            lastNameLabel = new Label();
            lastNameTextBox = new TextBox();
            emailLabel = new Label();
            emailTextBox = new TextBox();
            birthDateLabel = new Label();
            birthDatePicker = new DateTimePicker();
            captureButton = new Button();
            statusLabel = new Label();
            frameTimer = new System.Windows.Forms.Timer(components);
            picturebox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)cameraView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picturebox2).BeginInit();
            SuspendLayout();
            // 
            // cameraView
            // 
            cameraView.BackColor = Color.Black;
            cameraView.BorderStyle = BorderStyle.FixedSingle;
            cameraView.Location = new Point(66, 48);
            cameraView.Name = "cameraView";
            cameraView.Size = new Size(287, 199);
            cameraView.SizeMode = PictureBoxSizeMode.Zoom;
            cameraView.TabIndex = 0;
            cameraView.TabStop = false;
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Font = new Font("Bruno Ace SC", 12F);
            firstNameLabel.ForeColor = SystemColors.ButtonFace;
            firstNameLabel.Location = new Point(436, 39);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(121, 19);
            firstNameLabel.TabIndex = 1;
            firstNameLabel.Text = "First Name:";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(564, 35);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(200, 23);
            firstNameTextBox.TabIndex = 2;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Font = new Font("Bruno Ace SC", 12F);
            lastNameLabel.ForeColor = SystemColors.ButtonFace;
            lastNameLabel.Location = new Point(436, 92);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(116, 19);
            lastNameLabel.TabIndex = 3;
            lastNameLabel.Text = "Last Name:";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(564, 88);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(200, 23);
            lastNameTextBox.TabIndex = 4;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Bruno Ace SC", 12F);
            emailLabel.ForeColor = SystemColors.ButtonFace;
            emailLabel.Location = new Point(436, 145);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(67, 19);
            emailLabel.TabIndex = 5;
            emailLabel.Text = "Email:";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(564, 145);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(200, 23);
            emailTextBox.TabIndex = 6;
            // 
            // birthDateLabel
            // 
            birthDateLabel.AutoSize = true;
            birthDateLabel.Font = new Font("Bruno Ace SC", 12F);
            birthDateLabel.ForeColor = SystemColors.ButtonFace;
            birthDateLabel.Location = new Point(436, 191);
            birthDateLabel.Name = "birthDateLabel";
            birthDateLabel.Size = new Size(120, 19);
            birthDateLabel.TabIndex = 7;
            birthDateLabel.Text = "Birth Date:";
            // 
            // birthDatePicker
            // 
            birthDatePicker.Location = new Point(564, 187);
            birthDatePicker.Name = "birthDatePicker";
            birthDatePicker.Size = new Size(200, 23);
            birthDatePicker.TabIndex = 8;
            birthDatePicker.Value = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // captureButton
            // 
            captureButton.BackColor = Color.FromArgb(1, 252, 46);
            captureButton.Enabled = false;
            captureButton.FlatStyle = FlatStyle.Popup;
            captureButton.Font = new Font("Bruno Ace SC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            captureButton.Location = new Point(521, 248);
            captureButton.Name = "captureButton";
            captureButton.Size = new Size(136, 55);
            captureButton.TabIndex = 9;
            captureButton.Text = "CAPTURE/REGISTER";
            captureButton.UseVisualStyleBackColor = false;
            captureButton.Click += CaptureButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Font = new Font("Bruno Ace SC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusLabel.ForeColor = SystemColors.ButtonFace;
            statusLabel.Location = new Point(12, 295);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(71, 19);
            statusLabel.TabIndex = 10;
            statusLabel.Text = "Ready";
            // 
            // frameTimer
            // 
            frameTimer.Interval = 33;
            frameTimer.Tick += FrameTimer_Tick;
            // 
            // picturebox2
            // 
            picturebox2.BackColor = Color.FromArgb(36, 38, 58);
            picturebox2.Image = (Image)resources.GetObject("picturebox2.Image");
            picturebox2.Location = new Point(12, 12);
            picturebox2.Name = "picturebox2";
            picturebox2.Size = new Size(393, 271);
            picturebox2.SizeMode = PictureBoxSizeMode.StretchImage;
            picturebox2.TabIndex = 11;
            picturebox2.TabStop = false;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(36, 38, 58);
            ClientSize = new Size(794, 366);
            Controls.Add(statusLabel);
            Controls.Add(captureButton);
            Controls.Add(birthDatePicker);
            Controls.Add(birthDateLabel);
            Controls.Add(emailTextBox);
            Controls.Add(emailLabel);
            Controls.Add(lastNameTextBox);
            Controls.Add(lastNameLabel);
            Controls.Add(firstNameTextBox);
            Controls.Add(firstNameLabel);
            Controls.Add(cameraView);
            Controls.Add(picturebox2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register New User";
            Load += RegisterForm_Load;
            ((System.ComponentModel.ISupportInitialize)cameraView).EndInit();
            ((System.ComponentModel.ISupportInitialize)picturebox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox cameraView;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label birthDateLabel;
        private System.Windows.Forms.DateTimePicker birthDatePicker;
        private System.Windows.Forms.Button captureButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Timer frameTimer;
        private PictureBox picturebox2;
    }
}
