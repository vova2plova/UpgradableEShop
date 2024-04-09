using CatalogService.Application.Brands.CreateBrand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [ApiController]
    [Route("brands")]
    public class BrandsController(
        IMediator mediator
        ) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBrandsAsync()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddBrandAsync(CreateBrandCommand command, CancellationToken cancellationToken)
        {
            await mediator.Send(command, cancellationToken);
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
