using Microsoft.AspNetCore.Mvc;
using R.I.S.BLL.DTO;
using R.I.S.BLL.Services.Abstraction;

namespace R.I.S.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _ProductService;
        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var Products = await _ProductService.GetAllProducts().ConfigureAwait(false);
                return Ok(Products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByID(Guid id)
        {
            try
            {
                var Product = await _ProductService.GetProductById(id).ConfigureAwait(false);
                return Ok(Product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostProductt(ProductDTO Product)
        {
            try
            {
                await _ProductService.AddProduct(Product).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPut]
        public async Task<IActionResult> PutProduct(ProductDTO Product)
        {
            try
            {
                await _ProductService.UpdateProduct(Product).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            try
            {
                await _ProductService.DeleteProduct(id).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
