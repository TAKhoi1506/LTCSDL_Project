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
using DTO;

namespace BloodBankManagement
{
    public partial class UC_Donations: UserControl
    {
        public UC_Donations()
        {
            InitializeComponent();
        }
        private DonationBUS donationBUS = new DonationBUS();
        private DonorBUS donorBUS = new DonorBUS();         // để load danh sách donor
        private EventBUS eventBUS = new EventBUS();         // để load danh sách sự kiện

        private void UC_Donations_Load(object sender, EventArgs e)
        {
            LoadDonationList();
            LoadEventList();
        }
        private void LoadDonationList()
        {
            var donations = donationBUS.GetAllDonations();
            dgvDonation.DataSource = donations;
        }

        private void LoadEventList()
        {
            var events = eventBUS.GetAllEvents();
            listEvents.DataSource = events;
            listEvents.DisplayMember = "EventName";
            listEvents.ValueMember = "EventID";
        }

        private void btAddDonation_Click(object sender, EventArgs e)
        {
            string username = txtFullName.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username.");
                return;
            }

            // Lấy DonorID từ username
            string donorId = donorBUS.GetDonorIdByUsername(username);
            if (donorId == null)
            {
                MessageBox.Show("Username not found.");
                return;
            }

            var donation = new DonationDTO
            {
                DonorID = int.Parse(donorId),
                EventID = (int)listEvents.SelectedValue,
            };

            if (donationBUS.AddDonation(donation))
            {
                MessageBox.Show("Donation added successfully!");
                LoadDonationList();
            }
            else
            {
                MessageBox.Show("Failed to add donation.");
            }
        }
    }

}
