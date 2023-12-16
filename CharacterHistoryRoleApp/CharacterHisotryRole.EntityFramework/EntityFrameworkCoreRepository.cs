using AutoMapper;
using AutoMapper.QueryableExtensions;
using CharacterHistoryRole.Domain.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHisotryRole.EntityFramework
{
    public class EntityFrameworkCoreRepository<T> : IRelationalRepository<T> where T : class
    {
        protected readonly IMapper _mapper;
        
        public EntityFrameworkCoreRepository(DbContext context, IMapper mapper)
        {
            _mapper = mapper;
            Context = context;            
            Context.ChangeTracker.AutoDetectChangesEnabled = true;
            Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
        }

        public IQueryable<T> Queryable => Set.AsNoTracking();

        protected DbSet<T> Set => Context.Set<T>();

        protected DbContext Context { get; }

        public void Add(T item)
        {
            Set.Add(item);
        }

        public async Task AddAsync(T item)
        {
            await Set.AddAsync(item).ConfigureAwait(false);
        }

        public async Task AddIfNotExistsAsync(T item, Expression<Func<T, bool>> predicate = null)
        {
            var exists = predicate != null ? Set.Any(predicate) : Set.Any();
            if (!exists)
            {
                await Set.AddAsync(item).ConfigureAwait(false);
            }
        }

        public void AddRange(IEnumerable<T> list)
        {
            Set.AddRange(list);
        }

        public async Task AddRangeAsync(IEnumerable<T> list)
        {
            await Set.AddRangeAsync(list).ConfigureAwait(false);
        }

        public bool Any()
        {
            return Queryable.Any();
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            return Queryable.Any(where);
        }

        public Task<bool> AnyAsync()
        {
            return Queryable.AnyAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            return Queryable.AnyAsync(where);
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableInclude(include).AnyAsync(where);
        }

        public async Task<bool> AnyAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).AnyAsync();
        }

        public long Count()
        {
            return Queryable.LongCount();
        }

        public long Count(Expression<Func<T, bool>> where)
        {
            return Queryable.LongCount(where);
        }

        public Task<long> CountAsync()
        {
            return Queryable.LongCountAsync();
        }

        public Task<long> CountAsync(Expression<Func<T, bool>> where)
        {
            return Queryable.LongCountAsync(where);
        }

        public void Delete(params object[] key)
        {
            Set.Remove(Select(key));
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            Set.RemoveRange(List(where));
        }

        public async Task DeleteAsync(params object[] key)
        {
            Delete(key);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> where)
        {
            Delete(where);
            await Task.CompletedTask;
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where)
        {
            return QueryableWhere(where).FirstOrDefault();
        }

        public T FirstOrDefault(params Expression<Func<T, object>>[] include)
        {
            return QueryableInclude(include).FirstOrDefault();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).FirstOrDefault();
        }

        public T FirstOrDefaultOrderByDescending(Expression<Func<T, object>> orderBy, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).OrderByDescending(orderBy).FirstOrDefault();
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return QueryableWhere(where).FirstOrDefaultAsync();
        }

        public Task<T> FirstOrDefaultAsync(params Expression<Func<T, object>>[] include)
        {
            return QueryableInclude(include).FirstOrDefaultAsync();
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).FirstOrDefaultAsync();
        }

        public TEntityResult FirstOrDefaultResult<TEntityResult>(Expression<Func<T, bool>> where, Expression<Func<T, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).FirstOrDefault();
        }

        public Task<TEntityResult> FirstOrDefaultResultAsync<TEntityResult>(Expression<Func<T, bool>> where, Expression<Func<T, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).FirstOrDefaultAsync();
        }

        public T LastOrDefault(params Expression<Func<T, object>>[] include)
        {
            return QueryableInclude(include).LastOrDefault();
        }

        public T LastOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).LastOrDefault();
        }

        public Task<T> LastOrDefaultAsync(params Expression<Func<T, object>>[] include)
        {
            return QueryableInclude(include).LastOrDefaultAsync();
        }

        public Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).LastOrDefaultAsync();
        }

        public TEntityResult LastOrDefaultResult<TEntityResult>(Expression<Func<T, bool>> where, Expression<Func<T, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).LastOrDefault();
        }

        public Task<TEntityResult> LastOrDefaultResultAsync<TEntityResult>(Expression<Func<T, bool>> where, Expression<Func<T, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).LastOrDefaultAsync();
        }

        public IEnumerable<T> List()
        {
            return Queryable.ToList();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> where)
        {
            return QueryableWhere(where).ToList();
        }

        public IEnumerable<T> List(params Expression<Func<T, object>>[] include)
        {
            return QueryableInclude(include).ToList();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).ToList();
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await Queryable.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where)
        {
            return await QueryableWhere(where).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> ListAsync(params Expression<Func<T, object>>[] include)
        {
            return await QueryableInclude(include).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return await QueryableWhereInclude(where, include).ToListAsync().ConfigureAwait(false);
        }

        public T Select(params object[] key)
        {
            return Set.Find(key);
        }

        public async Task<T> SelectAsync(params object[] key)
        {
            return await Set.FindAsync(key);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where)
        {
            return QueryableWhere(where).SingleOrDefault();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).SingleOrDefault();
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return QueryableWhere(where).SingleOrDefaultAsync();
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).SingleOrDefaultAsync();
        }

        public TEntityResult SingleOrDefaultResult<TEntityResult>(Expression<Func<T, bool>> where, Expression<Func<T, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).SingleOrDefault();
        }

        public Task<TEntityResult> SingleOrDefaultResultAsync<TEntityResult>(Expression<Func<T, bool>> where, Expression<Func<T, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).SingleOrDefaultAsync();
        }

        public void Update(T item, params object[] key)
        {
            //Not update navigation properties
            Context.Entry(Select(key)).CurrentValues.SetValues(item);
        }

        public async Task UpdateAsync(T item, params object[] key)
        {
            Update(item, key);
            await Task.CompletedTask;
        }

        private static IQueryable<T> Include(IQueryable<T> queryable, Expression<Func<T, object>>[] properties)
        {
            properties?.ToList().ForEach(property => queryable = queryable.Include(property));
            return queryable;
        }

        private IQueryable<T> QueryableInclude(Expression<Func<T, object>>[] include)
        {
            return Include(Queryable, include);
        }

        private IQueryable<T> QueryableWhere(Expression<Func<T, bool>> where)
        {
            return Queryable.Where(where);
        }

        private IQueryable<T> QueryableWhereInclude(Expression<Func<T, bool>> where, Expression<Func<T, object>>[] include)
        {
            return Include(QueryableWhere(where), include);
        }

        private IQueryable<TEntityResult> QueryableWhereSelect<TEntityResult>(Expression<Func<T, bool>> where, Expression<Func<T, TEntityResult>> select)
        {
            return QueryableWhere(where).Select(select);
        }

        public async Task<T> FirstOrDefaultAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<T> LastOrDefaultAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<T> SingleOrDefaultAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> ListAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(Queryable, spec);
        }

        private IQueryable<T> ApplyCountSpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetCountQuery(Queryable, spec);
        }

        public async Task<IEnumerable<TEntityResult>> ListProjectToAsync<TEntityResult>(Expression<Func<T, bool>> where)
        {
            return await QueryableWhere(where)
                        .ProjectTo<TEntityResult>(_mapper.ConfigurationProvider)
                        .ToListAsync();
        }


        public async Task<TEntityResult> SingleOrDefaultProjectToAsync<TEntityResult>(Expression<Func<T, bool>> where)
        {
            return await QueryableWhere(where)
                        .ProjectTo<TEntityResult>(_mapper.ConfigurationProvider)
                        .SingleOrDefaultAsync();
        }

        public async Task<long> CountAsync(ISpecification<T> specification)
        {
            return await ApplyCountSpecification(specification).CountAsync();
        }

        public Task<T> SingleAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).SingleAsync();
        }

        public async Task<IEnumerable<T>> DistinctBy<TKey>(Func<T, TKey> select)
        {
            return Queryable.GroupBy(select).Select(x => x.First()).ToList();
        }

        public async Task<IEnumerable<T>> DistinctBy<TKey>(Func<T, TKey> select, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).GroupBy(select).Select(x => x.First()).ToList();
        }

        public async Task<IEnumerable<TEntityResult>> ListProjectToAsync<TEntityResult>(ISpecification<T> specification)
        {
            return await ApplyCountSpecification(specification)
                         .ProjectTo<TEntityResult>(_mapper.ConfigurationProvider)
                         .ToListAsync();
        }

        public async Task<decimal> SumAsync(ISpecification<T> specification, Func<T, decimal> select)
        {
            var sum = ApplyCountSpecification(specification).Sum(select);

            return await Task.FromResult(sum);
        }

    }

    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyScopeFilter<T>(this IQueryable<T> queryable, string userScope)
        {
            return queryable;
        }
    }
}
