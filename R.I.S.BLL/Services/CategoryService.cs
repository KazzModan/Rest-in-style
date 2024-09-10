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
        private readonly IRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = _unitOfWork.GetRepository<Category>();
            _mapper = mapper;
        }

        public async Task AddCategory(CategoryDTO category)
        {
            await _categoryRepository.Create(_mapper.Map<Category>(category)).ConfigureAwait(false);
        }
        public async Task DeleteCategory(Guid id)
        {
            await _categoryRepository.Delete(id).ConfigureAwait(false);
        }
        public async Task<ICollection<CategoryDTO>> GetAllCategorys()
        {
            var categorys = await _categoryRepository.Get().ConfigureAwait(false);
            var categoryDTOs = _mapper.Map<ICollection<CategoryDTO>>(categorys);

            return categoryDTOs;
        }
        public async Task<CategoryDTO> GetCategoryById(Guid id)
        {
            var category = await _categoryRepository.GetById(id).ConfigureAwait(false);
            var dto = _mapper.Map<CategoryDTO>(category);
            return dto;
        }
        public async Task UpdateCategory(CategoryDTO category)
        {
            await _categoryRepository.Update(_mapper.Map<Category>(category)).ConfigureAwait(false);
        }
    }
}