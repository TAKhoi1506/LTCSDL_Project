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

        // trước khi băm 
        //public UserAccountDTO Login(string username, string password)
        //{
        //    var user = dal.GetUserByUsername(username);
        //    if (user != null && user.Password == password)
        //    {
        //        return user; // Đúng tài khoản và mật khẩu
        //    }
        //    return null; // Sai
        //}

        // sử dụng băm 
        public UserAccountDTO Login(string username, string password)
        {
            var account = dal.GetUserByUsername(username);

            if (account != null && BCrypt.Net.BCrypt.Verify(password, account.Password))
            {
                return new UserAccountDTO
                {
                    AccountID = account.AccountID,
                    Username = account.Username,
                    Role = account.Role,
                    ObjectID = account.ObjectID
                };
            }
            return null;
        }

        public object GetUserInfo(string role, string objectId)
        {
            switch (role)
            {
                case "Donor":
                    var donor = db.Donors.FirstOrDefault(d => d.DonorID.ToString() == objectId);
                    return donor != null ? new DonorDTO
                    {
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

        //// băm mật khẩu plain text trong db => chỉ chạy 1 lần 
        //public bool IsHashed(string password)
        //{
        //    return password.StartsWith("$2a$") || password.StartsWith("$2b$") || password.StartsWith("$2y$");
        //}

        //public void MigratePlainPasswordsToHashed()
        //{
        //    foreach (var account in db.UserAccounts.ToList())
        //    {
        //        if (!IsHashed(account.Password))
        //        {
        //            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
        //        }
        //    }
        //    db.SaveChanges();
        //}
    }
}
