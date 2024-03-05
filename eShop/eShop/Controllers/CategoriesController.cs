using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        [HttpGet(Name = "GetAllCategories")]
        public async Task<IActionResult> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
