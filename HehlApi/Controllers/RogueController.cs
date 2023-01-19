using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;
using RepoLayer;

namespace HehlApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RogueController : ControllerBase
    {
          RogueRetreival v1 = new RogueRetreival();
    private readonly ILogger<RogueController> _logger;
    public RogueController(ILogger<RogueController> logger)
    {
        _logger = logger;
    }


    [HttpGet(Name = "Rogue")]
          public async Task<ActionResult<List<User>>> Get(User bit)
         {    
            if (!ModelState.IsValid) {
             UnprocessableEntity(bit);
            }
            else {
    
               List<Rogue> ret = await v1.getCharacter();
               return new JsonResult(ret);

        }
            return BadRequest();
        }
    }
}