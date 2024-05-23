using AutoMapper;
using CatalogService.Application.Items.CreateItem;
using CatalogService.Application.Items.Get;
using CatalogService.Application.Items.ToggleVisibility;
using CatalogService.Controllers.Brands.Dto;
using CatalogService.Controllers.Items.Dto;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace CatalogService.Controllers.Items
{
    /// <summary>
    /// Контроллер для работы с товарами
    /// </summary>
    [Route("api/v1/items")]
    public class ItemsController(
        IMediator mediator,
        IMapper mapper
        ) : BaseController
    {

        // GET: api/v1/items
        [HttpGet]
        public async Task<IActionResult> GetItems([FromQuery]GetItemsQuery query, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(query, cancellationToken);

            if (result.IsFailed)
                return BadRequest(string.Join(", ", result.Reasons.Select(r => r.Message)));

            var itemsDtos = mapper.Map<IEnumerable<ItemDto>>(result.Value);

            return Ok(itemsDtos);
        }

        // GET: api/v1/items/item?id=
        [HttpGet("item")]
        public async Task<IActionResult> GetItemById(string itemId)
        {
            await Console.Out.WriteLineAsync(itemId);
            return Ok();
        }

        // POST: api/v1/items
        [HttpPost]
        public async Task<IActionResult> CreateItemAsync(CreateItemCommand command, CancellationToken cancellationToken)
        {
            return ConvertFluentResultToIActionResult(await mediator.Send(command, cancellationToken));
        }

        // PUT: api/v1/items/item/togglevisibility?id=
        [HttpPut("item/togglevisibility")]
        public async Task<IActionResult> ToggleItemVisibilityAsync([FromQuery]ToggleVisibilityCommand command, CancellationToken cancellationToken)
        {
            return ConvertFluentResultToIActionResult(await mediator.Send(command, cancellationToken));
        }

        // DELETE: api/v1/items/item?id=
        [HttpDelete]
        public async Task<IActionResult> DeleteItemAsync(string id)
        {
            return Ok();
        }
    }
}
