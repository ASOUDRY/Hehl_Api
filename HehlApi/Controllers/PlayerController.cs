using Microsoft.AspNetCore.Mvc;
using ModelsLayer;
using BusinessLayer;
namespace HehlApi.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class PlayerController : ControllerBase
    {
        ConnectingClass businesLogic  = new ConnectingClass();
        private readonly ILogger<PlayerController> _logger;
        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "GetPlayer")]
        public async Task<ActionResult<Character>> Post(smallpayload drop) {
            if (!ModelState.IsValid) {
                UnprocessableEntity(User);
            }
            else {
                Character ret = await businesLogic.GetCharacter(drop.username, drop.cClass);
                return new JsonResult(ret);
            }
            return BadRequest();
        }
    }
}