using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [ApiController]
    [Route("/health-check")]
    public class HealthCheckController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("УСПЕШНО");
        }
    }
}
