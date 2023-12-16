using AutoMapper;
using CharacterHistoryRole.Domain.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace CharacterHisotryRole.EntityFramework
{
    public abstract class BaseUnitOfWork : IUnitOfWork
    {
        protected readonly DbContext _context;
        protected readonly IMapper _mapper;                
        protected Hashtable _repositories;

        protected BaseUnitOfWork(DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;            
        }

        public async Task<bool> CommitAsync(bool dispatchEvents = true)
        {
            var result = await _context.SaveChangesAsync() > 0;

            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IRelationalRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(EntityFrameworkCoreRepository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                        .MakeGenericType(typeof(TEntity)), _context, _mapper);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRelationalRepository<TEntity>)_repositories[type];
        }
    }
}