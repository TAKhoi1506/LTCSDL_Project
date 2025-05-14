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
    public partial class UC_BloodStock: UserControl
    {
        public UC_BloodStock()
        {
            InitializeComponent();
        }
        private BloodStockBUS bus = new BloodStockBUS();
        private BloodDetailBUS bloodDetailBUS = new BloodDetailBUS();


        private void btAddDonor_Click(object sender, EventArgs e)
        {
            string selectedBloodType = cbBloodType.SelectedItem?.ToString();
            double amountToAdd = Convert.ToDouble(numAmount.Value);

            if (string.IsNullOrEmpty(selectedBloodType) || amountToAdd <= 0)
            {
                MessageBox.Show("Vui lòng chọn nhóm máu và nhập số lượng hợp lệ!");
                return;
            }
            BloodStock existingStock = bus.GetStockByType(selectedBloodType);
            if (existingStock != null)
            {
                // Nếu có rồi thì cộng dồn
                existingStock.Amount += amountToAdd;
                bus.UpdateStock(existingStock);
            }
            LoadStockGrid();
        }

        private void LoadStockGrid()
        {
            dgvStock.DataSource = null;
            dgvStock.DataSource = bus.GetAllStock();
        }

        private void UC_BloodStock_Load(object sender, EventArgs e)
        {
            cbBloodType.SelectedIndex = 1;
            LoadStockGrid();
            LoadBloodDetails();
        }

        private void UC_BloodStock_Load_1(object sender, EventArgs e)
        {
            cbBloodType.SelectedIndex = 1;
            LoadStockGrid();

        }

        private void LoadBloodDetails()
        {
            var list = bloodDetailBUS.GetAllBloodDetails();
            dgvBloodDetails.DataSource = list;

            dgvBloodDetails.Columns["BloodDetailID"].HeaderText = "ID";
            dgvBloodDetails.Columns["BloodID"].HeaderText = "Blood ID";
            dgvBloodDetails.Columns["Status"].HeaderText = "Status";
            dgvBloodDetails.Columns["CollectionDate"].HeaderText = "Collected";
            dgvBloodDetails.Columns["ExpiredDate"].HeaderText = "Expired";
            dgvBloodDetails.Columns["DonorID"].HeaderText = "Donor";
        }
    }
}
