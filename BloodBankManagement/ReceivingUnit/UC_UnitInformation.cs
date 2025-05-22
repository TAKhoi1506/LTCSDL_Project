using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BloodBankManagement.Static;
using BUS;
using DTO;

namespace BloodBankManagement
{
    public partial class UC_UnitInformation : UserControl
    {
        public UC_UnitInformation()
        {
            InitializeComponent();
        }

        private void LoadReceivingUnit()
        {
            if (UserSession.ObjectID == null)
            {
                MessageBox.Show("User ID not found in session.");
                return;
            }

            string role = UserSession.Role;
            string objectId = UserSession.ObjectID.ToString();

            UserAccountBUS userBus = new UserAccountBUS();
            var ruObj = userBus.GetUserInfo(role, objectId);

            int accountID = UserSession.AccountID; // Lấy AccountID từ session

            // Lấy thông tin tài khoản

            var account = userBus.GetAccountById(UserSession.AccountID);

            if (ruObj is ReceivingUnitDTO ruDto && account != null)
            {
                txtUsername.Text = account.Username;

                txtUnitId.Text = ruDto.RU_ID;
                txtUnitId.ForeColor = Color.Silver;
                txtUnitId.ReadOnly = true; // không cho sửa RU_ID
                txtUnitName.Text = ruDto.UnitName;

                // Đặt con trỏ về đầu textbox
                txtUnitName.SelectionStart = 0;
                txtUnitName.SelectionLength = 0;

                txtAddress.Text = ruDto.Address;
                txtAddress.SelectionStart = 0;
                txtAddress.SelectionLength = 0;

                txtContactName.Text = ruDto.ContactName;
                txtContactName.SelectionStart = 0;
                txtContactName.SelectionLength = 0;

                txtPhoneNumber.Text = ruDto.PhoneNumber;
                txtEmail.Text = ruDto.Email;

                cbUnitType.Items.Clear();
                cbUnitType.Items.AddRange(new string[] { "Hospital", "Clinic", "Nursing home" });
                cbUnitType.SelectedItem = ruDto.UnitType;
            }
            else
            {
                MessageBox.Show("Failed to load user info.");
            }
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


        private void UC_UnitInformation_Load(object sender, EventArgs e)
        {
            Icons.SetupLeftIcon(btUpdate, "/Resources/update.jpg");
            Icons.SetupButtonIcon(btUpdate);
            LoadReceivingUnit();
            SetToolTip();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            string currentPassword = txtPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();

            
            // Lấy dữ liệu từ các control trên form
            ReceivingUnitDTO updatedUnit = new ReceivingUnitDTO
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text, // current password 
                RU_ID = UserSession.ObjectID,
                UnitName = txtUnitName.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                ContactName = txtContactName.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                UnitType = cbUnitType.SelectedItem?.ToString() ?? ""
            };

            // Gọi lớp BUS để cập nhật
            ReceivingUnitBUS bus = new ReceivingUnitBUS();

            bool success = bus.Update(updatedUnit, newPassword);

            if (success)
            {
                MessageBox.Show("Updating is successful!!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Update failed. Please check again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Choose avatar";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Hiển thị ảnh lên PictureBox
                    pbAvatar.Image = Image.FromFile(openFileDialog.FileName);

                    // Thiết lập để ảnh vừa với khung
                    pbAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void toggleShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtNewPassword.PasswordChar = toggleShowPassword.Checked ? '\0' : '*';
        }
    }
}
