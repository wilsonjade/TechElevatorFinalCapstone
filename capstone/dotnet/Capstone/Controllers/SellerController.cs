﻿using Capstone.DAO;
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
    public class SellerController : Controller
    {
        public ISellerDao sellerDao;

        public SellerController(ISellerDao sellerDao)
        {
            this.sellerDao = sellerDao;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<Seller>> GetSellers()
        {
            return Ok(sellerDao.GetSellers());
        }

        [HttpGet("{sellerId}")]
        [AllowAnonymous]

        public ActionResult<Seller> GetSellerById(int sellerId)
        {
            return Ok(sellerDao.GetSellerById(sellerId));
        }

        [HttpGet("plant/{plantId}")]
        [AllowAnonymous]
        public ActionResult<List<int>> GetSellersByPlantId(int plantId)
        {
            return Ok(sellerDao.GetSellerByPlantId(plantId));
            
        }

        //public ActionResult<Seller> GetSellerById(int sellerId)
        //{
        //    return Ok(sellerDao.GetSellerById(sellerId));
        //}

        [HttpPut("{id}")]
        
        public ActionResult<Seller> UpdateSeller(int id, Seller sellerToUpdate)
        {
            sellerToUpdate.SellerId = id;

            try
            {
                Seller result = sellerDao.UpdateSeller(sellerToUpdate);
                return Ok(result);
            }
            catch (DaoException)
            {
                return NotFound();
            }

        }

        [HttpDelete("{id}")]
        
        public ActionResult<Seller> DeleteSeller(int id)
        {
            bool isDeleted = sellerDao.DeleteSeller(id);
            if (isDeleted)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost()]
        
        public ActionResult<Seller> AddSeller(Seller newSeller)
        {
            Seller added = sellerDao.CreateSeller(newSeller);
            return Created($"/seller/{added.SellerId}", added);
        }
    }


}
