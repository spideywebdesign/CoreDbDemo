using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDbDemo.Strategy.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoreDbDemo.API.Controllers
{
    [Produces("application/json")]
    [Route("api/CMS")]
    public class CMSController : Controller
    {
        private readonly ICMSStrategy _cmsStrategy;

        public CMSController(ICMSStrategy cmsStrategy)
        {
            _cmsStrategy = cmsStrategy;
        }
        [HttpGet("GetAllContent")]
        public async Task<ActionResult> GetAllContent()
        {
            var result = await _cmsStrategy.GetAllContent();

            return Ok(result);
        }
    }
}
