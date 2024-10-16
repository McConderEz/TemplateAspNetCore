using Microsoft.EntityFrameworkCore;
using Template.SharedKernel.Shared;

namespace Template.Core.Specifications
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> GetQuery<TEntity, TId>(
            IQueryable<TEntity> inputQueryable,
            Specification<TEntity,TId> specification)
            where TEntity : Entity<TId>
            where TId : BaseId<TId>
        {
            IQueryable<TEntity> query = inputQueryable;

            if(specification.Criteria is not null)
            {
                query = query.Where(specification.Criteria);
            }

            specification.IncludeExpression.Aggregate(
                query,
                (current, includeExpression) =>
                    current.Include(includeExpression));

            if(specification.OrderByExpression is not null)
            {
                query = query.OrderBy(specification.OrderByExpression);
            }
            else if(specification.OrderByDescendingExpression is not null)
            {
                query = query.OrderByDescending(specification.OrderByDescendingExpression);
            }

            return query;
        }
    }
}
