using R.I.S.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.I.S.BLL.Services.Abstraction
{
    public interface IProductService
    {
        Task<ICollection<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProductById(Guid id);
        Task DeleteProduct(Guid id);
        Task AddProduct(ProductDTO Product);
        Task UpdateProduct(ProductDTO Product);
    }
}
