using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using BUS;
using DTO;

namespace BloodBankManagement
{
    public partial class UC_Events : UserControl
    {
        public UC_Events()
        {
            InitializeComponent();
            bunifuDataGridView1.CellValueChanged += bunifuDataGridView1_CellValueChanged;
        }
        private EventBUS eventBUS = new EventBUS();
        private void bunifuDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridView1.Columns[e.ColumnIndex].Name == "Status")
            {
                int eventID = Convert.ToInt32(bunifuDataGridView1.Rows[e.RowIndex].Cells["EventID"].Value);
                string newStatus = bunifuDataGridView1.Rows[e.RowIndex].Cells["Status"].Value.ToString();

                // Gọi BUS để cập nhật
                eventBUS.UpdateEventStatus(eventID, newStatus);
            }
        }
        private void LoadEvents()
        {
            // Reload data
            List<EventDTO> events = eventBUS.GetAllEvents();
            bunifuDataGridView1.DataSource = events;

            // Convert Status column to ComboBox
            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
            statusColumn.HeaderText = "Status";
            statusColumn.Name = "Status"; // phải trùng với tên property nếu muốn binding
            statusColumn.DataPropertyName = "Status"; // tên field trong EventDTO
            statusColumn.Items.AddRange("Ongoing", "Completed", "Cancelled");

            // Thêm vào đúng vị trí (ví dụ là cột đầu tiên)
            bunifuDataGridView1.Columns.Insert(0, statusColumn);

            // Ẩn cột cũ nếu bị trùng
            for (int i = 1; i < bunifuDataGridView1.Columns.Count; i++)
            {
                if (bunifuDataGridView1.Columns[i].HeaderText == "Status")
                {
                    bunifuDataGridView1.Columns[i].Visible = false;
                    break;
                }
            }

        }

        private void txtSearch_TextChange(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower();

            // Lấy lại danh sách đầy đủ
            List<EventDTO> allEvents = eventBUS.GetAllEvents();

            // Lọc theo tên sự kiện, mô tả, hoặc địa điểm
            var filtered = allEvents.Where(ev =>
                ev.EventName.ToLower().Contains(keyword) ||
                ev.Description.ToLower().Contains(keyword) ||
                ev.Location.ToLower().Contains(keyword) ||
                ev.Status.ToLower().Contains(keyword)
            ).ToList();

            // Gán lại dữ liệu
            bunifuDataGridView1.DataSource = filtered;

            // (Optional) Gán lại ComboBox status nếu cần
            foreach (DataGridViewRow row in bunifuDataGridView1.Rows)
            {
                DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();
                comboBoxCell.Items.AddRange("Ongoing", "Completed", "Cancelled");
                comboBoxCell.Value = row.Cells["Status"].Value?.ToString();
                row.Cells["Status"] = comboBoxCell;
            }
        }

        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortBy = cbSort.SelectedItem.ToString();
            List<EventDTO> events = eventBUS.GetAllEvents();

            switch (sortBy)
            {
                case "Event name":
                    events = events.OrderBy(x => x.EventName).ToList();
                    break;
                case "Event date":
                    events = events.OrderBy(x => x.EventDate).ToList();
                    break;
                case "Status":
                    events = events.OrderBy(x => x.Status).ToList();
                    break;
                default:
                    break;
            }

            bunifuDataGridView1.DataSource = events;
        }

        private void UC_Events_Load(object sender, EventArgs e)
        {
            LoadEvents();
        }
    }
}
