using shop_api.Models;

namespace shop_api.IRepository
{
    public interface ICartRepository
    {
        public void AddToCart(Cart cart);
        public void DeleteItem(Guid Id);
        public void UpdateItem(Cart cart);
        public List<Cart> GetCart(Guid userId);
    }
}
