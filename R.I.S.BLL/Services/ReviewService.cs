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
        private readonly IRepository<Review> _ReviewRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private bool disposed = false;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _ReviewRepository = _unitOfWork.GetRepository<Review>();
            _mapper = mapper;
        }

        public async Task AddReview(ReviewDTO Review)
        {
            await _ReviewRepository.Create(_mapper.Map<Review>(Review)).ConfigureAwait(false);
        }
        public async Task DeleteReview(int id)
        {
            await _ReviewRepository.Delete(id).ConfigureAwait(false);
        }
        public async Task<ICollection<ReviewDTO>> GetAllReviews()
        {
            var Reviews = await _ReviewRepository.Get().ConfigureAwait(false);
            var ReviewDTOs = _mapper.Map<ICollection<ReviewDTO>>(Reviews);

            return ReviewDTOs;
        }
        public async Task<ReviewDTO> GetReviewById(int id)
        {
            var Review = await _ReviewRepository.GetById(id).ConfigureAwait(false);
            var dto = _mapper.Map<ReviewDTO>(Review);
            return dto;
        }
        public async Task UpdateReview(ReviewDTO Review)
        {
            await _ReviewRepository.Update(_mapper.Map<Review>(Review)).ConfigureAwait(false);
        }
    }
}