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
using OfficeOpenXml;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;



namespace BloodBankManagement.Admin
{
    public partial class UC_DashBoard2 : UserControl
    {
        public UC_DashBoard2()
        {
            InitializeComponent();
        }

        private ReportBUS reportBUS = new ReportBUS();
        private DonorBUS donorBUS = new DonorBUS();


        //================ THÔNG TIN HIỂN THỊ TRÊN DATAGRIDVIEW =================
        private void LoadDistributedBlood()
        {
            var list = reportBUS.GetDistributedBlood();
            dgvReport.DataSource = list;
            dgvReport.Columns["StockAmount"].Visible = false;
            dgvReport.Visible = true;

            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
       
        }


        private void LoadAllDonorsInformation()
        {
            var list = donorBUS.GetAllDonors();
            dgvReport.DataSource = list;
            dgvReport.Columns["Username"].Visible = false;
            dgvReport.Columns["Password"].Visible = false;
            dgvReport.Visible = true;

            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
       
        }


        //======================================================================





        //================ THÔNG TIN HIỂN THỊ TRÊN CÁC BIỂU ĐỒ =================
        private void LoadBloodGroupStatistics()
        {
            lbTitle1.Text = "Thống kê nhóm máu";
            var list = reportBUS.GetBloodGroupStatistics();
            chartReport1.Series.Clear();

            Series series = new Series("Blood Group Statistics")
            {
                ChartType = SeriesChartType.Doughnut // Hoặc Column tùy

            };

            foreach (var item in list)
            {
                var point = new DataPoint();
                point.AxisLabel = ""; // Không hiển thị tên nhóm máu trên chart
                point.LegendText = item.BloodType; // Tên hiển thị trong legend
                point.YValues = new double[] { item.TotalAmount };

                series.Points.Add(point);
                //series.Points.AddXY(item.BloodType, item.TotalAmount);

            }

            chartReport1.Series.Add(series);
            chartReport1.Visible = true;
        }


       



        private void LoadBloodRequirementStatistic2()
        {
            lbTitle3.Text = "Thống kê số lượng máu cung cấp qua từng tháng";
            var list = reportBUS.BloodOverTimeStatistics();
            chartReport3.Series.Clear();
            chartReport3.ChartAreas[0].AxisX.Title = "Thời gian";
            chartReport3.ChartAreas[0].AxisY.Title = "Lượng máu";

            var bloodTypes = list.Select(x => x.BloodType).Distinct();

            foreach (var bloodType in bloodTypes)
            {
                Series series = new Series(bloodType)
                {
                    ChartType = SeriesChartType.Column
                };

                var data = list.Where(x => x.BloodType == bloodType).OrderBy(x => x.PeriodTime);

                foreach (var item in data)
                {
                    series.Points.AddXY(item.PeriodTime, item.TotalAmount);
                }

                chartReport3.Series.Add(series);
                chartReport3.Visible = true;
            }
        }


        private void LoadDistributedBloodStatistic()
        {
            lbTitle2.Text = "Phân phối lượng máu trong kho";
            var list = reportBUS.GetDistributedBloodStatistics();
            chartReport2.Series.Clear();
            chartReport2.ChartAreas.Clear();
            chartReport2.ChartAreas.Add(new ChartArea());

            chartReport2.ChartAreas[0].AxisX.Title = "Loại máu";
            chartReport2.ChartAreas[0].AxisY.Title = "Lượng máu";

            //Biểu đồ máu trong kho
            Series stockSeries = new Series("Còn trong kho")
            {
                ChartType = SeriesChartType.Column
            };

            //Biểu đồ máu đã phân phối
            Series distributedSeries = new Series("Đã phân phối")
            {
                ChartType = SeriesChartType.Column
            };


            foreach (var item in list)
            {
                stockSeries.Points.AddXY(item.BloodType, item.StockAmount);
                distributedSeries.Points.AddXY(item.BloodType, item.Amount);
            }

            chartReport2.Series.Add(stockSeries);
            chartReport2.Series.Add(distributedSeries);
            chartReport2.Visible = true;
        }




