using Microsoft.EntityFrameworkCore;
using shop_api.Data;
using shop_api.IRepository;
using shop_api.Models;

namespace shop_api.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ShopDbContext _db;
        public CartRepository(ShopDbContext db)
        {
            _db = db;
        }
        public void AddToCart(Cart cart)
        {
            try {
                _db.Carts.Add(cart);
                _db.SaveChanges();

            } catch
            {
                throw;
            }
        }

        public void DeleteItem(Guid Id)
        {
            try
            {
                Cart? cart = _db.Carts.Find(Id);
               
                if (cart != null)
                {
                    _db.Carts.Remove(cart);
                    _db.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<Cart> GetCart(Guid userId)
        {
            try {
                return _db.Carts.Where(c => c.UserId == userId).ToList();
            }catch 
            {
                throw;
            }
        }
        
        public void UpdateItem(Cart cart)
        {
            try
            {
                _db.Entry(cart).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
