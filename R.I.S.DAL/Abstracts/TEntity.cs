using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.I.S.DAL.Abstracts
{
    public abstract class TEntity
    {
        public virtual Guid Id { get; set; }
    }
}
