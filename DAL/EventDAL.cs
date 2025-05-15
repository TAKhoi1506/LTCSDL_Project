using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;  // Entity models đại diện bảng Events
using DTO;         // Các lớp Data Transfer Object

namespace DAL
{
    public class EventDAL
    {
        // Khởi tạo DbContext để truy cập dữ liệu
        private MyContext db = new MyContext();

        /// <summary>
        /// Lấy danh sách tất cả các sự kiện dưới dạng List<EventDTO>
        /// </summary>
        public List<EventDTO> GetAllEvents()
        {
            // Truy vấn tất cả các bản ghi Events, chuyển đổi entity sang DTO rồi trả về danh sách
            return db.Events
                .Select(e => new EventDTO
                {
                    EventID = e.EventID,
                    EventName = e.EventName,
                    Description = e.Description,
                    Location = e.Location,
                    EventDate = e.EventDate,
                    Status = e.Status,
                    AmountOfBlood = e.AmountOfBlood
                }).ToList();
        }

        /// <summary>
        /// Thêm mới một sự kiện dựa trên dữ liệu EventDTO truyền vào
        /// </summary>
        public bool AddEvent(EventDTO e)
        {
            // Tạo DbContext mới trong phạm vi using để đảm bảo dispose đúng cách
            using (var context = new MyContext())
            {
                // Tạo entity Event mới từ DTO
                var newEvent = new Event
                {
                    EventName = e.EventName,
                    Description = e.Description,
                    Location = e.Location,
                    EventDate = e.EventDate,
                    Status = e.Status,
                    AmountOfBlood = e.AmountOfBlood
                };
                // Thêm entity mới vào DbSet Events
                context.Events.Add(newEvent);
                // Lưu thay đổi vào DB, trả về true nếu thành công
                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Cập nhật trạng thái (Status) của một sự kiện theo eventId
        /// </summary>
        public bool UpdateEventStatus(int eventId, string newStatus)
        {
            using (var context = new MyContext())
            {
                // Tìm sự kiện có EventID khớp
                var existingEvent = context.Events.FirstOrDefault(ev => ev.EventID == eventId);
                if (existingEvent != null)
                {
                    // Cập nhật trạng thái mới
                    existingEvent.Status = newStatus;
                    // Lưu thay đổi và trả về kết quả
                    return context.SaveChanges() > 0;
                }
                // Nếu không tìm thấy sự kiện trả về false
                return false;
            }
        }

        /// <summary>
        /// Tìm kiếm sự kiện theo tên chính xác (EventName == search)
        /// </summary>
        public List<EventDTO> SearchEvent(string search)
        {
            // Truy vấn các event có EventName bằng với chuỗi tìm kiếm
            var events = db.Events
                                 .Where(e => e.EventName == search)
                                 .Select(e => new EventDTO
                                 {
                                     EventID = e.EventID,
                                     EventName = e.EventName,
                                     Description = e.Description,
                                     Location = e.Location,
                                     EventDate = e.EventDate,
                                     AmountOfBlood = e.AmountOfBlood,
                                     Status = e.Status
                                 })
                                 .ToList();

            return events;
        }

        /// <summary>
        /// Sắp xếp danh sách sự kiện theo trường được chọn
        /// </summary>
        /// <param name="sortBy">Tên trường để sắp xếp: "Event name", "Event date", "Status"</param>
        /// <returns>Danh sách sự kiện đã được sắp xếp</returns>
        public List<EventDTO> Sort(string sortBy)
        {
            // Truy vấn tất cả sự kiện dưới dạng DTO
            var query = from e in db.Events
                        select new EventDTO
                        {
                            EventID = e.EventID,
                            EventName = e.EventName,
                            Description = e.Description,
                            Location = e.Location,
                            EventDate = e.EventDate,
                            Status = e.Status,
                            AmountOfBlood = e.AmountOfBlood
                        };

            // Sắp xếp theo trường được chọn, nếu không hợp lệ trả về danh sách không sắp xếp
            switch (sortBy)
            {
                case "Event name":
                    return query.OrderBy(x => x.EventName).ToList();
                case "Event date":
                    return query.OrderBy(x => x.EventDate).ToList();
                case "Status":
                    return query.OrderBy(x => x.Status).ToList();
                default:
                    return query.ToList();
            }
        }
    }
}
