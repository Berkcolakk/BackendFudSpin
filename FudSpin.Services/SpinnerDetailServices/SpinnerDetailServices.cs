using FudSpin.Core.Repositories;
using FudSpin.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Services.SpinnerDetailServices
{
    public class SpinnerDetailServices : ISpinnerDetailServices
    {
        private readonly IGenericRepository<SpinnerDetail> spinnerDetailService;
        public SpinnerDetailServices(IGenericRepository<SpinnerDetail> spinnerDetailService)
        {
            this.spinnerDetailService = spinnerDetailService;
        }
    }
}
