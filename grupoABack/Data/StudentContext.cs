using grupoABack.Models;
using Microsoft.EntityFrameworkCore;

namespace grupoABack.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(s => s.AcademicRegistration);
        }
    }
}
