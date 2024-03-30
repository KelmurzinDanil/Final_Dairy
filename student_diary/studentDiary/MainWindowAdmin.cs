using System;
using System.Windows.Forms;

namespace studentDiary
{
    public partial class MainWindowAdmin : Form
    {
        public MainWindowAdmin()
        {
            MaximizeBox = false;
            InitializeComponent();
        }

        private void AdminProfileButton_Click(object sender, EventArgs e)
        {
            AdministratorProfile administratorProfile = new AdministratorProfile();
            administratorProfile.Show();
        }

        private void ScheduleAdminProfile_Click(object sender, EventArgs e)
        {
            AdminSchedule adminSchedule = new AdminSchedule();
            adminSchedule.Show();
        }

        private void GroupList_Click(object sender, EventArgs e)
        {
            EditGroupForm editGroupForm = new EditGroupForm();
            editGroupForm.Show();
        }
    }
}
