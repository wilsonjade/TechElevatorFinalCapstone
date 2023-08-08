using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public class EventsSqlDao : IEventsDao
    {
        public List<Events> GetEvents()
        {
            List<Events> events = new List<Events>();
            return events;
        }

        public Events GetEventById(int id)
        {
            Events events = new Events();
            return events;
        }

       
        public List<Events> GetFutureEvents()
        {
            List<Events> events = new List<Events>();
            return events;
        }
       
        public Events AddEvent(Events eventToAdd)
        {
            Events events = new Events();
            return events;
        }
        
        public Events UpdateEvent(Events eventToUpdate)
        {
            Events events = new Events();
            return events;
        }
        
        public bool DeleteEvent(int eventId)
        {

            Events events = new Events();
            return false;
        }
    }
}
