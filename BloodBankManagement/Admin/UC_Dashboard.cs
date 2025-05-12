using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BloodBankManagement.Admin
{
    public partial class UC_Dashboard : UserControl
    {
        public UC_Dashboard()
        {
            InitializeComponent();
        }
        private ReportBUS reportBUS = new ReportBUS();


     

        private void LoadBloodGroupStatistics()
        {
            var list = reportBUS.GetBloodGroupStatistics();
            chartReport1.Series.Clear();

            Series series = new Series("Blood Group Statistics")
            {
                ChartType = SeriesChartType.Doughnut // Hoặc Column tùy
            };

            foreach (var item in list)
            {
                series.Points.AddXY(item.BloodType, item.TotalAmount);
            }

            chartReport1.Series.Add(series);
            chartReport1.Visible = true;
        }


        private void LoadDistributedBlood()
        {
            var list = reportBUS.GetDistributedBlood();
            dgvReport.DataSource = list;
            dgvReport.Visible = true;

            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            LoadBloodGroupStatistics();
            LoadDistributedBlood();
        }

       
    }
}
