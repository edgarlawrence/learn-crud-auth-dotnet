using API_practice.Model;

namespace API_practice.Interface
{
    public interface ICartService
    {
        List<Cart> GetCartItems();
        Cart GetCartItem(int id);
        void AddCartItem(Cart item);
        void UpdateCartItem(int id, Cart item);
        void DeleteCartItem(int id);
    }
}
