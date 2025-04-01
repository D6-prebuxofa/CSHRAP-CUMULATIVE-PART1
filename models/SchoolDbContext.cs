using Microsoft.EntityFrameworkCore;
using System;

namespace YourProjectName.Models
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = 1,
                    FirstName = "Sean",
                    LastName = "Joe",
                    HireDate = new DateTime(2015, 8, 15),
                    Subject = "Physics"
                },
                new Teacher
                {
                    Id = 2,
                    FirstName = "Virat",
                    LastName = "Paul",
                    HireDate = new DateTime(2017, 9, 10),
                    Subject = "Social Studies"
                },
                new Teacher
                {
                    Id = 3,
                    FirstName = "Sweetie",
                    LastName = "Riya",
                    HireDate = new DateTime(2019, 3, 5),
                    Subject = "Mathematics"
                },
                new Teacher
                {
                    Id = 4,
                    FirstName = "Jitesh",
                    LastName = "Thomas",
                    HireDate = new DateTime(2020, 1, 22),
                    Subject = "Tamil Language"
                }
            );
        }
    }
}


