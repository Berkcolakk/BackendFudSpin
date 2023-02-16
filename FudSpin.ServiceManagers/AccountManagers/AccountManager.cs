using Microsoft.EntityFrameworkCore;
using FudSpin.Context.Context;
using FudSpin.Context.ParameterConstant;
using FudSpin.Dto.Users;
using FudSpin.Entities.Entities;
using FudSpin.Infrastructure.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.ServiceManagers.AccountManagers
{
    public class AccountManager : IAccountManager
    {
        private readonly ProjectContext context;
        private readonly ICryptographyProcessor cryptographyProcessor;
        public AccountManager(ProjectContext context, ICryptographyProcessor cryptographyProcessor)
        {
            this.context = context;
            this.cryptographyProcessor = cryptographyProcessor;
        }

        public async Task<User> Authentication(Authentication userLoginDTO, string UserType)
        {
            userLoginDTO.Password = cryptographyProcessor.GenerateHash(userLoginDTO.Password);
            return await context.User.Include(x => x.ParameterDetail_Nationality).FirstOrDefaultAsync(x => x.UserName.Equals(userLoginDTO.UserName) && x.Password.Equals(userLoginDTO.Password) && x.IsActive);
        }
    }
}
