using FudSpin.Dto.Users;
using FudSpin.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.ServiceManagers.UserManagers
{
    public interface IUserManager
    {
        Task<User> Authentication(Authentication userLoginDTO, string UserType);
    }
}
