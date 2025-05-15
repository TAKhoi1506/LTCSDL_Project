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
    public partial class UC_Events : UserControl
    {
        public UC_Events()
        {
            InitializeComponent();
            LoadEvents();
            bunifuDataGridView1.CellValueChanged += bunifuDataGridView1_CellValueChanged;
            txtSearch.TextChanged += txtSearch_TextChange;
            bunifuDataGridView1.CurrentCellDirtyStateChanged += bunifuDataGridView1_CurrentCellDirtyStateChanged;
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
            try
            {
                bunifuDataGridView1.Rows.Clear();
                var events = eventBUS.GetAllEvents();
                foreach (var e in events)
                {
                    bunifuDataGridView1.Rows.Add(
                        e.EventID,
                        e.EventName,
                        e.Description,
                        e.Location,
                        e.EventDate.ToString("dd/MM/yyyy"),
                        e.Status
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading events: " + ex.Message);

            }
        }
        private void LoadEvents(List<(EventDTO Event, string Status)> sortedList)
        {
            try
            {
                bunifuDataGridView1.Rows.Clear(); // Xóa tất cả dòng cũ trước khi load mới
                foreach (var e in sortedList)
                {
                    bunifuDataGridView1.Rows.Add(
                        e.Event.EventID,
                        e.Event.EventName,
                        e.Event.Description,
                        e.Event.Location,
                        e.Event.EventDate.ToString("dd/MM/yyyy"),
                        e.Status
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading events: " + ex.Message);
            }
        }

        private void txtSearch_TextChange(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(search))
            {
                LoadEvents(); // Nếu không có gì để tìm kiếm, load lại tất cả sự kiện
            }
            
        }

        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedColumn = cbSort.SelectedItem.ToString();
            var sortedList = eventBUS.SortEvents(selectedColumn);
            LoadEvents(sortedList);
        }

        private void UC_Events_Load(object sender, EventArgs e)
        {
            Icons.SetupLeftIcon(btAddEvent, "/Resources/event.jpg");
            Icons.SetupButtonIcon(btAddEvent);
            Icons.SetUpDgv(bunifuDataGridView1);
        }

        private void bunifuDataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if(bunifuDataGridView1.IsCurrentCellDirty)
            {
                bunifuDataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            bunifuDataGridView1.Rows.Clear();
            string search = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Please enter Event Name to search!");
                return;
            }
            var events = eventBUS.SearchEvent(search);
            if (events != null && events.Count > 0)
            {
                foreach (var eve in events)
                {
                    bunifuDataGridView1.Rows.Add(
                        eve.EventID,
                        eve.EventName,
                        eve.Description,
                        eve.Location,
                        eve.EventDate.ToString("dd/MM/yyyy"),
                        eve.Status
                    );
                }
            }
            else
            {
                MessageBox.Show("Not found!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
