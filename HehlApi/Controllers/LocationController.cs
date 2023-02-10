using ModelsLayer;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace HehlApi.Controllers
{
    [ApiController]
    [Route("[controller]/{key}")]
    public class LocationController : ControllerBase
    {
        ConnectingClass businesLogic = new ConnectingClass();
        private readonly ILogger<LocationController> _logger;
        public LocationController(ILogger<LocationController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Location")]
        public async Task<ActionResult<List<Location>>> Get(string key){    
            if (!ModelState.IsValid) {
                UnprocessableEntity();
            }
            else {
                List<Location> ret = await businesLogic.FetchLocation(key);
                return new JsonResult(ret);        
            }
            return BadRequest();
        }  
    }
}