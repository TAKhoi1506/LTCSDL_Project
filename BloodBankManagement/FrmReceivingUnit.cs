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
        public FrmReceivingUnit()
        {
            InitializeComponent();
        }

        private void FrmReceivingUnit_Load(object sender, EventArgs e)
        {
            
        }

        private void btInfor_Click(object sender, EventArgs e)
        {
            uC_Home.Visible = false;
            uC_UnitInformation1.Visible = true;
            uC_RegisterForBloodRequirement1.Visible = false;
        }

        private void btHome_Click(object sender, EventArgs e)
        {
            uC_Home.Visible = true;
            uC_UnitInformation1.Visible = false;
            uC_RegisterForBloodRequirement1.Visible = false;
        }

        private void btViewRequire_Click(object sender, EventArgs e)
        {
            uC_Home.Visible = false;
            uC_UnitInformation1.Visible = false;
            uC_RegisterForBloodRequirement1.Visible = true;
        }
    }
}
