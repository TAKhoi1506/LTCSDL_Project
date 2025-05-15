using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using BUS;
using BloodBankManagement.Static;
using System.IO;

namespace BloodBankManagement
{
    public partial class FrmForgotPassword : Form
    {
        private NotificationsBUS notificationsBUS = new NotificationsBUS();

        public FrmForgotPassword()
        {
            InitializeComponent();
        }
        private void FrmForgotPassword_Load(object sender, EventArgs e)
        {
            
        }

        public void SendEmail(string toEmail, string title, string message)
        {
            var fromEmail = "takhoi150604@gmail.com";
            var appPassword = "zder mvsk jdkh ogks";

            //var fromEmail = "tuongvyvo2804@gmail.com";
            //var appPassword = "cfly ngio tumw frxq";


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


        private void btSend_Click(object sender, EventArgs e)
        {
            string objectId = "Admin";
            string title = "Thư từ ngân hàng máu KVN";
            string message = "Đây là thư từ ngân hàng máu KVN! Vui lòng không phản hồi sau khi nhận tin nhắn. Xin cám ơn quý khách";

            bool isSuccess = notificationsBUS.AddNotification(objectId, title, message);

            if (isSuccess)
            {
                SendEmail("tuongvyvo2804@gmail.com", title, message);
                MessageBox.Show("Đã gửi thông báo và email thành công!");
            }
            else
            {
                MessageBox.Show("Gửi thông báo thất bại!");
            }

            Login frm = new Login();
            frm.Show();
            this.Hide();
        }
    }
}
