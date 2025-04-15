using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using Academic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Academic.Infrastructure.Repositories
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly ApplicationDbContext _context;

        public ProgramRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Program?> GetById(int id, CancellationToken cancellationToken = default)
        {
            Program? program = await _context.Programs
                .AsNoTracking()
                .Include(p => p.Courses)
                .ThenInclude(d => d.Department)
                .FirstOrDefaultAsync(p => p.IsDeleted != true && p.Id == id, cancellationToken);

            return program;
        }

        public async Task<Program?> GetByCode(string code, CancellationToken cancellationToken = default)
        {
            Program? program = await _context.Programs
                .AsNoTracking()
                .Include(p => p.Courses)
                .ThenInclude(d => d.Department)
                .FirstOrDefaultAsync(p => p.IsDeleted != true && p.Code == code.Trim().ToUpper(), cancellationToken);

            return program;
        }

        public async Task<Program?> GetByCourse(Course course, CancellationToken cancellationToken = default)
        {
            Program? program = await _context.Programs
                .AsNoTracking()
                .Include(p => p.Courses)
                .ThenInclude(d => d.Department)
                .FirstOrDefaultAsync(p => p.IsDeleted != true && p.Courses.Contains(course), cancellationToken);

            return program;
        }

        public async Task<IEnumerable<Program>> GetByName(string name, CancellationToken cancellationToken = default)
        {
            IEnumerable<Program> programs = await _context.Programs
                .AsNoTracking()
                .Include(p => p.Courses)
                .ThenInclude(d => d.Department)
                .Where(p => p.IsDeleted != true && p.Name.Contains(name.Trim().ToUpper()))
                .ToListAsync(cancellationToken);

            return programs;
        }

        public async Task<IReadOnlyList<Program>> GetAll(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<Program> programs = await _context.Programs
                .AsNoTracking()
                .Include(p => p.Courses)
                .ThenInclude(d => d.Department)
                .Where(p => p.IsDeleted != true)
                .ToListAsync(cancellationToken);

            return programs;
        }

        public async Task<IReadOnlyList<Program?>> Find(
            Expression<Func<Program, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            IReadOnlyList<Program?> departments = await _context.Programs
                .AsNoTracking()
                .Include(d => d.Courses)
                .ThenInclude(d => d.Department)
                .Where(predicate)
                .ToListAsync(cancellationToken);

            return departments;
        }

        public async Task Create(Program entity, CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task CreateRange(
            IEnumerable<Program> entities,
            CancellationToken cancellationToken = default)
        {
            await _context.Programs.AddRangeAsync(entities, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(Program entity, CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Program entity, CancellationToken cancellationToken = default)
        {
            _context.Programs.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}