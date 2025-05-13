using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;
using DTO;

namespace DAL
{
    public class ReportDAL
    {
        // 1. Lấy tổng số lượng máu đã nhận theo ngày
        public List<ReceivedBloodDTO> GetReceivedBloodByDate()
        {
            using (var context = new MyContext())
            {
                return (from bd in context.BloodDetails
                        join bs in context.BloodStocks on bd.BloodID equals bs.BloodID
                        select new ReceivedBloodDTO
                        {
                            CollectionDate = bd.CollectionDate,
                            BloodType = bs.BloodType,
                            Quantity = bs.Amount
                        }).ToList();
            }
        }

        // 2. Lấy số lượng máu đã cấp phát
        //public List<DistributedBloodDTO> GetDistributedBlood()
        //{
        //    using (var context = new MyContext())
        //    {
        //        return (from br in context.BloodRequirements
        //                join bs in context.BloodStocks on br.BloodType equals bs.BloodType
        //                where br.Status == "Completed" // chỉ lấy yêu cầu đã được cấp phát
        //                select new DistributedBloodDTO
        //                {
        //                    RU_ID = br.RU_ID,
        //                    BloodType = br.BloodType,
        //                    Amount = br.Amount,
        //                    SupplyDate = br.SupplyDate
        //                }).ToList();
        //    }
        //}

        // 3. Thống kê nhóm máu
        public List<BloodGroupStatisticsDTO> GetBloodGroupStatistics()
        {
            using (var context = new MyContext())
            {
                return context.BloodStocks
                              .GroupBy(x => x.BloodType)
                              .Select(g => new BloodGroupStatisticsDTO
                              {
                                  BloodType = g.Key,
                                  TotalAmount = g.Sum(x => x.Amount)
                              }).ToList();
            }
        }
    }

}
