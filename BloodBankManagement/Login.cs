using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BloodBankManagement.Static;
using BUS;

namespace BloodBankManagement
{
    public partial class Login : Form
    {
        private UserAccountBUS userBus = new UserAccountBUS();
        public Login()
        {
            InitializeComponent();
            this.AcceptButton = btLogin; // khi nhấn enter sẽ thực hiện login 
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            btnHashPasswords.Visible = false;
            //băm plain text trong db
            //btnHashPasswords.Visible = true; // ẩn nút băm mật khẩu
            //userBus.MigratePlainPasswordsToHashed();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            var user = userBus.Login(username, password);

            if (user != null)
            {
                UserSession.AccountID = user.AccountID;
                UserSession.Username = user.Username;
                UserSession.Role = user.Role;
                UserSession.ObjectID = user.ObjectID;

                // Mở form tương ứng theo vai trò user
                Form formToOpen = null;

                switch (user.Role)
                {
                    case "Admin":
                        formToOpen = new FrmAdmin();
                        break;

                    case "Donor":
                        formToOpen = new FrmDonor();
                        break;

                    case "ReceivingUnit":
                        formToOpen = new FrmReceivingUnit();
                        break;

                    default:
                        // không xác định được role
                        MessageBox.Show("Invalid user role!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // dừng hàm, không mở form nào
                }
                formToOpen.Show();
                this.Hide();
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    "Invalid username or password.",
                    "Error!",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);

                if (result == DialogResult.Retry)
                {
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            }
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            RegisterDonor registerDonor = new RegisterDonor();
            this.Hide();
            registerDonor.Show();
        }


        // băm mật khẩu (plain text) trong db => SỬ DỤNG 1 LẦN 
        private void btnHashPasswords_Click(object sender, EventArgs e)
        {
            UserAccountBUS bus = new UserAccountBUS();
            bus.MigratePlainPasswordsToHashed();
        }
    }
}
