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

        public int GetSumofUser()
        {
            return reportDAL.GetSumofUser();
        }

        public int GetSumofDonor()
        {
            return reportDAL.GetSumofDonor();
        }


        public int GetSumofReceivingUnit()
        {
            return reportDAL.GetSumofReceivingUnit();
        }


        public double GetSumofBlood()
        {
            return reportDAL.GetSumofBlood();
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


        public List<BloodOverTimeDTO> BloodOverTimeStatistics()
        {
            return reportDAL.GetBloodOverTimeStatistics();
        }


        public List<DistributedBloodDTO> GetDistributedBloodStatistics()
        {
            return reportDAL.GetBloodInventoryStatistics();
        }



        public List<DonorAgeGroupDTO> GetAgeofDonorStatistic()
        {
            return reportDAL.GetAgeofDonorStatistic();
        }


        public List<DonorGenderGroupDTO> GetGenderofDonorStatistic()
        {
            return reportDAL.donorGenderGroupStatistic();
        }


        public List<DonorDonatedTimeDTO> GetDonorDonatedTimeStatistic()
        {
            return reportDAL.donorDonatedTimeStatistic();
        }


        public List<ReceivingUnitBloodReceivedDTO> GetBloodReceivedByRUStatistic()
        {
            return reportDAL.BloodReceivedByRU();
        }



        public List<ReceivingUnitBloodSupplyComparisionDTO> GetReceivingUnitBloodSupplyComparisionStatistic()
        {
            return reportDAL.BloodSupplyComparisionByRU();
        }



        public List<StatusStatisticsDTO> GetStatusStatistics()
        {
            return reportDAL.RequestStatusStatistics();
        }
    }
}