        private void LoadBloodRequirementStatistic()
        {
            //lbTitle2.Text = "Thống kê số lượng máu nhận được qua từng tháng";
            //var list = reportBUS.BloodOverTimeStatistics();
            //chartReport2.Series.Clear();
            //chartReport2.ChartAreas[0].AxisX.Title = "Thời gian";
            //chartReport2.ChartAreas[0].AxisY.Title = "Lượng máu";

            //var bloodTypes = list.Select(x => x.BloodType).Distinct();

            //foreach (var bloodType in bloodTypes)
            //{
            //    Series series = new Series(bloodType)
            //    {
            //        ChartType = SeriesChartType.Column
            //    };

            //    var data = list.Where(x => x.BloodType == bloodType).OrderBy(x => x.PeriodTime);

            //    foreach (var item in data)
            //    {
            //        series.Points.AddXY(item.PeriodTime, item.TotalAmount);
            //    }

            //    chartReport2.Series.Add(series);
            //    chartReport2.Visible = true;
            //}
        }


        private void LoadDonorAgeGroupStatistic()
        {
            lbTitle3.Text = "Thống kê nhóm tuổi người dùng";
            var list = reportBUS.GetAgeofDonorStatistic();

            int total = list.Sum(x => x.Count);

            chartReport3.Series.Clear();
            chartReport3.ChartAreas[0].AxisX.Title = "Nhóm tuổi";
            chartReport3.ChartAreas[0].AxisY.Title = "Số lượng";
       


            Series series = new Series("Nhóm tuổi")
            {
                ChartType = SeriesChartType.Pie,
               
                
            };

            foreach (var item in list)
            {
                double percent = (double)item.Count/ total;
                DataPoint point = new DataPoint();
                point.AxisLabel = item.AgeGroup;
                point.YValues = new double[] { item.Count };
                point.Label = string.Format("{0:P1}",percent);
                point.LegendText = item.AgeGroup;
                series.Points.Add(point);
            }

            chartReport3.Series.Add(series);
            chartReport2.Visible = true;

        }
        

        private void LoadDonorGenderGroupStatistic() 
        {
            lbTitle1.Text = "Thống kê theo giới tính";
            var list = reportBUS.GetGenderofDonorStatistic();
            chartReport1.Series.Clear();
            chartReport1.ChartAreas[0].AxisX.Title = "Giới tính";
            chartReport1.ChartAreas[0].AxisX.Title = "Số lượng";

            Series series = new Series("Giới tính")
            {
                ChartType = SeriesChartType.Pie
            };

            foreach (var item in list)
            {
                series.Points.AddXY(item.Gender, item.Count);
            }
            chartReport1.Series.Add(series);
            chartReport1.Visible = true;
        }
           


        private void LoadDonorDonatedTimeStatistic()
        {
            lbTitle2.Text = "Thống kê số lần hiến máu của người hiến";
            var list = reportBUS.GetDonorDonatedTimeStatistic();
            chartReport2.Series.Clear();
            chartReport2.ChartAreas[0].AxisX.Title = "Số lần hiến máu";
            chartReport2.ChartAreas[0].AxisY.Title = "Số lượng người hiến máu";


            Series Series = new Series("Số lần hiến máu")
            {
               

                ChartType = SeriesChartType.Column

            };


            foreach (var item in list)
            {
                Series.Points.AddXY(item.DonatedTime, item.DonorCount);
            }

            chartReport2.Series.Add(Series);
            chartReport2.Visible = true;
        }



        private void LoadBloodReceivedByRUStatistic()
        {
            lbTitle1.Text = "Thống kê theo lượng máu\n"+"nhận được";
            var list = reportBUS.GetBloodReceivedByRUStatistic();
            chartReport1.Series.Clear();
            chartReport1.ChartAreas[0].AxisX.Title = "Đơn vị\n" + "cung cấp";
            chartReport1.ChartAreas[0].AxisY.Title = "Số lượng";

            Series series = new Series("Lượng máu nhận")
            {
                ChartType = SeriesChartType.Column,
            };

            foreach (var item in list)
            {
                // Hiển thị tên đơn vị hoặc RU_ID
                string label = string.IsNullOrEmpty(item.RU_Name) ? item.RU_ID : item.RU_Name;
                series.Points.AddXY(label, item.Amount);
            }

            chartReport1.Series.Add(series);
            chartReport1.Visible = true;
        }




        private void LoadBloodSupplyComparisionByRUStatistics()
        {
           
                lbTitle2.Text = "Thống kê so sánh lượng máu yêu cầu\n" + "và lượng mấu đã cung cấp";
                var list = reportBUS.GetReceivingUnitBloodSupplyComparisionStatistic();
                chartReport2.Series.Clear();
                chartReport2.ChartAreas[0].AxisX.Title = "RU_ID";
                chartReport2.ChartAreas[0].AxisY.Title = "Lượng máu(ml)";

                Series series1 = new Series("RequestAmount")
                {
                    ChartType = SeriesChartType.StackedColumn

                };


                Series series2 = new Series("SupplyAmount")
                {
                    ChartType = SeriesChartType.StackedColumn
                };



                foreach (var item in list)
                {
                    series1.Points.AddXY(item.RU_ID, item.RequestAmount);
                    series2.Points.AddXY(item.RU_ID, item.SupplyAmount);
                }

                chartReport2.Series.Add(series1);
                chartReport2.Series.Add(series2);
                chartReport2.Visible = true;
          
        }

