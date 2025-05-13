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

namespace BloodBankManagement
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }
        private UC_BloodStock ucBloodStock;
        private UC_Home ucHome;
        private UC_Events ucEvents;
        private UC_Donations ucDonations;
        private UC_ReceivingUnits ucReceivingUnits;
        private UC_DashBoard2 ucDashboard;
        private UC_Donors ucDonors;
        private NotificationsBUS notificationsBUS = new NotificationsBUS();
        private UserControl currentControl;
        private UC_BloodRequirements ucbloodRe;
        private void HomeLoad()
        {
            if (ucHome == null)
            {
                ucHome = new UC_Home();
                ucHome.Dock = DockStyle.Fill;
                panelShow.Controls.Add(ucHome);
            }

            ucHome.BringToFront();
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
            newControl.Left = (panelShow.Width - newControl.Width) / 2;
            newControl.Top = (panelShow.Height - newControl.Height) / 2;
            panelShow.Resize += (s, e) =>
            {
                newControl.Left = (panelShow.Width - newControl.Width) / 2;
                newControl.Top = (panelShow.Height - newControl.Height) / 2;
            };
        }
        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            Static.UserSession.ObjectID = "admin";
            HomeLoad();
            //LoadNotificationBadge();
            pnNotification.BringToFront();
            LoadUnreadCount();

        }
        private void LoadUnreadCount()
        {
            int unreadCount = notificationsBUS.GetUnreadCount(Static.UserSession.ObjectID);
            lblUnreadCount.Text = unreadCount.ToString();
            lblUnreadCount.Visible = unreadCount > 0;
        }

        private void btBloodStock_Click(object sender, EventArgs e)
        {
            if (ucBloodStock == null)
            {
                ucBloodStock = new UC_BloodStock();
                ucBloodStock.Dock = DockStyle.Fill;
                panelShow.Controls.Add(ucBloodStock);
            }

            ucBloodStock.BringToFront();
        }

        private void btHome_Click(object sender, EventArgs e)
        {
           HomeLoad();

        }

        private void btEvents_Click(object sender, EventArgs e)
        {
            if (ucEvents == null)
            {
                ucEvents = new UC_Events();
                ucEvents.Dock = DockStyle.Fill;
                panelShow.Controls.Add(ucEvents);
            }

            ucEvents.BringToFront();
        }



        private void btDonors_Click(object sender, EventArgs e)
        {
            if (ucDonors == null)
            {
                ucDonors = new UC_Donors();
                ucDonors.Dock = DockStyle.Fill;
                panelShow.Controls.Add(ucDonors);
            }

            ucDonors.BringToFront();
        }



        private void btReUnits_Click(object sender, EventArgs e)
        {
            if (ucReceivingUnits == null)
            {
                ucReceivingUnits = new UC_ReceivingUnits();
                ucReceivingUnits.Dock = DockStyle.Fill;
                panelShow.Controls.Add(ucReceivingUnits);
            }
            ucReceivingUnits.BringToFront();
        }


        private void btDonations_Click(object sender, EventArgs e)
        {

            if (ucDonations == null)
            {
                ucDonations = new UC_Donations();
                ucDonations.Dock = DockStyle.Fill;
                panelShow.Controls.Add(ucDonations);
            }

            ucDonations.BringToFront();
        }


        private void btDashboard_Click(object sender, EventArgs e)
        {
            //if (ucDashboard == null)
            //{
            //    ucDashboard = new UC_DashBoard2();
            //    ucDashboard.Dock = DockStyle.Fill;
            //    panelShow.Controls.Add(ucDashboard);
            //}

            //ucDashboard.BringToFront();
        }

            private void btDashboard2_Click(object sender, EventArgs e)
        {
            if (ucDashboard == null)
            {
                ucDashboard = new UC_DashBoard2();
                ucDashboard.Dock = DockStyle.Fill;
                panelShow.Controls.Add(ucDashboard);
            }

            ucDashboard.BringToFront();
        }

        private void panelShow_Paint(object sender, PaintEventArgs e)
        {
        }

        private void LoadNotificationPanel()
        {
            pnNotification.Controls.Clear();

            var notifications = notificationsBUS
    .GetMessageById(Static.UserSession.ObjectID)
    .OrderByDescending(n => n.CreatedAt)
    .ToList();

            int y = 10;
            foreach (var noti in notifications)
            {
                Panel itemPanel = new Panel
                {
                    Size = new Size(pnNotification.Width - 20, 50),
                    Location = new Point(10, y),
                    BackColor = noti.IsRead ? Color.LightGray : Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor = Cursors.Hand
                };

                Label lblTitle = new Label
                {
                    Text = noti.Title,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    AutoSize = false,
                    Size = new Size(itemPanel.Width - 10, 20),
                    Location = new Point(5, 5)
                };

                Label lblDate = new Label
                {
                    Text = noti.CreatedAt.ToString("dd/MM/yyyy HH:mm"),
                    Font = new Font("Arial", 8),
                    AutoSize = false,
                    Size = new Size(itemPanel.Width - 10, 15),
                    Location = new Point(5, 25)
                };

                // Gán sự kiện cho cả panel và labels
                void Notification_Click(object sender, EventArgs e)
                {
                    MessageBox.Show(noti.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (!noti.IsRead)
                    {
                        notificationsBUS.MaskAsRead(noti.NotifiID);
                        LoadUnreadCount();
                        LoadNotificationPanel();
                    }
                }

                itemPanel.Click += Notification_Click;
                lblTitle.Click += Notification_Click;
                lblDate.Click += Notification_Click;

                itemPanel.Controls.Add(lblTitle);
                itemPanel.Controls.Add(lblDate);
                pnNotification.Controls.Add(itemPanel);
                y += 60;
            }
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
            if (ucbloodRe == null)
            {
                ucbloodRe = new UC_BloodRequirements();
                ucbloodRe.Dock = DockStyle.Fill;
                panelShow.Controls.Add(ucbloodRe);
            }

            ucbloodRe.BringToFront();
        }
    }
}

