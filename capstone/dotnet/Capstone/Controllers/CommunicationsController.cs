﻿using Capstone.DAO;
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
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        public ActionResult<Communication> AddCommunication(Communication newCommunication)
        {
            Communication added = communicationsDao.AddCommunication(newCommunication);
            return Created($"/communications/{added.CommunicationId}", added);
        }
    }
}
