using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Domain;
using DTO;


namespace BUS
{
    public class DonorBUS
    {
        private DonorDAL donorDAL = new DonorDAL();

        private MyContext db = new MyContext();

        public bool AddDonor(DonorDTO donor)
        {   
            return donorDAL.AddDonor(donor);
        }


        public List<DonorDTO> GetAllDonors()
        {
            return donorDAL.GetAllDonors();
        }

        public bool RegisterDonor(DonorDTO donorDto, string username, string password)
        {
            try
            {
                if (db.UserAccounts.Any(u => u.Username == username))
                    return false;

                // Tạo Donor từ DTO
                var donor = new Donor
                {
                    FullName = donorDto.FullName,
                    BloodType = donorDto.BloodType,
                    BirthDate = donorDto.DateOfBirth,
                    PhoneNumber = donorDto.PhoneNumber,
                    Address = donorDto.Address,
                    LastDonationDate = donorDto.LastDonationDate,
                    Gender = donorDto.Gender,
                    Email = donorDto.Email
                };

                db.Donors.Add(donor);
                db.SaveChanges();

                var account = new UserAccount
                {
                    Username = username,
                    Password = password, // nhận password đã băm từ form
                    Role = "Donor",
                    ObjectID = donor.DonorID.ToString()
                };

                db.UserAccounts.Add(account);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        //public bool Login(string username, string password)
        //{
        //    return donorDAL.Login(username, password);
        //}


        //Update bởi admin
        public bool UpdateByAdmin(DonorDTO donor)
        {
            if (donor == null ||  donor.DonorID <= 0)
            {
                return false;
            }
            return donorDAL.UpdateDonorByAdmin(donor);
        }

        //Update bởi donors
        public bool UpdateByDonor(DonorDTO donor)
        {
            if (donor == null )
            {
                return false;
            }
            return donorDAL.UpdateDonorByDonor(donor);
        }

        public string GetDonorIdByUsername(string username)
        {
            return donorDAL.GetDonorIdByUsername(username);
        }


        public bool DeleteDonorByAdmin(int donorID)
        {
            return donorDAL.DeleteDonorByAdmin(donorID);
        }


    }
}
