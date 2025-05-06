using DAL.Domain;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserAccountDAL
    {
        private readonly MyContext db = new MyContext();

        public UserAccountDTO GetUserByUsername(string username)
        {
            var user = db.UserAccounts.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                return new UserAccountDTO
                {
                    AccountID = user.AccountID,
                    Username = user.Username,
                    Password = user.Password,
                    Role = user.Role,
                    ObjectID = user.ObjectID
                };
            }
            return null;
        }

        //Hình như phải bổ sung gì đó dô chỗ này ròi
        public UserAccountDTO GetUserById(int accountId)
        {
            var user = db.UserAccounts.FirstOrDefault(u => u.AccountID == accountId);
            if (user != null)
            {
                return new UserAccountDTO
                {
                    AccountID = user.AccountID,
                    Username = user.Username,
                    Password = user.Password,
                    Role = user.Role,
                    ObjectID = user.ObjectID
                };
            }
            return null;
        }
    }
}
