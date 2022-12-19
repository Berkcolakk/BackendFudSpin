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
        public DbSet<User> User { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Language> Language { get; set; }
    }
}
