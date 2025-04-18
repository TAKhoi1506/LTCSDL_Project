using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BloodStockBUS
    {
        BloodStockDAL dal = new BloodStockDAL();

        public void AddStock(BloodStock stock)
        {
            dal.Add(stock);
        }

        public List<BloodStock> GetAllStock()
        {
            return dal.GetAllStock();
        }
        public BloodStock GetStockByType(string bloodType)
        {
            return dal.GetStockByType(bloodType);
        }

        public void UpdateStock(BloodStock stock)
        {
            dal.UpdateStock(stock);
        }
    }
}