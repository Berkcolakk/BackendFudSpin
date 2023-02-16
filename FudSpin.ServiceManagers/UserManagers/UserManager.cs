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

namespace FudSpin.ServiceManagers.UserManagers
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
    }
}
