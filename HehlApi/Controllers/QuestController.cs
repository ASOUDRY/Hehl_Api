using Microsoft.AspNetCore.Mvc;
using ModelsLayer;
using BusinessLayer;

namespace HehlApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/{questgiver}/{location}")]
    public class QuestController : ControllerBase
    {
        ConnectingClass businesLogic  = new ConnectingClass();
        private readonly ILogger<QuestController> _logger;
        public QuestController(ILogger<QuestController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Quest")]
        public async Task<ActionResult<Quest>> Get(string questgiver, string location) {
            if (!ModelState.IsValid) {
                UnprocessableEntity();
            }
            else {
                Quest ret = await businesLogic.GetQuest(questgiver, location);
                return new JsonResult(ret);
            }
            return BadRequest();
        }
        
    }
}