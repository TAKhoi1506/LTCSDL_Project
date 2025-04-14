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

namespace BloodBankManagement
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
           
            
        }

        private void btRequirements_Click(object sender, EventArgs e)
        {
            uC_RegisterForBloodRequirement1.Visible = true;
            uC_Events1.Visible = false;
            uC_Home1.Visible = false;
            uC_ReceivingUnits1.Visible = false;
            uC_Donations.Visible = false;
            uC_BloodStock.Visible = false;
            uC_Donors.Visible = false;
        }
    }
}
