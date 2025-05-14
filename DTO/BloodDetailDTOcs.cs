using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BloodDetailDTO
    {
        public int BloodDetailID { get; set; }
        public int BloodID { get; set; }
        public DateTime CollectionDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string Status { get; set; }
        public int? DonorID { get; set; }
    }
}
