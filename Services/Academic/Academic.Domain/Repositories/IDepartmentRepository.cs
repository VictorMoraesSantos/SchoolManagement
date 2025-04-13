using Academic.Domain.Entities;
using Core.Domain.Repositories;

namespace Academic.Domain.Repositories
{
    public interface IDepartmentRepository : IRepository<Department, int>
    {
        Task<Department?> GetByCode(string code, CancellationToken cancellationToken);
        Task<IEnumerable<Department?>> GetByName(string name, CancellationToken cancellationToken);
        Task<Department?> GetByCourse(Course course, CancellationToken cancellationToken);
        Task<Department?> GetByTeacherId(int id, CancellationToken cancellationToken);
    }
}
