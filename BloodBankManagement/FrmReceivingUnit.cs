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
            uC_Home.Visible = false;
            uC_UnitInformation1.Visible = true;
            uC_RegisterForBloodRequirement1.Visible = false;
        }

    }
}
