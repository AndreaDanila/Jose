using Microsoft.EntityFrameworkCore;
using Academy.Lib.Models;
using System;

namespace Academy.Lib.DAL
{
    public class AcademyDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public AcademyDbContext() : base()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Subject>().ToTable("Subjects");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollments");

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Subject)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.SubjectId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=LAPTOP-TSPE80VL;Database=Academy;Trusted_Connection=True;MultipleActiveResultSets=true");
            optionsBuilder
                .UseMySql(connectionString: @"server=localhost;database=academy;uid=schooluser;password=1234;",
                new MySqlServerVersion(new Version(8, 0, 23)));
        }
    }
}
