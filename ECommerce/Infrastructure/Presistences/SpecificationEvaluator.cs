using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistences
{
    internal class SpecificationEvaluator
    {
        public static IQueryable<TEntity> GetQuery<TEntity, TKey>(IQueryable<TEntity> inputQuery, ISpecifications<TEntity, TKey> specifications) where TEntity : BaseEntity<TKey>
        {
            var query = inputQuery; //_dbContext.Set<Product>()
            if(specifications.Criteria is not null)
                query = query.Where(specifications.Criteria);
            if(specifications.IncludeExpressions?.Count > 0)
            {
                query = specifications.IncludeExpressions.Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));
            }
            if(specifications.OrderBy is not null)
                query = query.OrderBy(specifications.OrderBy);
            else if(specifications.OrderByDesc is not null)
                query = query.OrderByDescending(specifications.OrderByDesc);
            if(specifications.IsPaginated)
                query = query.Skip(specifications.Skip).Take(specifications.Take);
            return query;
        }
    }
}
