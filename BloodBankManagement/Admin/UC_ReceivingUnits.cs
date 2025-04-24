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
    public partial class UC_ReceivingUnits: UserControl
    {
        public UC_ReceivingUnits()
        {
            InitializeComponent();
        }
        ReceivingUnitBUS unitBUS = new ReceivingUnitBUS();
        private void UC_ReceivingUnits_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
        }
        private void LoadDataGrid()
        {
            dgvReceivingUnits.DataSource = unitBUS.GetAll();
        }

        private void btAddUnit_Click(object sender, EventArgs e)
        {
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
            LoadDataGrid();
        }
    }
}
