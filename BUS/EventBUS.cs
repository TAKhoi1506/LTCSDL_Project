using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class EventBUS
    {
        private EventDAL eventDAL = new EventDAL();

        public List<EventDTO> GetAllEvents()
        {
            return eventDAL.GetAllEvents();
        }

        public bool AddEvent(EventDTO e)
        {
            return eventDAL.AddEvent(e);
        }

        public void UpdateEventStatus(int eventID, string newStatus)
        {
            EventDAL dal = new EventDAL();
            dal.UpdateEventStatus(eventID, newStatus);
        }
    }

}