        //======================================================================



        //==========THIẾT LẬP CÁC CONTROL HIỂN THỊ TRÊN DATAGRIDVIEW============

        //Thiết lập cách lưu file excel từ datagridview
        private void ExportToExcel(DataGridView dataGridView, string filePath)
        {
            // Tạo một ứng dụng Excel mới
            Microsoft.Office.Interop.Excel.Application excel = null;
            Microsoft.Office.Interop.Excel.Workbook workbook = null;
            Microsoft.Office.Interop.Excel.Worksheet worksheet = null;

            try
            {
                // Khởi tạo Excel Application
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.DisplayAlerts = false;
                excel.Visible = false;

                // Tạo Workbook và Worksheet
                workbook = excel.Workbooks.Add(Type.Missing);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "Báo cáo";



                // Xuất header của DataGridView
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView.Columns[i].HeaderText;
                }

                // Xuất dữ liệu từ DataGridView
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        if (dataGridView.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }

                // Tự động điều chỉnh kích thước cột
                worksheet.Columns.AutoFit();

                // Lưu workbook
                workbook.SaveAs(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // Thiết lập nút ExportExcel
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files(*.xlsx)|*.xlsx|All files(*.*)|*.*",
                Title = "Chọn vị trí lưu file"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportToExcel(dgvReport, saveFileDialog.FileName);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





        //Thiết lập hàm lưu ảnh
        private void SaveChartAsImage(Chart chart)
        {
            using (SaveFileDialog save = new SaveFileDialog()
            {
                Filter = "PNG Image|*.png",
                Title = "Lưu biểu đồ dạng ảnh"

            })
            {
                if (save.ShowDialog() == DialogResult.OK)
                {
                    int chartWidth = 450;
                    int chartHeight = 250;

                    using (Bitmap chartImage = new Bitmap(chartWidth, chartHeight))
                    {
                        chart.DrawToBitmap(chartImage, new Rectangle(0, 0, chartWidth, chartHeight));
                        chartImage.Save(save.FileName,ImageFormat.Png);
                    }
                    MessageBox.Show("Lưu ảnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnPrintPic_Click(object sender, EventArgs e)
        {
            //printPic(chartReport1);


        }

        private void btnPrintChart1_Click(object sender, EventArgs e)
        {
            SaveChartAsImage(chartReport1);
        }


        private void btnPrint2_Click(object sender, EventArgs e)
        {
            SaveChartAsImage(chartReport2);
        }


        private void btnPrint3_Click(object sender, EventArgs e)
        {
            SaveChartAsImage(chartReport3);
        }




        //======================================================================




        // Load thống kê tổng trên các label
        private void LoadSum()
        {
            lbSumUser.Text = reportBUS.GetSumofUser().ToString();
            lbSumDonor.Text = reportBUS.GetSumofDonor().ToString();
            lbSumBlood.Text = reportBUS.GetSumofBlood().ToString();
            lbSumRU.Text = reportBUS.GetSumofReceivingUnit().ToString();
        }



        
        private void LoadForm()
        {
            //Load 
            LoadDistributedBlood();
            LoadBloodGroupStatistics();

           // LoadBloodRequirementStatistic();
            LoadBloodRequirementStatistic2();
            LoadDistributedBloodStatistic();
        }




        private void UC_Dashboard2_Load(object sender, EventArgs e)
        {
            LoadSum();
            LoadForm();

        }



        // Thiết lập lựa chọn trên combobox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbControl.SelectedIndex == 0)
            {
                LoadForm();
            }
            else if (cbControl.SelectedIndex == 1)
            {
                LoadAllDonorsInformation();
                LoadDonorAgeGroupStatistic();
                LoadDonorGenderGroupStatistic();
                LoadDonorDonatedTimeStatistic();
            }
            else
            {
                LoadBloodReceivedByRUStatistic();
                LoadBloodSupplyComparisionByRUStatistics();
            }

        }

        private void UC_DashBoard2_VisibleChanged(object sender, EventArgs e)
        {
            
        }
    }
}
