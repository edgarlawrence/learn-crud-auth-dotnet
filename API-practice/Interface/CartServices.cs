using API_practice.Context;
using API_practice.DTO;
using API_practice.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_practice.Interface
{
    public class CartServices : ICartService
    {
        private readonly AppDbContext _appDbContext;

        private List<Cart> cartItems = new List<Cart>();

        public CartServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddCartItem(Cart item)
        {
            item.Id = cartItems.Count + 1;
            cartItems.Add(item);
        }

        public void DeleteCartItem(int id)
        {
            var itemToRemove = GetCartItem(id);
            if(itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
            }
        }

        public Cart GetCartItem(int id)
        {
            return cartItems.FirstOrDefault(item => item.Id == id);
        }

        public List<Cart> GetCartItems()
        {
            return cartItems;
        }

        public void UpdateCartItem(int id, Cart item)
        {
            var existingItem = GetCartItem(id);
            if(existingItem != null)
            {
                existingItem.Music = item.Music;
                existingItem.Quantity = item.Quantity;
            }
        }
    }
}
