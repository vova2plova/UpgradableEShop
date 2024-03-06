using eShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace eShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogItemController(EShopDbContext eShopDbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBaskets(CancellationToken cancellationToken)
        {
            return Ok(await eShopDbContext.CatalogItems.ToListAsync(cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket(
            [FromQuery, BindRequired] CatalogItem catalogItemsDto,
            CancellationToken cancellationToken)
        {
            var catalogItem = await eShopDbContext.CatalogItems.SingleOrDefaultAsync(b => b.Id == catalogItemsDto.Id, cancellationToken);
            if (catalogItem != null)
            {
                return BadRequest("CatalogItem with provided Id alredy created");
            }

            await eShopDbContext.CatalogItems.AddAsync(catalogItemsDto, cancellationToken);

            return Ok("CatalogItem with provided Id succsessfuly created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBasket(
            [FromQuery, BindRequired] CatalogItem catalogItemsDto,
            CancellationToken cancellationToken)
        {
            var catalogItem = await eShopDbContext.CatalogItems.SingleOrDefaultAsync(b => b.Id == catalogItemsDto.Id, cancellationToken);
            if (catalogItem == null)
            {
                return BadRequest("CatalogItem with provided Id not found");
            }

            catalogItem.Item = catalogItemsDto.Item;
            catalogItem.AvailableStock = catalogItemsDto.AvailableStock;

            await eShopDbContext.SaveChangesAsync(cancellationToken);

            return Ok("CatalogItem with provided Id succsessfuly updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(
            [FromQuery, BindRequired] CatalogItem catalogItemsDto,
            CancellationToken cancellationToken)
        {
            var catalogItem = await eShopDbContext.CatalogItems.SingleOrDefaultAsync(b => b.Id == catalogItemsDto.Id, cancellationToken);
            if (catalogItem == null)
            {
                return BadRequest("CatalogItem with provided Id not found");
            }

            eShopDbContext.Remove(catalogItem);
            await eShopDbContext.SaveChangesAsync(cancellationToken);

            return Ok("CatalogItem with provided Id succsessfuly deleted");
        }
    }
}
