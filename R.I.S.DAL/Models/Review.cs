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
        public string Head { get; set; }
        [Required]
        [MinLength(10)]
        public string Body { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [NotMapped]
        public Product Product { get; set; }
        [NotMapped]
        public User User { get; set; }
    }
}
