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


        public object GetUserInfo(string role, string objectId)
        {
            switch (role)
            {
                case "Donor":
                    var donor = db.Donors.FirstOrDefault(d => d.DonorID.ToString() == objectId);
                    return donor != null ? new DonorDTO { 
                        DonorID = donor.DonorID, 
                        FullName = donor.FullName,
                        DateOfBirth = donor.BirthDate,
                        Gender = donor.Gender,
                        Address = donor.Address,
                        PhoneNumber = donor.PhoneNumber,
                        Email = donor.Email,
                        LastDonationDate = donor.LastDonationDate
                    } : null;
                case "ReceivingUnit":
                    var ru = db.ReceivingUnits.FirstOrDefault(r => r.RU_ID == objectId);
                    return ru != null ? new ReceivingUnitDTO
                    {
                        RU_ID = ru.RU_ID,
                        UnitName = ru.UnitName,
                        Address = ru.Address,
                        ContactName = ru.ContactName,
                        PhoneNumber = ru.PhoneNumber,
                        Email = ru.Email,
                        UnitType = ru.UnitType
                    } : null;
                default:
                    return null;
            }
        }

        public UserAccountDTO GetAccountById(int accountId)
        {
            return dal.GetUserById(accountId);
        }
    }

}
