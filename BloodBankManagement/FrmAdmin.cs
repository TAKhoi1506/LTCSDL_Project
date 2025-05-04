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
using BloodBankManagement.Admin;

namespace BloodBankManagement
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }
        private UC_BloodStock ucBloodStock;
        private UC_Home ucHome;
        private UC_Events ucEvents;
        private UC_Donations ucDonations;
        private UC_ReceivingUnits ucReceivingUnits;
        private UC_Dashboard ucDashboard;
        private UC_Donors ucDonors;


        private void HomeLoad()
        {
            if (ucHome == null)
            {
                ucHome = new UC_Home();
                ucHome.Dock = DockStyle.Fill;
                panelShow.Controls.Add(ucHome);
            }

            ucHome.BringToFront();
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            HomeLoad();
        }

        private void btBloodStock_Click(object sender, EventArgs e)
        {
            if (ucBloodStock == null)
            {
                ucBloodStock = new UC_BloodStock();
                ucBloodStock.Dock = DockStyle.Fill;
                panelShow.Controls.Add(ucBloodStock);
            }

            ucBloodStock.BringToFront();
        }

        private void btHome_Click(object sender, EventArgs e)
        {
           HomeLoad();
        }

        private void btEvents_Click(object sender, EventArgs e)
        {
            if (ucEvents == null)
            {
                ucEvents = new UC_Events();
                ucEvents.Dock = DockStyle.Fill;
                panelShow.Controls.Add(ucEvents);
            }

            ucEvents.BringToFront();
        }



        private void btDonors_Click(object sender, EventArgs e)
        {
            if (ucDonors == null)
            {
                ucDonors = new UC_Donors();
                ucDonors.Dock = DockStyle.Fill;
                panelShow.Controls.Add(ucDonors);
            }

            ucDonors.BringToFront();
        }



        private void btReUnits_Click(object sender, EventArgs e)
        {
            if (ucReceivingUnits == null)
            {
                ucReceivingUnits = new UC_ReceivingUnits();
                ucReceivingUnits.Dock = DockStyle.Fill;
                panelShow.Controls.Add(ucReceivingUnits);
            }
            ucReceivingUnits.BringToFront();
        }


        private void btDonations_Click(object sender, EventArgs e)
        {

            if (ucDonations == null)
            {
                ucDonations = new UC_Donations();
                ucDonations.Dock = DockStyle.Fill;
                panelShow.Controls.Add(ucDonations);
            }

            ucDonations.BringToFront();
        }


        private void btDashboard_Click(object sender, EventArgs e)
        {
            if (ucDashboard == null)
            {
                ucDashboard = new UC_Dashboard();
                ucDashboard.Dock = DockStyle.Fill;
                panelShow.Controls.Add(ucDashboard);
            }

            ucDashboard.BringToFront();
        }



       
    }
}
