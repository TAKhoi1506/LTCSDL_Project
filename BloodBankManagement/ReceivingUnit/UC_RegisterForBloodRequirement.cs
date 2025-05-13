using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BloodBankManagement.Static;
using Bunifu.UI.WinForms;
using BUS;
using DTO;

namespace BloodBankManagement
{
    public partial class UC_RegisterForBloodRequirement : UserControl
    {
        private BloodRequirementBUS brBUS = new BloodRequirementBUS();
        private BloodRequirementDetailBUS brDetailBUS = new BloodRequirementDetailBUS();

        private Dictionary<string, BunifuTextBox> bloodTypeTextBoxMap;

        public UC_RegisterForBloodRequirement()
        {
            InitializeComponent();
            LoadRequirementsToGrid();
        }

        private void UC_RegisterForBloodRequirement_Load(object sender, EventArgs e)
        {
            // Map từng loại máu đến textbox tương ứng
            bloodTypeTextBoxMap = new Dictionary<string, BunifuTextBox>
            {
                { "A+", txtAPlus },
                { "A-", txtAMinus },
                { "B+", txtBPlus },
                { "B-", txtBMinus },
                { "AB+", txtABPlus },
                { "AB-", txtABMinus },
                { "O+", txtOPlus },
                { "O-", txtOMinus }
            };

            if (UserSession.Role == "ReceivingUnit" && !string.IsNullOrEmpty(UserSession.ObjectID))
            {
                ReceivingUnitBUS bus = new ReceivingUnitBUS();
                var ru = bus.GetById(UserSession.ObjectID);

                if (ru != null)
                {
                    txtUnitId.Text = ru.RU_ID;
                    txtUnitName.Text = ru.UnitName;
                    txtUnitName.SelectionStart = 0;
                    txtUnitName.SelectionLength = 0;
                }
                else
                {
                    MessageBox.Show("Cannot load receiving unit info.");
                }
            }
        }

        // load requirement tương ứng với RU_ID trong session
        private void LoadRequirementsToGrid()
        {
            try
            {
                dgvBloodRequirement.Rows.Clear();

                string currentRuId = UserSession.ObjectID?.ToString();
                if (string.IsNullOrEmpty(currentRuId))
                {
                    MessageBox.Show("Receiving Unit ID not found in session.");
                    return;
                }

                var myRequirements = new BloodRequirementBUS().GetByUnitID(currentRuId);

                foreach (var req in myRequirements)
                {
                    var details = brDetailBUS.GetByRequirementID(req.ID);

                    foreach (var detail in details)
                    {
                        dgvBloodRequirement.Rows.Add(
                            req.RU_ID,
                            req.RequestDate.ToString("dd/MM/yyyy"),
                            req.SupplyDate.ToString("dd/MM/yyyy"),
                            detail.BloodType,
                            detail.Amount,
                            req.Status
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading blood request data: " + ex.Message);
            }
        }


        // Cách 2: load có tham số 
        private void LoadRequirementsToGrid(List<(BloodRequirementDTO Requirement, BloodRequirementDetailDTO Detail)> sortedList)
        {
            try
            {
                dgvBloodRequirement.Rows.Clear(); // Xóa tất cả dữ liệu cũ

                string currentRuId = UserSession.ObjectID?.ToString();
                if (string.IsNullOrEmpty(currentRuId))
                {
                    MessageBox.Show("Receiving Unit ID not found in session.");
                    return;
                }
                var myRequirements = new BloodRequirementBUS().GetByUnitID(currentRuId);

                foreach (var req in myRequirements)
                {
                    var details = brDetailBUS.GetByRequirementID(req.ID);

                    foreach (var item in sortedList)
                    {
                        dgvBloodRequirement.Rows.Add(
                            item.Requirement.RU_ID,
                            item.Requirement.RequestDate.ToString("dd/MM/yyyy"),
                            item.Requirement.SupplyDate.ToString("dd/MM/yyyy"),
                            item.Detail.BloodType,
                            item.Detail.Amount,
                            item.Requirement.Status
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading blood request data: " + ex.Message);
            }
        }


        // Sau khi SentBloodRequirement những dữ liệu trên control bị xóa đi 
        private void ClearForm()
        {
            // Giữ nguyên txtUnitID và txtUnitName
            dpSupplyDate.Value = DateTime.Now;

            // Bỏ chọn tất cả các blood type trong CheckedListBox
            for (int i = 0; i < clbBloodType.Items.Count; i++)
            {
                clbBloodType.SetItemChecked(i, false);
            }

            // Clear các TextBox số lượng máu
            txtAPlus.Clear();
            txtAMinus.Clear();
            txtBPlus.Clear();
            txtBMinus.Clear();
            txtABPlus.Clear();
            txtABMinus.Clear();
            txtOPlus.Clear();
            txtOMinus.Clear();
        }
    }
}
