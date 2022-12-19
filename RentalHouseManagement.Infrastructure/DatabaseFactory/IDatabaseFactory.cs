using RentalHouseManagement.Context.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalHouseManagement.Infrastructure.DatabaseFactory
{
    public interface IDatabaseFactory : IDisposable
    {
        ProjectContext Get();
    }
}
