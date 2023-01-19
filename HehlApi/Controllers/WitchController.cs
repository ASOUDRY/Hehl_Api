using ModelsLayer;
using Microsoft.AspNetCore.Mvc;
using RepoLayer;

namespace HehlApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WitchController : ControllerBase
    {
          WitchRetreival v1 = new WitchRetreival();
    private readonly ILogger<WitchController> _logger;
    public WitchController(ILogger<WitchController> logger)
    {
        _logger = logger;
    }


    [HttpGet(Name = "Witch")]
          public async Task<ActionResult<List<Witch>>> Get()
         {    
            if (!ModelState.IsValid) {
             UnprocessableEntity();
            }
            else { 
               List<Witch> ret = await v1.getCharacter();
               return new JsonResult(ret);
        }
            return BadRequest();
        }
    }
}