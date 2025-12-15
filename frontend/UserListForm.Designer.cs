using System.Windows.Forms;
using System.Drawing;

namespace frontend
{
    partial class UserListForm
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
            dgvUsers = new DataGridView();
            ColImage = new DataGridViewImageColumn();
            ColName = new DataGridViewTextBoxColumn();
            ColStudentNumber = new DataGridViewTextBoxColumn();
            ColView = new DataGridViewButtonColumn();
            ColEdit = new DataGridViewButtonColumn();
            ColDelete = new DataGridViewButtonColumn();
            ColId = new DataGridViewTextBoxColumn();
            lblTitle = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.BackgroundColor = Color.FromArgb(46, 48, 68);
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { ColImage, ColName, ColStudentNumber, ColView, ColEdit, ColDelete, ColId });
            dgvUsers.Location = new Point(29, 52);
            dgvUsers.Margin = new Padding(3, 2, 3, 2);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowTemplate.Height = 60;
            dgvUsers.Size = new Size(612, 375);
            dgvUsers.TabIndex = 1;
            dgvUsers.CellContentClick += dgvUsers_CellContentClick;
            // 
            // ColImage
            // 
            ColImage.HeaderText = "Image";
            ColImage.ImageLayout = DataGridViewImageCellLayout.Zoom;
            ColImage.Name = "ColImage";
            ColImage.ReadOnly = true;
            ColImage.Width = 80;
            // 
            // ColName
            // 
            ColName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColName.HeaderText = "Name";
            ColName.Name = "ColName";
            ColName.ReadOnly = true;
            // 
            // ColStudentNumber
            // 
            ColStudentNumber.HeaderText = "Student #";
            ColStudentNumber.Name = "ColStudentNumber";
            ColStudentNumber.ReadOnly = true;
            ColStudentNumber.Width = 120;
            // 
            // ColView
            // 
            ColView.HeaderText = "View";
            ColView.Name = "ColView";
            ColView.ReadOnly = true;
            ColView.Text = "View";
            ColView.UseColumnTextForButtonValue = true;
            ColView.Width = 80;
            // 
            // ColEdit
            // 
            ColEdit.HeaderText = "Edit";
            ColEdit.Name = "ColEdit";
            ColEdit.ReadOnly = true;
            ColEdit.Text = "Edit";
            ColEdit.UseColumnTextForButtonValue = true;
            ColEdit.Width = 80;
            // 
            // ColDelete
            // 
            ColDelete.HeaderText = "Delete";
            ColDelete.Name = "ColDelete";
            ColDelete.ReadOnly = true;
            ColDelete.Text = "Delete";
            ColDelete.UseColumnTextForButtonValue = true;
            ColDelete.Width = 80;
            // 
            // ColId
            // 
            ColId.HeaderText = "ID";
            ColId.Name = "ColId";
            ColId.ReadOnly = true;
            ColId.Visible = false;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.FromArgb(36, 38, 58);
            lblTitle.BorderStyle = BorderStyle.None;
            lblTitle.Font = new Font("Bruno Ace SC", 20.2499962F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(29, 15);
            lblTitle.Margin = new Padding(3, 2, 3, 2);
            lblTitle.Name = "lblTitle";
            lblTitle.ReadOnly = true;
            lblTitle.Size = new Size(236, 33);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "USER LIST";
            // 
            // UserListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(36, 38, 58);
            ClientSize = new Size(700, 450);
            Controls.Add(dgvUsers);
            Controls.Add(lblTitle);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UserListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User List";
            Load += UserListForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridViewImageColumn ColImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentNumber;
        private System.Windows.Forms.DataGridViewButtonColumn ColView;
        private System.Windows.Forms.DataGridViewButtonColumn ColEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.TextBox lblTitle;
    }
}
