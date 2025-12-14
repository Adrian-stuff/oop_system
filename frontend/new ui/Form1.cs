namespace frontend
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void adminloginButton_Click(object? sender, EventArgs e)
        {
            using adminpage adminpage = new adminpage();
            adminpage.ShowDialog(this);
        }
        private void studentlogin_Click(object? sender, EventArgs e)
        {
            using FaceRecognitionForm FaceRecognitionForm = new FaceRecognitionForm();
            FaceRecognitionForm.ShowDialog(this);
        }

    }
}