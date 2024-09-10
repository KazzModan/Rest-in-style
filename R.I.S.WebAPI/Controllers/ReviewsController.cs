using Microsoft.AspNetCore.Mvc;
using R.I.S.BLL.DTO;
using R.I.S.BLL.Services.Abstraction;

namespace R.I.S.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        IReviewService _ReviewService;
        public ReviewController(IReviewService ReviewService)
        {
            _ReviewService = ReviewService;
        }
        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            try
            {
                var Reviews = await _ReviewService.GetAllReviews().ConfigureAwait(false);
                return Ok(Reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewByID(Guid id)
        {
            try
            {
                var Review = await _ReviewService.GetReviewById(id).ConfigureAwait(false);
                return Ok(Review);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostReviewt(ReviewDTO Review)
        {
            try
            {
                await _ReviewService.AddReview(Review).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPut]
        public async Task<IActionResult> PutReview(ReviewDTO Review)
        {
            try
            {
                await _ReviewService.UpdateReview(Review).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteReview(Guid id)
        {
            try
            {
                await _ReviewService.DeleteReview(id).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
