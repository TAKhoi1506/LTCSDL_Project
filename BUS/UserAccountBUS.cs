using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class UserAccountBUS
    {
        private UserAccountDAL dal = new UserAccountDAL();

        public UserAccountDTO Login(string username, string password)
        {
            var user = dal.GetUserByUsername(username);
            if (user != null && user.Password == password)
            {
                return user; // Đúng tài khoản và mật khẩu
            }
            return null; // Sai
        }
    }

}
