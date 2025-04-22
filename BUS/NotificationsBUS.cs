using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;


namespace BUS
{
    public class NotificationsBUS
    {
        private NotitficationsDAL notifiDAL = new NotitficationsDAL();


        //Hàm lấy danh sách thông báo hiển thị trên ListView

        public List<Notifications> GetNotificationsList() 
        {
            return notifiDAL.GetTileList();
        }


        //Hàm lấy nội dung thông báo dựa trên id
        public Notifications GetMessageById(int id)
        {
           return notifiDAL.GetMessageByID(id);
        }


        //Hàm đánh dấu tin nhắn là đã đọc
        public bool MaskAsRead(int id)
        {
            return notifiDAL.MaskAsRead(id);
        }
    }
}
