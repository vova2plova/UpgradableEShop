using eShop.Data;
using eShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace eShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController(EShopDbContext eShopDbContext) : ControllerBase
    {
        const int startPage = 1;
        const int defaultPageSize = 10;

        [HttpGet]
        public async Task<IActionResult> GetItems(
            [FromQuery] int page,
            [FromQuery] int pageSize,
            CancellationToken cancellationToken)
        {
            if (page == 0)
                page = startPage;
            if (pageSize == 0)
                pageSize = defaultPageSize;

            return Ok(await eShopDbContext
                .Items
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(i => i.DiscountPolicy)
                .Include(i => i.Brand)
                .Include(i => i.Category)
                .ToListAsync(cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(
            [FromBody, BindRequired] Item itemDto,
            CancellationToken cancellationToken)
        {
            var item = await eShopDbContext.Items.SingleOrDefaultAsync(i => i.Id == itemDto.Id, cancellationToken);
            if (item != default)
            {
                return BadRequest("Item with provided Id already created");
            }

            await eShopDbContext.AddAsync(itemDto, cancellationToken);
            await eShopDbContext.SaveChangesAsync(cancellationToken);

            return Ok("Item succsessfuly created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItem(
            [FromBody, BindRequired] Item itemDto,
            CancellationToken cancellationToken)
        {
            var item = await eShopDbContext.Items.SingleOrDefaultAsync(i => i.Id == itemDto.Id, cancellationToken);
            if (item == default)
            {
                return NotFound("Item with provided Id not found");
            }

            await eShopDbContext.SaveChangesAsync(cancellationToken);

            return Ok("Item succsessfuly updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItem(
            [FromBody, BindRequired] Item itemDto,
            CancellationToken cancellationToken)
        {
            var item = await eShopDbContext.Items.SingleOrDefaultAsync(i => i.Id == itemDto.Id, cancellationToken);
            if (item ==  default)
            {
                return NotFound("Item with provided Id not found");
            }

            eShopDbContext.Items.Remove(item);
            await eShopDbContext.SaveChangesAsync(cancellationToken);

            return Ok("Item succsessfuly deleted");
        }
    }
}
