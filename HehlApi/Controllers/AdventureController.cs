using ModelsLayer;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
namespace HehlApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/{key}")]
    public class AdventureController : ControllerBase
    {
        ConnectingClass businesslogic = new ConnectingClass();
        private readonly ILogger<AdventureController> _logger;
        public AdventureController(ILogger<AdventureController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Adventure")]
        public async Task<ActionResult<Adventure>> Get(string key){    
                if (!ModelState.IsValid) {
                    UnprocessableEntity();
                }
                else {
                    Adventure ret = await businesslogic.GetAdventure(key);
                    return new JsonResult(ret);        
                }
            return BadRequest();
        }
    }
}