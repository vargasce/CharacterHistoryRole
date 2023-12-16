using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHistoryRole.Domain.Core.Interfaces
{
	public interface IRelationalRepository<T> : IRepository<T> where T : class
	{
		IQueryable<T> Queryable { get; }

		T FirstOrDefault(params Expression<Func<T, object>>[] include);

		T FirstOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

		T FirstOrDefaultOrderByDescending(Expression<Func<T, object>> orderBy, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

		Task<T> FirstOrDefaultAsync(params Expression<Func<T, object>>[] include);

		Task<T> FirstOrDefaultAsync(ISpecification<T> specification);

		Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

		TResult FirstOrDefaultResult<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);

		Task<TResult> FirstOrDefaultResultAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);

		T LastOrDefault(params Expression<Func<T, object>>[] include);

		T LastOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

		Task<T> LastOrDefaultAsync(ISpecification<T> specification);

		Task<T> LastOrDefaultAsync(params Expression<Func<T, object>>[] include);

		Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

		TResult LastOrDefaultResult<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);

		Task<TResult> LastOrDefaultResultAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);

		IEnumerable<T> List(params Expression<Func<T, object>>[] include);

		IEnumerable<T> List(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

		Task<IEnumerable<T>> ListAsync(ISpecification<T> specification);

		Task<IEnumerable<T>> ListAsync(params Expression<Func<T, object>>[] include);

		Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

		Task<T> SingleAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

		T SingleOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

		Task<T> SingleOrDefaultAsync(ISpecification<T> specification);

		Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

		TResult SingleOrDefaultResult<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);

		Task<TResult> SingleOrDefaultResultAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);

		Task<IEnumerable<TEntityResult>> ListProjectToAsync<TEntityResult>(Expression<Func<T, bool>> where);

		Task<IEnumerable<TEntityResult>> ListProjectToAsync<TEntityResult>(ISpecification<T> specification);

		Task<TEntityResult> SingleOrDefaultProjectToAsync<TEntityResult>(Expression<Func<T, bool>> where);

		Task<IEnumerable<T>> DistinctBy<TKey>(Func<T, TKey> select);

		Task<IEnumerable<T>> DistinctBy<TKey>(Func<T, TKey> select, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);
	}
}
