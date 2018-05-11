using CoreDbDemo.Model.Domain;
using CoreDbDemo.Strategy.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CoreDbDemo.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Brand")]
    public class BrandController : Controller
    {
        private readonly IBrandStrategy _brandStrategy;

        public BrandController(IBrandStrategy brandStrategy)
        {
            _brandStrategy = brandStrategy;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _brandStrategy.GetAll();

            return Ok(result);
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _brandStrategy.Get(id);

            return Ok(result);
        }

        [HttpPut("AddOrUpdate")]
        public async Task<ActionResult> AddOrUpdate([FromBody] Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _brandStrategy.AddOrUpdate(brand);

                return Ok(result);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}