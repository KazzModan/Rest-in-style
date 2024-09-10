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
        private readonly IRepository<Brand> _brandRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BrandService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _brandRepository = _unitOfWork.GetRepository<Brand>();
            _mapper = mapper;
        }

        public async Task AddBrand(BrandDTO brand)
        {
            await _brandRepository.Create(_mapper.Map<Brand>(brand)).ConfigureAwait(false);
        }
        public async Task DeleteBrand(Guid id)
        {
            await _brandRepository.Delete(id).ConfigureAwait(false);
        }
        public async Task<ICollection<BrandDTO>> GetAllBrands()
        {
            var brands = await _brandRepository.Get().ConfigureAwait(false);
            var brandDTOs = _mapper.Map<ICollection<BrandDTO>>(brands);

            return brandDTOs;
        }
        public async Task<BrandDTO> GetBrandById(Guid id)
        {
            var brand = await _brandRepository.GetById(id).ConfigureAwait(false);
            var dto = _mapper.Map<BrandDTO>(brand);
            return dto;
        }
        public async Task UpdateBrand(BrandDTO brand)
        {
            await _brandRepository.Update(_mapper.Map<Brand>(brand)).ConfigureAwait(false);
        }
    }
}