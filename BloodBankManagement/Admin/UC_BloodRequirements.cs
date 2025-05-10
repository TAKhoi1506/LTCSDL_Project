using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace BloodBankManagement.Admin
{
    public partial class UC_BloodRequirements : UserControl
    {
        private BloodRequirementDetailBUS brDetailBUS = new BloodRequirementDetailBUS();
        private BloodRequirementBUS brBUS = new BloodRequirementBUS();

        public UC_BloodRequirements()
        {
            InitializeComponent();
            LoadRequirementsToGrid();
            txtSearch.TextChanged += txtSearch_TextChanged;
            dgvBloodRequirement.CellValueChanged += dgvBloodRequirement_CellValueChanged;
            dgvBloodRequirement.CurrentCellDirtyStateChanged += dgvBloodRequirement_CurrentCellDirtyStateChanged;

        }

        private void UC_BloodRequirements_Load(object sender, EventArgs e)
        {

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
                            req.ID,
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

        // Cách 2: load có tham số, dùng khi sort 
        private void LoadRequirementsToGrid(List<(BloodRequirementDTO Requirement, BloodRequirementDetailDTO Detail)> sortedList)
        {
            try
            {
                dgvBloodRequirement.Rows.Clear(); // Xóa tất cả dữ liệu cũ

                foreach (var item in sortedList)
                {
                    dgvBloodRequirement.Rows.Add(
                        item.Requirement.ID,
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
                            requirement.ID,
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

        private void dgvBloodRequirement_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvBloodRequirement.Columns[e.ColumnIndex].Name == "Status")
            {
                try
                {
                    // Lấy RequirementID từ dòng đó
                    int requirementId = Convert.ToInt32(dgvBloodRequirement.Rows[e.RowIndex].Cells["ID"].Value);
                    string newStatus = dgvBloodRequirement.Rows[e.RowIndex].Cells["Status"].Value?.ToString();

                    if (!string.IsNullOrEmpty(newStatus))
                    {
                        BloodRequirementBUS bus = new BloodRequirementBUS();
                        bool success = bus.UpdateStatus(requirementId, newStatus);
                        if (!success)
                            MessageBox.Show("Cập nhật trạng thái thất bại.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật trạng thái: " + ex.Message);
                }
            }
        }

        private void dgvBloodRequirement_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvBloodRequirement.IsCurrentCellDirty)
            {
                dgvBloodRequirement.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
