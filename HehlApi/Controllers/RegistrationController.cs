using Microsoft.AspNetCore.Mvc;
using RepoLayer;
using ModelsLayer;

namespace HehlApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        Registration v1 = new Registration();
        private readonly ILogger<RegistrationController> _logger;
        public RegistrationController(ILogger<RegistrationController> logger)
        {
            _logger = logger;
        }

    [HttpPost(Name = "Registration")]
          public async Task<ActionResult<User>> Post(User user)
         {
            if (!ModelState.IsValid) {
             UnprocessableEntity(user);
            }
            else {
               User ret = await v1.RegisterUser(user);
               return new JsonResult(ret);
            }
            return BadRequest();
        }
    }
}