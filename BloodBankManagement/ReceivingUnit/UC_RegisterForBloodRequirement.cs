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
        private BloodRequirementBUS brBUS = new BloodRequirementBUS();
        private BloodRequirementDetailBUS brDetailBUS = new BloodRequirementDetailBUS();

        private Dictionary<string, BunifuTextBox> bloodTypeTextBoxMap;

        public UC_RegisterForBloodRequirement()
        {
            InitializeComponent();
            LoadRequirementsToGrid();
            txtSearch.TextChanged += txtSearch_TextChanged;
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
            //        txtUnitId.Text = unit.UnitID;
            //        txtUnitName.Text = unit.UnitName;
            //        txtUnitId.ForeColor = Color.Silver;
            //        txtUnitName.ForeColor = Color.Silver;
            //        txtUnitId.ReadOnly = true;
            //        txtUnitName.ReadOnly = true;
            //    }
            //}
        }

        // Cách 1: load không tham số 
        private void LoadRequirementsToGrid()
        {
            try
            {
                dgvBloodRequirement.Rows.Clear(); // Xóa tất cả dòng cũ trước khi load mới

                var requirements = new BloodRequirementBUS().GetAllRequirements();

                foreach (var req in requirements)
                {
                    // Lấy danh sách chi tiết loại máu cho mỗi yêu cầu
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

                int newRequirementID = brBUS.AddRequirement(brDTO); // Trả về ID vừa tạo

                // 2. Duyệt các nhóm máu đã check để lưu detail

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

        // Search by unit ID 
        private void btSearch_Click(object sender, EventArgs e)
        {
            dgvBloodRequirement.Rows.Clear();
            string unitID = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(unitID))
            {
                MessageBox.Show("Please enter Unit ID to search!");
                return;
            }

            var requirementList = brBUS.SearchRequirementByID(unitID);

            if (requirementList != null && requirementList.Count > 0)
            {
                foreach (var requirement in requirementList)
                {
                    var details = brDetailBUS.GetByRequirementID(requirement.ID);
                    foreach (var detail in details)
                    {
                        dgvBloodRequirement.Rows.Add(
                            requirement.RU_ID,
                            requirement.RequestDate.ToString("dd/MM/yyyy"),
                            requirement.SupplyDate.ToString("dd/MM/yyyy"),
                            detail.BloodType,
                            detail.Amount,
                            requirement.Status
                        );
                    }
                }
            }
            else
            {
                MessageBox.Show("Not found!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Nếu ô tìm kiếm rỗng, hiển thị lại toàn bộ dữ liệu
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadRequirementsToGrid();
            }
        }

        // Sort
        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedColumn = cbSort.SelectedItem.ToString(); // Lấy cột cần sắp xếp

            var sortedList = brBUS.SortRequirements(selectedColumn); // Sắp xếp danh sách

            LoadRequirementsToGrid(sortedList); // Hiển thị danh sách đã sắp xếp
        }
    }
}
