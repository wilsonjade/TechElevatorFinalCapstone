using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RatingsController : Controller
    {
        public IRatingDao ratingsDao;

        public RatingsController(IRatingDao ratingsDao)
        {
            this.ratingsDao = ratingsDao;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<Ratings>> GetRatings()
        {
            return Ok(ratingsDao.GetRatings());
        }

        [HttpPost()]
        public ActionResult<Ratings> AddRating(Ratings newRating)
        {
            Ratings added = ratingsDao.AddRatings(newRating);
            return Created($"/ratings/{added.RatingId}", added);
        }




        [HttpDelete("{id}")]
        public ActionResult<Ratings> DeleteRating(int id)
        {
            bool isDeleted = ratingsDao.DeleteRating(id);
            if (isDeleted)
            {
                return Ok();
            }
            return NotFound();
        }


    }
}
