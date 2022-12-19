using RentalHouseManagement.Dto.Users;
using RentalHouseManagement.Entities.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalHouseManagement.ServiceManagers.UserManagers
{
    public interface IUserManager
    {
        Task<User> LoginWithBasicUser(UserLoginDTO userLoginDTO);
    }
}
