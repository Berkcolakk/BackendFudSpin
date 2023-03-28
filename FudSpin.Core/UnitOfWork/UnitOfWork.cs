using FudSpin.Context.Context;
using FudSpin.Core.Repositories;
using FudSpin.Infrastructure.DatabaseFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FudSpin.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;

        private ProjectContext dataContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected ProjectContext DataContext => dataContext ?? (dataContext = databaseFactory.Get());

        public async Task Save()
        {
            using TransactionScope tScope = new(TransactionScopeAsyncFlowOption.Enabled);
            await DataContext.SaveChangesAsync();
            tScope.Complete();
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(databaseFactory);
        }
    }
}
