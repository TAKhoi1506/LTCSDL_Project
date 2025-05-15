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



        //Hàm lấy nội dung thông báo dựa trên id
        public List<NotificationsDTO> GetMessageById(string objectID)
        {
            return notifiDAL.GetMessageByID(objectID);
        }


        //Hàm đánh dấu tin nhắn là đã đọc
        public bool MaskAsRead(int id)
        {
            return notifiDAL.MaskAsRead(id);
        }

        //Đếm số thông báo chưa đọc
        public int GetUnreadCount(string objectID)
        {
            return notifiDAL.GetTileList(objectID).Count(n => !n.IsRead);
        }

        // Forgot password
        public bool AddNotification(string objectID, string title, string message)
        {
            return notifiDAL.AddNotification(objectID, title, message);
        }
    }
}
