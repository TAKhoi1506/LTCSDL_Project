using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;
using DTO;

namespace DAL
{
    public class BloodStockDAL
    {
        private readonly MyContext _context;

        public BloodStockDAL()
        {
            _context = new MyContext();
        }

        // Lấy danh sách tất cả BloodStock
        public List<DTO.BloodStock> GetAllStock()
        {
            return _context.BloodStocks.Select(b => new DTO.BloodStock
            {
                BloodType = b.BloodType,
                Amount = b.Amount,
            }).ToList();
        }

        // Hàm thêm blood stock(nếu cần)
        public bool Add(DTO.BloodStock bloodStockDTO)
        {
            try
            {
                var bloodStock = new DAL.Domain.BloodStock
                {
                    BloodType = bloodStockDTO.BloodType,
                    Amount = bloodStockDTO.Amount,
                };
                _context.BloodStocks.Add(bloodStock);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public DTO.BloodStock GetStockByType(string bloodType)
        {
            using (var context = new MyContext())
            {
                var stock = context.BloodStocks.FirstOrDefault(s => s.BloodType == bloodType);
                if (stock != null)
                {
                    return new DTO.BloodStock
                    {
                        BloodType = stock.BloodType,
                        Amount = stock.Amount
                    };
                }
                return null;
            }
        }
        public void UpdateStock(DTO.BloodStock stock)
        {
            using (var context = new MyContext())
            {
                var existing = context.BloodStocks.FirstOrDefault(s => s.BloodType == stock.BloodType);
                if (existing != null)
                {
                    existing.Amount = stock.Amount;
                    context.SaveChanges();
                }
            }
        }
        public void DeleteStock(string bloodType)
        {
            using (var context = new MyContext())
            {
                var stock = context.BloodStocks.FirstOrDefault(s => s.BloodType == bloodType);
                if (stock != null)
                {
                    context.BloodStocks.Remove(stock);
                    context.SaveChanges();
                }
            }
        }
        
    }
}
