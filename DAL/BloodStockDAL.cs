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
        private readonly MyContext _myContext;
        public BloodStockDAL()
        {
            _myContext = new MyContext();
        }
        public List<BloodStockDTO> GetLowStockBloodTypes(float threshold = 5.0f)
        {
            return _myContext.BloodStocks
                .Where(bs => bs.Amount < threshold)
                .Select(bs => new BloodStockDTO
                {
                    BloodID = bs.BloodID,
                    BloodType = bs.BloodType,
                    Amount = bs.Amount,
                    // thêm các thuộc tính khác nếu có
                })
                .ToList();
        }
    }
}
