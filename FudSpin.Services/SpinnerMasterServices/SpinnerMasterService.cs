using FudSpin.Core.Repositories;
using FudSpin.Entities.Entities;
using FudSpin.ServiceManagers.SpinnerMasterManagers;
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
        private readonly ISpinnerMasterManager spinnerMasterManager;
        public SpinnerMasterService(IGenericRepository<SpinnerMaster> spinnerService, ISpinnerMasterManager spinnerMasterManager)
        {
            this.spinnerService = spinnerService;
            this.spinnerMasterManager = spinnerMasterManager;
        }

        public async Task<bool> Add(SpinnerMaster spinnerMaster)
        {
            try
            {
                await spinnerService.Insert(spinnerMaster);
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<List<SpinnerMaster>> GetMySpinnerListByUserID(Guid UserID)
        {
            return await spinnerMasterManager.GetMySpinnerListByUserID(UserID);
        }
    }
}
