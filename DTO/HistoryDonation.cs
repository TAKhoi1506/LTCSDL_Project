using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HistoryDonation
    {
        public int HisDonaID { get; set; }  

        public int DonorID { get; set; }

        public int? EventID { get; set; }    

        public DateTime DonationDate {  get; set; } 
    
        public double Weight { get; set; }

        public string BloodPressure { get; set; }

        public double? Amount {  get; set; }

        public string HealthStatus {  get; set; }


    
    }
}
