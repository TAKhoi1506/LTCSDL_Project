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
using DTO;
using System.Net.Mail;
using System.Net;

namespace BloodBankManagement
{
    public partial class UC_BloodStock: UserControl
    {
        public UC_BloodStock()
        {
            InitializeComponent();
        }
        private BloodStockBUS bus = new BloodStockBUS();
        private BloodDetailBUS bloodDetailBUS = new BloodDetailBUS();
        private NotificationsBUS notificationsBUS = new NotificationsBUS();

        //private void btAddDonor_Click(object sender, EventArgs e)
        //{
        //    string selectedBloodType = cbBloodType.SelectedItem?.ToString();
        //    double amountToAdd = Convert.ToDouble(numAmount.Value);

        //    if (string.IsNullOrEmpty(selectedBloodType) || amountToAdd <= 0)
        //    {
        //        MessageBox.Show("Vui lòng chọn nhóm máu và nhập số lượng hợp lệ!");
        //        return;
        //    }
        //    BloodStock existingStock = bus.GetStockByType(selectedBloodType);
        //    if (existingStock != null)
        //    {
        //        // Nếu có rồi thì cộng dồn
        //        existingStock.Amount += amountToAdd;
        //        bus.UpdateStock(existingStock);
        //    }
        //    LoadStockGrid();
        //}

        private void LoadStockGrid()
        {
            dgvStock.DataSource = null;
            dgvStock.DataSource = bus.GetAllStock();
        }

        private void UC_BloodStock_Load(object sender, EventArgs e)
        {
            //cbBloodType.SelectedIndex = 1;
            LoadStockGrid();
            LoadBloodDetails();
        }

        private void LoadBloodDetails()
        {
            var list = bloodDetailBUS.GetAllBloodDetails();
            dgvBloodDetails.DataSource = list;

            dgvBloodDetails.Columns["BloodDetailID"].HeaderText = "ID";
            dgvBloodDetails.Columns["BloodID"].HeaderText = "Blood ID";
            dgvBloodDetails.Columns["Status"].HeaderText = "Status";
            dgvBloodDetails.Columns["CollectionDate"].HeaderText = "Collected";
            dgvBloodDetails.Columns["ExpiredDate"].HeaderText = "Expired";
            dgvBloodDetails.Columns["DonorID"].HeaderText = "Donor";
        }

        private void dgvStock_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try

                {
                    var row = dgvStock.Rows[e.RowIndex];
                    var updatedValue = new DTO.BloodStock
                    {
                        BloodType = row.Cells["BloodType"].Value.ToString(),
                        Amount = Convert.ToInt16(row.Cells["Amount"].Value)
                    };
                    // Lấy giá trị của ô đã thay đổi
                    string bloodType = dgvStock.Rows[e.RowIndex].Cells["BloodType"].Value.ToString();
                    double amount = Convert.ToDouble(dgvStock.Rows[e.RowIndex].Cells["Amount"].Value);
                    // Cập nhật giá trị vào cơ sở dữ liệu
                    BloodStock stock = new BloodStock
                    {
                        BloodType = bloodType,
                        Amount = amount
                    };
                    bus.UpdateStock(stock);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        public void SendEmail(string toEmail, string title, string message)
        {
            var fromEmail = "takhoi150604@gmail.com";
            var appPassword = "zder mvsk jdkh ogks";

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromEmail, appPassword),
                EnableSsl = true,
            };


            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = title,
                Body = message,
                IsBodyHtml = false
            };


            mailMessage.To.Add(toEmail);
            smtpClient.Send(mailMessage);
        }


        private void btSendEmail_Click(object sender, EventArgs e)
        {
            string objectId = "13";
            string title = "Thư từ ngân hàng máu KVN";
            string message = "Đây là thư từ ngân hàng máu KVN! Vui lòng không phản hồi sau khi nhận tin nhắn. Xin cám ơn quý khách";

            bool isSuccess = notificationsBUS.AddNotification(objectId, title, message);    

            if (isSuccess) 
            {
                SendEmail("2251012080khoi@ou.edu.vn", title, message);
                MessageBox.Show("Đã gửi thông báo và email thành công!");

            }
            else
            {
                MessageBox.Show("Gửi thông báo thất bại!");
            }
        }
    }
}
