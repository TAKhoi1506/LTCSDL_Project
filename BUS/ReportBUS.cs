using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class ReportBUS
    {
        private readonly ReportDAL reportDAL;

        public ReportBUS()
        {
            reportDAL = new ReportDAL();
        }


        public List<ReceivedBloodDTO> GetReceivedBloodByDate()
        {
            return reportDAL.GetReceivedBloodByDate();
        }

        public List<DistributedBloodDTO> GetDistributedBlood()
        {
            return reportDAL.GetDistributedBlood();
        }

        public List<BloodGroupStatisticsDTO> GetBloodGroupStatistics()
        {
            return reportDAL.GetBloodGroupStatistics();
        }
    }
}
