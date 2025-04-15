using Academic.Domain.Entities;
using Core.Domain.Repositories;

namespace Academic.Domain.Repositories
{
    public interface IProgramRepository : IRepository<Program, int>
    {
        Task<Program?> GetByCode(string code, CancellationToken cancellationToken = default);
        Task<IEnumerable<Program>> GetByName(string name, CancellationToken cancellationToken = default);
        Task<Program?> GetByCourse(Course course, CancellationToken cancellationToken = default);
    }
}
