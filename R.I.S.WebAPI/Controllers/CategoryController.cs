using Microsoft.AspNetCore.Mvc;
using R.I.S.BLL.DTO;
using R.I.S.BLL.Services.Abstraction;

namespace R.I.S.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _CategoryService;
        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var Categorys = await _CategoryService.GetAllCategorys().ConfigureAwait(false);
                return Ok(Categorys);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByID(Guid id)
        {
            try
            {
                var Category = await _CategoryService.GetCategoryById(id).ConfigureAwait(false);
                return Ok(Category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostCategoryt(CategoryDTO Category)
        {
            try
            {
                await _CategoryService.AddCategory(Category).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPut]
        public async Task<IActionResult> PutCategory(CategoryDTO Category)
        {
            try
            {
                await _CategoryService.UpdateCategory(Category).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            try
            {
                await _CategoryService.DeleteCategory(id).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
