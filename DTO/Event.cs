using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Event
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int AmountOfBlood { get; set; }
        public string Status { get; set; }
        public DateTime EventDate { get; set; }
    }
}

