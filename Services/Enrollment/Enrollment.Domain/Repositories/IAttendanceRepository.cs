using Core.Domain.Repositories;
using Enrollment.Domain.Entities;

namespace Enrollment.Domain.Repositories
{
    public interface IAttendanceRepository : IRepository<Attendance, int>
    {
        Task<IEnumerable<Attendance>> GetAttendancesByStudentId(int studentId);
        Task<IEnumerable<Attendance>> GetAttendancesByCourseId(int courseId);
        Task<IEnumerable<Attendance>> GetAttendancesByDateRange(DateTime startDate, DateTime endDate);
        Task<Attendance> GetAttendanceByStudentAndCourse(int studentId, int courseId);
        Task<bool> AttendanceExists(int studentId, int courseId);
    }
}
