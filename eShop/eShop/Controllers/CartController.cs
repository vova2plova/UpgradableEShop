using eShop.Data;
using eShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace eShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CartController(EShopDbContext eShopDbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<List<Cart>> GetAllCarts()
        {
            return await eShopDbContext.Carts.ToListAsync();
        }

        [HttpGet("{userId}")]
        public async Task<List<CartItem>> GetItemsFromUserCart(Guid userId)
        {
            var cart = await eShopDbContext.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart == null)
            {
                cart = new Cart();
                await eShopDbContext.SaveChangesAsync();
            }

            return cart.CartItems;
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToUserCart(Guid userId, CartItem cartItem)
        {
            var cart = await eShopDbContext.Carts.FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart();
            }
            cart.CartItems.Add(cartItem);
            await eShopDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItemsInUserCart(Guid userId, CartItem cartItemDbo)
        {
            var cart = await eShopDbContext.Carts.FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                return NotFound();
            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.Equals(cartItemDbo));
            if (cartItem == null)
            {
                return NotFound();
            }

            cartItem.Item = cartItemDbo.Item;
            cartItem.Quantity = cartItemDbo.Quantity;
            
            await eShopDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
