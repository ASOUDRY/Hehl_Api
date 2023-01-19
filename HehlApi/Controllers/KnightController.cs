using ModelsLayer;
using RepoLayer;
using Microsoft.AspNetCore.Mvc;

namespace HehlApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KnightController : ControllerBase
    {
          Login v1 = new Login();
    private readonly ILogger<KnightController> _logger;
    public KnightController(ILogger<KnightController> logger)
    {
        _logger = logger;
    }


    [HttpGet(Name = "Knight")]
          public async Task<ActionResult<List<Knight>>> Get(User bit)
         {    
            if (!ModelState.IsValid) {
             UnprocessableEntity(bit);
            }
            else {
           
               List<User> ret = await v1.LoginUser(bit);
               return new JsonResult(ret);
        }
            return BadRequest();
        }
    }
}