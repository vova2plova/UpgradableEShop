using AutoMapper;
using CatalogService.Application.Brands.Create;
using CatalogService.Application.Brands.Get;
using CatalogService.Controllers.Brands.Dto;
using CatalogService.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers.Brands
{
    [ApiController]
    [Route("brands")]
    public class BrandsController(
        IMediator mediator,
        IMapper mapper
        ) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBrandsAsync([FromQuery] GetBrandsCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            var brandsDtos =  mapper.Map<IEnumerable<BrandDto>>(result.Value);

            return Ok(brandsDtos);
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
