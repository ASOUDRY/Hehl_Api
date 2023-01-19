using ModelsLayer;
using RepoLayer;
using Microsoft.AspNetCore.Mvc;

namespace HehlApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonsterController : ControllerBase
    {
          MonsterRetreival v1 = new MonsterRetreival();
    private readonly ILogger<MonsterController> _logger;
    public MonsterController(ILogger<MonsterController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Monster")]
          public async Task<ActionResult<List<Monster>>> Get()
         {    
            if (!ModelState.IsValid) {
             UnprocessableEntity();
            }
            else {
               List<Monster> ret = await v1.FetchMonster();
               return new JsonResult(ret);        
        }
            return BadRequest();
        }
    }
}