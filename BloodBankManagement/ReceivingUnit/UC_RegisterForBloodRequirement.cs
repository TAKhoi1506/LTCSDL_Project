using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using BUS;
using DTO;

namespace BloodBankManagement
{
    public partial class UC_RegisterForBloodRequirement : UserControl
    {
        private BloodRequirementBUS requirementBUS = new BloodRequirementBUS();
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

            // lấy thông tin người dùng lên => HIỆN TẠI CHƯA LÀM LOGIN NÊN CHƯA CÓ 
            //if (!string.IsNullOrEmpty(CurrentUnitID))
            //{
            //    ReceivingUnitBUS ruBUS = new ReceivingUnitBUS();
            //    var unit = ruBUS.GetByID(CurrentUnitID);
            //    if (unit != null)
            //    {
            //        txtUnitID.Text = unit.UnitID;
            //        txtUnitName.Text = unit.UnitName;
            //    }
            //}
        }

        private void LoadRequirementsToGrid()
        {
            try
            {
                //dgvBloodRequirement.Rows.Clear();
                //dgvBloodRequirement.Columns.Clear();

                //dgvBloodRequirement.Columns.Add("UnitID", "Mã đơn vị");
                //dgvBloodRequirement.Columns.Add("RequestDate", "Ngày yêu cầu");
                //dgvBloodRequirement.Columns.Add("SupplyDate", "Ngày cung cấp");
                //dgvBloodRequirement.Columns.Add("BloodType", "Nhóm máu");
                //dgvBloodRequirement.Columns.Add("Amount", "Số lượng");
                //dgvBloodRequirement.Columns.Add("Status", "Trạng thái");

                var requirements = new BloodRequirementBUS().GetAllRequirements();
                var detailBUS = new BloodRequirementDetailBUS();


                foreach (var req in requirements)
                {
                    // Lấy danh sách chi tiết loại máu cho mỗi yêu cầu
                    var details = detailBUS.GetByRequirementID(req.ID);

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

        private void btSent_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUnitId.Text.Trim()))
                {
                    MessageBox.Show("Please enter Receiving Unit ID");
                    return;
                }

                if (clbBloodType.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Please select at least one blood type!");
                    return;
                }

                // 1. Tạo yêu cầu máu chính
                var brDTO = new BloodRequirementDTO
                {
                    RU_ID = txtUnitId.Text,
                    RequestDate = DateTime.Now,
                    SupplyDate = dpSupplyDate.Value,
                    Status = "Pending"
                };

                var brBUS = new BloodRequirementBUS();
                int newRequirementID = brBUS.AddRequirement(brDTO); // Trả về ID vừa tạo

                // 2. Duyệt các nhóm máu đã check để lưu detail
                var brDetailBUS = new BloodRequirementDetailBUS();

                foreach (var item in clbBloodType.CheckedItems)
                {
                    string bloodType = item.ToString();

                    if (bloodTypeTextBoxMap.TryGetValue(bloodType, out BunifuTextBox amountTextBox))
                    {
                        if (int.TryParse(amountTextBox.Text.Trim(), out int amount) && amount > 0)
                        {
                            var detailDTO = new BloodRequirementDetailDTO
                            {
                                RequirementID = newRequirementID,
                                BloodType = bloodType,
                                Amount = amount
                            };

                            brDetailBUS.AddDetail(detailDTO);
                        }
                    }
                }

                MessageBox.Show("Blood requirement submitted successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRequirementsToGrid(); // Refresh lại DataGridView
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error registering a blood request: " + ex.Message);
            }
        }
    }
}
