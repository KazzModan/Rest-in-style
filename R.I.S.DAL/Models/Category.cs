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
    public class Category : TEntity
    {
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; }
        [NotMapped]
        public ICollection<Product> ProductList { get; set; }
    }
}
