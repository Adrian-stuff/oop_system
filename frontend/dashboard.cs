using System;
using System.Data;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frontend
{
    public partial class Dashboard : Form
    {
        private readonly Services.IAttendanceService _attendanceService;

        public Dashboard()
        {
            InitializeComponent();
            string apiBaseUrl = "http://localhost:5207/api/Attendances";
            _attendanceService = new Services.AttendanceService(new HttpClient(), apiBaseUrl);
        }

        private async void dashboard_Load(object sender, EventArgs e)
        {
            await LoadAttendancesAsync();
        }

        private async Task LoadAttendancesAsync()
        {
            try
            {
                var attendances = await _attendanceService.GetAttendancesAsync();
                
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = attendances;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load attendances: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewUsers_Click(object sender, EventArgs e)
        {
          
            var userDataService = new Services.UserDataService(new System.Net.Http.HttpClient(), "http://localhost:5207/api/UserDatas");
            var userListForm = new UserListForm(userDataService);
            userListForm.ShowDialog(this);
        }
    }
}
