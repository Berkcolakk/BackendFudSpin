using FudSpin.Core.Repositories;
using FudSpin.Core.UnitOfWork;
using FudSpin.Dto.Spinners;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="IsDefault">True > Default Spinner List - False > Owned Spinner List</param>
        /// <returns></returns>
        public async Task<List<SpinnerMasterDTO>> GetMySpinnerListByUserID(Guid? UserID, bool IsDefault)
        {
            List<SpinnerMasterDTO> spinnerMasterDTOs = new();
            List<SpinnerMaster> spinnerMaster = await spinnerMasterManager.GetMySpinnerListByUserID(UserID, IsDefault);
            foreach (SpinnerMaster master in spinnerMaster)
            {
                SpinnerMasterDTO spinnerMasterDTO = new()
                {
                    ID = master.ID,
                    MasterName = master.Name,
                    SpinnerList = new List<SpinnerListDTO>()
                };
                foreach (SpinnerDetail detail in master.IPSpinnerDetail)
                {
                    spinnerMasterDTO.SpinnerList.Add(new SpinnerListDTO()
                    {
                        Color = detail.Color,
                        Description = detail.Description,
                        ID = detail.ID,
                        Name = detail.Name
                    });
                }
                spinnerMasterDTOs.Add(spinnerMasterDTO);
            }

            return await Task.FromResult(spinnerMasterDTOs);
        }
        public async Task Save()
        {
            await Task.FromResult(unitOfWork.Save());
        }
    }
}
