using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult HealthCheck()
        {
            return Ok(new { Status = "Ok" });
        }

        [Authorize]
        [HttpGet("Authorization")]
        public IActionResult AuthorizationHealthCheck()
        {
            return Ok(new { Status = "Ok" });
        }
    }
}
