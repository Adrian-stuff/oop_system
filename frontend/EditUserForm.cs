using System;
using System.Windows.Forms;
using frontend.Services;
using System.Threading.Tasks;

namespace frontend
{
    public partial class EditUserForm : Form
    {
        private readonly IUserDataService _userDataService;
        private readonly UserDataResponse _user;

        public EditUserForm(UserDataResponse user, IUserDataService userDataService)
        {
            InitializeComponent();
            _user = user;
            _userDataService = userDataService ?? throw new ArgumentNullException(nameof(userDataService));

            // Populate fields
            txtFirstName.Text = _user.FirstName;
            txtLastName.Text = _user.LastName;
            txtEmail.Text = _user.Email;
            txtStudentNumber.Text = _user.StudentNumber;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Name fields cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Update user object
                _user.FirstName = txtFirstName.Text.Trim();
                _user.LastName = txtLastName.Text.Trim();
                _user.Email = txtEmail.Text.Trim();
                _user.StudentNumber = txtStudentNumber.Text.Trim();
                // BirthDate and UserID remain unchanged

                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                
                if (_user.UserID.HasValue)
                {
                    await _userDataService.UpdateUserAsync(_user.UserID.Value, _user);
                    MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
