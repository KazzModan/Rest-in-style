using R.I.S.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.I.S.BLL.Services.Abstraction
{
    public interface IReviewService
    {
        Task<ICollection<ReviewDTO>> GetAllReviews();
        Task<ReviewDTO> GetReviewById(Guid id);
        Task DeleteReview(Guid id);
        Task AddReview(ReviewDTO Review);
        Task UpdateReview(ReviewDTO Review);
    }
}
