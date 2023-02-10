using Microsoft.AspNetCore.Mvc;
using ModelsLayer;
using BusinessLayer;
namespace HehlApi.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class LoginController : ControllerBase
    {
        ConnectingClass businesLogic = new ConnectingClass();
        private readonly ILogger<LoginController> _logger;
        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Login")]
        public async Task<ActionResult<UserApiResponse>> Post(User bit) {    
            if (!ModelState.IsValid) {
                UnprocessableEntity(bit);
            }
            else {
                UserApiResponse ret = await businesLogic.LoginUser(bit);
                return new JsonResult(ret);
            }
                return BadRequest();
        }   
    }
}