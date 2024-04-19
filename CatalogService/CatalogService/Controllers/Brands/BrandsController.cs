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
    [Route("api/v1/brands")]
    public class BrandsController(
        IMediator mediator,
        IMapper mapper
        ) : BaseController
    {
        // GET:: api/v1/brands
        [HttpGet]
        public async Task<IActionResult> GetBrandsAsync([FromQuery] GetBrandsQuery query, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(query, cancellationToken);

            if (result.IsFailed)
                return BadRequest(string.Join(", ", result.Reasons.Select(r => r.Message)));

            var brandsDtos = mapper.Map<IEnumerable<BrandDto>>(result.Value);

            return Ok(brandsDtos);
        }

        // GET: api/v1/brands/brand?id=
        [HttpGet("brand")]
        public async Task<IActionResult> GetBrandByIdAsync([FromQuery]GetBrandByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(query, cancellationToken);

            if (result.IsFailed)
                return BadRequest(string.Join(", ", result.Reasons.Select(r => r.Message)));

            var brand = mapper.Map<BrandDto>(result.Value);

            return Ok(brand);
        }

        // POST: api/v1/brands
        [HttpPost]
        public async Task<IActionResult> AddBrandAsync(CreateBrandCommand command, CancellationToken cancellationToken)
        {
            return ConvertFluentResultToIActionResult(await mediator.Send(command, cancellationToken));
        }

        // PUT: api/v1/brands
        [HttpPut]
        public async Task<IActionResult> UpdateBrandAsync(UpdateBrandCommand command, CancellationToken cancellationToken)
        {
            return ConvertFluentResultToIActionResult(await mediator.Send(command, cancellationToken));
        }

        // DELETE: api/v1/brands/brand?id=
        [HttpDelete("brand")]
        public async Task<IActionResult> DeleteBrandAsync([FromQuery]DeleteBrandCommand command, CancellationToken cancellationToken)
        {
            return ConvertFluentResultToIActionResult(await mediator.Send(command, cancellationToken));
        }
    }
}
