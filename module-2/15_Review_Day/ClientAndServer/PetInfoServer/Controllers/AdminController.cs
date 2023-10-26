using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetInfoServer.Controllers
{
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpGet("/ready")]
        public ActionResult<string> Ready()
        {
            return "Server Ready!";
        }

    }
}
