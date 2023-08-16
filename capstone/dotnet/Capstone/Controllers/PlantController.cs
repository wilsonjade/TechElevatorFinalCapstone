using Capstone.DAO;
using Capstone.Exceptions;
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
        public ITasksDao tasksDao;

        public PlantController(IPlantDao plantDao, ITasksDao tasksDao)
        {
            this.plantDao = plantDao;
            this.tasksDao = tasksDao;

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

        [HttpGet("name/{commonName}")]

        public ActionResult<List<Plant>>GetPlantByCommonName(string commonName)
        {
            return Ok(plantDao.GetPlantsByCommonName(commonName));
        }




        [HttpGet("garden/{userId}")]
        public ActionResult<List<Plant>> GetMyPlants(int userId)
        {
            List<Plant> result = new List<Plant>();

            result = plantDao.GetPlantsByUserId(userId);

            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpGet("gardens/")]
        public ActionResult<List<Garden>> GetAllGardens()
        {
            List<Garden> result = new List<Garden>();

            result = plantDao.GetAllGardens();

            if (result.Count > 0)
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

            bool added = plantDao.AddPlantToVG(pair.PlantId, pair.UserId);

            if (added == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("garden")] 

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
        public ActionResult<List<Tasks>> GetMyTaskReminders(int userId)
        {  
            List<Tasks> result = new List<Tasks>();

            result = tasksDao.GetMyTaskReminders(userId);
            
            return Ok(result);

        }

        [HttpPut("tasks/{userId}")]
        public ActionResult UpdateTaskAck(TasksAck ack)
        {
            int count = tasksDao.UpdateTaskAck(ack);
            if(count > 0)
            {
                return Ok(count);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("tasks/ad")]
        public ActionResult<List<Tasks>> GetTasks()
        {
            return Ok(tasksDao.GetTasks());

        }

        [HttpGet("tasks/ad/{taskId}")]
        public ActionResult<Tasks> GetTasksById(int taskId)
        {
            Tasks result = new Tasks();

            result = tasksDao.GetTasksById(taskId);

            return Ok(result);

        }

        [HttpGet("tasks/plant/{plantId}")]
        public ActionResult<List<Tasks>> GetTasksByPlantId(int plantId)
        {
            List<Tasks> result = new List<Tasks>();

            result = tasksDao.GetTasksByPlantId(plantId);

            return Ok(result);

        }

        [HttpPut("tasks/ad/{taskId}")]

        public ActionResult<Tasks> UpdateTask(int taskId, Tasks taskToUpdate)
        {
            taskToUpdate.TaskId = taskId;

            try
            {
                Tasks result = tasksDao.UpdateTask(taskToUpdate);
                return Ok(result);
            }
            catch (DaoException)
            {
                return NotFound();
            }

        }

        [HttpDelete("{id}")]
        public ActionResult<Tasks> DeleteTask(int id)
        {
            bool isDeleted = tasksDao.DeleteTask(id);
            if (isDeleted)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost("tasks")]
        public ActionResult<Tasks> AddTask(Tasks newTask)
        {
            Tasks added = tasksDao.AddTask(newTask);
            return Created($"/tasks/{added.TaskId}", added);
        }
    }


}

