using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_api.IRepository;
using shop_api.Models;

namespace shop_api.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _IProduct;
        public ProductController(IProductRepository IProduct)
        {
            _IProduct = IProduct;
        }
        [HttpGet("getAllProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> getAllProducts()
        {
            return await Task.FromResult(_IProduct.GetAllProducts());
        }
        [HttpGet("getProduct/{Id}")]
        public async Task<ActionResult<Product>> getProduct(Guid Id)
        {
            var product = await Task.FromResult(_IProduct.GetProduct(Id));
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost("addProduct")]
        public async Task<ActionResult<Product>> addProduct(Product product)
        {
            _IProduct.AddProduct(product);
            return await Task.FromResult(product);
        }
        [HttpPut("editProduct/{Id}")]
        public async Task<ActionResult<Product>> editCategory(Guid Id, Product product)
        {
            if (Id != product.Id)
            {
                return BadRequest();
            }
            try
            {
                _IProduct.UpdateProduct(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_IProduct.CheckProduct(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(product);
        }
        [HttpDelete("deleteProduct/{Id}")]
        public async Task<ActionResult<Product>> Delete(Guid Id)
        {
            var product = _IProduct.DeleteProduct(Id);
            return await Task.FromResult(product);
        }
    }
}
