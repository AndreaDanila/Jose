using Microsoft.EntityFrameworkCore;
using WpfApp3.Models;

namespace WpfApp3.DAL
{
    public class AcademyDbContext : DbContext
    {
        public AcademyDbContext() : base()
        {
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Subject>().ToTable("Subjects");
            //modelBuilder.Entity<Registration>().ToTable("Registrations");

            //modelBuilder.Entity<Registration>()
            //   .HasOne(p => p.Student)
            //   .WithMany(b => b.Registrations)
            //   .HasForeignKey(p => p.StudentId);

            //modelBuilder.Entity<Registration>()
            //   .HasOne(p => p.Subject)
            //   .WithMany(b => b.Registrations)
            //   .HasForeignKey(p => p.SubjectId);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-TSPE80VL;Database=Academy;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

    }
}
