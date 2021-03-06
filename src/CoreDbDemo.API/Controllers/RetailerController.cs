﻿using CoreDbDemo.Model.Domain;
using CoreDbDemo.Strategy.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CoreDbDemo.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Retailer")]
    public class RetailerController : Controller
    {
        private readonly IRetailerStrategy _retailerStrategy;

        public RetailerController(IRetailerStrategy retailerStrategy)
        {
            _retailerStrategy = retailerStrategy;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _retailerStrategy.GetAll();
            return Ok(result);
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _retailerStrategy.Get(id);
            return Ok(result);
        }

        [HttpGet("GetByStaffMember/{id}")]
        public async Task<ActionResult> GetByStaffMember(int id)
        {
            var result = await _retailerStrategy.GetByStaffMember(id);

            return Ok(result);
        }

        [HttpPost]
        public void Post([FromBody]Retailer retailer)
        {
        }

        [HttpPut("AddOrUpdate")]
        public async Task<ActionResult> AddOrUpdate([FromBody]Retailer retailer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _retailerStrategy.AddOrUpdate(retailer);

                return Ok(result);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}