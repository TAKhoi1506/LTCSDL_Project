using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Domain;
using DTO;

namespace BUS
{
    public class BloodStockBUS
    {
        BloodStockDAL dal = new BloodStockDAL();

        public void AddStock(DTO.BloodStock stock)
        {
            dal.Add(stock);
        }

        public List<DTO.BloodStock> GetAllStock()
        {
            return dal.GetAllStock();
        }
        public DTO.BloodStock GetStockByType(string bloodType)
        {
            return dal.GetStockByType(bloodType);
        }

        public void UpdateStock(DTO.BloodStock stock)
        {
            dal.UpdateStock(stock);
        }
    }
}