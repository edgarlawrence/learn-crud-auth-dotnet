using API_practice.Interface;
using API_practice.Model;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API_practice.Controller
{
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet]
        public ActionResult<List<Cart>> GetCartItems()
        {
            return Ok(GetCartItems());
        }

        [HttpGet("{id}")]
        public ActionResult<Cart> GetCartItem(int id)
        {
            var item = GetCartItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost("/cart")]
        public ActionResult AddCartItem(Cart item)
        {
            AddCartItem(item);
            return CreatedAtAction(nameof(GetCartItem), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCartItem(int id, Cart item)
        {
            UpdateCartItem(id, item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCartItem(int id)
        {
            DeleteCartItem(id);
            return NoContent();
        }
    }
}
