using Academic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Academic.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Program> Programs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Índice único no código do curso
            //modelBuilder.Entity<Course>()
            //    .HasIndex(c => c.Code)
            //    .IsUnique();

            // Outras configurações podem ser adicionadas aqui
        }
    }
}
