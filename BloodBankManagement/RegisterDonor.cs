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

        private void btLogIn_Click(object sender, EventArgs e)
        {
            Login frmLogin = new Login();
            this.Hide();
            frmLogin.Show();
        }

        private void btRegisterRU_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and Password are required.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            // băm trước khi đưa xuống BUS 
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            DonorDTO donorDto = new DonorDTO
            {
                FullName = txtFullName.Text.Trim(),
                BloodType = cbBloodType.SelectedItem?.ToString(),
                DateOfBirth = dpDateOfBirth.Value.Date,
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                LastDonationDate = dpLastDonationDate.Checked ? dpLastDonationDate.Value.Date : (DateTime?)null,
                Gender = cbGender.SelectedItem?.ToString(),
                Email = txtEmail.Text.Trim()
            };

            DonorBUS donorBUS = new DonorBUS();
            bool success = donorBUS.RegisterDonor(donorDto, username, hashedPassword);

            if (success)
            {
                MessageBox.Show("Registration successful!");
                Login form = new Login();
                this.Hide(); // Hoặc clear form
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Registration failed. Username may already exist.");
            }
        }
    }
}
