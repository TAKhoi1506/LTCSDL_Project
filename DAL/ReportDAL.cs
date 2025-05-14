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
                                     .Select(g => new DonorDTO
                                     {
                                         DonorID = g.Key
                                     }).Count();
            }
        }


        public int GetSumofUser()
        {
            using (var context = new MyContext())
            {
                return context.UserAccounts.GroupBy(x => x.AccountID)
                                     .Select(g => new UserAccountDTO
                                     {
                                         AccountID = g.Key
                                     }).Count();
            }
        }


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
                        join brd in context.BloodRequirementDetails on br.ID equals brd.RequirementID
                        where br.Status == "Completed" // chỉ lấy yêu cầu đã được cấp phát
                        select new DistributedBloodDTO
                        {
                            RU_ID = br.RU_ID,
                            BloodType = brd.BloodType,
                            Amount = brd.Amount,
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
        //public List<DistributedBloodDTO> GetDistributedBloodStatistics()
        //{
        //    using (var context = new MyContext())
        //    {
        //        return (from br in context.BloodRequirements
        //               join brd in context.BloodRequirementDetails on br.ID equals brd.RequirementID
        //               where br.Status == "Completed" // chỉ lấy yêu cầu đã được cấp phát
        //               select new DistributedBloodDTO
        //               { 
        //                   BloodType = brd.BloodType,
        //                   Amount = brd.Amount,

        //               }).ToList();
        //    }
        //}


        public List<DistributedBloodDTO> GetBloodInventoryStatistics()
        {
            using (var context = new MyContext())
            {
                // Tổng lượng máu đã cung cấp (chỉ đếm các yêu cầu đã hoàn thành)
                var distributed = context.BloodRequirements
                                     .Where(x => x.Status == "Completed" || x.Status == "Approved")
                                     .Join(context.BloodRequirementDetails,
                                           br => br.ID,
                                           brd => brd.RequirementID,
                                           (br, brd) => new { br, brd })
                                     .GroupBy(x => new
                                     {
                                         x.brd.BloodType,
                                     })
                                     .Select(g => new
                                     {
                                         g.Key.BloodType,
                                         TotalAmount = g.Sum(x => x.brd.Amount)
                                     }).ToList();

                // Tổng lượng máu tồn kho
                var stocked = context.BloodStocks
                                     .GroupBy(bs => bs.BloodType)
                                     .Select(g => new
                                     {
                                         BloodType = g.Key.Trim().ToUpper(),
                                         TotalAmount = g.Sum(x => x.Amount)
                                     }).ToList();

                // Tập hợp đầy đủ các nhóm máu (bao gồm cả bên stocked hoặc distributed riêng lẻ)
                var allTypes = distributed.Select(d => d.BloodType)
                                          .Union(stocked.Select(s => s.BloodType))
                                          .Distinct();

                // Gộp thông tin
                var result = allTypes.Select(bt =>
                {
                    var dist = distributed.FirstOrDefault(d => d.BloodType == bt);
                    var stock = stocked.FirstOrDefault(s => s.BloodType == bt);

                    return new DistributedBloodDTO
                    {
                        BloodType = bt,
                        Amount = dist?.TotalAmount ?? 0,
                        StockAmount = stock?.TotalAmount ?? 0
                    };
                }).ToList();

                return result;
            }
        }




        //Thống kê nhóm máu nhận được trong 1 đơn vị thời gian
        public List<BloodOverTimeDTO> GetBloodOverTimeStatistics()
        {
            using (var context = new MyContext())
            {

                var rawData = context.BloodRequirements
                                     .Where(x => x.Status == "Completed" || x.Status == "Approved")
                                     .Join(context.BloodRequirementDetails,
                                           br => br.ID,
                                           brd => brd.RequirementID,
                                           (br, brd) => new { br, brd })
                                     .GroupBy(x => new
                                     {
                                         x.brd.BloodType,
                                         x.br.RequestDate.Year,
                                         x.br.RequestDate.Month
                                     })
                                     .Select(g => new
                                     {
                                         g.Key.BloodType,
                                         g.Key.Year,
                                         g.Key.Month,
                                         TotalAmount = g.Sum(x => x.brd.Amount)
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

        //Thống kê các nhóm tuổi
        public List<DonorAgeGroupDTO> GetAgeofDonorStatistic()
        {
            using (var context = new MyContext())
            {
                int currentYear = DateTime.Now.Year;

                var donors = context.Donors.Select(d => new
                {
                    Age = currentYear - d.BirthDate.Year
                }).ToList();


                var result = donors.GroupBy(d =>
                    d.Age < 18 ? "Dưới 18" :
                    d.Age <= 30 ? "Từ 18 đến 30" :
                    d.Age <= 45 ? "Từ 31 - 45" :
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
            using (var context = new MyContext())
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
            using (var context = new MyContext())
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



        //public List<ReceivingUnitBloodSupplyComparisionDTO> BloodSupplyComparisionByRU()
        //{
        //    using (var context = new MyContext())
        //    {
        //        return context.BloodRequirements.GroupBy(x => x.RU_ID)
        //                                        .Select(g => new ReceivingUnitBloodSupplyComparisionDTO
        //                                        {
        //                                            // RU_ID = g.Key,
        //                                            //RequestAmount = g.Sum(x => x.Amount),
        //                                            // SupplyAmount = g.Where(x=>x.Status == "Completed").Sum(x=>x.Amount)
        //                                        }).ToList();
        //    }
        //}

        //Thống kê so sánh số lượng máu yêu cầu và lượng máu đã cấp phát
        public List<ReceivingUnitBloodSupplyComparisionDTO> BloodSupplyComparisionByRU()
        {
            using (var context = new MyContext())
            {
               

                return context.BloodRequirements.Join(context.BloodRequirementDetails,
                                                      br => br.ID,
                                                      brd => brd.RequirementID,
                                                      (br, brd) => new { br, brd })
                                                 .GroupBy(x => new
                                                 {
                                                     x.br.RU_ID
                                                 })
                                                 .Select(g => new ReceivingUnitBloodSupplyComparisionDTO
                                                 {
                                                     RU_ID= g.Key.RU_ID,
                                                     RequestAmount = g.Sum(x => x.brd.Amount),
                                                     SupplyAmount = g.Where(x=> x.br.Status == "Completed" || x.br.Status == "Approved").Sum(x=>x.brd.Amount)
                                                 }).ToList();
               
            }
        }






        // ========================================================
    

    }
}
