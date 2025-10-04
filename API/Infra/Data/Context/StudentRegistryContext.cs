using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class StudentRegistryContext(DbContextOptions<StudentRegistryContext> options) : DbContext(options)
    {
        public DbSet<Domain.Models.Student> Students { get; set; } = null!;
        public DbSet<Domain.Models.Guardian> Guardians { get; set; } = null!;
        public DbSet<Domain.Models.StudentGuardian> StudentGuardians { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentRegistryContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
