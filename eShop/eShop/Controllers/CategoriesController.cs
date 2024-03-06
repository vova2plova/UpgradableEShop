using eShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace eShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController(EShopDbContext eShopDbContext) : ControllerBase
    {
        // GET: api/categories
        [HttpGet(Name = "GetAllCategories")]
        public async Task<IActionResult> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            return Ok(await eShopDbContext.Categories.ToListAsync(cancellationToken));
        }

        // POST: api/categories
        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync(
            [FromBody, BindRequired] Category categoryDto,
            CancellationToken cancellationToken)
        {
            var category = await eShopDbContext.Categories.SingleOrDefaultAsync(c => string.Equals(c.Name, categoryDto.Name), cancellationToken);
            if (category != default)
            {
                return BadRequest("Category with provided Name already created");
            }

            await eShopDbContext.Categories.AddAsync(categoryDto, cancellationToken);
            await eShopDbContext.SaveChangesAsync(cancellationToken);

            return Ok("Category succsessfuly created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategoryAsync(
            [FromBody, BindRequired] Category categoryDto,
            CancellationToken cancellationToken)
        {
            var category = await eShopDbContext.Categories.SingleOrDefaultAsync(c => categoryDto.Id == c.Id, cancellationToken);
            if (category == default)
            {
                return NotFound("Category with provided Id not found");
            }

            category.Name = categoryDto.Name;

            await eShopDbContext.SaveChangesAsync(cancellationToken);

            return Ok("Category with Id succsessfuly updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategoryAsync(
            [FromBody, BindRequired] Category categoryDto,
            CancellationToken cancellationToken)
        {
            var category = await eShopDbContext.Categories.SingleOrDefaultAsync(c => categoryDto.Id == c.Id, cancellationToken);
            if (category == default)
            {
                return NotFound("Category with provided Id not found");
            }

            eShopDbContext.Categories.Remove(category);
            await eShopDbContext.SaveChangesAsync(cancellationToken);

            return Ok("Category with provided Id succsessfuly deleted");
        }
    }
}
