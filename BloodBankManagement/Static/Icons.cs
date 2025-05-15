using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankManagement.Static
{
    public class Icons
    {
        // trong frm lớn 
        public static void SetupButtonIcon(Bunifu.UI.WinForms.BunifuButton.BunifuButton2 button, string imageName)
        {
            string path = Path.Combine(Application.StartupPath, "Resources", imageName);
            if (File.Exists(path))
            {
                button.IdleIconLeftImage = Image.FromFile(path);
            }

            // Các thuộc tính muốn set
            button.IconSize = 50;
            button.IconLeftPadding = new Padding(1, 3, 3, 3);
            button.AutoSizeLeftIcon = false;
            button.Padding = new Padding(60, 0, 0, 0);
            button.onHoverState.BorderColor = Color.FromArgb(165, 110, 110);
            button.onHoverState.FillColor = Color.FromArgb(165, 110, 110);
            button.OnIdleState.BorderColor = Color.White;
            button.OnIdleState.FillColor = Color.White;
            button.OnPressedState.BorderColor = Color.FromArgb(139, 58, 58);
            button.OnPressedState.FillColor = Color.FromArgb(139, 58, 58);
        }

        // trong uc
        public static void SetupButtonIcon(Bunifu.UI.WinForms.BunifuButton.BunifuButton2 button)
        {
            // Các thuộc tính muốn set
            button.onHoverState.BorderColor = Color.FromArgb(165, 110, 110);
            button.onHoverState.FillColor = Color.FromArgb(165, 110, 110);
            button.OnIdleState.BorderColor = Color.FromArgb(255, 250, 251);
            button.OnIdleState.FillColor = Color.FromArgb(255, 250, 251);
            button.OnPressedState.BorderColor = Color.FromArgb(139, 58, 58);
            button.OnPressedState.FillColor = Color.FromArgb(139, 58, 58);
        }

        public static void SetupLeftIcon(Bunifu.UI.WinForms.BunifuButton.BunifuButton2 button, string path)
        {
            button.IdleIconLeftImage = Image.FromFile(Application.StartupPath + path);
            button.IconSize = 40;
            button.TextPadding = new Padding(50, 0, 0, 0);
            button.AutoSizeLeftIcon = false;
        }

        public static void SetUpDgv(DataGridView dgv)
        {
            // Set màu nền cho DataGridView
            dgv.BackgroundColor = Color.FromArgb(255, 250, 251);
            dgv.BorderStyle = BorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 250, 251);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(139, 58, 58);
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 250, 251);
            dgv.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(139, 58, 58);


            // Đặt màu header
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(96, 5, 5);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false; // Quan trọng để áp dụng màu tùy chỉnh

            // Đặt màu xen kẽ cho các dòng
            dgv.GridColor = Color.LightGray;

            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(165, 110, 110);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;


            // Màu khi chọn cả hàng 
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(251,208,208); // hồng nhạt
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black; // Chữ đen 

            // Hoặc cài đặt riêng cho header cột khi ô được chọn
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(251, 208, 208); // Màu header khi chọn
        }
    }
}
