using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReceivingUnitDTO
    {
        public string RU_ID { get; set; }

        public string UnitName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UnitType { get; set; }

        // Dùng để tạo tài khoản UserAccount
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
