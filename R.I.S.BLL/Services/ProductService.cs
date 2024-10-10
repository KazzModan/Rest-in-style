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
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;

namespace R.I.S.BLL.Services
{
    public class ProductService : IProductService

    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Brand> _brandRepository;
        private readonly IRepository<Category> _categoryRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _productRepository = _unitOfWork.GetRepository<Product>();
            _brandRepository = _unitOfWork.GetRepository<Brand>();
            _categoryRepository = _unitOfWork.GetRepository<Category>();
            _mapper = mapper;
        }

        public async Task AddProduct(ProductDTO product)
        {
            await _productRepository.Create(_mapper.Map<Product>(product)).ConfigureAwait(false);
        }
        public async Task DeleteProduct(Guid id)
        {
            await _productRepository.Delete(id).ConfigureAwait(false);
        }
        public async Task<ICollection<ProductDTO>> GetAllProducts(Expression<Func<Product, bool>> filter = null)
        {
            var products = await _productRepository.Get().ConfigureAwait(false);
            if (filter == null)
            {
                var productDTOs = _mapper.Map<ICollection<ProductDTO>>(products);
                foreach (var product in productDTOs)
                {
                    await MapInfo(product);
                }
                return productDTOs;
            }
            else
            {
                var filteredProducts = _mapper.Map<ICollection<ProductDTO>>(products.Where(filter.Compile()).ToList());

                foreach (var product in filteredProducts)
                {
                    await MapInfo(product);
                }

                return filteredProducts;
            }

        }
        public async Task<ProductDTO> GetProductById(Guid id)
        {
            var product = await _productRepository.GetById(id).ConfigureAwait(false);
            var dto = _mapper.Map<ProductDTO>(product);
            return await MapInfo(dto);
        }

        public async Task UpdateProduct(ProductDTO product)
        {
            await _productRepository.Update(_mapper.Map<Product>(product)).ConfigureAwait(false);
        }
        public async Task<ProductDTO> MapInfo(ProductDTO product)
        {
            var category = await _categoryRepository.GetById(product.CategoryId).ConfigureAwait(false);
            var brand = await _brandRepository.GetById(product.BrandId).ConfigureAwait(false);
            product.CtName = category.Name;
            product.BrName = brand.Name;
            return product;
        }
    }
}