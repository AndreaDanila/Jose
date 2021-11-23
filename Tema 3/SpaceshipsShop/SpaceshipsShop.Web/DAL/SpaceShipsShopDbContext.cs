using Microsoft.EntityFrameworkCore;
using SpaceshipsShop.Lib.Models;

namespace SpaceshipsShop.Web.DAL
{
    public class SpaceShipsShopDbContext : DbContext
    {
        public DbSet<SpaceShip> SpaceShips { get; set; }

        public SpaceShipsShopDbContext() : base()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SpaceShip>().ToTable("SpaceShips");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql(connectionString: @"server=localhost;database=spaceships;uid=spaceshipsadmin;password=1234;",
                new MySqlServerVersion(new Version(8, 0, 23)));
        }

    }
}
