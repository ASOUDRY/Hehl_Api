using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using ModelsLayer;
namespace HehlApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        ConnectingClass businesLogic  = new ConnectingClass();
     
        private readonly ILogger<RegistrationController> _logger;
        public RegistrationController(ILogger<RegistrationController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Registration")]
        public async Task<ActionResult<UserApiResponse>> Post(User user){
            if (!ModelState.IsValid) {
                UnprocessableEntity(user);
            }
            else {
               UserApiResponse ret = await businesLogic.RegisterUser(user);
               return new JsonResult(ret);
            }
            return BadRequest();
        }
    }
}