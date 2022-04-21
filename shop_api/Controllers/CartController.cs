using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_api.IRepository;
using shop_api.Models;

namespace shop_api.Controllers
{
    [Route("api/Cart")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICartRepository _ICart;
        public CartController(ICartRepository ICart)
        {
            _ICart= ICart;
        }
        [HttpPost("addToCart")]
        public async Task<ActionResult<Cart>> addToCart(Cart cart)
        {
            _ICart.AddToCart(cart);
            return await Task.FromResult(cart);
        }
        [HttpGet("getCart/{userId}")]
        public async Task<ActionResult<IEnumerable<Cart>>> getCart(Guid userId)
        {
            return await Task.FromResult(_ICart.GetCart(userId));
        }
        [HttpPut("editCart/{Id}")]
        public async Task<ActionResult<Cart>> editCategory(Guid Id,Cart cart)
        {
            if (Id != cart.CartId)
            {
                return BadRequest();
            }
            _ICart.UpdateItem(cart);
           
            return await Task.FromResult(cart);
        }
        [HttpDelete("deleteCart/{Id}")]
        public async Task<ActionResult> deleteCart(Guid Id)
        {
            _ICart.DeleteItem(Id);
            return Ok();
        }
    }
}
