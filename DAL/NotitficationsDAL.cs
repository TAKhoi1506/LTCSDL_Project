using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;
using DTO;

namespace DAL
{
    public class NotitficationsDAL
    {
        private readonly MyContext _myContext;

        public NotitficationsDAL()
        {
            _myContext = new MyContext();
        }

        //Lấy danh sách các tin nhắn hiển thị trên listview
        public List<DTO.Notifications> GetTileList() 
        {
            return _myContext.Notifications.Select(d => new DTO.Notifications
            {
                NotifiID = d.NotifiID,
                Title = d.Title,
                CreatedAt = d.CreateAt,
                IsRead = d.IsRead
               
            }).ToList();
        }



        //Lấy nội dung tin nhắn theo ID
       public DTO.Notifications GetMessageByID(int notifiID)
        {
            try
            {
                var notification = _myContext.Notifications.FirstOrDefault(d => d.NotifiID == notifiID);
                if (notification == null)
                    return null; //Nếu trong tin nhắn không có nội dung thì trả về null 

                return new DTO.Notifications
                {
                    NotifiID = notification.NotifiID,
                    Title = notification.Title,
                    Message = notification.Message,
                    CreatedAt = notification.CreateAt,
                    DonorID = notification.DonorID,
                    IsRead = notification.IsRead
                };
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }


        //Đánh dấu thông báo đã đọc
        public bool MaskAsRead(int notifiID)
        {
            try
            {
                var notification = _myContext.Notifications.FirstOrDefault(d => d.NotifiID == notifiID);
                if (notification == null) 
                    return false;

                notification.IsRead = true;
                return _myContext.SaveChanges() > 0;
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }



    }
}
