﻿using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Capstone.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class PlantController : Controller
    {
        public IPlantDao plantDao;

        public PlantController(IPlantDao plantDao)
        {
            this.plantDao = plantDao;

        }


        [HttpGet]
        public ActionResult<List<Plant>> GetPlants()
        {

            return Ok(plantDao.GetPlants());
        }

        [HttpGet("{plantId}")]

        public ActionResult<Plant> GetPlantById(int plantId)
        {
            return Ok(plantDao.GetPlantById(plantId));
        }

        [HttpGet("garden/{userId}")]
        public ActionResult<List<Plant>> GetMyPlants(int userId)
        {
            List<Plant> result = new List<Plant>();

            result = plantDao.GetPlantsByUserId(userId);
          
            if(result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpPost("garden")]
        //public ActionResult AddPantToVG( int plantId, int userId)
        public ActionResult AddPantToVG(PlantUserPair pair)

        {
           
            bool added = plantDao.AddPlantToVG(pair.PlantId, pair.UserId );

                if(added == true)
                {
                    return Ok();
                }
                else
                {
                return BadRequest();
                }
        }

        [HttpDelete("garden")] //todo needs to take in id

        public ActionResult DeletePlantFromGarden(PlantUserPair pair)
        {
            bool isDeleted = plantDao.DeletePlantFromGarden(pair.PlantId, pair.UserId);
            if (isDeleted)
            {
                return Ok();
            }
            return NotFound();
        }

        //this section is for plant task reminders
        [HttpGet("tasks/{userId}")]
        public ActionResult<int[]> GetMyTaskReminders(int userId)
        {
            
            List<Tasks> result = new List<Tasks>();

           // result = tasksDao.Getname of list method here(userId);
            int[] testresult = new int[4] { 1, 3, 5, 7 };

            
                return Ok(testresult);
            //    return Ok(result);
            
            

        }

        [HttpPut("tasks/{userId}")]
        public ActionResult UpdateTaskAck(int userId)
        {


            return Ok();
        }


    }
}
