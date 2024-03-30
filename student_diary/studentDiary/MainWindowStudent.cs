using System;
using System.Windows.Forms;

namespace studentDiary
{
    public partial class MainWindowStudent : Form
    {
        public MainWindowStudent()
        {
            InitializeComponent();
            Timer.Start();
            MaximizeBox = false;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToString("HH:mm");
        }

        private void MainWindowButton_Click(object sender, EventArgs e)
        {
            MainWindowStudent mainWindowStudent = new MainWindowStudent();
            mainWindowStudent.Show();
        }

        private void StudentProfileButton_Click(object sender, EventArgs e)
        {
            StudentProfile studentProfile = new StudentProfile();
            studentProfile.Show();
        }

        private void ScheduleStudentProfile_Click(object sender, EventArgs e)
        {
            StudentScheduleWindow studentScheduleWindow = new StudentScheduleWindow();
            studentScheduleWindow.Show();
        }
    }
}
