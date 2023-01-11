using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepoLayer;
using ModelsLayer;
namespace HehlApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        Test v1 = new Test();
    private readonly ILogger<PlayerController> _logger;
    public PlayerController(ILogger<PlayerController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetPlayer")]
          public async Task<ActionResult<Rogue>> Get()
         {
            if (!ModelState.IsValid) {
             UnprocessableEntity(User);
            }
            else {
               Rogue ret = await v1.Return();
               return new JsonResult(ret);
            }
            return BadRequest();
        }
    }
}