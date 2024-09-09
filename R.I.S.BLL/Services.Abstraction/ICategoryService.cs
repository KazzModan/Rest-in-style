using R.I.S.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.I.S.BLL.Services.Abstraction
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDTO>> GetAllCategorys();
        Task<CategoryDTO> GetCategoryById(int id);
        Task DeleteCategory(int id);
        Task AddCategory(CategoryDTO Category);
        Task UpdateCategory(CategoryDTO Category);
    }
}
