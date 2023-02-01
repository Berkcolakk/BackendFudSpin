using FudSpin.Context.Context;
using FudSpin.Entities.Entities;
using FudSpin.Infrastructure.Cryptography;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.ServiceManagers.SpinnerDetailSelectionManagers
{
    public class SpinnerDetailSelectionManager : ISpinnerDetailSelectionManager
    {
        private readonly ProjectContext context;
        private readonly ICryptographyProcessor cryptographyProcessor;
        public SpinnerDetailSelectionManager(ProjectContext context, ICryptographyProcessor cryptographyProcessor)
        {
            this.context = context;
            this.cryptographyProcessor = cryptographyProcessor;
        }

        public async Task<List<SpinnerDetailSelection>> GetAllSelections()
        {
            return await context.SpinnerDetailSelection.Include(x => x.IPSpinnerDetailSelection).ThenInclude(x => x.IPSpinnerDetail).ToListAsync();
        }
    }
}
