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

        private void SetupButton(Bunifu.UI.WinForms.BunifuButton.BunifuButton2 button)
        {
            button.onHoverState.BorderColor = Color.FromArgb(165, 110, 110);
            button.onHoverState.FillColor = Color.FromArgb(165, 110, 110);
            button.OnPressedState.BorderColor = Color.FromArgb(139, 58, 58);
            button.OnPressedState.FillColor = Color.FromArgb(139, 58, 58);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // setup button
            btRegister.OnIdleState.BorderColor = Color.FromArgb(96,5,5);
            btRegister.OnIdleState.FillColor = Color.FromArgb(96, 5, 5);
            SetupButton(btLogin);
            btRegister.OnIdleState.BorderColor = Color.DimGray;
            btRegister.OnIdleState.FillColor = Color.FromArgb(166,110,110);
            SetupButton(btRegister);


            this.StartPosition = FormStartPosition.CenterScreen;
            btnHashPasswords.Visible = false;
            //băm plain text trong db
            btnHashPasswords.Visible = true; // ẩn nút băm mật khẩu
            userBus.MigratePlainPasswordsToHashed();
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

        private void lbForgotPassword_Click(object sender, EventArgs e)
        {
            FrmForgotPassword frm = new FrmForgotPassword();
            this.Hide();
            frm.Show(); 
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
