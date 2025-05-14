using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BloodBankManagement.Admin;
using BUS;
using BloodBankManagement.Static;

namespace BloodBankManagement
{
    public partial class FrmAdmin : Form
    {
        private System.Windows.Forms.Timer refreshTimer;
        private UserControl currentControl;

        private NotificationsBUS notificationsBUS = new NotificationsBUS();

        public FrmAdmin()
        {
            InitializeComponent();
        }
     
        private void ShowUserControl(UserControl newControl)
        {
            if (currentControl != null)
            {
                panelShow.Controls.Remove(currentControl);
                currentControl.Dispose(); // Giải phóng bộ nhớ
            }

            currentControl = newControl;
            newControl.Dock = DockStyle.Fill;
            panelShow.Controls.Add(newControl);
        }
        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Home());
            //var notis = notificationsBUS.GetUnreadCount();
            //StartTimer();
            LoadUnreadCount();
        }
        private void LoadUnreadCount()
        {
            //int unreadCount = notificationsBUS.GetUnreadCount(Static.UserSession.ObjectID);
            //lblUnreadCount.Text = unreadCount.ToString();
            //lblUnreadCount.Visible = unreadCount > 0;
        }

        private void btBloodStock_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_BloodStock());
        }

        private void btHome_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Home());
        }

        private void btEvents_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Events());
        }

        private void btDonors_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Donors());
        }

        private void btReUnits_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_ReceivingUnits());
        }

        private void btDonations_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_Donations());
        }


        private void btDashboard_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_DashBoard2());
        }

        private void LoadNotificationPanel()
        {
            //pnNotification.Controls.Clear();

            //var notifications = notificationsBUS
            //    .GetMessageById(Static.UserSession.ObjectID)
            //    .OrderByDescending(n => n.CreatedAt)
            //    .ToList();

            //int y = 10;
            //foreach (var noti in notifications)
            //{
            //    Panel itemPanel = new Panel
            //    {
            //        Size = new Size(pnNotification.Width - 20, 50),
            //        Location = new Point(10, y),
            //        BackColor = noti.IsRead ? Color.LightGray : Color.White,
            //        BorderStyle = BorderStyle.FixedSingle,
            //        Cursor = Cursors.Hand
            //    };

            //    Label lblTitle = new Label
            //    {
            //        Text = noti.Title,
            //        Font = new Font("Arial", 10, FontStyle.Bold),
            //        AutoSize = false,
            //        Size = new Size(itemPanel.Width - 10, 20),
            //        Location = new Point(5, 5)
            //    };

            //    Label lblDate = new Label
            //    {
            //        Text = noti.CreatedAt.ToString("dd/MM/yyyy HH:mm"),
            //        Font = new Font("Arial", 8),
            //        AutoSize = false,
            //        Size = new Size(itemPanel.Width - 10, 15),
            //        Location = new Point(5, 25)
            //    };

                // Gán sự kiện cho cả panel và labels
                //void Notification_Click(object sender, EventArgs e)
                //{
                //    MessageBox.Show(noti.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    if (!noti.IsRead)
                //    {
                //        notificationsBUS.MaskAsRead(noti.NotifiID);
                //        LoadUnreadCount();
                //        LoadNotificationPanel();
                //    }
                //}

                //itemPanel.Click += Notification_Click;
                //lblTitle.Click += Notification_Click;
                //lblDate.Click += Notification_Click;

                //itemPanel.Controls.Add(lblTitle);
                //itemPanel.Controls.Add(lblDate);
                //pnNotification.Controls.Add(itemPanel);
                //y += 60;
            //}
        }

        private void btNotification_Click_1(object sender, EventArgs e)
        {
            // Toggle danh sách thông báo
            pnNotification.Visible = !pnNotification.Visible;

            if (pnNotification.Visible)
            {
                pnNotification.BringToFront(); // Đưa panel ra trước các control khác
                LoadNotificationPanel();        // Load danh sách thông báo
            }
        }

        private void btRequirements_Click(object sender, EventArgs e)
        {
           ShowUserControl(new UC_BloodRequirements());
        }

        private void FrmAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            UserSession.Clear();

            this.Hide();

            // Mở lại form Login
            Login loginForm = new Login();
            loginForm.Show();
        }
    }
}

