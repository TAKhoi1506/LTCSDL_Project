using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserAccountDTO
    {
        public int AccountID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // Admin, Donor, ReceivingUnit
        public int? ObjectID { get; set; } // DonorID hoặc RU_ID
    }
}
