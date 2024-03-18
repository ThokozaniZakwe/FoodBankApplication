using FoodBankApplication.Data.Models;
using FoodBankApplication.Data.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBankApplication.Domain
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<HighSchoolGrade> HighSchoolGrades { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Province>().HasData(
                new Province {Id = 1, Description = "Gauteng", Code = "GP" },
                new Province { Id = 2, Description = "North West", Code = "NW" },
                new Province { Id = 3, Description = "Limpopo", Code = "LP" },
                new Province { Id = 4, Description = "Northern Cape", Code = "NC" },
                new Province { Id = 5, Description = "KwaZulu-Natal", Code = "KZN" },
                new Province { Id = 6, Description = "Free State", Code = "FS" },
                new Province { Id = 7, Description = "Eastern Cape", Code = "EC" },
                new Province { Id = 8, Description = "Western Cape", Code = "WC" },
                new Province { Id = 9, Description = "Mpumalanga", Code = "MP"}
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
