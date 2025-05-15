using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;  // Tham chiếu các entity models
using DTO;         // Tham chiếu các lớp Data Transfer Object

namespace DAL
{
    public class HistoryDonationDAL
    {
        // Khai báo biến _myContext dùng để thao tác với database thông qua Entity Framework
        private readonly MyContext _myContext;

        // Constructor khởi tạo instance của MyContext
        public HistoryDonationDAL()
        {
            _myContext = new MyContext();
        }
        // Lấy danh sách tất cả các bản ghi lịch sử hiến máu (HistoryDonations)
        public List<DTO.HistoryDonation> GetAllHistoryDonations()
        {
            // Truy vấn toàn bộ bảng HistoryDonations trong database,
            // chuyển đổi entity sang DTO để trả về cho lớp gọi
            return _myContext.HistoryDonations.Select(d => new DTO.HistoryDonation
            {
                HisDonaID = d.HisDonaID,           // ID của lịch sử hiến máu
                DonorID = d.DonorID,               // ID người hiến máu
                EventID = d.EventID,               // ID sự kiện hiến máu
                DonationDate = d.DonationDate,    // Ngày hiến máu
                Weight = d.Weight,                 // Cân nặng người hiến máu lúc đó
                BloodPressure = d.BloodPressure,  // Huyết áp người hiến máu lúc đó
                Amount = d.Amount,                 // Lượng máu hiến (ml)
                HealthStatus = d.HealthStatus,    // Tình trạng sức khỏe khi hiến máu
            }).ToList();  // Chuyển kết quả sang List để trả về
        }
    }
}
