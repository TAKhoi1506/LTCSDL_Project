using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BloodBankManagement.Donor;
using BUS;

namespace BloodBankManagement
{
    public partial class FrmDonor2 : Form
    {

        public FrmDonor2()
        {
            InitializeComponent();
        }

        private UC_Home ucHome;
        private UC_Benefits ucBenefits;
        private UC_HistoryDonations ucHistoryDonation;
        private UC_Notifications ucNotifications;
        private UC_PersonalInformation ucPersonalInformation;
        private UC_RegisterforBloodDonation ucRegisterforBloodDonation;



        private void FrmDonor2_Load(object sender, EventArgs e)
        {

        }

        private void btInfor_Click(object sender, EventArgs e)
        {
            if (ucPersonalInformation == null)
            {
                ucPersonalInformation = new UC_PersonalInformation();
                ucPersonalInformation.Dock = DockStyle.Fill;
                this.Controls.Add(ucPersonalInformation);
            }

            ucPersonalInformation.BringToFront();
        }


        private void btHistoryDonations_Click(object sender, EventArgs e)
        {
            if (ucHistoryDonation == null)
            {
                ucHistoryDonation = new UC_HistoryDonations();
                ucHistoryDonation.Dock = DockStyle.Fill;
                this.Controls.Add(ucHistoryDonation);
            }

            ucHistoryDonation.BringToFront();

        }

        private void btRegisterForDonation_Click(object sender, EventArgs e)
        {
            if (ucRegisterforBloodDonation == null)
            {
                ucRegisterforBloodDonation = new UC_RegisterforBloodDonation();
                ucRegisterforBloodDonation.Dock = DockStyle.Fill;
                this.Controls.Add(ucRegisterforBloodDonation);
            }

            ucRegisterforBloodDonation.BringToFront();
        }

        private void btBenefit_Click(object sender, EventArgs e)
        {
            if (ucBenefits == null)
            {
                ucBenefits = new UC_Benefits();
                ucBenefits.Dock = DockStyle.Fill;
                this.Controls.Add(ucBenefits);
            }

            ucBenefits.BringToFront();
        }

        private void btNotification_Click(object sender, EventArgs e)
        {
            if (ucNotifications == null)
            {
                ucNotifications = new UC_Notifications();
                ucNotifications.Dock = DockStyle.Fill;
                this.Controls.Add(ucNotifications);
            }

            ucNotifications.BringToFront();
        }

        private void btHome_Click(object sender, EventArgs e)
        {
            if (ucHome == null)
            {
                ucHome = new UC_Home();
                ucHome.Dock = DockStyle.Fill;
                this.Controls.Add(ucHome);
            }

            ucHome.BringToFront();
        }
    }
}
