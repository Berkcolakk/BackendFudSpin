using FudSpin.Core.Repositories;
using FudSpin.Entities.Entities;
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
        public SpinnerDetailService(IGenericRepository<SpinnerDetail> spinnerDetailService)
        {
            this.spinnerDetailService = spinnerDetailService;
        }
    }
}
