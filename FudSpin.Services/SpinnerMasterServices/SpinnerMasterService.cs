using FudSpin.Core.Repositories;
using FudSpin.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Services.SpinnerMasterServices
{
    public class SpinnerMasterService : ISpinnerMasterService
    {
        private readonly IGenericRepository<SpinnerMaster> spinnerService;
        public SpinnerMasterService(IGenericRepository<SpinnerMaster> spinnerService)
        {
            this.spinnerService = spinnerService;
        }
        
    }
}
