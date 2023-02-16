using FudSpin.Dto.Users;
using FudSpin.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Services.Services.AccountServices
{
    public interface IAccountService
    {
        Task<string> LoginWithBasicUser(Authentication userLoginDTO);
        Task<bool> UserCreated(User user);
    }
}
