using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace BloodBankManagement
{
    public partial class UC_PersonalInformation: UserControl
    {
        public UC_PersonalInformation()
        {
            InitializeComponent();
        }

        private void lbAvatar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh đại diện";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Hiển thị ảnh lên PictureBox
                    pbAvatar.Image = Image.FromFile(openFileDialog.FileName);

                    // Thiết lập để ảnh vừa với khung
                    pbAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }

            Console.WriteLine("Clicked");
        }



        //Đoạn này cần lấy dữ liệu để đưa lên giao diện
        private void ShowDonorInfo(DTO.Donor donor)
        {
            txtUsername.Text = donor.Username;
            txtPassword.Text = donor.Password;
            txtFullName.Text = donor.FullName;
            dpDateOfBirth.Value = donor.DateOfBirth;
            txtEmail.Text = donor.Email;
            cbGender.SelectedItem = donor.Gender;
            txtAddress.Text = donor.Address;
            txtPhoneNumber.Text = donor.PhoneNumber;

            if (donor.LastDonationDate.HasValue)
            {
                dpLastDonationDate.Value = donor.LastDonationDate.Value;
            }
            else
            {
                dpLastDonationDate.Value = DateTime.Now; // hoặc một ngày mặc định khác
            }

        }
    }
}
