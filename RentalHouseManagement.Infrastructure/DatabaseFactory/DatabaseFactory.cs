using Microsoft.EntityFrameworkCore;
using RentalHouseManagement.Context.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalHouseManagement.Infrastructure.DatabaseFactory
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private DbContextOptions<ProjectContext> options;

        public DatabaseFactory(DbContextOptions<ProjectContext> options)
        {
            this.options = options;
        }

        private ProjectContext dataContext;

        public ProjectContext Get()
        {
            return dataContext ?? (dataContext = new ProjectContext(options));
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
