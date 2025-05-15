using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BloodBankManagement.Static;

namespace BloodBankManagement
{
    public partial class UC_RegisterforBloodDonation : UserControl
    {
        private EventBUS eventBUS = new EventBUS();
        DonorBUS bus = new DonorBUS();
        private DonationBUS donationBUS = new DonationBUS();

        public UC_RegisterforBloodDonation()
        {
            InitializeComponent();
        }


        //Lấy danh sách các event
        private void LoadEventList()
        {
            var events = eventBUS.GetAllEvents();
            listEvents.DataSource = events;
            listEvents.DisplayMember = "EventName";
            listEvents.ValueMember = "EventID";
        }

        private void UC_RegisterforBloodDonation_Load(object sender, EventArgs e)
        {
            Icons.SetupLeftIcon(btSent, "/Resources/send.jpg");
            Icons.SetupButtonIcon(btSent);

            if (UserSession.Role == "Donor" && !string.IsNullOrEmpty(UserSession.ObjectID))
            {
                var donor = bus.GetDonorByID(UserSession.ObjectID);

                if (donor != null)
                {
                    txtFullName.Text = donor.FullName;
                    txtEmail.Text = donor.Email;
                    txtPhoneNo.Text = donor.PhoneNumber;
                    txtGender.Text = donor.Gender;
                    txtFullName.SelectionStart = 0;
                }
                else
                {
                    MessageBox.Show("Cannot load receiving unit info.");
                }
                LoadEventList();
            }
        }

        private void ClearForm()
        {
            listEvents.ClearSelected();
            numericWeight.Value = numericWeight.Minimum;
            checkboxConditions.Checked = false;
            numericWeight.Value = 0;
        }

        private void btSent_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra donor ID
                if (string.IsNullOrEmpty(UserSession.ObjectID))
                {
                    return;
                }

                // 2. Kiểm tra đã chọn sự kiện
                if (listEvents.SelectedItem == null)
                {
                    MessageBox.Show("Please select an event.");
                    return;
                }

                // 3. Kiểm tra đã tick điều kiện sức khỏe
                if (!checkboxConditions.Checked)
                {
                    MessageBox.Show("You must agree to the health conditions to donate blood.");
                    return;
                }

                // 4. Kiểm tra cân nặng hợp lệ
                decimal weight = numericWeight.Value;
                string gender = txtGender.Text.Trim().ToLower();
                var donor = bus.GetDonorByID(UserSession.ObjectID);

                if ((donor.Gender == "Male" && weight < 45) || (donor.Gender == "Female" && weight < 42))
                {
                    MessageBox.Show("Weight does not meet the minimum requirement for donation.");
                    return;
                }

                // 5. Lấy EventID
                var selectedEvent = listEvents.SelectedItem as EventDTO;
                if (selectedEvent == null)
                {
                    MessageBox.Show("Invalid event selection.");
                    return;
                }

                // 6. Tạo DonationDTO
                var donation = new DonationDTO
                {
                    DonorID = int.Parse(UserSession.ObjectID),
                    EventID = selectedEvent.EventID,
                };

                // 7. Gọi BUS thêm vào DB
                bool success = donationBUS.AddDonation(donation);

                if (success)
                {
                    MessageBox.Show("Donation registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm(); // Xóa dữ liệu sau khi lưu nếu muốn
                }
                else
                {
                    MessageBox.Show("Failed to register donation. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
