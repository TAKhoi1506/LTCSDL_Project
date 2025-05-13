using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DistributedBloodDTO
    {
        public string RU_ID { get; set; }
        public string BloodType { get; set; }
        public double Amount { get; set; }
        public DateTime SupplyDate { get; set; }

        public double StockAmount { get; set; }
    }
}
