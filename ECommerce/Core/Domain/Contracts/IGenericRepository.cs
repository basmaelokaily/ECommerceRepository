using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        //get all
        Task<IEnumerable<TEntity>> GetAllAsync(bool asNotracking = false);
        //get by id 
        Task<TEntity> GetAsync(TKey key);
        //create 
        Task AddAsync(TEntity entity);
        //update
        void Update(TEntity entity);
        //delete
        void Delete(TEntity entity);
    }
}
