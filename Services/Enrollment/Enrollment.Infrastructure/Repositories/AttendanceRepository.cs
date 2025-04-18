using Enrollment.Domain.Entities;
using Enrollment.Domain.Repositories;
using Enrollment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Enrollment.Infrastructure.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Attendance?> GetById(int id, CancellationToken cancellationToken = default)
        {
            Attendance? attendance = await _context.Attendances
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.IsDeleted != true && x.Id == id, cancellationToken);

            return attendance;
        }

        public async Task<bool> AttendanceExists(int studentId, int courseId)
        {
            bool exists = await _context.Attendances
                .AsNoTracking()
                .AnyAsync(x => x.StudentId == studentId &&
                            x.CourseId == courseId &&
                            x.IsDeleted != true);

            return exists;
        }

        public async Task<IReadOnlyList<Attendance>> GetAll(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<Attendance> attendances = await _context.Attendances
                .AsNoTracking()
                .Where(x => x.IsDeleted != true)
                .ToListAsync();

            return attendances;
        }

        public Task<Attendance> GetAttendanceByStudentAndCourse(int studentId, int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Attendance>> GetAttendancesByCourseId(int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Attendance>> GetAttendancesByDateRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Attendance>> GetAttendancesByStudentId(int studentId)
        {
            throw new NotImplementedException();
        }

        public Task Create(Attendance entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task CreateRange(IEnumerable<Attendance> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Attendance>> Find(Expression<Func<Attendance, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Update(Attendance entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        public Task Delete(Attendance entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
