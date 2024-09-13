using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace R.I.S.BLL.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Photo { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public string BrName { get; set; }
        public string CtName { get; set; }
    }
}
