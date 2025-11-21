using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Presistences.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistences.Repositories
{
    internal class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDbContext _dbContext;
        public GenericRepository(StoreDbContext dbContext) { 
            _dbContext = dbContext;
        }
        public async Task AddAsync(TEntity entity)
            => _dbContext.Set<TEntity>().AddAsync(entity);

        public void Delete(TEntity entity)
            => _dbContext.Set<TEntity>().Remove(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool asNotracking = false) 
            => asNotracking ? await _dbContext.Set<TEntity>().ToListAsync() : await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();

        //check local first then database
        public async Task<TEntity> GetAsync(TKey key)
            => await _dbContext.Set<TEntity>().FindAsync(key);
        

        public void Update(TEntity entity)
            => _dbContext?.Set<TEntity>().Update(entity);
    }
}
