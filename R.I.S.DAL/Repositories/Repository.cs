﻿using Microsoft.EntityFrameworkCore;
using R.I.S.DAL.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace R.I.S.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : TEntity
    {
        private readonly RISContext context;
        public Repository(RISContext context)
        {
            this.context = context;
        }
        public async Task<ICollection<T>> Get(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> list = context.Set<T>();
            if (filter != null)
                return await list?.Where(filter).ToListAsync();
            else return await list?.ToListAsync();
        }
        public async Task Create(T entity, string createBody = null)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task<T> GetById(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }
        public async Task Update(T entity, string updateBody = null)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task Delete(Guid id)
        {
            T entity = await context.Set<T>().FindAsync(id).ConfigureAwait(false);
            context.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
