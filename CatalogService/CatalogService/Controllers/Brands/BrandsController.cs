using AutoMapper;
using CatalogService.Application.Brands.Create;
using CatalogService.Application.Brands.Delete;
using CatalogService.Application.Brands.Get;
using CatalogService.Application.Brands.GetById;
using CatalogService.Application.Brands.Update;
using CatalogService.Controllers.Brands.Dto;
using CatalogService.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace CatalogService.Controllers.Brands
{
    [ApiController]
    [Route("api/v1/brands")]
    public class BrandsController(
        IMediator mediator,
        IMapper mapper
        ) : ControllerBase
    {
        // GET:: api/v1/brands
        [HttpGet]
        public async Task<IActionResult> GetBrandsAsync([FromQuery] GetBrandsQuery query, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(query, cancellationToken);

            var brandsDtos = mapper.Map<IEnumerable<BrandDto>>(result.Value);

            return Ok(brandsDtos);
        }

        // GET: api/v1/brands/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandsByIdAsync(string id, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetBrandByIdQuery { Id = id }, cancellationToken);

            var brand = mapper.Map<BrandDto>(result.Value);

            return Ok(brand);
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
