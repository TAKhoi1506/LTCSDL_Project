using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;
using DTO;

namespace DAL
{
    public class EventDAL
    {
        public List<EventDTO> GetAllEvents()
        {
            using (var context = new MyContext())
            {
                return context.Events.Select(e => new EventDTO
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
        }


        public bool AddEvent(EventDTO e)
        {
            using (var context = new MyContext())
            {
                var newEvent = new Event
                {
                    EventName = e.EventName,
                    Description = e.Description,
                    Location = e.Location,
                    EventDate = e.EventDate,
                    Status = e.Status,
                    AmountOfBlood = e.AmountOfBlood
                };
                context.Events.Add(newEvent);
                return context.SaveChanges() > 0;
            }
        }


        public bool UpdateEventStatus(int eventId, string newStatus)
        {
            using (var context = new MyContext())
            {
                var existingEvent = context.Events.FirstOrDefault(ev => ev.EventID == eventId);
                if (existingEvent != null)
                {
                    existingEvent.Status = newStatus;
                    return context.SaveChanges() > 0;
                }
                return false;
            }
        }
    }
}
