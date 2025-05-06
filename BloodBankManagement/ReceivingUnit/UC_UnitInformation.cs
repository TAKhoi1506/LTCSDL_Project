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
using BloodBankManagement.Static;
using System.CodeDom;

namespace BloodBankManagement
{
    public partial class UC_UnitInformation : UserControl
    {
        public UC_UnitInformation()
        {
            InitializeComponent();
        }

        // Dùng để test hiển thị khi chưa có cơ sở dữ liệu
        //private void AddSampleData()
        //{
        //    ReceivingUnitBUS bus = new ReceivingUnitBUS();

        //    var sample = new ReceivingUnitDTO
        //    {
        //        RU_ID = "RU001",
        //        //Username = "ruuser1",
        //        //Password = "123456",
        //        UnitName = "Bệnh viện Huyết học",
        //        ContactName = "Nguyễn Văn A",
        //        Address = "123 Lê Lợi, Quận 1, TP.HCM",
        //        PhoneNumber = "0901234567",
        //        Email = "benhvien@example.com",
        //        UnitType = "Hospital"
        //    };

        //    var existing = bus.GetById(sample.RU_ID);
        //    if (existing == null)
        //    {
        //        bus.Add(sample); // Chỉ thêm nếu chưa có
        //    }
        //}

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
                txtPassword.Text = account.Password;

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


        private void UC_UnitInformation_Load(object sender, EventArgs e)
        {
            //AddSampleData(); // Gọi chỉ 1 lần khi test
            LoadReceivingUnit();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các control trên form
            ReceivingUnitDTO updatedUnit = new ReceivingUnitDTO
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                RU_ID = txtUnitId.Text.Trim(),
                UnitName = txtUnitName.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                ContactName = txtContactName.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                UnitType = cbUnitType.SelectedItem?.ToString() ?? ""
            };


            if (string.IsNullOrWhiteSpace(updatedUnit.Username) || string.IsNullOrWhiteSpace(updatedUnit.Password))
            {
                MessageBox.Show("Username and Password are required.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Gọi lớp BUS để cập nhật
            ReceivingUnitBUS bus = new ReceivingUnitBUS();
            bool success = bus.Update(updatedUnit);

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
            txtPassword.PasswordChar = toggleShowPassword.Checked ? '\0' : '*';
        }
    }
}
