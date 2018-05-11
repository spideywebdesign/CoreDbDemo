using CoreDbDemo.Model.Domain;
using CoreDbDemo.Strategy.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CoreDbDemo.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Request")]
    public class RequestController : Controller
    {
        private readonly IRequestStrategy _requestStrategy;
        public RequestController(IRequestStrategy requestStrategy)
        {
            _requestStrategy = requestStrategy;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _requestStrategy.GetAll();

            return Ok(result);
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _requestStrategy.Get(id);

            return Ok(result);
        }

        [HttpGet("GetByStaffMember/{id}")]
        public async Task<ActionResult> GetByStaffMember(int id)
        {
            var result = await _requestStrategy.GetByStaffMember(id);

            return Ok(result);
        }

        [HttpPut("AddOrUpdate")]
        public async Task<ActionResult> AddOrUpdate([FromBody] Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _requestStrategy.AddOrUpdate(request);

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