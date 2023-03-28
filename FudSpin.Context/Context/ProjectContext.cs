using Microsoft.EntityFrameworkCore;
using FudSpin.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FudSpin.Entities.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace FudSpin.Context.Context
{
    public class ProjectContext : DbContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public ProjectContext(DbContextOptions<ProjectContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseNpgsql(@"Host=localhost;Username=postgres;Password=05128950;Database=FudSpin;");
        public DbSet<User> User { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<SpinnerMaster> SpinnerMaster { get; set; }
        public DbSet<SpinnerDetail> SpinnerDetail { get; set; }
        public DbSet<SpinnerDetailSelection> SpinnerDetailSelection { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();
            var tokenHandler = new JwtSecurityTokenHandler();
            string jwtToken = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
            var key = Encoding.ASCII.GetBytes("*G-KaPdSgUkXp2s5v8y/B?E(H+MbQeTh");
            tokenHandler.ValidateToken(jwtToken, new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);
            var jwt = (JwtSecurityToken)validatedToken;
            Guid userID = Guid.Parse(jwt.Claims.First(x => x.Type == "UserID").Value);
            foreach (var item in ChangeTracker.Entries())
            {
                BaseEntity baseEntity = item.Entity as BaseEntity;
                if (item.State == EntityState.Modified)
                {
                    baseEntity.UpdDate = DateTime.UtcNow;
                    baseEntity.UpdIPAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

                }
                else if (item.State == EntityState.Deleted)
                {
                    baseEntity.UpdDate = DateTime.UtcNow;
                    baseEntity.IsActive = false;
                    baseEntity.UpdIPAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

                }
                else
                {
                    baseEntity.IsActive = true;
                    baseEntity.CrtDate = DateTime.UtcNow;
                    baseEntity.UpdDate = DateTime.UtcNow;
                    baseEntity.CrtIPAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                    baseEntity.UpdIPAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
