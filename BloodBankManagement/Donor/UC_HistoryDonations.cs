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
using BloodBankManagement.Static;


namespace BloodBankManagement
{
    public partial class UC_HistoryDonations : UserControl
    {
        //private readonly HistoryDonationBUS historyDonationBUS = new HistoryDonationBUS();
        public UC_HistoryDonations()
        {
            InitializeComponent();
        }

        public void LoadHistoryDonation()
        {
            //dgvDonors.DataSource = historyDonationBUS.GetHistoryDonations();
            //dgvDonors.ReadOnly = true;

            try
            {
                dgvDonors.Rows.Clear();

                string currentDonorId = UserSession.ObjectID?.ToString();


                if (string.IsNullOrEmpty(currentDonorId))
                {
                    MessageBox.Show("Donor ID not found in session.");
                    return;
                }

                if (dgvDonors.Columns.Count == 0)
                {
                    dgvDonors.Columns.Add("HisDonaID", "HisDonaID");
                    dgvDonors.Columns.Add("DonorID", "DonorID");
                    dgvDonors.Columns.Add("EventID", "EventID");
                    dgvDonors.Columns.Add("DonationDate", "Donation Date");
                    dgvDonors.Columns.Add("Weight", "Weight");
                    dgvDonors.Columns.Add("BloodPressure", "Blood Pressure");
                    dgvDonors.Columns.Add("Amount", "Amount");
                    dgvDonors.Columns.Add("HealthStatus", "Health Status");
                }

                var donations = new HistoryDonationBUS().GetHistoryDonations();

                // Chỉ lọc donation của donor đang đăng nhập
                var userDonations = donations
                    .Where(d => d.DonorID.ToString() == currentDonorId)
                    .ToList();

                foreach (var donation in userDonations)
                {
                    dgvDonors.Rows.Add(
                        donation.HisDonaID,
                        donation.DonorID,
                        donation.EventID,
                        donation.DonationDate,
                        donation.Weight,
                        donation.BloodPressure,
                        donation.Amount,
                        donation.HealthStatus
                        );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading history donation data: " + ex.Message);
            }
        }

        private void UC_HistoryDonations_Load(object sender, EventArgs e)
        {
            LoadHistoryDonation();
        }
    }
}
