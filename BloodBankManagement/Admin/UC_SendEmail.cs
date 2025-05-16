using BloodBankManagement.Static;
using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace BloodBankManagement.Admin
{
    public partial class UC_SendEmail : UserControl
    {

        private NotificationsBUS notificationsBUS = new NotificationsBUS();
        private DonorBUS donorBUS = new DonorBUS();

        public UC_SendEmail()
        {
            InitializeComponent();
        }


        private void SetUpControl()
        {
            //Thiết lập splitContainer 

            splitContainer1.SplitterDistance = this.Width / 3;


            //Thiết lập Listview cho danh sách tin nhắn

            listViewMessage.View = View.Details;
            listViewMessage.Columns.Add("Tài khoản", 200);
            listViewMessage.Columns.Add("Tên người dùng", 100);
            listViewMessage.FullRowSelect = true;
            listViewMessage.HideSelection = false;



            //Thiết lập RichTextBox cho nội dung tin nhắn

        }


        private void UpdateNotificationListView()
        {
            listViewMessage.Items.Clear();
            var donors = donorBUS.GetAllDonors();

            foreach (var donor in donors)
            {
                ListViewItem item = new ListViewItem(donor.FullName);
                item.SubItems.Add(donor.Email);
                item.Tag= donor.DonorID;
                listViewMessage.Items.Add(item);
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



        private void UC_SendEmail_Load(object sender, EventArgs e)
        {
            Icons.SetupButtonIcon(btSend);
            Icons.SetupLeftIcon(btSend, "/Resources/send.jpg");
            Icons.SetupLeftIcon(btRefresh, "/Resources/refresh.jpg");
            Icons.SetupButtonIcon(btRefresh);
            SetUpControl();
            UpdateNotificationListView();
        }


        private string selectedObjectID = null; //Lấy objectId người được hcọn
        private string selectedEmail = null; //Lấy email người được chọn

        private void listViewMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewMessage.SelectedItems.Count > 0)
            {
                ListViewItem listViewItem = listViewMessage.SelectedItems[0];

                //Lấy email từ cột thứ 2
                selectedEmail = listViewItem.SubItems[1].Text;
                selectedObjectID = listViewItem.Tag.ToString();
                txtEmail.Text = selectedEmail;

            }
        }


        private void btSend_Click(object sender, EventArgs e)
        {
            
            string objectId = selectedObjectID;
            string title = txtTitle.Text;
            string message = txtMessage.Text;

          
            if (string.IsNullOrEmpty(selectedEmail))
            {
                MessageBox.Show("Vui lòng chọn người dùng để gửi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Vui lòng không để trống tiêu đề hoặc nội dung!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            bool isSuccess = notificationsBUS.AddNotification(objectId, title, message);

            if (isSuccess)
            {
                SendEmail(selectedEmail, title, message);
                MessageBox.Show("Đã gửi thông báo và email thành công!");

            }
            else
            {
                MessageBox.Show("Gửi thông báo thất bại!");
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
            txtTitle.Clear();
            txtMessage.Clear();
        }
    }
}
