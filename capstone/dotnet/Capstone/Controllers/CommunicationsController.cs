using Capstone.DAO;
using Capstone.Exceptions;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;

namespace Capstone.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class CommunicationsController : Controller
    {
        public ICommunicationDao communicationsDao;

        public CommunicationsController(ICommunicationDao communicationsDao)
        {
            this.communicationsDao = communicationsDao;
        }



        [HttpGet]
        //[Authorize(Roles = "admin")]
        public ActionResult<List<Communication>> GetCommunications()
        {
            return Ok(communicationsDao.GetCommunications());
        }



        [HttpGet("{communicationId}")]
        public ActionResult<Communication> GetCommunicationById(int communicationId)
        {
            return Ok(communicationsDao.GetCommunicationById(communicationId));
        }




        [HttpGet("future")] //GetFutureCommunications()
        [Authorize(Roles = "admin, user")]
        public ActionResult<List<Communication>> GetFutureCommunications()
        {
            return Ok(communicationsDao.GetFutureCommunications());
        }


        [HttpGet("type/{communicationType}")]
        //[Authorize(Roles = "admin, user")]
        public ActionResult<List<Communication>> GetCommunicationsByType(string communicationType)
        {
            return Ok(communicationsDao.GetCommunicationsByType(communicationType));
        }

        [HttpGet("polloption/{pollId}")]
        //[Authorize(Roles = "admin, user")]
        public ActionResult<List<PollOptions>> GetPollOptionsByPollId(int id)
        {
            return Ok(communicationsDao.GetPollOptionsByPollId(id));
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult<Communication> UpdateCommunication(int id, Communication communicationToUpdate)
        {
            communicationToUpdate.CommunicationId = id;

            try
            {
                Communication result = communicationsDao.UpdateCommunication(communicationToUpdate);
                return Ok(result);
            }
            catch (DaoException)
            {
                return NotFound();
            }
        }


        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        public ActionResult<Communication> DeleteCommunication(int id)
        {
            bool isDeleted = communicationsDao.DeleteCommunication(id);
            if (isDeleted)
            {
                return Ok();
            }
            return NotFound();
        }




        [HttpPost()]
        //[Authorize(Roles = "admin")]
        public ActionResult<Communication> AddCommunication(Communication newCommunication)
        {
            Communication added = communicationsDao.AddCommunication(newCommunication);
            return Created($"/communications/{added.CommunicationId}", added);
        }

        [HttpPost("polls")]
        public ActionResult<PollOptions> AddPollOption(PollOptions newPollOption)
        {
            PollOptions added = communicationsDao.AddPollOption(newPollOption);
            return Created($"/communications/polls/{added.PollId}", added);
        }

        //TODO - NEED METHOD TO POST USER'S POLL RESPONSE
        //[HttpPost("/{type}/{id}")]
        //[Authorize(Roles = "admin, user")]
        //public ActionResult<Communication> AddPollResponse(Communication pollResponse)
        //{
        //    Communication pollResponse = communicationsDao.AddPollResponse(pollResponse);
        //    return Created($"/communications/polls/{pollResponse.pollId}");
        //}
    }
}