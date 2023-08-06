using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        
        public ActionResult< List<Plant>> GetPlants()
        {
            
            return Ok(plantDao.GetPlants());
        }

    }
}
