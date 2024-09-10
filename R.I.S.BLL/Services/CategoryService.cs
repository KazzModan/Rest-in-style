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
    public class CategoryService : ICategoryService

    {
        private readonly IRepository<Category> _CategoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private bool disposed = false;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _CategoryRepository = _unitOfWork.GetRepository<Category>();
            _mapper = mapper;
        }

        public async Task AddCategory(CategoryDTO Category)
        {
            await _CategoryRepository.Create(_mapper.Map<Category>(Category)).ConfigureAwait(false);
        }
        public async Task DeleteCategory(Guid id)
        {
            await _CategoryRepository.Delete(id).ConfigureAwait(false);
        }
        public async Task<ICollection<CategoryDTO>> GetAllCategorys()
        {
            var Categorys = await _CategoryRepository.Get().ConfigureAwait(false);
            var CategoryDTOs = _mapper.Map<ICollection<CategoryDTO>>(Categorys);

            return CategoryDTOs;
        }
        public async Task<CategoryDTO> GetCategoryById(Guid id)
        {
            var Category = await _CategoryRepository.GetById(id).ConfigureAwait(false);
            var dto = _mapper.Map<CategoryDTO>(Category);
            return dto;
        }
        public async Task UpdateCategory(CategoryDTO Category)
        {
            await _CategoryRepository.Update(_mapper.Map<Category>(Category)).ConfigureAwait(false);
        }
    }
}