using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        public List<DTO.NotificationsDTO> GetTileList(string objectID)
        {
            return _myContext.Notifications
                .Where(d => d.ObjectID == objectID)
                .Select(d => new DTO.NotificationsDTO
                {
                    ObjectID = d.ObjectID,
                    Title = d.Title,
                    CreatedAt = d.CreateAt,
                    IsRead = d.IsRead
                })
                .ToList();
        }



        //Lấy nội dung tin nhắn theo notifiID
        //public List<NotificationsDTO> GetMessageByID(string objectID)
        //{
        //    try
        //    {
        //        var notification = _myContext.Notifications.FirstOrDefault(d => d.ObjectID == objectID);
        //        if (notification == null)
        //            return null; //Nếu trong tin nhắn không có nội dung thì trả về null 

        //        return new NotificationsDTO
        //        {
        //            NotifiID = notification.NotifiID,
        //            Title = notification.Title,
        //            Message = notification.Message,
        //            CreatedAt = notification.CreateAt,
        //            ObjectID = notification.ObjectID,
        //            IsRead = notification.IsRead
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return null;
        //    }
        //}
        public List<DTO.NotificationsDTO> GetMessageByID(string objectID)
        {
            try
            {
                return _myContext.Notifications
                    .Where(n => n.ObjectID == objectID)
                    .Select(n => new DTO.NotificationsDTO
                    {
                        NotifiID = n.NotifiID,
                        Title = n.Title,
                        Message = n.Message,
                        CreatedAt = n.CreateAt,
                        IsRead = n.IsRead,
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }







        //Đánh dấu thông báo đã đọc
        public bool MaskAsRead(int ID)
        {
            try
            {
                var notification = _myContext.Notifications.FirstOrDefault(d => d.NotifiID == ID);
                if (notification == null)
                    return false;

                notification.IsRead = true;
                return _myContext.SaveChanges() > 0;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }


        public int GetUnreadCount(string objectID)
        {
            try
            {
                return _myContext.Notifications
                                 .Where(n => n.ObjectID == objectID && !n.IsRead)
                                 .Count();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }


        //Lấy nội dung tin nhắn theo ObjectID
      




        public bool AddNotification(Notification notification)
        {
            try
            {
                _myContext.Notifications.Add(notification);
                return _myContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("AddNotification Error: " + ex.Message);
                return false;
            }
        }
    }
}
