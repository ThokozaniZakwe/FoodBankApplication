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
    }
}
