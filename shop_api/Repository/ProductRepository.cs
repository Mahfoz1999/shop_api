using Microsoft.EntityFrameworkCore;
using shop_api.Data;
using shop_api.IRepository;
using shop_api.Models;

namespace shop_api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopDbContext _db;
        public ProductRepository(ShopDbContext db)
        {
            _db = db;
        }
        public void AddProduct(Product product)
        {
            try
            {
                _db.Products.AddAsync(product);
                _db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public bool CheckProduct(Guid Id)
        {
            return _db.Products.Any(e => e.Id == Id);
        }

        public Product DeleteProduct(Guid Id)
        {
            try
            {
                Product? product = _db.Products.Find(Id);
                if (product != null)
                {
                    _db.Products.Remove(product);
                    _db.SaveChanges();
                    return product;
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

        public List<Product> GetAllProducts()
        {

            try
            {
                return _db.Products.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Product GetProduct(Guid Id)
        {
            try
            {
                Product? product = _db.Products.Find(Id);
                if (product != null)
                {
                    return product;
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

        public void UpdateProduct(Product product)
        {
            try
            {
                _db.Entry(product).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
