using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NotificationsDTO
    {
        public int NotifiID { get; set; }

        public string ObjectID { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsRead { get; set; }


    }
}
