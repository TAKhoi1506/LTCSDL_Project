using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Domain;
using DTO;

namespace DAL
{
    // Để đảm bảo giải phóng tài nguyên, lớp này triển khai IDisposable
    public class DonationDAL 
    {
        // Khai báo context EF dùng chung trong lớp
        private readonly MyContext _context;

        // Khởi tạo context khi tạo instance của lớp
        public DonationDAL()
        {
            _context = new MyContext();
        }

        // Thêm bản ghi Donation mới vào database
        public bool AddDonation(DonationDTO donation)
        {
            var newDonation = new Donation
            {
                DonorID = donation.DonorID,
                EventID = donation.EventID
            };

            _context.Donations.Add(newDonation);

            // Lưu thay đổi vào DB, trả về true nếu thành công
            return _context.SaveChanges() > 0;
        }

        // Lấy danh sách tất cả Donation dưới dạng DTO
        public List<DonationDTO> GetAllDonations()
        {
            return _context.Donations
                .Select(d => new DonationDTO
                {
                    DonationID = d.DonationID,
                    DonorID = d.DonorID,
                    EventID = d.EventID
                }).ToList();
        }
    }
}
