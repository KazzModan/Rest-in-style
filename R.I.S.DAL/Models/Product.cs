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
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string Photo { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public Guid BrandId { get; set; }
        [NotMapped]
        public Category Category { get; set; }
        [NotMapped]
        public Brand Brand { get; set; }
        [NotMapped]
        public ICollection<Review> ReviewList { get; set; }
    }
}
