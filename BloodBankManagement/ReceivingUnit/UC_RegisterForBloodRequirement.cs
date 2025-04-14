using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BUS;
using DTO;

namespace BloodBankManagement
{
    public partial class UC_RegisterForBloodRequirement : UserControl
    {
        private BloodRequirementBUS requirementBUS = new BloodRequirementBUS();

        public UC_RegisterForBloodRequirement()
        {
            InitializeComponent();
        }

        private void UC_RegisterForBloodRequirement_Load(object sender, EventArgs e)
        {
            dgvBloodRequirement.ColumnCount = 5;
            dgvBloodRequirement.Columns[0].Name = "Receiving Unit ID";
            dgvBloodRequirement.Columns[1].Name = "Blood Type";
            dgvBloodRequirement.Columns[2].Name = "Amount (ml)";
            // thêm cột request date 
            dgvBloodRequirement.Columns[3].Name = "Supply Date";
            dgvBloodRequirement.Columns[4].Name = "Status";
        }

        private void btSent_Click(object sender, EventArgs e)
        {
            var ruId = txtId.Text.Trim();
            var supplyDate = dpSupplyDate.Value;

            if (string.IsNullOrEmpty(ruId))
            {
                MessageBox.Show("Please enter Receiving Unit ID");
                return;
            }

            // Tạo danh sách các loại máu được chọn
            var detailList = new List<BloodRequirementDetailDTO>();

            foreach (var checkedItem in clbBloodType.CheckedItems)
            {
                string bloodType = checkedItem.ToString(); // e.g., "A+" hoặc "O-"
                string txtName = "txt" + bloodType.Replace("+", "Plus").Replace("-", "Minus");

                // DEBUG
                Console.WriteLine("Looking for TextBox: " + txtName);

                // Tìm textbox tương ứng
                var txtBoxArray = this.Controls.Find(txtName, true);

                if (txtBoxArray.Length > 0 && double.TryParse(txtBoxArray[0].Text, out double amount) && amount > 0)
                {
                    detailList.Add(new BloodRequirementDetailDTO
                    {
                        BloodType = bloodType,
                        Amount = amount
                    });
                }
            }

            if (detailList.Count == 0)
            {
                MessageBox.Show("Please select at least one blood type and enter a valid amount.");
                return;
            }

            // Tạo DTO yêu cầu chính
            var requirementDTO = new BloodRequirementDTO
            {
                RU_ID = ruId,
                SupplyDate = supplyDate,
                RequestDate = DateTime.Now,
                Status = "Pending",
                DetailList = detailList
            };

            bool result = requirementBUS.SendBloodRequirement(requirementDTO);

            if (result)
            {
                MessageBox.Show("Blood requirement submitted successfully!");
                dgvBloodRequirement.Rows.Clear();
                foreach (var detail in detailList)
                {
                    dgvBloodRequirement.Rows.Add(ruId, detail.BloodType, detail.Amount, supplyDate.ToShortDateString(), "Pending");
                }
            }
            else
                MessageBox.Show("Failed to submit blood requirement.");
        }

        
    }
}
