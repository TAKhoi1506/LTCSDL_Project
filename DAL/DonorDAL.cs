using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain; // Entity models - các lớp đại diện cho bảng trong CSDL
using DTO; // Các lớp Data Transfer Object dùng để trao đổi dữ liệu

namespace DAL
{
    public class DonorDAL
    {
        // Thay thế SqlConnection bằng DbContext của Entity Framework để thao tác với DB
        private readonly MyContext _myContext;

        // Constructor khởi tạo DbContext để sử dụng trong các phương thức
        public DonorDAL()
        {
            _myContext = new MyContext();
        }

        public DonorDTO GetDonorByID(string donorID)
        {
            var donor = _myContext.Donors.FirstOrDefault(d => d.DonorID.ToString() == donorID);

            if (donor == null)
                return null;

            return new DonorDTO
            {
                DonorID = donor.DonorID,
                FullName = donor.FullName,
                Gender = donor.Gender,
                BloodType = donor.BloodType,
                DateOfBirth = donor.BirthDate,
                PhoneNumber = donor.PhoneNumber,
                Email = donor.Email,
                LastDonationDate = donor.LastDonationDate,
                Address = donor.Address
            };
        }

        // Thêm mới một donor với đầy đủ thông tin từ DTO truyền vào
        public bool AddDonor(DTO.DonorDTO donorDTO)
        {
            try
            {
                // Tạo một đối tượng Donor entity từ dữ liệu DTO
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
                // Thêm đối tượng mới vào DbSet Donors của DbContext
                _myContext.Donors.Add(donor);
                // Lưu thay đổi vào database, trả về true nếu thành công (số bản ghi thay đổi > 0)
                return _myContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                // Nếu có lỗi xảy ra, in lỗi ra console và trả về false
                Console.WriteLine(ex);
                return false;
            }
        }

        // Thêm donor mới nhưng không bao gồm trường BloodType (ví dụ trường hợp nhóm máu chưa rõ)
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
                    // BloodType không được gán
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

        // Lấy danh sách tất cả donors dưới dạng List<DonorDTO>
        public List<DTO.DonorDTO> GetAllDonors()
        {
            // Truy vấn tất cả donor từ DbContext rồi chuyển đổi từ entity sang DTO để trả về
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

        // Cập nhật thông tin donor do admin quản lý (có thể sửa BloodType và ID)
        public bool UpdateDonorByAdmin(DTO.DonorDTO donorDTO)
        {
            try
            {
                // Tìm donor theo ID
                var donor = _myContext.Donors.FirstOrDefault(d => d.DonorID == donorDTO.DonorID);
                if (donor == null)
                    return false; // Không tìm thấy donor thì trả về false

                // Cập nhật các thuộc tính từ DTO
                donor.FullName = donorDTO.FullName;
                donor.BirthDate = donorDTO.DateOfBirth;
                donor.BloodType = donorDTO.BloodType;
                donor.Gender = donorDTO.Gender;
                donor.PhoneNumber = donorDTO.PhoneNumber;
                donor.Email = donorDTO.Email;
                donor.LastDonationDate = donorDTO.LastDonationDate;
                donor.Address = donorDTO.Address;

                // Lưu thay đổi vào DB
                return _myContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        // Xóa donor bởi admin theo donorID
        public bool DeleteDonorByAdmin(int donorID)
        {
            try
            {
                // Tìm donor theo ID
                var donor = _myContext.Donors.FirstOrDefault(d => d.DonorID == donorID);
                if (donor == null) return false;

                // Xóa donor khỏi DbSet
                _myContext.Donors.Remove(donor);
                // Lưu thay đổi vào DB
                return _myContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        // Cập nhật thông tin do chính donor thực hiện, chỉ cập nhật các trường có trên form
        public bool UpdateDonorByDonor(DTO.DonorDTO donorDTO)
        {
            try
            {
                // Tìm donor theo ID
                var donor = _myContext.Donors.FirstOrDefault(d => d.DonorID == donorDTO.DonorID);
                if (donor == null)
                    return false;

                // Cập nhật các thuộc tính donor
                donor.FullName = donorDTO.FullName;
                donor.BirthDate = donorDTO.DateOfBirth;
                donor.BloodType = donorDTO.BloodType;
                donor.Gender = donorDTO.Gender;
                donor.PhoneNumber = donorDTO.PhoneNumber;
                donor.Email = donorDTO.Email;
                donor.LastDonationDate = donorDTO.LastDonationDate;
                donor.Address = donorDTO.Address;



                // Tìm tài khoản người dùng liên quan trong bảng UserAccounts (theo ObjectID là donorID)
                var userAccount = _myContext.UserAccounts.FirstOrDefault(u => u.ObjectID == donorDTO.DonorID.ToString() && u.Role == "Donor");

                // Kiểm tra xem username mới có trùng với username khác không (ngoại trừ tài khoản hiện tại)
                var exists = _myContext.UserAccounts.Any(u => u.Username == donorDTO.Username && u.AccountID != userAccount.AccountID);
                if (exists)
                    throw new Exception("Username already exists."); // Ném ngoại lệ nếu trùng username

                // Nếu tìm thấy tài khoản, cập nhật username và password
                if (userAccount != null)
                {
                    userAccount.Username = donorDTO.Username;
                    userAccount.Password = donorDTO.Password;
                }

                // Lưu thay đổi
                return _myContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        // Lấy donorID dựa trên username trong bảng UserAccounts
        public string GetDonorIdByUsername(string username)
        {
            // Sử dụng DbContext mới để truy vấn (khác với _myContext)
            using (var context = new MyContext())
            {
                var donor = context.UserAccounts.FirstOrDefault(d => d.Username == username);
                // Trả về ObjectID (được dùng làm donorID)
                return donor.ObjectID;
            }
        }
    }
}
