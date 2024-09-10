using Microsoft.AspNetCore.Mvc;
using R.I.S.BLL.DTO;
using R.I.S.BLL.Services.Abstraction;

namespace R.I.S.WebAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class BrandController : ControllerBase
        {
            IBrandService _BrandService;
            public BrandController(IBrandService BrandService)
            {
                _BrandService = BrandService;
            }
            [HttpGet]
            public async Task<IActionResult> GetBrands()
            {
                try
                {
                    var Brands = await _BrandService.GetAllBrands().ConfigureAwait(false);
                    return Ok(Brands);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "An error occurred while processing your request.");
                }
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetBrandByID(Guid id)
            {
                try
                {
                    var Brand = await _BrandService.GetBrandById(id).ConfigureAwait(false);
                    return Ok(Brand);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "An error occurred while processing your request.");
                }
            }
            [HttpPost]
            public async Task<IActionResult> PostBrandt(BrandDTO Brand)
            {
                try
                {
                    await _BrandService.AddBrand(Brand).ConfigureAwait(false);
                    return Ok();
                }
                catch (Exception)
                {
                    return StatusCode(500, "An error occurred while processing your request.");
                }
            }
            [HttpPut]
            public async Task<IActionResult> PutBrand(BrandDTO Brand)
            {
                try
                {
                    await _BrandService.UpdateBrand(Brand).ConfigureAwait(false);
                    return Ok();
                }
                catch (Exception)
                {
                    return StatusCode(500, "An error occurred while processing your request.");
                }
            }
            [HttpDelete]
            public async Task<IActionResult> DeleteBrand(Guid id)
            {
                try
                {
                    await _BrandService.DeleteBrand(id).ConfigureAwait(false);
                    return Ok();
                }
                catch (Exception)
                {
                    return StatusCode(500, "An error occurred while processing your request.");
                }
            }
        }
}
