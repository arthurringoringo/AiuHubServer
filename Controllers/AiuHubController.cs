using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AiuHubServer.Services.SarraService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AiuHubServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AiuHubController : ControllerBase
    {
        private readonly ISarraAPIService _sarraAPI;

        public AiuHubController(ISarraAPIService SarraAPi)
        {
            _sarraAPI = SarraAPi;
        
        }


        [HttpGet("run/sarra")]
        public IActionResult GetSarraNews()
        {
            var result = _sarraAPI.Run();

            return Ok(result);
            
        }


    }
}
