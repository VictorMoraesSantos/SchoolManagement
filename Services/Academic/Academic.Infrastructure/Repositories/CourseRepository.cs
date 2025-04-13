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

        public async Task<Course?> GetById(int id, CancellationToken cancellationToken = default)
        {
            Course? course = await _context.Courses
                .AsNoTracking()
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.IsDeleted != true && c.Id == id, cancellationToken);

            return course;
        }

        public async Task<Course?> GetByCode(string code, CancellationToken cancellationToken = default)
        {
            Course? course = await _context.Courses
                .AsNoTracking()
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.IsDeleted != true && c.Code == code.Trim().ToUpper(), cancellationToken);

            return course;
        }

        public async Task<IEnumerable<Course>> GetByName(string name, CancellationToken cancellationToken = default)
        {
            IEnumerable<Course> courses = await _context.Courses
                .AsNoTracking()
                .Include(c => c.Department)
                .Where(c => c.IsDeleted != true && c.Name.Contains(name.Trim().ToUpper()))
                .ToListAsync(cancellationToken);

            return courses;
        }

        public async Task<IEnumerable<Course>> GetByCredits(int credits, CancellationToken cancellationToken = default)
        {
            IEnumerable<Course> courses = await _context.Courses
                .AsNoTracking()
                .Include(c => c.Department)
                .Where(c => c.IsDeleted != true && c.Credits == credits)
                .ToListAsync(cancellationToken);

            return courses;
        }

        public async Task<IEnumerable<Course>> GetByTeacherId(int teacherId, CancellationToken cancellationToken = default)
        {
            IEnumerable<Course> courses = await _context.Courses
                .AsNoTracking()
                .Include(c => c.Department)
                .Where(c => c.IsDeleted != true && c.TeacherId == teacherId)
                .ToListAsync(cancellationToken);

            return courses;
        }

        public async Task<IEnumerable<Course>> GetByStudentId(int studentId, CancellationToken cancellationToken = default)
        {
            IEnumerable<Course> courses = await _context.Courses
                .AsNoTracking()
                .Include(c => c.Department)
                .Where(c => c.IsDeleted != true && c.StudentsId.Contains(studentId))
                .ToListAsync(cancellationToken);

            return courses;
        }

        public async Task<IReadOnlyList<Course>> GetAll(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<Course> courses = await _context.Courses
                .AsNoTracking()
                .Include(c => c.Department)
                .Where(c => c.IsDeleted != true)
                .ToListAsync(cancellationToken);

            return courses;
        }

        public async Task<IReadOnlyList<Course>> Find(Expression<Func<Course, bool>> predicate, CancellationToken cancellationToken = default)
        {
            IReadOnlyList<Course> courses = await _context.Courses
                .AsNoTracking()
                .Include(c => c.Department)
                .Where(c => c.IsDeleted != true)
                .Where(predicate)
                .ToListAsync(cancellationToken);

            return courses;
        }

        public async Task Create(Course entity, CancellationToken cancellationToken = default)
        {
            _context.Courses.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task CreateRange(IEnumerable<Course> entities, CancellationToken cancellationToken = default)
        {
            await _context.Courses.AddRangeAsync(entities, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(Course entity, CancellationToken cancellationToken = default)
        {
            _context.Courses.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Course entity, CancellationToken cancellationToken = default)
        {
            _context.Courses.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
