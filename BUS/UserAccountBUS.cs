using DAL;
using DAL.Domain;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class UserAccountBUS
    {
        private UserAccountDAL dal = new UserAccountDAL();
        private MyContext db = new MyContext();


        public UserAccountDTO Login(string username, string password)
        {
            var user = dal.GetUserByUsername(username);
            if (user != null && user.Password == password)
            {
                return user; // Đúng tài khoản và mật khẩu
            }
            return null; // Sai
        }

        // lỗi do donorid và ruid không cùng kiểu dữ liệu => không so sánh với objectid được 
        // chưa có adminDTO 
        //public object GetUserInfo(string role, int objectId)
        //{
        //    switch (role)
        //    {
        //        case "Donor":
        //            var donor = db.Donors.FirstOrDefault(d => d.DonorID == objectId);
        //            return donor != null ? new DonorDTO { DonorID = donor.DonorID, FullName = donor.FullName } : null;
        //        case "ReceivingUnit":
        //            var ru = db.ReceivingUnits.FirstOrDefault(r => r.RU_ID == objectId);
        //            return ru != null ? new ReceivingUnitDTO { RU_ID = ru.RU_ID, UnitName = ru.UnitName } : null;
        //        case "Admin":
        //            return new AdminDTO { Username = account.Username, Role = account.Role };
        //        default:
        //            return null;
        //    }
        //}
    }
}
