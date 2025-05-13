using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BloodOverTimeDTO
    {
        public string BloodType {  get; set; }
        public string PeriodTime { get; set;}

        public double TotalAmount { get; set;}
    }
}
