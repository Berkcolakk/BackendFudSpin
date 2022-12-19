﻿using RentalHouseManagement.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalHouseManagement.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task Save();

        IGenericRepository<T> GetRepository<T>() where T : class;
    }
}
