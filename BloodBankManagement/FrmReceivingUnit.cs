using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BloodBankManagement.Static;

namespace BloodBankManagement
{
    public partial class FrmReceivingUnit : Form
    {
        private UserControl currentControl;

        public FrmReceivingUnit()
        {
            InitializeComponent();
        }

        private void FrmReceivingUnit_Load(object sender, EventArgs e)
        {
            LoadIcon();
            ShowUserControl(new UC_Home());
        }

        private void ShowUserControl(UserControl newControl)
        {
            if (currentControl != null)
            {
                pnlMain.Controls.Remove(currentControl);
                currentControl.Dispose(); // Giải phóng bộ nhớ
            }

            currentControl = newControl;
            newControl.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(newControl);
        }

        private void btInfor_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_UnitInformation());
        }

        private void btHome_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Home());
        }

        private void btViewRequire_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_RegisterForBloodRequirement());
        }

        private void btNoti_Click(object sender, EventArgs e)
        {
            // ĐỂ TẠM - CHƯA XỬ LÝ NOTIFICATION 
            ShowUserControl(new Donor.UC_Notifications());
        }

        private void btLogOut_Click(object sender, EventArgs e)
        {
            UserSession.Clear();

            this.Hide();

            // Mở lại form Login
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void LoadIcon()
        {
            Icons.SetupButtonIcon(btHome, "home.jpg");
            Icons.SetupButtonIcon(btInfor, "ru.jpg");
            Icons.SetupButtonIcon(btViewRequire, "req.jpg");
            Icons.SetupButtonIcon(btNoti, "noti.jpg");
            Icons.SetupButtonIcon(btLogout, "logout.jpg");
        }
    }
}
