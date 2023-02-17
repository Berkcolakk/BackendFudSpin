using FudSpin.Core.Repositories;
using FudSpin.Core.UnitOfWork;
using FudSpin.Dto.Spinners;
using FudSpin.Entities.Entities;
using FudSpin.ServiceManagers.SpinnerDetailManagers;
using FudSpin.ServiceManagers.SpinnerMasterManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Services.SpinnerDetailServices
{
    public class SpinnerDetailService : ISpinnerDetailService
    {
        private readonly IGenericRepository<SpinnerDetail> spinnerDetailService;
        private readonly IUnitOfWork unitOfWork;
        private readonly ISpinnerDetailManager spinnerDetailManager;

        public SpinnerDetailService(IGenericRepository<SpinnerDetail> spinnerDetailService, IUnitOfWork unitOfWork, ISpinnerDetailManager spinnerDetailManager)
        {
            this.spinnerDetailService = spinnerDetailService;
            this.unitOfWork = unitOfWork;
            this.spinnerDetailManager = spinnerDetailManager;
        }
        public async Task<SpinnerMasterDTO> GetSpinnerDetailByMasterID(Guid MasterID)
        {
            List<SpinnerDetail> spinnerDetails = await spinnerDetailManager.GetAllSpinnerDetailBySpinnerMasterID(MasterID);
            if (spinnerDetails.Count == 0)
                throw new ArgumentNullException();

            SpinnerMasterDTO SpinnerListDTOs = new()
            {
                ID = MasterID,
                MasterName = spinnerDetails[0].IPSpinnerDetail.Name,
                SpinnerList = new List<SpinnerListDTO>()
            };
            for (int i = 0; i < spinnerDetails.Count; i++)
            {
                SpinnerListDTO spinnerListDTO = new()
                {
                    Color = spinnerDetails[i].Color,
                    Name = spinnerDetails[i].Name,
                    ID = spinnerDetails[i].ID,
                    Description = spinnerDetails[i].Description,
                };
                SpinnerListDTOs.SpinnerList.Add(spinnerListDTO);
            }

            return SpinnerListDTOs;
        }

        public async Task<bool> MultipleAdd(List<SpinnerDetail> spinnerDetail)
        {
            try
            {
                await spinnerDetailService.Insert(spinnerDetail);
                await Save();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task Save()
        {
            await unitOfWork.Save();
        }
    }
}
