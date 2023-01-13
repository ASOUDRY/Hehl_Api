using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;
using RepoLayer;

namespace HehlApi.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class LoginController : ControllerBase
    {
        Login v1 = new Login();
    private readonly ILogger<LoginController> _logger;
    public LoginController(ILogger<LoginController> logger)
    {
        _logger = logger;
    }


    [HttpGet(Name = "Login")]
          public async Task<ActionResult<List<User>>> Get(User bit)
         {    
            if (!ModelState.IsValid) {
             UnprocessableEntity(bit);
            }
            else {
            string retreivedHash = await v1.RetreivePassword(bit);
           
            PasswordHasher<User> v = new PasswordHasher<User>();

            bit.checkHashed = (int)v.VerifyHashedPassword(bit, retreivedHash, bit.password);
if (bit.checkHashed == 1) {
               List<User> ret = await v1.LoginUser(bit);
               return new JsonResult(ret);
            }
        }
            return BadRequest();
        }
        
    }
}