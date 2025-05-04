using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;


namespace BloodBankManagement
{
    public partial class UC_HistoryDonations: UserControl
    {
        private readonly HistoryDonationBUS historyDonationBUS = new HistoryDonationBUS();
        public UC_HistoryDonations()
        {
            InitializeComponent();
        }

        public void LoadHistoryDonation()
        {
            dgvDonors.DataSource = historyDonationBUS.GetHistoryDonations();
            dgvDonors.ReadOnly = true;
        }

        private void UC_HistoryDonations_Load(object sender, EventArgs e)
        {
            LoadHistoryDonation();
        }
    }
}
