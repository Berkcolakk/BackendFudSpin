﻿using Microsoft.EntityFrameworkCore;
using RentalHouseManagement.Context.Context;
using RentalHouseManagement.Context.ParameterConstant;
using RentalHouseManagement.Dto.Users;
using RentalHouseManagement.Entities.Entities.Users;
using RentalHouseManagement.Infrastructure.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalHouseManagement.ServiceManagers.UserManagers
{
    public class UserManager : IUserManager
    {
        private readonly ProjectContext context;
        private readonly ICryptographyProcessor cryptographyProcessor;
        public UserManager(ProjectContext context, ICryptographyProcessor cryptographyProcessor)
        {
            this.context = context;
            this.cryptographyProcessor = cryptographyProcessor;
        }

        public async Task<User> Authentication(Authentication userLoginDTO, string UserType)
        {
            userLoginDTO.Password = cryptographyProcessor.GenerateHash(userLoginDTO.Password);
            return await context.User.FirstOrDefaultAsync(x => x.UserName.Equals(userLoginDTO.UserName) && x.Password.Equals(userLoginDTO.Password) && x.IsActive && x.PKUsersTitles.ShortName == UserType);
        }
    }
}
