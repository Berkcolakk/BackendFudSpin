using FudSpin.Core.Repositories;
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
        Task<List<SpinnerMaster>> GetMySpinnerListByUserID(Guid UserID);
        Task<bool> Add(SpinnerMaster spinnerMaster);
    }
}
