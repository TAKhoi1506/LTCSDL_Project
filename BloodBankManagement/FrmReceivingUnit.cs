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
            ShowUserControl(uC_Home);
        }

        private void ShowUserControl(UserControl newControl)
        {
            if (currentControl != null)
            {
                currentControl.Hide(); // Ẩn UserControl hiện tại
            }

            currentControl = newControl;

            currentControl.BringToFront(); // Đưa UserControl lên trên
            currentControl.Show(); // Hiển thị UserControl mới
        }

        private void btInfor_Click(object sender, EventArgs e)
        {
            ShowUserControl(uC_UnitInformation1);
        }

        private void btHome_Click(object sender, EventArgs e)
        {
            ShowUserControl(uC_Home);
        }

        private void btViewRequire_Click(object sender, EventArgs e)
        {
            ShowUserControl(uC_RegisterForBloodRequirement1);
        }

        // chưa tạo uc notification 
        private void btNoti_Click(object sender, EventArgs e)
        {
            ShowUserControl(uC_Notifications1);
        }
    }
}
