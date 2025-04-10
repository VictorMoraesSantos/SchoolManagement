using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using Academic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Academic.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Course?> GetById(int id)
        {
            Course course = await _context.Courses
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            return course;
        }

        public async Task<Course?> GetByCode(string code, CancellationToken cancellationToken = default)
        {
            Course course = await _context.Courses
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Code == code, cancellationToken);

            return course;
        }

        public async Task<IEnumerable<Course>> GetByName(string name, CancellationToken cancellationToken = default)
        {
            IEnumerable<Course> courses = await _context.Courses
                .AsNoTracking()
                .Where(c => c.Name.Contains(name))
                .ToListAsync();

            return courses;
        }

        public async Task<IEnumerable<Course>> GetByCredits(int credits, CancellationToken cancellationToken = default)
        {
            IEnumerable<Course> courses = await _context.Courses
                .AsNoTracking()
                .Where(c => c.Credits == credits)
                .ToListAsync();

            return courses;
        }

        public async Task<IEnumerable<Course>> GetByTeacherId(int teacherId, CancellationToken cancellationToken = default)
        {
            IEnumerable<Course> courses = await _context.Courses
                .AsNoTracking()
                .Where(c => c.TeacherId == teacherId)
                .ToListAsync();

            return courses;
        }

        public async Task<IEnumerable<Course>> GetByStudentId(int studentId, CancellationToken cancellationToken = default)
        {
            IEnumerable<Course> courses = await _context.Courses
                .AsNoTracking()
                .Where(c => c.StudentsId.Contains(studentId))
                .ToListAsync();

            return courses;
        }

        public async Task<IReadOnlyList<Course>> GetAll()
        {
            IReadOnlyList<Course> courses = await _context.Courses
                .AsNoTracking()
                .ToListAsync();

            return courses;
        }

        public Task<IReadOnlyList<Course>> Find(Expression<Func<Course, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        // CREATE methods
        public Task Create(Course entity)
        {
            throw new NotImplementedException();
        }

        public Task CreateRange(IEnumerable<Course> entities)
        {
            throw new NotImplementedException();
        }

        // UPDATE method
        public void Update(Course entity)
        {
            throw new NotImplementedException();
        }

        // DELETE method
        public void Delete(Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
