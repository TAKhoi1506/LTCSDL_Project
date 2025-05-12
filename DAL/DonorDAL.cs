using System;
using System.Collections.Generic;
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
        public bool AddDonor(DonorDTO donorDTO)
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


        //Lấy đầy đủ thông tin
        public bool InsertDonor(DonorDTO donorDTO)
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



        //Lấy danh sách các donors
        public List<DonorDTO> GetAllDonors()
        {
            return _myContext.Donors.Select(d => new DonorDTO
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
      

        //Update do admin quản lý: Có thể sửa ID và nhóm máu BloodType
        public bool UpdateDonorByAdmin(DonorDTO donorDTO)
        {
            try
            {
                //Kiểm tra id có giống với id của donor muốn sửa hay không
                var donor = _myContext.Donors.FirstOrDefault(d => d.DonorID == donorDTO.DonorID);
                if (donor == null)
                    return false;

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
        public bool UpdateDonorByDonor(DonorDTO donorDTO)
        {
            try
            {
                //Kiểm tra id có giống với id của donor muốn sửa hay không
                var donor = _myContext.Donors.FirstOrDefault(d => d.DonorID == donorDTO.DonorID);
                if (donor == null)
                    return false;

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
    }
}
