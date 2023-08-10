using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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

        [HttpPost("garden/")]
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

    }
}
