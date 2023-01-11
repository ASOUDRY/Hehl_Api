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
    public class LoginController : ControllerBase
    {
        Login v1 = new Login();
    private readonly ILogger<LoginController> _logger;
    public LoginController(ILogger<LoginController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Login")]
          public async Task<ActionResult<User>> Get()
         {
            if (!ModelState.IsValid) {
             UnprocessableEntity(User);
            }
            else {
               User ret = await v1.LoginUser();
               return new JsonResult(ret);
            }
            return BadRequest();
        }
        
    }
}