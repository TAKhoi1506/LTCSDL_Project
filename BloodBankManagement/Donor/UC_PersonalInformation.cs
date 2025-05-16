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
using System.Security.Principal;
using BloodBankManagement.Static;
using BUS;
using System.Web.Security;
using System.Web.UI.WebControls;

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
                    pbAvatar.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);

                    // Thiết lập để ảnh vừa với khung
                    pbAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }

            Console.WriteLine("Clicked");
        }
        
        //Đoạn này cần lấy dữ liệu để đưa lên giao diện
        private void ShowDonorInfo()
        {
            if (UserSession.ObjectID == null)
            {
                MessageBox.Show("User ID not found in session.");
                return;
            }

            string role = UserSession.Role;
            string objectId = UserSession.ObjectID.ToString();

            UserAccountBUS userBus = new UserAccountBUS();
            var donorObj = userBus.GetUserInfo(role, objectId);

            int accountID = UserSession.AccountID; // Lấy AccountID từ session

            // Lấy thông tin tài khoản

            var account = userBus.GetAccountById(UserSession.AccountID);

            if (donorObj is DonorDTO donorDto && account != null)
            {
                txtUsername.Text = account.Username;
                

                txtFullName.Text = donorDto.FullName;
                txtFullName.SelectionStart = 0;
                dpDateOfBirth.Value = donorDto.DateOfBirth;
                txtEmail.Text = donorDto.Email;
                cbGender.SelectedItem = donorDto.Gender;

                txtAddress.Text = donorDto.Address;
                txtAddress.SelectionStart = 0;
                txtPhoneNumber.Text = donorDto.PhoneNumber;

                if (donorDto.LastDonationDate.HasValue)
                {
                    dpLastDonationDate.Value = donorDto.LastDonationDate.Value;
                }
                else
                {
                    dpLastDonationDate.Value = DateTime.Now; // hoặc một ngày mặc định khác
                }
            }
            else
            {
                MessageBox.Show("Failed to load user info.");
            }
        }

        private void UC_PersonalInformation_Load(object sender, EventArgs e)
        {
            Icons.SetupLeftIcon(btUpdate, "/Resources/update.jpg");
            Icons.SetupButtonIcon(btUpdate);
            ShowDonorInfo();
            SetToolTip();
        }

        private void SetToolTip()
        {
            ToolTip toolTip = new ToolTip();

            // Đặt thuộc tính cho ToolTip (tùy chọn)
            toolTip.AutoPopDelay = 2000; // Thời gian hiển thị (ms)
            toolTip.InitialDelay = 500;  // Thời gian chờ trước khi hiển thị
            toolTip.ReshowDelay = 500;   // Thời gian chờ giữa các lần hiển thị
            toolTip.ShowAlways = true;   // Hiển thị cả khi form không active

            // Gán ToolTip cho TextBox
            toolTip.SetToolTip(txtUsername, "Username cannot be changed");
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();

            //if (string.IsNullOrWhiteSpace(currentPassword) && !string.IsNullOrWhiteSpace(newPassword))
            //{
            //    MessageBox.Show("You must enter your current password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}


            DonorDTO updateDonor = new DonorDTO
            {
                Username = txtUsername.Text.Trim(),
                Password = txtCurrentPassword.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                DateOfBirth = dpDateOfBirth.Value,
                Gender = cbGender.SelectedItem.ToString(),
                Address = txtAddress.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                LastDonationDate = dpLastDonationDate.Value
            };

            // Gọi lớp BUS để cập nhật
            DonorBUS bus = new DonorBUS();

            bool success = bus.UpdateByDonor(updateDonor, newPassword);

            if (success)
            {
                MessageBox.Show("Updating is successful!!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Update failed. Please check again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
