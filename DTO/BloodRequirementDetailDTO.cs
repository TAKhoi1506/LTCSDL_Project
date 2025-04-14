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
        public string BloodType { get; set; } // A+, O-, etc.
        public double Amount { get; set; }
    }
}
