using CoreDbDemo.Model.Domain;
using CoreDbDemo.Strategy.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CoreDbDemo.API.Controllers
{
    [Produces("application/json")]
    [Route("api/ExternalSystem")]
    public class ExternalSystemController : Controller
    {
        private readonly IExternalSystemStrategy _externalSystemStrategy;

        public ExternalSystemController(IExternalSystemStrategy externalSystemStrategy)
        {
            _externalSystemStrategy = externalSystemStrategy;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _externalSystemStrategy.GetAll();

            return Ok(result);
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _externalSystemStrategy.Get(id);

            return Ok(result);
        }

        [HttpPut("AddOrUpdate")]
        public async Task<ActionResult> AddOrUpdate([FromBody] ExternalSystem externalSystem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _externalSystemStrategy.AddOrUpdate(externalSystem);

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