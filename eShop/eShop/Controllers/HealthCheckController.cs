using eShop.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthCheckController(EShopDbContext eShopDbContext) : ControllerBase
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

        [HttpGet("Database")]
        public async Task<IActionResult> DatabaseHealthCheck()
        {
            try
            {
                await eShopDbContext.Items.FirstOrDefaultAsync();
                return Ok(new { Status = "Ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { Status = "ERROR", Details = ex.Message });
            }
        }
    }
}
