using R.I.S.DAL.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.I.S.DAL.Models
{
    public class Review : TEntity
    {
        [Required]
        [MinLength(3)]
        string Head { get; set; }
        [Required]
        [MinLength(10)]
        string Body { get; set; }
        [Required]
        int Rating { get; set; }
        [Required]
        Guid Product_type_id { get; set; }
        [Required]
        Guid User_id { get; set; }
        [NotMapped]
        Category Category { get; set; }
        [NotMapped]
        Brand Brand { get; set; }
    }
}
