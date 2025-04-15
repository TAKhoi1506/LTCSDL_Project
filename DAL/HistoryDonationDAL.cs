using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;
using DTO;

namespace DAL
{
    public class HistoryDonationDAL
    {
        //khởi tạo Mycontext
        private readonly MyContext _myContext;

        public HistoryDonationDAL()
        {
            _myContext = new MyContext();
        }

        
        //Lấy danh sách các lịch sử hiển máu
        public List<DTO.HistoryDonation> GetAllHistoryDonations()
        {
            return _myContext.HistoryDonations.Select(d => new DTO.HistoryDonation
            {
                HisDonaID = d.HisDonaID,
                DonorID = d.DonorID,
                EventID = d.EventID,
                DonationDate = d.DonationDate,
                Weight = d.weight,
                BloodPressure = d.BloodPressure,
                Amount = d.Amount,
                HealthStatus = d.HealthStatus,

            }).ToList();
        }

    }
}
