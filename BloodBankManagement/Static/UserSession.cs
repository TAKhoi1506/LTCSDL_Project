using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Static
{
    public static class UserSession
    {
        public static int AccountID { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; }
        public static string ObjectID { get; set; }

        public static void Clear()
        {
            AccountID = 0;
            Username = null;
            Role = null;
            ObjectID = null;
        }
    }
}