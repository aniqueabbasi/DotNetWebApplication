using Microsoft.EntityFrameworkCore;
using DotNetWebApplication.Models;

namespace DotNetWebApplication.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Anique", Age = 24, Email = "Anique1234@gmail.com", DisplayOrder = 2 },
                new Category { Id = 2, Name = "Ali", Age = 22, Email = "Aliii134@gmail.com", DisplayOrder = 5 },
                new Category { Id = 3, Name = "Daud", Age = 22, Email = "ss789@gmail.com", DisplayOrder = 7 },
                new Category { Id = 4, Name = "Umer", Age = 32, Email = "jkls@gmail.com", DisplayOrder = 89 }
            );
        }
    }
}