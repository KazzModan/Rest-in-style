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
    public class User : TEntity
    {
        string Name { get; set; }
        [Required]
        [MinLength(3)]
        string Email { get; set; }
        [Required]
        string Password { get; set; }
        [NotMapped]
        public ICollection<Review> ReviewList { get; set; }
    }
}
