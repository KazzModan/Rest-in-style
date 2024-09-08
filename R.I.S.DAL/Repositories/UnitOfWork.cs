using R.I.S.DAL.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.I.S.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public RISContext context;
        public UnitOfWork(RISContext context)
        {
            this.context = context;
        }
        public IRepository<T> GetRepository<T>() where T : TEntity
        {
            return new Repository<T>(context);
        }
        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
