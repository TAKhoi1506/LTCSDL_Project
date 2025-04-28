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
using DTO;

namespace BloodBankManagement
{
    public partial class RegisterDonor: Form
    {
        public RegisterDonor()
        {
            InitializeComponent();
        }

        private void bunifuPanel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btRegisterRU_Click(object sender, EventArgs e)
        {
            //if (txtPassword.Text != txtConfirmPassword.Text)
            //{
            //    MessageBox.Show("Passwords do not match.");
            //    return;
            //}

            //DonorDTO donor = new DonorDTO
            //{
            //    Username = txtUsername.Text,
            //    Password = txtPassword.Text,
            //    FullName = txtFullName.Text,
            //    Gender = cbGender.Text,
            //    Address = txtAddress.Text,
            //    DateOfBirth = dpDateOfBirth.Value,
            //    LastDonationDate = dpLastDonationDate.Value,
            //    PhoneNumber = txtPhoneNumber.Text,
            //    Email = txtEmail.Text
            //};
            //DonorBUS bus = new DonorBUS();
            //if (bus.RegisterDonor(donor))
            //{
            //    MessageBox.Show("Registration successful.");
            //}
            //else
            //{
            //    MessageBox.Show("Registration failed.");
            //}
        }
    }
}
