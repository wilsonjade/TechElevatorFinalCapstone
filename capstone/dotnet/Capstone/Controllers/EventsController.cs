using Capstone.DAO;
using Microsoft.AspNetCore.Mvc;
using Capstone.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Capstone.Exceptions;

namespace Capstone.Controllers
{

    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class EventsController : Controller
    {
        public IEventsDao eventsDao;

        public EventsController(IEventsDao eventsDao)
        {
            this.eventsDao = eventsDao;
        }

        [HttpGet]

        public ActionResult<List<Events>> GetEvents()
        {
            return Ok(eventsDao.GetEvents());
        }

        [HttpGet("{eventsId}")]

        public ActionResult<Events> GetEventsById(int eventsId)
        {
            return Ok(eventsDao.GetEventById(eventsId));
        }

        [HttpGet("future")] //getFutureEvents()
        public ActionResult<List<Events>> GetFutureEvents()
        {
            return Ok(eventsDao.GetFutureEvents());
        }

        [HttpPut("{id}")]

        public ActionResult<Events> UpdateEvent(int id, Events eventToUpdate)
        {
            eventToUpdate.EventId = id;

            try
            {
                Events result = eventsDao.UpdateEvent(eventToUpdate);
                return Ok(result);
            }
            catch (DaoException)
            {
                return NotFound();
            }

        }

        [HttpDelete("{id}")]
        public ActionResult<Events> DeleteEvent(int id)
        {
            bool isDeleted = eventsDao.DeleteEvent(id);
            if (isDeleted)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<Events> AddEvent(Events newEvent)
        {
            Events added = eventsDao.AddEvent(newEvent);
            return Created($"/events/{added.EventId}", added);
        }
    }


}
