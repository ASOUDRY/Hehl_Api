using ModelsLayer;
using RepoLayer;
using Microsoft.AspNetCore.Mvc;

namespace HehlApi.Controllers
{
    [ApiController]
    [Route("[controller]/{key}")]
    public class LocationController : ControllerBase
    {
        LocationRetreival v1 = new LocationRetreival();

          private readonly ILogger<LocationController> _logger;
    public LocationController(ILogger<LocationController> logger)
    {
        _logger = logger;
    }

         [HttpGet(Name = "Location")]
          public async Task<ActionResult<List<Location>>> Get(string key)
         {    

            if (!ModelState.IsValid) {
             UnprocessableEntity();
            }
            else {
               List<Location> ret = await v1.FetchLocation(key);
               return new JsonResult(ret);        
        }
            return BadRequest();
        }
        
    }
}