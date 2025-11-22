using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        //Criteria ---> where(p => p.Id)
        public Expression<Func<TEntity, bool>>? Criteria { get; } //p.id
        //include ---> Include(P => P.ProductBrand)
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } 
    }
}
