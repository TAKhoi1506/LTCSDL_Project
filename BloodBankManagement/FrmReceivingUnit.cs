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
    public partial class FrmReceivingUnit : Form
    {
        private UserControl currentControl;

        public FrmReceivingUnit()
        {
            InitializeComponent();
        }

        private void FrmReceivingUnit_Load(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Home());
        }

        private void ShowUserControl(UserControl newControl)
        {
            // Cách 1: hide, bring to front user control 
            //if (currentControl != null)
            //{
            //    currentControl.Hide(); // Ẩn UserControl hiện tại
            //}

            //currentControl = newControl;

            //currentControl.BringToFront(); // Đưa UserControl lên trên
            //currentControl.Show(); // Hiển thị UserControl mới


            // Cách 2: remove, dispose user control => tối ưu bộ nhớ, hiệu năng 
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

            this.Close();

            // Mở lại form Login
            Login loginForm = new Login();
            loginForm.Show();
        }
    }
}
