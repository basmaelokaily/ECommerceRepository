using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUniteOfWork
    {
        public Task<int> SaveChangesAsync();

        IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
        // new genericRepository<product, int>();
        // new genericRepository<ProductType, int>();
        // new genericRepository<ProductBrand, int>();

    }
}
