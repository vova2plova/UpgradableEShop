using eShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace eShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController(EShopDbContext eShopDbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBaskets(CancellationToken cancellationToken)
        {
            return Ok(await eShopDbContext.Catalogs.ToListAsync(cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket(
            [FromQuery, BindRequired] Catalog catalogDto,
            CancellationToken cancellationToken)
        {
            var catalog = await eShopDbContext.Catalogs.SingleOrDefaultAsync(b => b.Id == catalogDto.Id, cancellationToken);
            if (catalog != null)
            {
                return BadRequest("Catalog with provided Id alredy created");
            }

            await eShopDbContext.Catalogs.AddAsync(catalogDto, cancellationToken);
            return Ok("Catalog with provided Id succsessfuly created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBasket(
            [FromQuery, BindRequired] Catalog catalogDto,
            CancellationToken cancellationToken)
        {
            var catalog = await eShopDbContext.Catalogs.SingleOrDefaultAsync(b => b.Id == catalogDto.Id, cancellationToken);
            if (catalog == null)
            {
                return BadRequest("Catalog with provided Id not found");
            }

            catalog.Items = catalogDto.Items;
            await eShopDbContext.SaveChangesAsync(cancellationToken);
            return Ok("Catalog with provided Id succsessfuly updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(
            [FromQuery, BindRequired] Catalog catalogDto,
            CancellationToken cancellationToken)
        {
            var catalog = await eShopDbContext.Catalogs.SingleOrDefaultAsync(b => b.Id == catalogDto.Id, cancellationToken);
            if (catalog == null)
            {
                return BadRequest("Catalog with provided Id not found");
            }

            eShopDbContext.Remove(catalog);
            await eShopDbContext.SaveChangesAsync(cancellationToken);
            return Ok("Catalog with provided Id succsessfuly deleted");
        }
    }
}