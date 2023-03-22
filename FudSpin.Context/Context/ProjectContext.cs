﻿using Microsoft.EntityFrameworkCore;
using FudSpin.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Context.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseNpgsql(@"Server=fudspin.postgres.database.azure.com;Database=postgres;Port=5432;User Id=berkcolak;Password=fudspin!1;");
        public DbSet<User> User { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<SpinnerMaster> SpinnerMaster { get; set; }
        public DbSet<SpinnerDetail> SpinnerDetail { get; set; }
        public DbSet<SpinnerDetailSelection> SpinnerDetailSelection { get; set; }

    }
}
