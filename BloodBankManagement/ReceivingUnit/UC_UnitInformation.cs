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
    public partial class UC_UnitInformation : UserControl
    {
        public UC_UnitInformation()
        {
            InitializeComponent();
            lbAvatar.Click += new EventHandler(lbAvatar_Click);
        }

        // tao du lieu de test 
        private void AddSampleData()
        {
            ReceivingUnitBUS bus = new ReceivingUnitBUS();

            var sample = new ReceivingUnitDTO
            {
                RU_ID = "RU001",
                //Username = "ruuser1",
                //Password = "123456",
                UnitName = "Bệnh viện Huyết học",
                ContactName = "Nguyễn Văn A",
                Address = "123 Lê Lợi, Quận 1, TP.HCM",
                PhoneNumber = "0901234567",
                Email = "benhvien@example.com",
                UnitType = "Hospital"
            };

            var existing = bus.GetById(sample.RU_ID);
            if (existing == null)
            {
                bus.Add(sample); // Chỉ thêm nếu chưa có
            }
        }

        private void LoadReceivingUnit(string ruId)
        {
            ReceivingUnitBUS bus = new ReceivingUnitBUS();
            var dto = bus.GetById(ruId);

            if (dto != null)
            {
                //txtUsername.Text = dto.Username;
                //txtPassword.Text = dto.Password;
                txtUnitId.Text = dto.RU_ID;
                txtUnitId.ForeColor = Color.Silver;
                txtUnitName.Text = dto.UnitName;
                txtAddress.Text = dto.Address;
                txtContactName.Text = dto.ContactName;
                txtPhoneNumber.Text = dto.PhoneNumber;
                txtEmail.Text = dto.Email;

                // ComboBox dữ liệu mẫu
                cbUnitType.Items.Clear();
                cbUnitType.Items.AddRange(new string[] { "Hospital", "Clinic", "Nursing home" });
                cbUnitType.SelectedItem = dto.UnitType;
            }
            else
            {
                MessageBox.Show("Không tìm thấy đơn vị có mã: " + ruId);
            }
        }

        private void UC_UnitInformation_Load(object sender, EventArgs e)
        {
            AddSampleData(); // Gọi chỉ 1 lần khi test
            LoadReceivingUnit("RU001");
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các control trên form
            ReceivingUnitDTO updatedUnit = new ReceivingUnitDTO
            {
                //Username = txtUsername.Text.Trim(),
                //Password = txtPassword.Text.Trim(),
                RU_ID = txtUnitId.Text.Trim(),
                UnitName = txtUnitName.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                ContactName = txtContactName.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                UnitType = cbUnitType.SelectedItem?.ToString() ?? ""
            };



            // Kiểm tra dữ liệu đầu vào (ví dụ: bắt buộc nhập Email, SDT đúng định dạng,...)

            // Gọi lớp BUS để cập nhật
            ReceivingUnitBUS bus = new ReceivingUnitBUS();
            bool success = bus.Update(updatedUnit);

            if (success)
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Để xử lý việc form/ UC bị load lại 2 lần khiến việc chọn ảnh lặp lại 2 lần 
        private bool _isProcessingClick = false;

        private void lbAvatar_Click(object sender, EventArgs e)
        {
            if (_isProcessingClick) return;

            _isProcessingClick = true;
            try
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
            }
            finally
            {
                _isProcessingClick = false;
            }
            Console.WriteLine("Clicked");
        }      
    }
}
