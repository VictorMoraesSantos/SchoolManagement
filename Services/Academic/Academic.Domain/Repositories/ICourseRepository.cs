using Academic.Domain.Entities;
using Core.Domain.Repositories;

namespace Academic.Domain.Repositories
{
    public interface ICourseRepository : IRepository<Course, int>
    {
        Task<Course?> GetByCode(string code, CancellationToken cancellationToken = default);
        Task<IEnumerable<Course>> GetByName(string name, CancellationToken cancellationToken = default);
        Task<IEnumerable<Course>> GetByCredits(int credits, CancellationToken cancellationToken = default);
        Task<IEnumerable<Course>> GetByTeacherId(int teacherId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Course>> GetByStudentId(int studentId, CancellationToken cancellationToken = default);
    }
}
