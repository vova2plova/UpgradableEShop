using CatalogService.Application.Items.CreateItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
            var response = await _mediator.Send(createItemCommand, cancellationToken);
            if (response.IsFailed)
                return BadRequest(string.Join(" ", response.Reasons.Select(r => r.Message)));
            return Ok();
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
        /// Обновление товара
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAuctionAsync()
        {
            return Ok();
        }

        /// <summary>
        /// Получение списка товаров
        /// </summary>
        /// <returns></returns>
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
    }
}
