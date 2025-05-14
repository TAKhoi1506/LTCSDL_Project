using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Domain;
using DTO;


namespace BUS
{
    public class NotificationsBUS
    {
        private NotitficationsDAL notifiDAL = new NotitficationsDAL();
        private readonly BloodStockDAL _bloodStockDAL;

        //Hàm lấy danh sách thông báo hiển thị trên ListView
        public List<NotificationsDTO> GetNotificationsList(string objectID) 
        {
            return notifiDAL.GetTileList(objectID);
        }
        //Kiểm tra số lượng máu tồn kho và gửi thông báo
        //public void CheckAndNotifyLowStock(float threshold = 5.0f)
        //{
        //    var lowStockBloodTypes = _bloodStockDAL.GetLowStockBloodTypes(threshold);

        //    foreach (var stock in lowStockBloodTypes)
        //    {
        //        string title = $"Cảnh báo: Nhóm máu {stock.BloodType} sắp hết!";
        //        string message = $"Số lượng hiện tại: {stock.Amount}. Cần bổ sung gấp.";

        //        var notification = new Notification
        //        {
        //            ObjectID = "admin", // ID của người nhận thông báo
        //            Title = title,
        //            Message = message,
        //            CreateAt = DateTime.Now,
        //            IsRead = false
        //        };

        //        notifiDAL.AddNotification(notification);
        //    }
        //}



        //Hàm lấy nội dung thông báo dựa trên id
        public NotificationsDTO GetMessageById(string objectID)
        {
            return notifiDAL.GetMessageByID(objectID);
        }


        //Hàm đánh dấu tin nhắn là đã đọc
        public bool MaskAsRead(string objectID)
        {
            return notifiDAL.MaskAsRead(objectID);
        }

        //Đếm số thông báo chưa đọc 
        //public int GetUnreadCount()
        //{
        //    return notifiDAL.GetTileList().Count(n => !n.IsRead);
        //}

        //public int GetUnreadCount(int notifiID)
        //{
        //    return notifiDAL.GetUnreadCount(notifiID);
        //}
    }
}
