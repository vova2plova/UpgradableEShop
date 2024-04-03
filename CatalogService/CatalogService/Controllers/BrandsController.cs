using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [ApiController]
    [Route("brands")]
    public class BrandsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBrandsAsync()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddBrandAsync()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrandAsync()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBrandAsync()
        {
            return Ok();
        }
    }
}
