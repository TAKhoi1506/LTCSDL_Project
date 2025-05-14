using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EventDTO
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime EventDate { get; set; } 
        public string Status { get; set; } = "Upcoming";
        public int AmountOfBlood { get; set; }
    }
}
