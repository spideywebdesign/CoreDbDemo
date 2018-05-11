using CoreDbDemo.Model.Domain;
using CoreDbDemo.Strategy.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CoreDbDemo.API.Controllers
{
    [Produces("application/json")]
    [Route("api/AreaManager")]
    public class AreaManagerController : Controller
    {
        private readonly IAreaManagerStrategy _areaManagerStrategy;

        public AreaManagerController(IAreaManagerStrategy areaManagerStrategy)
        {
            _areaManagerStrategy = areaManagerStrategy;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _areaManagerStrategy.GetAll();

            return Ok(result);
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _areaManagerStrategy.Get(id);

            return Ok(result);
        }

        [HttpPut("AddOrUpdate")]
        public async Task<ActionResult> AddOrUpdate([FromBody] AreaManager areaManager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _areaManagerStrategy.AddOrUpdate(areaManager);

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