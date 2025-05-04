using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReceivedBloodDTO
    {
        public DateTime? CollectionDate { get; set; }
        public string BloodType { get; set; }
        public double Quantity { get; set; }
    }
}
