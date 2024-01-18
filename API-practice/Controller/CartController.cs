using API_practice.Context;
using Microsoft.AspNetCore.Mvc;

namespace API_practice.Controller
{
    public class CartController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CartController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            // Retrieve the user's cart items based on user authentication (you may use a more secure approach)
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account"); // Redirect to login if the user is not authenticated
            }

            var user = _context.Users.FirstOrDefault(u => u.UserName == username);
            var cartItems = _context.CartItems.Where(c => c.UserId == user.Id).ToList();


            return StatusCode(StatusCodes.Status200OK, cartItems);
        }
    }
}
