using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BloodRequirementDetailDTO
    {
        // Bảng Blood requirement detail 
        public int DetailID { get; set; }
        public int RequirementID { get; set; }
        public string BloodType { get; set; }
        public double Amount { get; set; }
    }
}
