using Library.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.DAL
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Client> Clients { get; set; }  
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCopy> BooksCopies { get; set; }
        public DbSet<Loan> Loans { get; set; }

        public LibraryDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Tables' Names

            builder.Entity<Librarian>().ToTable("librarians");
            builder.Entity<Client>().ToTable("clients");
            builder.Entity<Book>().ToTable("books");
            builder.Entity<BookCopy>().ToTable("bookscopies");
            builder.Entity<Loan>().ToTable("loans");

            #endregion

            #region Relations
            builder.Entity<Loan>()
                .HasOne(x => x.Client)
                .WithMany(x => x.Loans)
                .HasForeignKey(x => x.ClientId);

            builder.Entity<Loan>()
                .HasOne(x => x.BookCopy)
                .WithMany(x => x.Loans)
                .HasForeignKey(x => x.BookCopyId);

            builder.Entity<BookCopy>()
                .HasOne(x => x.Book)
                .WithMany(x => x.BookCopies)
                .HasForeignKey(x => x.BookId);

            #endregion
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySQL("server=localhost;database=school;user=schooluser;password=1234");

            optionsBuilder
                .UseMySql(connectionString: @"server=localhost;database=library;uid=libraryadmin;password=1234;",
                new MySqlServerVersion(new Version(8, 0, 23)));

        }
    }
}
