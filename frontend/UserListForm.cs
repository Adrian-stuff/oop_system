using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using frontend.Services;

namespace frontend
{
    public partial class UserListForm : Form
    {
        private readonly IUserDataService _userDataService;

        public UserListForm(IUserDataService userDataService)
        {
            InitializeComponent();
            _userDataService = userDataService ?? throw new ArgumentNullException(nameof(userDataService));
            
            // Set dark theme
            this.BackColor = Color.FromArgb(36, 38, 58);
        }

        private async void UserListForm_Load(object sender, EventArgs e)
        {
            await LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            try
            {
                var users = await _userDataService.GetUsersAsync();
                
                // Clear existing info (if reloading)
                dgvUsers.Rows.Clear();

                foreach (var user in users)
                {
                    Image userImage = null;
                    try
                    {
                        // Fetch image asynchronously
                        // Note: This matches the endpoint we added in UserDatasController
                        // Since we are inside a loop, this might be slow for many users.
                        // Ideally we'd lazy load or pagination, but for now this works.
                        string imageUrl = $"http://localhost:5207/api/UserDatas/{user.UserID}/photo";
                        // We need a way to download this image. 
                        // Since we don't have dependency injected HttpClient here aside from the hidden one in Service,
                        // let's create a temp usage or pass it. 
                        // Better: Helper method using WebClient or HttpClient.
                        // Since we are in WinForms, we can use PictureBox's Load method, 
                        // BUT DataGridViewImageColumn needs a Bitmap object.
                        
                        using (var webClient = new System.Net.WebClient())
                        {
                            var bytes = await webClient.DownloadDataTaskAsync(imageUrl);
                            using (var ms = new System.IO.MemoryStream(bytes))
                            {
                                userImage = Image.FromStream(ms);
                            }
                        }
                    }
                    catch
                    {
                        // Fallback image or keeping null handles it (default x or empty)
                        // If we had a resource for "no_image", we'd use it.
                        // userImage = Properties.Resources.DefaultUser; 
                    }

                    dgvUsers.Rows.Add(
                        userImage, 
                        user.FirstName + " " + user.LastName,
                        user.StudentNumber ?? "N/A",
                        "View Profile", // Button text
                        user.UserID // Hidden ID for click handling
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle View Profile button click
            if (e.RowIndex >= 0 && dgvUsers.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                if (dgvUsers.Rows[e.RowIndex].Cells["ColId"].Value is int userId)
                {
                    OpenUserProfile(userId);
                }
                else
                {
                    // Try parsing if stored as object/string
                    var val = dgvUsers.Rows[e.RowIndex].Cells["ColId"].Value;
                    if (val != null && int.TryParse(val.ToString(), out int id))
                    {
                        OpenUserProfile(id);
                    }
                }
            }
        }

        private void OpenUserProfile(int userId)
        {
            var profileForm = new UserProfileForm(userId, _userDataService);
            profileForm.ShowDialog(this);
        }
    }
}
