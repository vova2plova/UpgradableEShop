using eShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace eShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController(EShopDbContext eShopDbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBaskets(CancellationToken cancellationToken) 
        {
            return Ok(await eShopDbContext.Baskets.ToListAsync(cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket(
            [FromQuery, BindRequired] Basket basketDto,
            CancellationToken cancellationToken)
        {
            var basket = await eShopDbContext.Baskets.SingleOrDefaultAsync(b => b.Id == basketDto.Id, cancellationToken);
            if (basket != null)
            {
                return BadRequest("Basket with provided Id alredy created");
            }

            await eShopDbContext.Baskets.AddAsync(basketDto, cancellationToken);
            return Ok("Basket with provided Id succsessfuly created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBasket(
            [FromQuery, BindRequired] Basket basketDto,
            CancellationToken cancellationToken)
        {
            var basket = await eShopDbContext.Baskets.SingleOrDefaultAsync(b => b.Id == basketDto.Id, cancellationToken);
            if (basket == null)
            {
                return BadRequest("Basket with provided Id not found");
            }

            basket.BasketItems = basketDto.BasketItems;
            await eShopDbContext.SaveChangesAsync(cancellationToken);
            return Ok("Basket with provided Id succsessfuly updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(
            [FromQuery, BindRequired] Basket basketDto,
            CancellationToken cancellationToken)
        {
            var basket = await eShopDbContext.Baskets.SingleOrDefaultAsync(b => b.Id == basketDto.Id, cancellationToken);
            if (basket == null)
            {
                return BadRequest("Basket with provided Id not found");
            }

            eShopDbContext.Remove(basket);
            await eShopDbContext.SaveChangesAsync(cancellationToken);
            return Ok("Basket with provided Id succsessfuly deleted");
        } 
    }
}
