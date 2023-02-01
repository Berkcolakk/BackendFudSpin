using FudSpin.Core.Repositories;
using FudSpin.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Services.SpinnerDetailSelectionServices
{
    public class SpinnerDetailSelectionServices : ISpinnerDetailSelectionServices
    {
        private readonly IGenericRepository<SpinnerDetailSelection> spinnerDetailSelectionService;
        public SpinnerDetailSelectionServices(IGenericRepository<SpinnerDetailSelection> spinnerDetailSelectionService)
        {
            this.spinnerDetailSelectionService = spinnerDetailSelectionService;
        }
    }
}
