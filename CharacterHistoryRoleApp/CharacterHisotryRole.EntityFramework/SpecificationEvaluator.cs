using CharacterHistoryRole.Domain.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHisotryRole.EntityFramework
{
    public class SpecificationEvaluator<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        {
            var query = inputQuery;

            if (specification.Where != null)
            {
                query = query.Where(specification.Where);
            }

            query = specification.Includes.Aggregate(query,
                                    (current, include) => current.Include(include));

            query = specification.IncludeStrings.Aggregate(query,
                                    (current, include) => current.Include(include));

            if (specification.OrderBy != null)
            {
                if (specification.OrderDirection.Equals("asc"))
                {
                    query = query.OrderBy(specification.OrderBy);
                }
                else if (specification.OrderDirection.Equals("desc"))
                {
                    query = query.OrderByDescending(specification.OrderBy);
                }
            }

            if (specification.GroupBy != null)
            {
                query = query.GroupBy(specification.GroupBy).SelectMany(x => x);
            }

            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip)
                             .Take(specification.Take);
            }
            return query;
        }

        public static IQueryable<TEntity> GetCountQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        {
            var query = inputQuery;

            if (specification.Where != null)
            {
                query = query.Where(specification.Where);
            }

            return query;
        }
    }
}
