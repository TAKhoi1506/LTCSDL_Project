using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BloodRequirementDTO
    {
        public int RU_ID { get; set; }

        public string RU_Name { get; set; }
        public string BloodType { get; set; }

        public double Amount { get; set; }

        public DateTime SupplyDate { get; set; }

        public string Status { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }
    }
}
