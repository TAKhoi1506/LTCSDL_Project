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
    public partial class UC_Donors: UserControl
    {
        public UC_Donors()
        {
            InitializeComponent();
        }

        private DonorBUS donorBUS = new DonorBUS();
        private void btAddDonor_Click(object sender, EventArgs e)
        {
            DonorDTO donor = new DonorDTO()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                FullName = txtFullName.Text,
                DateOfBirth = dpDateOfBirth.Value,
                BloodType = cbBloodType.Text,
                Gender = cbGender.Text,
                PhoneNumber = txtPhoneNo.Text,
                Email = txtEmail.Text,
                LastDonationDate = dpLastDonationDate.Value,
                //Address = txtAddress.Text,
            };

            bool result = donorBUS.AddDonor(donor);
            if (result)
            {
                MessageBox.Show("Donor added successfully.");
                LoadDonors(); // Cập nhật lại DataGridView
            }
            else
            {
                MessageBox.Show("Failed to add donor.");
            }

        }
        private void LoadDonors()
        {
            dgvDonors.DataSource = donorBUS.GetAllDonors();
        }
    }
}
