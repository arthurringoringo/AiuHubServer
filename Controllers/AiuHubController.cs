using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AiuHubServer.Services.SarraService;
using AiuHubServer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AiuHubServer.Controllers
{
    [Route("[controller]")]
   
    [ApiController]
    public class AiuHubController : ControllerBase
    {
        private readonly ISarraAPIService _sarraAPI;
        private readonly INewsAndAnnouncementRepository _repo;

        public AiuHubController(ISarraAPIService SarraAPi,INewsAndAnnouncementRepository Repo)
        {
            _sarraAPI = SarraAPi;
            _repo = Repo;
        
        }
        


        [HttpGet("run/sarra")]
        public IActionResult GetSarraNews()
        {
            var result = _sarraAPI.Run();

            return Ok(result);
            
        }

        [HttpGet("view/news")]
        public IActionResult ViewAllNews() 
        {
            var result = _repo.GetAllItem();

            return Ok(result);


        }

        [HttpGet("view/news/{id}")]
        public IActionResult ViewAllNews([FromRoute] int id)
        {
            var result = _repo.GetItemById(id);

            return Ok(result);


        }


    }
}
