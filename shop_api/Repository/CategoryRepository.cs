using Microsoft.EntityFrameworkCore;
using shop_api.Data;
using shop_api.IRepository;
using shop_api.Models;

namespace shop_api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopDbContext _db;
        public CategoryRepository(ShopDbContext db)
        {
            _db = db;
        }
        public void AddCategory(Category category)
        {
            try
            {
                _db.Categories.AddAsync(category);
                _db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public bool CheckCategory(Guid Id)
        {
            return _db.Categories.Any(e => e.Id == Id);
        }

        public Category DeleteCategory(Guid Id)
        {
            try
            {
                Category? category = _db.Categories.Find(Id);
                List<Product> products = _db.Products.Where(p => p.Category!.Id == Id).ToList();
                if (category != null)
                {
                    _db.Products.RemoveRange(products);
                    _db.Categories.Remove(category);
                    _db.SaveChanges();
                    return category;
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

        public List<Category> GetAllCategory()
        {
            try
            {
                return _db.Categories.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Category GetCategory(Guid Id)
        {
            try
            {
                Category? category = _db.Categories.Find(Id);
                if (category != null)
                {
                    return category;
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

        public void UpdateCategory(Category category)
        {
            try
            {
                _db.Entry(category).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
