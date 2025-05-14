using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain; //Entity models
using DTO; //DTO classes

namespace DAL
{
    public class DonorDAL
    {
        //Thay thế SqlConnection bằng DbContext

        private readonly MyContext _myContext;

        public DonorDAL()
        {
            _myContext = new MyContext();
        }


        //Thêm đầy đủ thông tin
        public bool AddDonor(DTO.DonorDTO donorDTO)
        {
            try
            {
                var donor = new DAL.Domain.Donor
                {

                    FullName = donorDTO.FullName,
                    BirthDate = donorDTO.DateOfBirth,
                    BloodType = donorDTO.BloodType,
                    Gender = donorDTO.Gender,
                    PhoneNumber = donorDTO.PhoneNumber,
                    Email = donorDTO.Email,
                    LastDonationDate = donorDTO.LastDonationDate,
                    Address = donorDTO.Address

                };
                _myContext.Donors.Add(donor);
                return _myContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }


        //Lấy đầy đủ thông tin trừ BloodType
        public bool InsertDonor(DTO.DonorDTO donorDTO)
        {
            try
            {
                var donor = new DAL.Domain.Donor
                {

                    FullName = donorDTO.FullName,
                    BirthDate = donorDTO.DateOfBirth,
                    Gender = donorDTO.Gender,
                    PhoneNumber = donorDTO.PhoneNumber,
                    Email = donorDTO.Email,
                    LastDonationDate = donorDTO.LastDonationDate,
                    Address = donorDTO.Address

                };
                _myContext.Donors.Add(donor);
                return _myContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }



        //Lấy danh sách các donors
        public List<DTO.DonorDTO> GetAllDonors()
        {
            return _myContext.Donors.Select(d => new DTO.DonorDTO
            {
                DonorID = d.DonorID,
                FullName = d.FullName,
                DateOfBirth = d.BirthDate,
                BloodType = d.BloodType,
                Gender = d.Gender,
                PhoneNumber = d.PhoneNumber,
                Email = d.Email,
                LastDonationDate = d.LastDonationDate,
                Address = d.Address
            }).ToList();
        }


        //Kiểm tra tên đăng nhập có phải user hay không
        //public bool Login(string username, string password)
        //{
        //    return _myContext.Donors.Any(d => d.UserName == username && d.Password == password);
        //}



        //Update do admin quản lý: Có thể sửa ID và nhóm máu BloodType
        public bool UpdateDonorByAdmin(DTO.DonorDTO donorDTO)
        {
            try
            {
                //Kiểm tra id có giống với id của donor muốn sửa hay không
                var donor = _myContext.Donors.FirstOrDefault(d => d.DonorID == donorDTO.DonorID);
                if (donor == null)
                    return false;

                //donor.UserName = donorDTO.Username;
                //donor.Password = donorDTO.Password;
                donor.FullName = donorDTO.FullName;
                donor.BirthDate = donorDTO.DateOfBirth;
                donor.BloodType = donorDTO.BloodType;
                donor.Gender = donorDTO.Gender;
                donor.PhoneNumber = donorDTO.PhoneNumber;
                donor.Email = donorDTO.Email;
                donor.LastDonationDate = donorDTO.LastDonationDate;
                donor.Address = donorDTO.Address;

                return _myContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        //Xóa donor thực hiện bới admin 
        public bool DeleteDonorByAdmin(int donorID)
        {
            try
            {
                var donor = _myContext.Donors.FirstOrDefault(d => d.DonorID == donorID);
                if (donor == null) return false;

                _myContext.Donors.Remove(donor);
                return _myContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }


        //Update do donor thực hiện: Chỉ cập nhật được những thông tin có sẵn trên form
        public bool UpdateDonorByDonor(DTO.DonorDTO donorDTO)
        {
            try
            {
                //Kiểm tra id có giống với id của donor muốn sửa hay không
                var donor = _myContext.Donors.FirstOrDefault(d => d.DonorID == donorDTO.DonorID);
                if (donor == null)
                    return false;

                //donor.UserName = donorDTO.Username;
                //donor.Password = donorDTO.Password;
                donor.FullName = donorDTO.FullName;
                donor.BirthDate = donorDTO.DateOfBirth;
                donor.BloodType = donorDTO.BloodType;
                donor.Gender = donorDTO.Gender;
                donor.PhoneNumber = donorDTO.PhoneNumber;
                donor.Email = donorDTO.Email;
                donor.LastDonationDate = donorDTO.LastDonationDate;
                donor.Address = donorDTO.Address;

                var userAccount = _myContext.UserAccounts.FirstOrDefault(u => u.ObjectID == donorDTO.DonorID.ToString() && u.Role == "Donor");

                var exists = _myContext.UserAccounts.Any(u => u.Username == donorDTO.Username && u.AccountID != userAccount.AccountID);
                if (exists)
                    throw new Exception("Username already exists.");


                if (userAccount != null)
                {
                    userAccount.Username = donorDTO.Username;
                    userAccount.Password = donorDTO.Password;
                }

                return _myContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public string GetDonorIdByUsername(string username)
        {
            using (var context = new MyContext())
            {
                var donor = context.UserAccounts.FirstOrDefault(d => d.Username == username);
                return donor.ObjectID;
            }
        }
    }
}
