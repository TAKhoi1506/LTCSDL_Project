using Bunifu.UI.WinForms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace BloodBankManagement
{
    public partial class FrmSplash : Form
    {
        public FrmSplash()
        {
            InitializeComponent();
        }

        int start = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (start < 100)
            {
                start += 5;
                bunifuCircleProgress1.Value = start;
                txtPercent.Text = bunifuCircleProgress1.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop(); // Dừng Timer khi đạt 100%
                start = 0; // Reset giá trị nếu cần
                Login login = new Login();
                login.Show();
                this.Hide();
            }
        }

        private void FrmSplash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}

