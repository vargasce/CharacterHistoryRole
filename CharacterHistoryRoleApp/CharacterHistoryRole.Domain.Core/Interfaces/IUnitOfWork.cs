using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHistoryRole.Domain.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRelationalRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        Task<bool> CommitAsync(bool dispatchEvents = true);
    }
}
