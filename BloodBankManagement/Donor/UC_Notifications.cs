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

namespace BloodBankManagement.Donor
{
    public partial class UC_Notifications : UserControl
    {
        private NotificationsBUS notificationsBUS = new NotificationsBUS();
        private List<Notifications> notificationsList = new List<Notifications>();

        public UC_Notifications()
        {
            InitializeComponent();
        }

        private void UC_Notifications_Load(object sender, EventArgs e)
        {

        }


        //Thiết lập control
        private void SetUpControl()
        {
            //Thiết lập splitContainer 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.SplitterDistance = this.Width / 3;


            //Thiết lập Listview cho danh sách tin nhắn
            listViewMessage.Dock = DockStyle.Fill;
            listViewMessage.View = View.Details;
            listViewMessage.Columns.Add("Tiêu đề", 200);
            listViewMessage.Columns.Add("Ngày", 100);
            listViewMessage.FullRowSelect = true;
            listViewMessage.HideSelection = false;



            //Thiết lập RichTextBox cho nội dung tin nhắn
            MessageContent.Dock = DockStyle.Fill;
            MessageContent.ReadOnly = true;
            


            
        }




        //Tải danh sách thông báo từ database
        public void LoadNotifications()
        {
            notificationsList = notificationsBUS.GetNotificationsList();   
            //Cập nhật danh sách
            UpdateNotificationListView();
        }


        //Cập nhật giao diện ListView
        private void UpdateNotificationListView()
        {
            listViewMessage.Items.Clear();

            foreach(var notification in notificationsList) 
            {
                ListViewItem item = new ListViewItem(notification.Title);
                item.SubItems.Add(notification.CreatedAt.ToString("dd/MM/yyyy HH:mm"));


                // Lưu ID của thông báo vào Tag dễ dàng truy xuất sau này
                item.Tag = notification.NotifiID;


                //Hiển thị thông báo chưa đọc với font in đậm
                if(!notification.IsRead)
                {
                    item.Font = new Font(listViewMessage.Font, FontStyle.Bold);
                }

                listViewMessage.Items.Add(item);
            }
        }



        // Xử lý sự kiện khi người dùng chọn một thông báo
        private void ListViewMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listViewMessage.SelectedItems.Count > 0) 
            {
                ListViewItem selectedItem = listViewMessage.SelectedItems[0];
                int notificationId = (int)selectedItem.Tag;


                //Lấy nội dung đầy đủ của thông báo



                //Đánh dấu thông báo đã đọc
                notificationsBUS.MaskAsRead(notificationId);


                //Cập nhật trạng thái hiển thị (bỏ in đậm cho thông báo)
                selectedItem.Font = new Font(listViewMessage.Font, FontStyle.Regular);


                //Cập nhật trạng thái trong danh sách cục bộ
                var notification = notificationsList.
            }
        }
    }
}
