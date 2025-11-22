using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    internal class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        #region Critera
        protected BaseSpecifications(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }
        //set the criteria
        public Expression<Func<TEntity, bool>> Criteria { get; private set; }

        #endregion


        #region order by
        public Expression<Func<TEntity, object>>? OrderBy { get; private set; }
        public Expression<Func<TEntity, object>>? OrderByDesc { get; private set; }
        protected void SetOrderBy(Expression<Func<TEntity, object>> orderByExpression)
            => OrderBy = orderByExpression;
        protected void SetOrderByDesc(Expression<Func<TEntity, object>> orderByDescExpression)
            => OrderBy = orderByDescExpression;
        #endregion

        #region Include exoression
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new();
        protected void AddIncludes(Expression<Func<TEntity, object>> includeExpression)
            => IncludeExpressions.Add(includeExpression);
        #endregion

    }
}
