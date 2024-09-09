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
    public class BrandService : IBrandService

    {
        private readonly IRepository<Brand> _BrandRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private bool disposed = false;

        public BrandService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _BrandRepository = _unitOfWork.GetRepository<Brand>();
            _mapper = mapper;
        }

        public async Task AddBrand(BrandDTO Brand)
        {
            await _BrandRepository.Create(_mapper.Map<Brand>(Brand)).ConfigureAwait(false);
        }
        public async Task DeleteBrand(int id)
        {
            await _BrandRepository.Delete(id).ConfigureAwait(false);
        }
        public async Task<ICollection<BrandDTO>> GetAllBrands()
        {
            var Brands = await _BrandRepository.Get().ConfigureAwait(false);
            var BrandDTOs = _mapper.Map<ICollection<BrandDTO>>(Brands);

            return BrandDTOs;
        }
        public async Task<BrandDTO> GetBrandById(int id)
        {
            var Brand = await _BrandRepository.GetById(id).ConfigureAwait(false);
            var dto = _mapper.Map<BrandDTO>(Brand);
            return dto;
        }
        public async Task UpdateBrand(BrandDTO Brand)
        {
            await _BrandRepository.Update(_mapper.Map<Brand>(Brand)).ConfigureAwait(false);
        }
    }
}