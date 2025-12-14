namespace frontend;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void adminloginButton_Click(object? sender, EventArgs e)
    {
        using AdminPage adminPage = new AdminPage();
        adminPage.ShowDialog(this);
    }

    private void studentlogin_Click(object? sender, EventArgs e)
    {
        using FaceRecognitionForm faceRecognitionForm = new FaceRecognitionForm();
        faceRecognitionForm.ShowDialog(this);
    }
}
