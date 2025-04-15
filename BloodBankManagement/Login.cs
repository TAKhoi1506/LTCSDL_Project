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

namespace BloodBankManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void lbLogin_Click(object sender, EventArgs e)
        {

        }
        DonorBUS donorBUS = new DonorBUS();



        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (donorBUS.Login(username, password))
            {
                MessageBox.Show("Login successful!");
                // Mở giao diện chính (MainForm chẳng hạn)
                this.Hide();
                new FrmDonor().Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void Login_Load_1(object sender, EventArgs e)
        {

        }
    }
}
