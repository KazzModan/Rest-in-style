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
    public class ProductService : IProductService

    {
        private readonly IRepository<Product> _ProductRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private bool disposed = false;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _ProductRepository = _unitOfWork.GetRepository<Product>();
            _mapper = mapper;
        }

        public async Task AddProduct(ProductDTO Product)
        {
            await _ProductRepository.Create(_mapper.Map<Product>(Product)).ConfigureAwait(false);
        }
        public async Task DeleteProduct(Guid id)
        {
            await _ProductRepository.Delete(id).ConfigureAwait(false);
        }
        public async Task<ICollection<ProductDTO>> GetAllProducts()
        {
            var Products = await _ProductRepository.Get().ConfigureAwait(false);
            var ProductDTOs = _mapper.Map<ICollection<ProductDTO>>(Products);

            return ProductDTOs;
        }
        public async Task<ProductDTO> GetProductById(Guid id)
        {
            var Product = await _ProductRepository.GetById(id).ConfigureAwait(false);
            var dto = _mapper.Map<ProductDTO>(Product);
            return dto;
        }
        public async Task UpdateProduct(ProductDTO Product)
        {
            await _ProductRepository.Update(_mapper.Map<Product>(Product)).ConfigureAwait(false);
        }
    }
}