using Microsoft.EntityFrameworkCore;
using Academy.Lib.Models;
using System;

namespace Academy.Lib.DAL
{
    public class AcademyDbContext : DbContext
    {
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

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
            //optionsBuilder.UseMySQL("server=localhost;database=school;user=schooluser;password=1234");

            optionsBuilder
                .UseMySql(connectionString: @"server=localhost;database=school;uid=schooluser;password=1234;",
                new MySqlServerVersion(new Version(8, 0, 23)));

        }

    }
}
