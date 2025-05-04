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
using System.Windows.Forms.DataVisualization.Charting;
using System.Management;

namespace BloodBankManagement.Admin
{
    public partial class UC_Dashboard: UserControl
    {
        private readonly ReportBUS reportBUS;
        public UC_Dashboard()
        {
            InitializeComponent();
            reportBUS = new ReportBUS();

        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selected)) return;

            dgvReport.Visible = false;
            chartReport.Visible = false;

            if (selected == "Tổng số lượng máu đã nhận")
            {
                LoadReceivedBlood();
            }
            else if (selected == "Số lượng máu đã cấp phát")
            {
                LoadDistributedBlood();
            }
            else if (selected == "Thống kê theo nhóm máu")
            {
                LoadBloodGroupStatistics();
            }
        }
        private void LoadReceivedBlood()
        {
            var list = reportBUS.GetReceivedBloodByDate();
            dgvReport.DataSource = list;
            dgvReport.Visible = true;
        }

        private void LoadDistributedBlood()
        {
            var list = reportBUS.GetDistributedBlood();
            dgvReport.DataSource = list;
            dgvReport.Visible = true;
        }

        private void LoadBloodGroupStatistics()
        {
            var list = reportBUS.GetBloodGroupStatistics();
            chartReport.Series.Clear();

            Series series = new Series("Blood Group Statistics")
            {
                ChartType = SeriesChartType.Pie // Hoặc Column tùy
            };

            foreach (var item in list)
            {
                series.Points.AddXY(item.BloodType, item.TotalAmount);
            }

            chartReport.Series.Add(series);
            chartReport.Visible = true;
        }
    }
}
