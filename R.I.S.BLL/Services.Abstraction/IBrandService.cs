using R.I.S.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.I.S.BLL.Services.Abstraction
{
    public interface IBrandService
    {
        Task<ICollection<BrandDTO>> GetAllBrands();
        Task<BrandDTO> GetBrandById(int id);
        Task DeleteBrand(int id);
        Task AddBrand(BrandDTO Brand);
        Task UpdateBrand(BrandDTO Brand);
    }
}
