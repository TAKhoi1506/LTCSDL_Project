using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Domain;
using DTO;

namespace DAL
{
    public class BloodStockDAL 
    {
        // Khai báo context dùng chung cho toàn bộ lớp
        private readonly MyContext _context;

        public BloodStockDAL()
        {
            _context = new MyContext();
        }

        // Lấy danh sách tất cả BloodStock dưới dạng DTO
        public List<DTO.BloodStock> GetAllStock()
        {
            return _context.BloodStocks
                .Select(b => new DTO.BloodStock
                {
                    BloodID = b.BloodID,
                    BloodType = b.BloodType,
                    Amount = b.Amount,
                })
                .ToList();
        }

        // Thêm một bản ghi mới vào kho máu
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

        // Lấy stock theo nhóm máu
        public DTO.BloodStock GetStockByType(string bloodType)
        {
            var stock = _context.BloodStocks.FirstOrDefault(s => s.BloodType == bloodType);
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

        // Cập nhật số lượng trong kho cho nhóm máu
        public bool UpdateStock(DTO.BloodStock stock)
        {
            try
            {
                var existing = _context.BloodStocks.FirstOrDefault(s => s.BloodType == stock.BloodType);
                if (existing != null)
                {
                    existing.Amount = stock.Amount;
                    _context.SaveChanges();
                    return true;
                }
                return false; // Không tìm thấy stock để update
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        // Xóa bản ghi kho máu theo nhóm máu
        public bool DeleteStock(string bloodType)
        {
            try
            {
                var stock = _context.BloodStocks.FirstOrDefault(s => s.BloodType == bloodType);
                if (stock != null)
                {
                    _context.BloodStocks.Remove(stock);
                    _context.SaveChanges();
                    return true;
                }
                return false; // Không tìm thấy stock để xóa
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
