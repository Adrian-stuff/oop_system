namespace frontend;

partial class Form1
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        studentlogin = new Button();
        adminlogin = new Button();
        pictureBox1 = new PictureBox();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // studentlogin
        // 
        studentlogin.BackColor = Color.FromArgb(177, 179, 177);
        studentlogin.FlatStyle = FlatStyle.Popup;
        studentlogin.Font = new Font("Bruno Ace SC", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
        studentlogin.Location = new Point(229, 246);
        studentlogin.Margin = new Padding(0);
        studentlogin.Name = "studentlogin";
        studentlogin.Size = new Size(158, 38);
        studentlogin.TabIndex = 1;
        studentlogin.Text = "LOGIN STUDENT";
        studentlogin.UseVisualStyleBackColor = false;
        studentlogin.Click += studentlogin_Click;
        // 
        // adminlogin
        // 
        adminlogin.BackColor = Color.FromArgb(177, 179, 177);
        adminlogin.FlatStyle = FlatStyle.Popup;
        adminlogin.Font = new Font("Bruno Ace SC", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
        adminlogin.Location = new Point(229, 314);
        adminlogin.Margin = new Padding(0);
        adminlogin.Name = "adminlogin";
        adminlogin.Size = new Size(158, 37);
        adminlogin.TabIndex = 2;
        adminlogin.Text = "ADMIN LOGIN";
        adminlogin.UseVisualStyleBackColor = false;
        adminlogin.Click += adminloginButton_Click;
        // 
        // pictureBox1
        // 
        pictureBox1.Anchor = AnchorStyles.None;
        pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
        pictureBox1.Location = new Point(199, 47);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(216, 179);
        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox1.TabIndex = 3;
        pictureBox1.TabStop = false;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(36, 38, 58);
        ClientSize = new Size(640, 480);
        Controls.Add(adminlogin);
        Controls.Add(studentlogin);
        Controls.Add(pictureBox1);
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "BIOMETRIXX";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Button studentlogin;
    private Button adminlogin;
    private PictureBox pictureBox1;
}
