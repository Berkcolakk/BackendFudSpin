using Microsoft.EntityFrameworkCore;
using RentalHouseManagement.Context.Context;
using RentalHouseManagement.Context.ParameterConstant;
using RentalHouseManagement.Dto.Users;
using RentalHouseManagement.Entities.Entities.Users;
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
        public UserManager(ProjectContext context)
        {
            this.context = context;
        }

        public async Task<User> LoginWithBasicUser(UserLoginDTO userLoginDTO)
        {
            
             return await context.User.FirstOrDefaultAsync(x => string.Equals(x.UserName, userLoginDTO.UserName, StringComparison.OrdinalIgnoreCase) && string.Equals(x.Password, userLoginDTO.Password, StringComparison.OrdinalIgnoreCase) && x.IsActive && string.Equals(x.PKUsersTitles.ShortName, ParameterList.BasicUser, StringComparison.OrdinalIgnoreCase)) ?? new User();
        }
    }
}
