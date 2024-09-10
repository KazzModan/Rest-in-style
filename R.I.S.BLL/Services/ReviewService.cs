using AutoMapper;
using R.I.S.BLL.Services.Abstraction;
using R.I.S.DAL.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using R.I.S.DAL.Models;
using R.I.S.BLL.DTO;
namespace R.I.S.BLL.Services
{
    public class ReviewService : IReviewService

    {
        private readonly IRepository<Review> _reviewRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _reviewRepository = _unitOfWork.GetRepository<Review>();
            _mapper = mapper;
        }

        public async Task AddReview(ReviewDTO review)
        {
            await _reviewRepository.Create(_mapper.Map<Review>(review)).ConfigureAwait(false);
        }
        public async Task DeleteReview(Guid id)
        {
            await _reviewRepository.Delete(id).ConfigureAwait(false);
        }
        public async Task<ICollection<ReviewDTO>> GetAllReviews()
        {
            var reviews = await _reviewRepository.Get().ConfigureAwait(false);
            var reviewDTOs = _mapper.Map<ICollection<ReviewDTO>>(reviews);

            return reviewDTOs;
        }
        public async Task<ReviewDTO> GetReviewById(Guid id)
        {
            var review = await _reviewRepository.GetById(id).ConfigureAwait(false);
            var dto = _mapper.Map<ReviewDTO>(review);
            return dto;
        }
        public async Task UpdateReview(ReviewDTO review)
        {
            await _reviewRepository.Update(_mapper.Map<Review>(review)).ConfigureAwait(false);
        }
    }
}