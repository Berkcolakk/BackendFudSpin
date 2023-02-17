using FudSpin.Core.Repositories;
using FudSpin.Core.UnitOfWork;
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
        private readonly IUnitOfWork unitOfWork;
        public SpinnerMasterService(IGenericRepository<SpinnerMaster> spinnerService, ISpinnerMasterManager spinnerMasterManager, IUnitOfWork unitOfWork)
        {
            this.spinnerService = spinnerService;
            this.spinnerMasterManager = spinnerMasterManager;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Guid> ReturnIDAndAdd(SpinnerMaster spinnerMaster)
        {
            try
            {
                await spinnerService.Insert(spinnerMaster);
               await Save();
                return await Task.FromResult(spinnerMaster.ID);
            }
            catch (Exception)
            {
                return await Task.FromResult(Guid.Empty);
            }
        }

        public async Task<List<SpinnerMaster>> GetMySpinnerListByUserID(Guid UserID)
        {
            return await spinnerMasterManager.GetMySpinnerListByUserID(UserID);
        }
        public async Task Save()
        {
            await unitOfWork.Save();
        }
    }
}
