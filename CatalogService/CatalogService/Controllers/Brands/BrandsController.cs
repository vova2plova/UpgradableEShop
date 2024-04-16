using AutoMapper;
using CatalogService.Application.Brands.Create;
using CatalogService.Application.Brands.Delete;
using CatalogService.Application.Brands.Get;
using CatalogService.Application.Brands.Update;
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
        public async Task<IActionResult> GetBrandsAsync([FromQuery]GetBrandsQuery command, CancellationToken cancellationToken)
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
        public async Task<IActionResult> UpdateBrandAsync(UpdateBrandCommand command, CancellationToken cancellationToken)
        {
            await mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBrandAsync([FromQuery]DeleteBrandCommand command, CancellationToken cancellationToken)
        {
            await mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}
