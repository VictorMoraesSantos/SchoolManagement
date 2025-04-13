using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using Academic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Academic.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Department?> GetById(int id, CancellationToken cancellationToken = default)
        {
            Department? department = await _context.Departments
                .AsNoTracking()
                .Include(d => d.Courses)
                .FirstOrDefaultAsync(d => d.IsDeleted != true && d.Id == id, cancellationToken);

            return department;
        }

        public async Task<Department?> GetByCode(string code, CancellationToken cancellationToken)
        {
            Department? department = await _context.Departments
                .AsNoTracking()
                .Include(d => d.Courses)
                .FirstOrDefaultAsync(d => d.IsDeleted != true && d.Code == code.Trim().ToUpper(), cancellationToken);

            return department;
        }

        public async Task<IEnumerable<Department?>> GetByName(string name, CancellationToken cancellationToken)
        {
            IEnumerable<Department> departments = await _context.Departments
                .AsNoTracking()
                .Include(d => d.Courses)
                .Where(d => d.Name == name.Trim().ToUpper())
                .ToListAsync(cancellationToken);

            return departments;
        }

        public async Task<Department?> GetByTeacherId(int id, CancellationToken cancellationToken)
        {
            Department? department = await _context.Departments
                .AsNoTracking()
                .Include(d => d.Courses)
                .FirstOrDefaultAsync(d => d.IsDeleted != true && d.TeachersId.Contains(id), cancellationToken);

            return department;
        }

        public async Task<Department?> GetByCourse(Course course, CancellationToken cancellationToken)
        {
            Department? department = await _context.Departments
                .AsNoTracking()
                .Include(d => d.Courses)
                .FirstOrDefaultAsync(d => d.IsDeleted != true && d.Courses.Contains(course), cancellationToken);

            return department;
        }

        public async Task<IReadOnlyList<Department?>> GetAll(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<Department?> departments = await _context.Departments
                .AsNoTracking()
                .Include(d => d.Courses)
                .Where(d => d.IsDeleted != true)
                .ToListAsync(cancellationToken);

            return departments;
        }

        public async Task<IReadOnlyList<Department?>> Find(
            Expression<Func<Department, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            IReadOnlyList<Department?> departments = await _context.Departments
                .AsNoTracking()
                .Include(d => d.Courses)
                .Where(predicate)
                .ToListAsync(cancellationToken);

            return departments;
        }

        public async Task Create(Department entity, CancellationToken cancellationToken = default)
        {
            _context.Departments.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task CreateRange(
            IEnumerable<Department> entities,
            CancellationToken cancellationToken = default)
        {
            await _context.Departments.AddRangeAsync(entities, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(Department entity, CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Department entity, CancellationToken cancellationToken = default)
        {
            _context.Departments.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}