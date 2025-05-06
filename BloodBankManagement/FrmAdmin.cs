using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BloodBankManagement.Static;


namespace BloodBankManagement
{
    public partial class FrmAdmin : Form
    {
        private UserControl currentControl;

        public FrmAdmin()
        {
            InitializeComponent();
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Home());
        }

        private void ShowUserControl(UserControl newControl)
        {
            if (currentControl != null)
            {
                pnlUserControl.Controls.Remove(currentControl);
                currentControl.Dispose(); // Giải phóng bộ nhớ
            }

            currentControl = newControl;
            newControl.Dock = DockStyle.Fill;
            pnlUserControl.Controls.Add(newControl);
            newControl.Left = (pnlUserControl.Width - newControl.Width) / 2;
            newControl.Top = (pnlUserControl.Height - newControl.Height) / 2;
            pnlUserControl.Resize += (s, e) =>
            {
                newControl.Left = (pnlUserControl.Width - newControl.Width) / 2;
                newControl.Top = (pnlUserControl.Height - newControl.Height) / 2;
            };
        }
        private void btRequirements_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Admin.UC_BloodRequirements());
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
