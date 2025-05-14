using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace BloodBankManagement
{
    public partial class UC_RegisterforBloodDonation : UserControl
    {
        private EventBUS eventBUS = new EventBUS();
        public UC_RegisterforBloodDonation()
        {
            InitializeComponent();
        }


        //Lấy danh sách các event
        private void LoadEventList()
        {
            var events = eventBUS.GetAllEvents();
            listEvents.DataSource = events;
            listEvents.DisplayMember = "EventName";
            listEvents.ValueMember = "EventID";
        }

        private void UC_RegisterforBloodDonation_Load(object sender, EventArgs e)
        {
            LoadEventList();
        }
    }
}
