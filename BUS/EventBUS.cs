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
        public List<(EventDTO Event, string Status)> SortEvents(string sortBy)
        {
            var results = eventDAL.Sort(sortBy);
            return results.Select(x => (
                new EventDTO
                {
                    EventID = x.EventID,
                    EventName = x.EventName,
                    Description = x.Description,
                    Location = x.Location,
                    EventDate = x.EventDate,
                    Status = x.Status,
                    AmountOfBlood = x.AmountOfBlood
                },
                x.Status
            )).ToList();
        }
        public List<EventDTO> SearchEvent(string search)
        {
            return eventDAL.SearchEvent(search);
        }
    }

}
