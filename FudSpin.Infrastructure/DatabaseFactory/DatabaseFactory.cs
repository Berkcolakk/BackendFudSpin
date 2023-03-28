using Microsoft.EntityFrameworkCore;
using FudSpin.Context.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FudSpin.Infrastructure.DatabaseFactory
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private DbContextOptions<ProjectContext> options;
        private readonly IHttpContextAccessor httpContextAccessor;

        public DatabaseFactory(DbContextOptions<ProjectContext> options, IHttpContextAccessor httpContextAccessor)
        {
            this.options = options;
            this.httpContextAccessor = httpContextAccessor;
        }

        private ProjectContext dataContext;

        public ProjectContext Get()
        {
            return dataContext ??= new ProjectContext(options, httpContextAccessor);
        }

        protected override void DisposeCore()
        {
            if (dataContext != null)
            {
                dataContext.Dispose();
            }
        }
    }
}
