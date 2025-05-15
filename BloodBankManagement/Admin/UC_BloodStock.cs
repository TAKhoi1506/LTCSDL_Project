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

namespace BloodBankManagement
{
    public partial class UC_BloodStock : UserControl
    {
        public UC_BloodStock()
        {
            InitializeComponent();
        }
        private BloodStockBUS bus = new BloodStockBUS();
        private BloodDetailBUS bloodDetailBUS = new BloodDetailBUS();


        //private void btAddDonor_Click(object sender, EventArgs e)
        //{
        //    string selectedBloodType = cbBloodType.SelectedItem?.ToString();
        //    double amountToAdd = Convert.ToDouble(numAmount.Value);

        //    if (string.IsNullOrEmpty(selectedBloodType) || amountToAdd <= 0)
        //    {
        //        MessageBox.Show("Vui lòng chọn nhóm máu và nhập số lượng hợp lệ!");
        //        return;
        //    }
        //    BloodStock existingStock = bus.GetStockByType(selectedBloodType);
        //    if (existingStock != null)
        //    {
        //        // Nếu có rồi thì cộng dồn
        //        existingStock.Amount += amountToAdd;
        //        bus.UpdateStock(existingStock);
        //    }
        //    LoadStockGrid();
        //}

        private void LoadStockGrid()
        {
            dgvStock.DataSource = null;
            dgvStock.DataSource = bus.GetAllStock();
        }

        private void UC_BloodStock_Load(object sender, EventArgs e)
        {
            Icons.SetUpDgv(dgvBloodDetails);
            Icons.SetUpDgv(dgvStock);
            //cbBloodType.SelectedIndex = 1;
            LoadStockGrid();
            LoadBloodDetails();
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

        private void dgvStock_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try

                {
                    var row = dgvStock.Rows[e.RowIndex];
                    var updatedValue = new DTO.BloodStock
                    {
                        BloodType = row.Cells["BloodType"].Value.ToString(),
                        Amount = Convert.ToInt16(row.Cells["Amount"].Value)
                    };
                    // Lấy giá trị của ô đã thay đổi
                    string bloodType = dgvStock.Rows[e.RowIndex].Cells["BloodType"].Value.ToString();
                    double amount = Convert.ToDouble(dgvStock.Rows[e.RowIndex].Cells["Amount"].Value);
                    // Cập nhật giá trị vào cơ sở dữ liệu
                    BloodStock stock = new BloodStock
                    {
                        BloodType = bloodType,
                        Amount = amount
                    };
                    bus.UpdateStock(stock);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
