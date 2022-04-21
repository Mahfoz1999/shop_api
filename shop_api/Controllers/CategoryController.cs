using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_api.IRepository;
using shop_api.Models;

namespace shop_api.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _ICategory;
        public CategoryController(ICategoryRepository ICategory)
        {
            _ICategory = ICategory;
        }
        [HttpGet("getAllCategories")]
        public async Task<ActionResult<IEnumerable<Category>>> getAllCategories()
        {
            return await Task.FromResult(_ICategory.GetAllCategory());
        }
        [HttpGet("getCategory/{Id}")]
        public async Task<ActionResult<Category>> getCategory(Guid Id)
        {
            var category = await Task.FromResult(_ICategory.GetCategory(Id));
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPost("addCategory")]
        public async Task<ActionResult<Category>> addCategory(Category category)
        {
            _ICategory.AddCategory(category);
            return await Task.FromResult(category);
        }
        [HttpPut("editCategory/{Id}")]
        public async Task<ActionResult<Category>> editCategory(Guid Id, Category category)
        {
            if (Id != category.Id)
            {
                return BadRequest();
            }
            try
            {
                _ICategory.UpdateCategory(category);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_ICategory.CheckCategory(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(category);
        }
        [HttpDelete("deleteCategory/{Id}")]
        public async Task<ActionResult<Category>> Delete(Guid Id)
        {
            var category = _ICategory.DeleteCategory(Id);
            return await Task.FromResult(category);
        }
    }
}
