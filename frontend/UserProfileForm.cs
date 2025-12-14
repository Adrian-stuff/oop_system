using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using frontend.Services;
using System.Drawing.Drawing2D;

namespace frontend
{
    public partial class UserProfileForm : Form
    {
        private readonly int _userId;
        private readonly IUserDataService _userDataService;

        public UserProfileForm(int userId, IUserDataService userDataService)
        {
            InitializeComponent();
            _userId = userId;
            _userDataService = userDataService ?? throw new ArgumentNullException(nameof(userDataService));

            // Set dark theme
            this.BackColor = Color.FromArgb(36, 38, 58);
            
            // Make picture box circular
            MakeControlCircular(pbProfile);
            pbProfile.SizeChanged += (s, e) => MakeControlCircular(pbProfile);
        }

        private async void UserProfileForm_Load(object sender, EventArgs e)
        {
            await LoadUserProfileAsync();
        }

        private async Task LoadUserProfileAsync()
        {
            try
            {
                var user = await _userDataService.GetUserDataAsync(_userId);
                if (user != null)
                {
                    lblName.Text = $"{user.FirstName} {user.LastName}";
                    lblStudentNumber.Text = $"Student #: {user.StudentNumber ?? "N/A"}";
                    lblEmail.Text = $"Email: {user.Email}";
                    lblBirthDate.Text = $"Birth Date: {user.BirthDate}";
                    
                    try
                    {
                        // Load image
                        string imageUrl = $"http://localhost:5207/api/UserDatas/{user.UserID}/photo";
                        pbProfile.LoadAsync(imageUrl); // LoadAsync is built-in for PictureBox
                    }
                    catch
                    {
                        // Ignore load error (keeps placeholder)
                    }
                }
                else
                {
                    MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MakeControlCircular(Control control)
        {
            using GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, control.Width, control.Height);
            control.Region = new Region(path);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
