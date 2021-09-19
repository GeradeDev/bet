using BestShop.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestShop.Api.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private BetShopDbContext db;

        public UnitOfWork(BetShopDbContext dbContext)
        {
            db = dbContext;
        }

        public T GetRepository<T>() where T : class
        {
            var result = (T)Activator.CreateInstance(typeof(T), db);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
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
