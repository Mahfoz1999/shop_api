using shop_api.Models;

namespace shop_api.IRepository
{
    public interface IProductRepository
    {
        public List<Product> GetAllProducts();
        public Product GetProduct(Guid Id);
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public Product DeleteProduct(Guid Id);
        public bool CheckProduct(Guid Id);
    }
}
