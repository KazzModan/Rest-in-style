﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace R.I.S.DAL.Abstracts
{
    public interface IRepository<T> where T : TEntity
    {
        Task<ICollection<T>> Get(Expression<Func<T, bool>> filter = null);
        Task<T> GetById(Guid id);
        Task Create(T entity, string createBody = null);
        Task Update(T entity, string modifieBody = null);
        Task Delete(Guid id);
    }
}

