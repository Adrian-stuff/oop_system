namespace frontend
{
    partial class Dashboard
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
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            btnViewUsers = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(29, 69);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(575, 353);
            dataGridView1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(36, 38, 58);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Bruno Ace SC", 20.2499962F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.Transparent;
            textBox1.Location = new Point(29, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(236, 33);
            textBox1.TabIndex = 1;
            textBox1.Text = "DASHBOARD";
            // 
            // btnViewUsers
            // 
            btnViewUsers.BackColor = Color.FromArgb(222, 248, 22);
            btnViewUsers.FlatStyle = FlatStyle.Popup;
            btnViewUsers.Font = new Font("Bruno Ace SC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnViewUsers.ForeColor = Color.Black;
            btnViewUsers.Location = new Point(451, 30);
            btnViewUsers.Margin = new Padding(3, 2, 3, 2);
            btnViewUsers.Name = "btnViewUsers";
            btnViewUsers.Size = new Size(152, 30);
            btnViewUsers.TabIndex = 2;
            btnViewUsers.Text = "View Users";
            btnViewUsers.UseVisualStyleBackColor = false;
            btnViewUsers.Click += btnViewUsers_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(198, 62, 62);
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.Font = new Font("Bruno Ace SC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.Black;
            btnClose.Location = new Point(515, 427);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(88, 30);
            btnClose.TabIndex = 6;
            btnClose.Text = "LOGUT";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnCloseButton_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(36, 38, 58);
            ClientSize = new Size(640, 480);
            Controls.Add(btnClose);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Controls.Add(btnViewUsers);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "dashboard";
            Load += dashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox textBox1;
        private Button btnViewUsers; // Declare button
        private Button btnClose;
    }
}