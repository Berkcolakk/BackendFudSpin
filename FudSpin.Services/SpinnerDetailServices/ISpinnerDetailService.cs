using FudSpin.Core.Repositories;
using FudSpin.Dto.Spinners;
using FudSpin.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Services.SpinnerDetailServices
{
    public interface ISpinnerDetailService
    {
        Task<SpinnerMasterDTO> GetSpinnerDetailByMasterID(Guid MasterID);
        Task<bool> MultipleAdd(List<SpinnerDetail> spinnerDetail);
    }
}
