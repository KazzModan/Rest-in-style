using R.I.S.DAL.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.I.S.DAL.Models
{
    public class Brand : TEntity
    {
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
