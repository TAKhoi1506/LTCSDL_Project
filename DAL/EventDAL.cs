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
        private MyContext db = new MyContext();
        public List<EventDTO> GetAllEvents()
        {
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
        public List<EventDTO> SearchEvent(string search)
        {
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
        public List<EventDTO> Sort(string sortBy)
        {
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
