using Core.Domain.Entities;
using Core.Domain.Repositories;
using System.Linq.Expressions;

namespace Core.Infrastructure.Repositories
{
    public class Repository<T, TId> : IRepository<T, TId> where T : IBaseEntity<TId>
    {
        public Task<T?> GetById(TId id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task CreateRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
