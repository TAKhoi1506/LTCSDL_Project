using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace BloodBankManagement
{
    public partial class FrmDonor: Form
    {
        

        public FrmDonor()
        {
            InitializeComponent();
        }

        private void FrmDonor_Load(object sender, EventArgs e)
        {
            uC_Home2.Visible = true;
            uC_HistoryDonations2.Visible = false;
            uC_PersonalInformation.Visible = false;
            uC_RegistBloodDonation.Visible = false;
            uC_Benefits2.Visible = false;
        }

        private void btInfor_Click(object sender, EventArgs e)
        {
            uC_Home2.Visible = false;
            uC_HistoryDonations2.Visible = false;
            uC_PersonalInformation.Visible = true;
            uC_RegistBloodDonation.Visible = false;
            uC_Benefits2.Visible = false;
        }

     
        private void btHistoryDonations_Click(object sender, EventArgs e)
        {
            uC_Home2.Visible = false;
            uC_HistoryDonations2.Visible = true;
            uC_PersonalInformation.Visible = false;
            uC_RegistBloodDonation.Visible = false;
            uC_Benefits2.Visible = false;


            uC_HistoryDonations2.LoadHistoryDonation(); 

        }

        private void btRegisterForDonation_Click(object sender, EventArgs e)
        {
            uC_Home2.Visible = false;
            uC_HistoryDonations2.Visible = false;
            uC_PersonalInformation.Visible = false;
            uC_RegistBloodDonation.Visible = true;
            uC_Benefits2.Visible = false;
        }

        private void btBenefit_Click(object sender, EventArgs e)
        {
            uC_Home2.Visible = false;
            uC_HistoryDonations2.Visible = false;
            uC_PersonalInformation.Visible = false;
            uC_RegistBloodDonation.Visible = false;
            uC_Benefits2.Visible = true;
        }
    }
}
