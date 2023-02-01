using FudSpin.Core.Repositories;
using FudSpin.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Services.SpinnerDetailSelectionServices
{
    public class SpinnerDetailSelectionService : ISpinnerDetailSelectionService
    {
        private readonly IGenericRepository<SpinnerDetailSelection> spinnerDetailSelectionService;
        public SpinnerDetailSelectionService(IGenericRepository<SpinnerDetailSelection> spinnerDetailSelectionService)
        {
            this.spinnerDetailSelectionService = spinnerDetailSelectionService;
        }
    }
}
