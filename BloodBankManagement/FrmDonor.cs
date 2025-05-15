using BloodBankManagement.Donor;
using BloodBankManagement.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankManagement
{
    public partial class FrmDonor : Form
    {
        private UserControl currentControl;

        public FrmDonor()
        {
            InitializeComponent();
        }

        private void ShowUserControl(UserControl newControl)
        {
            if (currentControl != null)
            {
                pnShow.Controls.Remove(currentControl);
                currentControl.Dispose(); // Giải phóng bộ nhớ
            }

            currentControl = newControl;
            newControl.Dock = DockStyle.Fill;
            pnShow.Controls.Add(newControl);
        }

        private void FrmDonor_Load(object sender, EventArgs e)
        {
            LoadIcons();
            ShowUserControl(new UC_Home());
        }

        private void btInfor_Click(object sender, EventArgs e)
        {
           ShowUserControl(new UC_PersonalInformation());
        }

        private void btHistoryDonations_Click(object sender, EventArgs e)
        {
           ShowUserControl(new UC_HistoryDonations());
        }

        private void btRegisterForDonation_Click(object sender, EventArgs e)
        {
           ShowUserControl(new UC_RegisterforBloodDonation());
        }

        private void btBenefit_Click(object sender, EventArgs e)
        {
           ShowUserControl(new UC_Benefits());
        }

        private void btNotification_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Notifications());
        }

        private void btHome_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Home());
        }

        private void btLogOut_Click(object sender, EventArgs e)
        {
            UserSession.Clear();

            this.Hide();

            // Mở lại form Login
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void FrmDonor_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void LoadIcons()
        {
            Icons.SetupButtonIcon(btHome, "home.jpg");
            Icons.SetupButtonIcon(btInfor, "info.jpg");
            Icons.SetupButtonIcon(btHistoryDonations, "history.jpg");
            Icons.SetupButtonIcon(btNotification, "noti.jpg");
            Icons.SetupButtonIcon(btRegisterForDonation, "register.jpg");
            Icons.SetupButtonIcon(btBenefit, "benefit.jpg");
            Icons.SetupButtonIcon(btLogout, "logout.jpg");
        }
    }
}
