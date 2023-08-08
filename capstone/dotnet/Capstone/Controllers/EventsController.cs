using Capstone.DAO;
using Microsoft.AspNetCore.Mvc;
using Capstone.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{

    [Route("[controller]")]
    [ApiController]
    //[Authorize(Roles = "admin")]
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

        //[HttpPut("{eventsId}")]

        //public ActionResult<Events> UpdateEvent(Events eventToUpdate)
        //{

        //}

    }

    
}
