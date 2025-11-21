using Domain.Contracts;
using Domain.Entities;
using Presistences.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistences.Repositories
{
    public class UniteOfWork : IUniteOfWork
    {
        public readonly StoreDbContext _dbContext;

        private readonly ConcurrentDictionary<string, object> _repositories;

        public UniteOfWork(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new();
        }

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
            => (IGenericRepository<TEntity, TKey>)_repositories.GetOrAdd(typeof(TEntity).Name, (_) => new GenericRepository<TEntity, TKey>(_dbContext));
           //return new GenericRepository<TEntity, Tkey>(_dbContext)
           //req ----> give me 20 instances from GenericRepo
           /// Dictionary
           /// key ----> Name of Entity [product, ProductBrand, ProductType, etc]
           /// value ----> Object of Generic repo
           /// product ----> new GenericRepo<Product, int>
           /// 

            //var Key = typeof(TEntity).Name;      //product[String]
            //if (_repositories.ContainsKey(Key))
            //    _repositories[Key] = new GenericRepository<TEntity, TKey>(_dbContext);
            //return (IGenericRepository<TEntity, TKey>) _repositories[Key];

        

        public Task<int> SaveChangesAsync() => _dbContext.SaveChangesAsync();
    }
}
