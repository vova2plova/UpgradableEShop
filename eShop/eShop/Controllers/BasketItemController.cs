using eShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace eShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketItemController(EShopDbContext eShopDbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBasketItems(CancellationToken cancellationToken)
        {
            return Ok(await eShopDbContext.BasketItems.ToListAsync(cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasketItem(
            [FromQuery, BindRequired] BasketItem basketItemDto,
            CancellationToken cancellationToken)
        {
            var basketItem = await eShopDbContext.BasketItems.SingleOrDefaultAsync(b => b.Id == basketItemDto.Id, cancellationToken);
            if (basketItem != null)
            {
                return BadRequest("BasketItem with provided Id alredy created");
            }

            await eShopDbContext.BasketItems.AddAsync(basketItemDto);
            return Ok("BasketItem with provided Id succsessfuly created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBasketItem(
            [FromQuery, BindRequired] BasketItem basketItemDto,
            CancellationToken cancellationToken)
        {
            var basketItem = await eShopDbContext.BasketItems.SingleOrDefaultAsync(b => b.Id == basketItemDto.Id, cancellationToken);
            if (basketItem == null)
            {
                return BadRequest("BasketItem with provided Id not found");
            }

            basketItem.CatalogItem = basketItemDto.CatalogItem;
            basketItem.Quantity = basketItemDto.Quantity;
            await eShopDbContext.SaveChangesAsync(cancellationToken);
            return Ok("BasketItem with provided Id succsessfuly updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(
            [FromQuery, BindRequired] BasketItem basketItemDto,
            CancellationToken cancellationToken)
        {
            var basketItem = await eShopDbContext.BasketItems.SingleOrDefaultAsync(b => b.Id == basketItemDto.Id, cancellationToken);
            if (basketItem == null)
            {
                return BadRequest("BasketItem with provided Id not found");
            }

            eShopDbContext.Remove(basketItem);
            await eShopDbContext.SaveChangesAsync(cancellationToken);
            return Ok("BasketItem with provided Id succsessfuly deleted");
        }
    }
}
