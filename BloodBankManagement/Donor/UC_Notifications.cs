﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BloodBankManagement.Static;
using BUS;
using DTO;

namespace BloodBankManagement.Donor
{
    public partial class UC_Notifications : UserControl
    {
        private NotificationsBUS notificationsBUS = new NotificationsBUS();
        private List<NotificationsDTO> notificationsList = new List<NotificationsDTO>();

        public UC_Notifications()
        {
            InitializeComponent();

        }

        private void UC_Notifications_Load(object sender, EventArgs e)
        {
            Icons.SetupLeftIcon(btRefresh, "/Resources/refresh.jpg");   
            Icons.SetupButtonIcon(btRefresh);
            SetUpControl();
            LoadNotifications();
        }


        //Thiết lập control
        private void SetUpControl()
        {
            //Thiết lập splitContainer 

            splitContainer1.SplitterDistance = this.Width / 3;


            //Thiết lập Listview cho danh sách tin nhắn

            listViewMessage.View = View.Details;
            listViewMessage.Columns.Add("Tiêu đề", 200);
            listViewMessage.Columns.Add("Ngày", 100);
            listViewMessage.FullRowSelect = true;
            listViewMessage.HideSelection = false;



            //Thiết lập RichTextBox cho nội dung tin nhắn

            MessageContent.ReadOnly = true;

        }




        //Tải danh sách thông báo từ database
        public void LoadNotifications()
        {
            //Cập nhật danh sách
            UpdateNotificationListView();
        }


        //Cập nhật giao diện ListView
        private void UpdateNotificationListView()
        {
            listViewMessage.Items.Clear();
            var notifications = notificationsBUS.GetNotificationsList(Static.UserSession.ObjectID);

            foreach (var notification in notifications)
            {
                ListViewItem item = new ListViewItem(notification.Title);
                item.SubItems.Add(notification.CreatedAt.ToString("dd/MM/yyyy HH:mm"));


                // Lưu ID của thông báo vào Tag dễ dàng truy xuất sau này
                item.Tag = notification.NotifiID;



                //Hiển thị thông báo chưa đọc với font in đậm
                if (!notification.IsRead)
                {
                    item.Font = new Font(listViewMessage.Font, FontStyle.Bold);
                }

                listViewMessage.Items.Add(item);
            }
        }



        // Xử lý sự kiện khi người dùng chọn một thông báo
        private void ListViewMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewMessage.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewMessage.SelectedItems[0];

                string notifiID = selectedItem.Tag.ToString();

                //Lấy nội dung đầy đủ của thông báo
                DisplayNotificationContent(int.Parse(notifiID));


                //Đánh dấu thông báo đã đọc
                notificationsBUS.MaskAsRead(int.Parse(notifiID));


                //Cập nhật trạng thái hiển thị (bỏ in đậm cho thông báo)
                selectedItem.Font = new Font(listViewMessage.Font, FontStyle.Regular);


                //Cập nhật trạng thái trong danh sách cục bộ
                var notification = notificationsList.Find(n => n.NotifiID == int.Parse(notifiID));
                if (notification != null)
                {
                    notification.IsRead = true;
                }

            }
        }



        //Hiển thị nội dung thông báo
        private void DisplayNotificationContent(int notifiID)
        {
            // Lấy danh sách thông báo từ database
            var notification = notificationsBUS.GetNotifications(notifiID);

            if (notification != null)
            {
                // Lấy thông báo đầu tiên (hoặc bạn có thể lấy thông báo khác theo ý muốn)

                MessageContent.Clear();

                // Định dạng tiêu đề thông báo (có thể tùy chỉnh)
                MessageContent.SelectionFont = new Font(MessageContent.Font.FontFamily, 12, FontStyle.Bold);
                MessageContent.AppendText(notification.Title + "\n");

                // Thêm ngày tạo thông báo (nếu cần)
                MessageContent.SelectionFont = new Font(MessageContent.Font.FontFamily, 9, FontStyle.Italic);
                MessageContent.AppendText(notification.CreatedAt.ToString("dd/MM/yyyy HH:mm") + "\n\n");

                // Thêm nội dung thông báo
                MessageContent.SelectionFont = new Font(MessageContent.Font.FontFamily, 10, FontStyle.Regular);
                MessageContent.AppendText(notification.Message);

            }
            else
            {
                MessageContent.Clear();
                MessageContent.AppendText("Không có thông báo nào để hiển thị.");
            }
        }




        public void RefreshNotifications()
        {
            LoadNotifications();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            RefreshNotifications();
            MessageContent.Clear();
        }
    }
}
