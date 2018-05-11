using CoreDbDemo.Model.Domain;
using CoreDbDemo.Strategy.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CoreDbDemo.API.Controllers
{
    [Produces("application/json")]
    [Route("api/StaffMember")]
    public class StaffMemberController : Controller
    {
        private readonly IStaffMemberStrategy _staffMemberStrategy;

        public StaffMemberController(IStaffMemberStrategy staffMemberStrategy)
        {
            _staffMemberStrategy = staffMemberStrategy;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _staffMemberStrategy.GetAll();

            return Ok(result);
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _staffMemberStrategy.Get(id);

            return Ok(result);
        }

        [HttpGet("GetByRetailer/{id}")]
        public async Task<ActionResult> GetByRetailer(int id)
        {
            var result = await _staffMemberStrategy.GetByRetailer(id);

            return Ok(result);
        }

        [HttpPut("AddOrUpdate")]
        public async Task<ActionResult> AddOrUpdate([FromBody]StaffMember staffMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _staffMemberStrategy.AddOrUpdate(staffMember);

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