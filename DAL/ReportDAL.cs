using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL.Domain;
using DTO;

namespace DAL
{
    public class ReportDAL
    {

        // ============== HIỂN THỊ TỔNG SỐ LƯỢNG  =======================
        public int GetSumofDonor()
        {
            using (var context = new MyContext()) 
            {
                return context.Donors.GroupBy(x => x.DonorID)
                                     .Select(g => new DTO.Donor
                                     {
                                         DonorID = g.Key
                                     }).Count();
            }
        }


        //public int GetSumofUser()
        //{
        //    using(var context = new MyContext())
        //    {
        //        return context.Donors.GroupBy(x => x.DonorID)
        //                             .Select(g => new DTO.Donor
        //                             {
        //                                 DonorID = g.Key
        //                             }).Count();
        //    }
        //}


        public int GetSumofReceivingUnit()
        {
            using (var context = new MyContext()) 
            {
                return context.ReceivingUnits.GroupBy(x => x.RU_ID)
                                             .Select(g => new ReceivingUnitDTO
                                             {
                                                 RU_ID = g.Key
                                             }).Count();
            }
        }



        public double GetSumofBlood()
        {
            using (var context = new MyContext())
            {
                return context.BloodStocks.Sum(bs => bs.Amount);
            }
        }


        // ==============================================================



        // =============== THỐNG KÊ THEO NHÓM MÁU ========================
        //Lấy tổng số lượng máu đã nhận theo ngày
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

        //Lấy số lượng máu đã cấp phát
        public List<DistributedBloodDTO> GetDistributedBlood()
        {
            using (var context = new MyContext())
            {
                return (from br in context.BloodRequirements
                        join bs in context.BloodStocks on br.BloodType equals bs.BloodType
                        where br.Status == "Completed" // chỉ lấy yêu cầu đã được cấp phát
                        select new DistributedBloodDTO
                        {
                            RU_ID = br.RU_ID,
                            BloodType = br.BloodType,
                            Amount = br.Amount,
                            SupplyDate = br.SupplyDate
                        }).ToList();
            }
        }


        //Thống kê nhóm máu
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



        //Thống kê số lượng máu phân phối
        public List<DistributedBloodDTO> GetDistributedBloodStatistics()
        {
            using (var context = new MyContext())
            {
                var distributed = context.BloodRequirements
                                         .Where(x => x.Status =="Completed")
                                         .GroupBy(br => br.BloodType)
                                         .Select(g => new
                                         {
                                            BloodType = g.Key,
                                            TotalAmount = g.Sum(x => x.Amount)
                                         }).ToList();

                var stocked = context.BloodStocks
                                     .GroupBy(br => br.BloodType)
                                     .Select(g => new
                                     {
                                         BloodType = g.Key,
                                         TotalAmount = g.Sum(x => x.Amount)
                                     }).ToList();

                var result = from d in distributed
                             join s in stocked
                             on d.BloodType equals s.BloodType
                             select new DistributedBloodDTO
                             {
                                 BloodType = d.BloodType,
                                 Amount = d.TotalAmount,
                                 StockAmount = s?.TotalAmount?? 0 //để Stock amount có thể có giá trị là 0
                             };
                return result.ToList();
            }
        }



        //Thống kê nhóm máu nhận được trong 1 đơn vị thời gian
        public List<BloodOverTimeDTO> GetBloodOverTimeStatistics() 
        {
            using (var context = new MyContext())
            {

                var rawData = context.BloodRequirements
                                     .Where(x => x.Status == "Completed")
                                     .GroupBy(x => new {
                                         x.BloodType,
                                         x.RequestDate.Year,
                                         x.RequestDate.Month
                                     })
                                     .Select(g => new
                                     {
                                         g.Key.BloodType,
                                         g.Key.Year,
                                         g.Key.Month,
                                         TotalAmount = g.Sum(x => x.Amount)
                                     }).ToList(); 

                return rawData.Select(x => new BloodOverTimeDTO
                {
                    BloodType = x.BloodType,
                    PeriodTime = $"{x.Year}-{x.Month:D2}", 
                    TotalAmount = x.TotalAmount
                }).ToList();
            }
        }



        // ========================================================



        // ================THỐNG KÊ THEO NGƯỜI HIẾN  ==============
        
        // Thống kê các nhóm tuổi
        public List<DonorAgeGroupDTO> GetAgeofDonorStatistic()
        {
            using ( var context = new MyContext()) 
            {
                int currentYear = DateTime.Now.Year;

                var donors = context.Donors.Select(d => new
                {
                    Age = currentYear - d.BirthDate.Year
                }).ToList();


                var result = donors.GroupBy(d =>
                    d.Age < 18 ? "Dưới 18" :
                    d.Age <= 30 ? "Từ 18 đến 30" :
                    d.Age <= 45 ? "Từ 31 - 45":
                    "Trên 45"
                )
                .Select(g => new DonorAgeGroupDTO
                { 
                    AgeGroup = g.Key,
                    Count = g.Count()
                }).ToList();

                return result;
            }
        }



        // Thống kê giới tính của người hiến

        public List<DonorGenderGroupDTO> donorGenderGroupStatistic()
        {
            using ( var context = new MyContext()) 
            {
                return context.Donors.GroupBy(d => d.Gender)
                                     .Select(g => new DonorGenderGroupDTO
                                     {
                                        Gender = g.Key,
                                        Count = g.Count()
                                     }).ToList();
            }
        }






        public List<DonorDonatedTimeDTO> donorDonatedTimeStatistic() 
        {
            using (var context = new MyContext()) 
            {
                //Lấy số lần hiến máu của mỗi người
                var donateFrequencies = context.HistoryDonations
                                       .GroupBy(x => x.DonorID)
                                       .Select(d => d.Count())
                                       .ToList();


                var result = donateFrequencies.GroupBy(count => count)
                                              .Select(d => new DonorDonatedTimeDTO
                                              {
                                                  DonatedTime = d.Key,
                                                  DonorCount = d.Count()
                                              })
                                              .ToList();

                return result;




            }
        }







        // ========================================================






        // ================THỐNG KÊ THEO ĐƠN VỊ CUNG CẤP  =========

        // Thống kê số lượng máu nhận được của mỗi đơn vị cung cấp
        
        public List<ReceivingUnitBloodReceivedDTO> BloodReceivedByRU()
        {
            using ( var context = new MyContext()) 
            {
                var data = from r in context.BloodRequirements
                           join ru in context.ReceivingUnits on r.RU_ID equals ru.RU_ID
                           join ru_dt in context.BloodRequirementDetails on r.ID equals ru_dt.RequirementID
                           where r.Status == "Completed"
                           select new ReceivingUnitBloodReceivedDTO
                           {
                               RU_ID = ru.RU_ID,
                               Amount = ru_dt.Amount
                           };

                return data.ToList();     
            }
        }



       // Thống kê so sánh số lượng máu yêu cầu và lượng máu đã cấp phát
       public List<ReceivingUnitBloodSupplyComparisionDTO> BloodSupplyComparisionByRU()
        {
            using (var context = new MyContext())
            {
                return context.BloodRequirements.GroupBy(x => x.RU_ID)
                                                .Select(g => new ReceivingUnitBloodSupplyComparisionDTO 
                                                {
                                                    RU_ID = g.Key,
                                                    RequestAmount = g.Sum(x => x.Amount),
                                                    SupplyAmount = g.Where(x=>x.Status == "Completed").Sum(x=>x.Amount)
                                                }).ToList();
            }    
        }






        // ========================================================
    }

}
