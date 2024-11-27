using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Programming", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Databases", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Web Design", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Networking", DisplayOrder = 4 }
            );
        }
    }
}
