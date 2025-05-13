using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BloodSupplyDetailDTO
    {
        public int SupplyID { get; set; }
        public int RequirementDetailID { get; set; }
        public int BloodDetailID { get; set; }
        public float Amount { get; set; }
    }
}
