using shop_api.Models;

namespace shop_api.IRepository
{
    public interface ICategoryRepository
    {
        public List<Category> GetAllCategory();
        public Category GetCategory(Guid Id);
        public void AddCategory(Category category);
        public void UpdateCategory(Category category);
        public Category DeleteCategory(Guid Id);
        public bool CheckCategory(Guid Id);
    }
}
