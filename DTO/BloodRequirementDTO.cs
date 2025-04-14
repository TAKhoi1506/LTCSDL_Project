using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BloodRequirementDTO
    {
        public int ID { get; set; }
        public string RU_ID { get; set; }
        //public string BloodType { get; set; }
        //public double Amount { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime SupplyDate { get; set; }
        public string Status { get; set; } = "Pending";

        public List<BloodRequirementDetailDTO> DetailList { get; set; }

    }
}
