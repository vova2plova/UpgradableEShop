using eShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace eShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController(EShopDbContext eShopDbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetOrders(CancellationToken cancellationToken)
        {
            return Ok(await eShopDbContext.Orders.ToListAsync(cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(
            [FromBody, BindRequired] Order orderDto,
            CancellationToken cancellationToken)
        {
            var order = await eShopDbContext.Orders.SingleOrDefaultAsync(i => i.Id == orderDto.Id, cancellationToken);
            if (order != default)
            {
                return BadRequest("Order with provided Id already created");
            }

            await eShopDbContext.AddAsync(orderDto, cancellationToken);
            await eShopDbContext.SaveChangesAsync(cancellationToken);

            return Ok("Order succsessfuly created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(
            [FromBody, BindRequired] Order orderDto,
            CancellationToken cancellationToken)
        {
            var order = await eShopDbContext.Orders.SingleOrDefaultAsync(i => i.Id == orderDto.Id, cancellationToken);
            if (order == default)
            {
                return NotFound("Order with provided Id not found");
            }

            order.DiscountPolicy = orderDto.DiscountPolicy;
            order.OrderDate = orderDto.OrderDate;
            order.Items = orderDto.Items;

            await eShopDbContext.SaveChangesAsync(cancellationToken);

            return Ok("Order succsessfuly updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(
            [FromBody, BindRequired] Order orderDto,
            CancellationToken cancellationToken)
        {
            var order = await eShopDbContext.Orders.SingleOrDefaultAsync(i => i.Id == orderDto.Id, cancellationToken);
            if (order == default)
            {
                return NotFound("Order with provided Id not found");
            }

            eShopDbContext.Orders.Remove(order);
            await eShopDbContext.SaveChangesAsync(cancellationToken);

            return Ok("Order succsessfuly deleted");
        }
    }
}
