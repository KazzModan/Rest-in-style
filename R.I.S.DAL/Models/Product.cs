using R.I.S.DAL.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.I.S.DAL.Models
{
    public class Product : TEntity
    {
        [Required]
        [MinLength(3)]
        string Name { get; set; }
        [Required]
        int Price { get; set; }
        [Required]
        int Quantity { get; set; }
        [Required]
        Guid Product_type_id { get; set; }
        [Required]
        Guid Brand_id { get; set; }
        [NotMapped]
        Category Category { get; set; }
        [NotMapped]
        Brand Brand { get; set; }
    }
}
