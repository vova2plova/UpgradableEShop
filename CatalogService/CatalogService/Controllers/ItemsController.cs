using CatalogService.Application.Items.CreateItem;
using CatalogService.Application.Items.ToggleVisibilityItem;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace CatalogService.Controllers
{
    /// <summary>
    /// Контроллер для работы с товарами
    /// </summary>
    [ApiController]
    [Route("api/v1/items")]
    public class ItemsController(
        IMediator _mediator
        ) : ControllerBase
    {
        /// <summary>
        /// Создание товара
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateItemAsync(CreateItemCommand createItemCommand, CancellationToken cancellationToken)
        {
            return ConvertFluentResultToIActionResult(await _mediator.Send(createItemCommand, cancellationToken));
        }

        /// <summary>
        /// Удаление товара
        /// </summary>
        /// <param name="id">Идентификатор товара</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteItemAsync(int id)
        {
            return Ok();
        }


        /// <summary>
        /// Переключить видимость товара вкл/выкл
        /// </summary>
        [HttpPut("toggleVisibility")]
        public async Task<IActionResult> ToggleItemVisibilityAsync([FromQuery]ToggleVisibilityItemCommand command, CancellationToken cancellationToken)
        {
            return ConvertFluentResultToIActionResult(await _mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Получение списка товаров
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            return Ok();
        }


        /// <summary>
        /// Получение товара по идентификатору
        /// </summary>
        /// <param name="itemId">Идентификатор товара</param>
        /// <returns></returns>
        [HttpGet("{itemId}")]
        public async Task<IActionResult> GetItemById([FromQuery]int itemId)
        {
            return Ok();
        }


        private IActionResult ConvertFluentResultToIActionResult(Result result)
        {
            if (result.IsFailed)
                return BadRequest(string.Join(" ", result.Reasons.Select(r => r.Message)));

            return Ok();
        }
    }
}
