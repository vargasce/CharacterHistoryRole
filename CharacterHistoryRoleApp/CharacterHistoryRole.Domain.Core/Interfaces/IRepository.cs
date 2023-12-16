using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHistoryRole.Domain.Core.Interfaces
{
	public interface IRepository<T> where T : class
	{
		void Add(T item);

		Task AddAsync(T item);

		Task AddIfNotExistsAsync(T item, Expression<Func<T, bool>> predicate = null);

		void AddRange(IEnumerable<T> list);

		Task AddRangeAsync(IEnumerable<T> list);

		bool Any();

		bool Any(Expression<Func<T, bool>> where);

		Task<bool> AnyAsync();

		Task<bool> AnyAsync(Expression<Func<T, bool>> where);

		Task<bool> AnyAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

		Task<bool> AnyAsync(ISpecification<T> specification);

		long Count();

		long Count(Expression<Func<T, bool>> where);

		Task<long> CountAsync();

		Task<long> CountAsync(Expression<Func<T, bool>> where);

		Task<long> CountAsync(ISpecification<T> specification);

		void Delete(params object[] key);

		void Delete(Expression<Func<T, bool>> where);

		Task DeleteAsync(params object[] key);

		Task DeleteAsync(Expression<Func<T, bool>> where);

		T FirstOrDefault(Expression<Func<T, bool>> where);

		Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where);

		IEnumerable<T> List();

		IEnumerable<T> List(Expression<Func<T, bool>> where);

		Task<IEnumerable<T>> ListAsync();

		Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where);

		T Select(params object[] key);

		Task<T> SelectAsync(params object[] key);

		T SingleOrDefault(Expression<Func<T, bool>> where);

		Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where);

		void Update(T item, params object[] key);

		Task UpdateAsync(T item, params object[] key);

		Task<decimal> SumAsync(ISpecification<T> specification, Func<T, decimal> select);
	}
}
