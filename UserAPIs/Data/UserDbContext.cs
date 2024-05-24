using UserAPIs.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UserAPIs.Data
{
    public class UserDbContext : DbContext
    {

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) 
        { 
        }

        public DbSet<User> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("DefaultConnection");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                    new User() { Id = 1, Name = "Samuel Toch", Email = "samueltochi1@gmail.com", Password = "password", Phone = "08011223344" },
                    new User() { Id = 2, Name = "Samuel Offiah", Email = "tochi1@gmail.com", Password = "password", Phone = "08011223344" }
                );
        }
    }
}
