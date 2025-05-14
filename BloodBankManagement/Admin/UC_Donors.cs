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

namespace BloodBankManagement.Admin
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
            DTO.DonorDTO donor = new DTO.DonorDTO()
            {
                
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
            dgvDonors.Columns["Username"].Visible = false; // Ẩn cột 
            dgvDonors.Columns["Password"].Visible = false; // Ẩn cột 
        }

        private void UC_Donors_Load(object sender, EventArgs e)
        {
            LoadDonors();
        }
    }
}
