using FudSpin.Context.Context;
using FudSpin.Entities.Entities;
using FudSpin.Infrastructure.Cryptography;
using FudSpin.ServiceManagers.SpinnerDetailManagers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.ServiceManagers.SpinnerMasterManagers
{
    public class SpinnerDetailManager : ISpinnerDetailManager
    {
        private readonly ProjectContext context;
        private readonly ICryptographyProcessor cryptographyProcessor;
        public SpinnerDetailManager(ProjectContext context, ICryptographyProcessor cryptographyProcessor)
        {
            this.context = context;
            this.cryptographyProcessor = cryptographyProcessor;
        }

        public async Task<List<SpinnerDetail>> GetAllSpinnerDetailBySpinnerMasterID(Guid MasterID)
        {
            return await context.SpinnerDetail.Where(x => x.SpinnerMasterID == MasterID).ToListAsync();
        }
    }
}
