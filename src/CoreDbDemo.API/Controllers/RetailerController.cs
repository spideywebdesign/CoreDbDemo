﻿using CoreDbDemo.Model.Domain;
using CoreDbDemo.Strategy.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        // GET: api/Retailer
        [HttpGet]
        public async Task<IEnumerable<Retailer>> GetAll()
        {
            return await _retailerStrategy.GetAll();
        }

        // GET: api/Retailer/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Retailer> Get(int id)
        {
            return await _retailerStrategy.Get(id);
        }

        // POST: api/Retailer
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Retailer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}