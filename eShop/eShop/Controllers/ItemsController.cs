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
        [HttpGet]
        public async Task<IActionResult> GetItems(CancellationToken cancellationToken)
        {
            return Ok(await eShopDbContext.Items.ToListAsync(cancellationToken));
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

            item.Brand = itemDto.Brand;
            item.Name = itemDto.Name;
            item.Description = itemDto.Description;
            item.Category = itemDto.Category;
            item.DiscountPolicy = itemDto.DiscountPolicy;
            item.Images = itemDto.Images;
            item.IsHidden = itemDto.IsHidden;
            item.MainImageUrl = itemDto.MainImageUrl;

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
