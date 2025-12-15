using System.Windows.Forms;
using System.Drawing;

namespace frontend
{
    partial class UserProfileForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pbProfile = new PictureBox();
            lblName = new Label();
            lblStudentNumber = new Label();
            lblEmail = new Label();
            lblBirthDate = new Label();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)pbProfile).BeginInit();
            SuspendLayout();
            // 
            // pbProfile
            // 
            pbProfile.BackColor = Color.Gray;
            pbProfile.Location = new Point(131, 22);
            pbProfile.Margin = new Padding(3, 2, 3, 2);
            pbProfile.Name = "pbProfile";
            pbProfile.Size = new Size(175, 150);
            pbProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            pbProfile.TabIndex = 0;
            pbProfile.TabStop = false;
            // 
            // lblName
            // 
            lblName.Font = new Font("Bruno Ace SC", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(44, 188);
            lblName.Name = "lblName";
            lblName.Size = new Size(350, 30);
            lblName.TabIndex = 1;
            lblName.Text = "Loading Name...";
            lblName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStudentNumber
            // 
            lblStudentNumber.Font = new Font("Bruno Ace SC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStudentNumber.ForeColor = Color.White;
            lblStudentNumber.Location = new Point(44, 225);
            lblStudentNumber.Name = "lblStudentNumber";
            lblStudentNumber.Size = new Size(350, 22);
            lblStudentNumber.TabIndex = 2;
            lblStudentNumber.Text = "Student #";
            lblStudentNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEmail
            // 
            lblEmail.Font = new Font("Bruno Ace SC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(44, 255);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(350, 22);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email";
            lblEmail.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBirthDate
            // 
            lblBirthDate.Font = new Font("Bruno Ace SC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBirthDate.ForeColor = Color.White;
            lblBirthDate.Location = new Point(44, 285);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(350, 19);
            lblBirthDate.TabIndex = 4;
            lblBirthDate.Text = "Birth Date";
            lblBirthDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(198, 62, 62);
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.Font = new Font("Bruno Ace SC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.Black;
            btnClose.Location = new Point(175, 338);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(88, 30);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // UserProfileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(36, 38, 58);
            ClientSize = new Size(438, 412);
            Controls.Add(btnClose);
            Controls.Add(lblBirthDate);
            Controls.Add(lblEmail);
            Controls.Add(lblStudentNumber);
            Controls.Add(lblName);
            Controls.Add(pbProfile);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "UserProfileForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "User Profile";
            Load += UserProfileForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbProfile).EndInit();
            ResumeLayout(false);

        }

        private System.Windows.Forms.PictureBox pbProfile;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblStudentNumber;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Button btnClose;
    }
}
