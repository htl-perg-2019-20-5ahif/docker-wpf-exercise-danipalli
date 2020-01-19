using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : Controller
    {
        public PingController()
        { }

        // GET: api/Ping
        [HttpGet]
        public async Task<ActionResult> Ping()
        {
            return Ok();
        }
    }
}