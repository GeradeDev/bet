using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestShop.Api.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        T GetRepository<T>() where T : class;
        void Save();
    }
}
