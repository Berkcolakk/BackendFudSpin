using FudSpin.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.ServiceManagers.SpinnerMasterManagers
{
    public interface ISpinnerMasterManager
    {
        Task<List<SpinnerMaster>> GetMySpinnerListByUserID(Guid UserID);
    }
}
