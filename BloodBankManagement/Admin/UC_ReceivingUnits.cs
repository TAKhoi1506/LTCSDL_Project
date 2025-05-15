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
using System.Text.RegularExpressions;
using BloodBankManagement.Static;

namespace BloodBankManagement
{
    public partial class UC_ReceivingUnits: UserControl
    {
        ReceivingUnitBUS unitBUS = new ReceivingUnitBUS();
        ToolTip toolTip = new ToolTip();

        public UC_ReceivingUnits()
        { 
            InitializeComponent();
        }
        private void UC_ReceivingUnits_Load(object sender, EventArgs e)
        {
            Icons.SetupLeftIcon(btAddUnit, "\\Resources\\ru.jpg");
            Icons.SetupButtonIcon(btAddUnit);
            Icons.SetUpDgv(dgvReceivingUnits);
            LoadDataGrid();
            // Hiển thị tooltip cho ô nhập số điện thoại
            toolTip.SetToolTip(txtPhoneNo, "Please enter a phone number consisting of 10 or 11 digits, starting with the number 0.");
        }

        private void ClearFields()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUnitName.Clear();
            txtId.Clear();
            txtAddress.Clear();
            txtContactName.Clear();
            txtPhoneNo.Clear();
            txtEmail.Clear();
            cbUnitType.SelectedIndex = -1;
        }

        private void LoadDataGrid()
        {
            dgvReceivingUnits.AutoGenerateColumns = true;
            dgvReceivingUnits.DataSource = unitBUS.GetAll();
            dgvReceivingUnits.Columns["RU_ID"].HeaderText = "Unit ID";
            dgvReceivingUnits.Columns["RU_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvReceivingUnits.Columns["UnitName"].HeaderText = "Unit Name";
            dgvReceivingUnits.Columns["UnitName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvReceivingUnits.Columns["ContactName"].HeaderText = "Contact Name";
            dgvReceivingUnits.Columns["PhoneNumber"].HeaderText = "Phone Number";
            dgvReceivingUnits.Columns["UnitType"].HeaderText = "Unit Type";
            dgvReceivingUnits.Columns["Username"].Visible = false;
            dgvReceivingUnits.Columns["Password"].Visible = false;
            dgvReceivingUnits.AutoResizeColumns();
        }

        private void Validation()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) ||
                  string.IsNullOrWhiteSpace(txtUsername.Text) ||
                  string.IsNullOrWhiteSpace(txtPassword.Text) ||
                  string.IsNullOrWhiteSpace(txtUnitName.Text) ||
                  string.IsNullOrWhiteSpace(txtAddress.Text) ||
                  string.IsNullOrWhiteSpace(txtContactName.Text) ||
                  string.IsNullOrWhiteSpace(txtPhoneNo.Text) ||
                  string.IsNullOrWhiteSpace(cbUnitType.Text))
            {
                MessageBox.Show("Please fill in all the information!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validate số điện thoại
            if (!Regex.IsMatch(txtPhoneNo.Text, @"^0\d{9,10}$"))
            {
                MessageBox.Show("Phone number is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng email nếu cần
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) &&
                !Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btAddUnit_Click(object sender, EventArgs e)
        {
            try
            {
                Validation();

                var dto = new ReceivingUnitDTO
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    UnitName = txtUnitName.Text,
                    RU_ID = txtId.Text,
                    Address = txtAddress.Text,
                    ContactName = txtContactName.Text,
                    PhoneNumber = txtPhoneNo.Text,
                    Email = txtEmail.Text,
                    UnitType = cbUnitType.Text
                };

                unitBUS.Add(dto);
                MessageBox.Show("Added successfully!");
                dgvReceivingUnits.DataSource = unitBUS.GetAll();
                LoadDataGrid();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add failed! " + ex.Message);
            }
        }

        // cập nhật dữ liệu khi thay đổi trong DataGridView
        private void dgvReceivingUnits_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var row = dgvReceivingUnits.Rows[e.RowIndex];

                    var updatedDto = new ReceivingUnitDTO
                    {
                        RU_ID = row.Cells["RU_ID"].Value?.ToString(),
                        UnitName = row.Cells["UnitName"].Value?.ToString(),
                        ContactName = row.Cells["ContactName"].Value?.ToString(),
                        Address = row.Cells["Address"].Value?.ToString(),
                        PhoneNumber = row.Cells["PhoneNumber"].Value?.ToString(),
                        Email = row.Cells["Email"].Value?.ToString(),
                        UnitType = row.Cells["UnitType"].Value?.ToString()
                        // Username và Password bị ẩn hoặc không cập nhật tại đây
                    };

                    // Gọi cập nhật từ BUS
                    bool success = unitBUS.AdminUpdate(updatedDto);
                    if (!success)
                    {
                        MessageBox.Show("Update failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while updating: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
