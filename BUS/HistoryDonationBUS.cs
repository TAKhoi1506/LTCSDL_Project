using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace BUS
{
    public class HistoryDonationBUS
    {

        private HistoryDonationDAL History = new HistoryDonationDAL();

        //Lấy danh sách lịch sử hiến máu
        public List<HistoryDonation> GetHistoryDonations()
        {
            return History.GetAllHistoryDonations();
        }
    }
}
