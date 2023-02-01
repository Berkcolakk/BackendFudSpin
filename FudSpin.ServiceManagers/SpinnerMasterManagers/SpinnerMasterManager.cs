﻿using FudSpin.Context.Context;
using FudSpin.Entities.Entities;
using FudSpin.Infrastructure.Cryptography;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.ServiceManagers.SpinnerMasterManagers
{
    public class SpinnerMasterManager : ISpinnerMasterManager
    {
        private readonly ProjectContext context;
        private readonly ICryptographyProcessor cryptographyProcessor;
        public SpinnerMasterManager(ProjectContext context, ICryptographyProcessor cryptographyProcessor)
        {
            this.context = context;
            this.cryptographyProcessor = cryptographyProcessor;
        }

        public async Task<List<SpinnerMaster>> GetMySpinnerListByUserID(Guid UserID)
        {
            return await context.SpinnerMaster.Where(x => x.UserID == UserID && x.IsActive).ToListAsync();
        }
    }
}