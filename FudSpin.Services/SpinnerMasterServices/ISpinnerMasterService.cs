using FudSpin.Core.Repositories;
using FudSpin.Dto.Spinners;
using FudSpin.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Services.SpinnerMasterServices
{
    public interface ISpinnerMasterService
    {
        Task<List<SpinnerMasterDTO>> GetMySpinnerListByUserID(Guid? UserID, bool IsDefault);
        Task<Guid> ReturnIDAndAdd(SpinnerMaster spinnerMaster);
    }
}
