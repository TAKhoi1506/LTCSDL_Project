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
using OfficeOpenXml.FormulaParsing.FormulaExpressions;
using BloodBankManagement.Static;

namespace BloodBankManagement.Admin
{
    public partial class UC_Donors : UserControl
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
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                FullName = txtFullName.Text,
                DateOfBirth = dpDateOfBirth.Value,
                BloodType = cbBloodType.Text,
                Gender = cbGender.Text,
                PhoneNumber = txtPhoneNo.Text,
                Email = txtEmail.Text,
                LastDonationDate = dpLastDonationDate.Value,
                Address = txtAddress.Text
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
            LoadCheckColumn();
            dgvDonors.ReadOnly = true;
            dgvDonors.DataSource = donorBUS.GetAllDonors();
            dgvDonors.Columns["Username"].Visible = false; // Ẩn cột 
            dgvDonors.Columns["Password"].Visible = false; // Ẩn cột 
            dgvDonors.Columns["Edit"].Visible = false;
        }


        private void LoadCheckColumn()
        {
            if (dgvDonors.Columns["Edit"] == null)
            {
                DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
                check.Name = "Edit";
                check.HeaderText = "Select";
                check.Visible = false;
                dgvDonors.Columns.Insert(0, check);

            }
        }

        private void UC_Donors_Load(object sender, EventArgs e)
        {
            Icons.SetupLeftIcon(btAddDonor, "\\Resources\\add.jpg");
            Icons.SetupLeftIcon(btEdit, "\\Resources\\update.jpg");
            Icons.SetupButtonIcon(btAddDonor);
            Icons.SetupButtonIcon(btEdit);
            Icons.SetUpDgv(dgvDonors);
            LoadDonors();
        }

        private void dgvDonors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDonors.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDonors.Rows[e.RowIndex];
                bool isChecked = Convert.ToBoolean(row.Cells["Edit"].EditedFormattedValue);

                if (isChecked)
                {
                    row.ReadOnly = false;
                    row.Cells["DonorID"].ReadOnly = true; //Không cho sửa ID
                }
                else
                {
                    row.ReadOnly = true;
                }
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            dgvDonors.Columns["Edit"].Visible = true;
            dgvDonors.ReadOnly = false;
            btSave.Visible = true;
            btnDelete.Visible = true;
            MessageBox.Show("Hãy chọn vào ô cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> idsToDelete = new List<int>();

            foreach (DataGridViewRow row in dgvDonors.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["Edit"].Value ?? false);
                if (isChecked)
                {
                    int donorID = Convert.ToInt16(row.Cells["DonorID"].Value);
                    idsToDelete.Add(donorID);
                }
            }
            if (idsToDelete.Count == 0)
            {
                MessageBox.Show("Chưa chọn dòng nào để xóa.");
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa {idsToDelete.Count} dòng đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            foreach (int id in idsToDelete)
            {
                donorBUS.DeleteDonorByAdmin(id);
            }

            LoadDonors();
            MessageBox.Show("Đã xóa thành công!");
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn lưu các thay đổi?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result != DialogResult.OK)
            {
                return;
            }

            foreach (DataGridViewRow row in dgvDonors.Rows)
            {

                try
                {
                    DonorDTO donorDTO = new DonorDTO()
                    {
                        DonorID = Convert.ToInt16(row.Cells["DonorID"].Value),
                        FullName = row.Cells["FullName"].Value?.ToString(),
                        BloodType = row.Cells["BloodType"].Value?.ToString(),
                        DateOfBirth = Convert.ToDateTime(row.Cells["DateOfBirth"].Value),
                        PhoneNumber = row.Cells["PhoneNumber"].Value?.ToString(),
                        Address = row.Cells["Address"].Value?.ToString(),
                        LastDonationDate = Convert.ToDateTime(row.Cells["LastDonationDate"].Value),
                        Gender = row.Cells["Gender"].Value?.ToString(),
                        Email = row.Cells["Email"].Value?.ToString()
                    };

                    donorBUS.UpdateByAdmin(donorDTO);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật " + ex.Message);
                    return;
                }
            }

            LoadDonors();
            MessageBox.Show("Cập nhật thành công!");

        }
    }
}
