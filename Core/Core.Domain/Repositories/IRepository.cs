using Core.Domain.Entities;
using System.Linq.Expressions;

namespace Core.Domain.Repositories
{
    public interface IRepository<T, TId> where T : IBaseEntity<TId>
    {
        Task<T?> GetById(TId id);
        Task<IReadOnlyList<T>> GetAll();
        Task<IReadOnlyList<T>> Find(Expression<Func<T, bool>> predicate);
        Task Create(T entity);
        Task CreateRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
    }
}
