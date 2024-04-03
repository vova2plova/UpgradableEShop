using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory()
        {
            return Ok();
        }
    }
}
