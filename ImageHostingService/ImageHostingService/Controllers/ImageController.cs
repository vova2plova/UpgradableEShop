using Microsoft.AspNetCore.Mvc;

namespace ImageHostingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateImage(FormFile file)
        {
            return Ok();
        }
    }
}
