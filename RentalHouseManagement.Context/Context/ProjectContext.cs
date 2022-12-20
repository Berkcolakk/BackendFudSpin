using Microsoft.EntityFrameworkCore;
using RentalHouseManagement.Entities.Entities;
using RentalHouseManagement.Entities.Entities.Companies;
using RentalHouseManagement.Entities.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalHouseManagement.Context.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseNpgsql(@"Host=localhost;Username=postgres;Password=5128950;Database=RentalHouseManagement");
        public DbSet<User> User { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Language> Language { get; set; }
    }
}
