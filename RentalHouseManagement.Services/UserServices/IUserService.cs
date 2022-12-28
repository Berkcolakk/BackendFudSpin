using RentalHouseManagement.Dto.Users;
using RentalHouseManagement.Entities.Entities;
using RentalHouseManagement.Entities.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalHouseManagement.Services.Services.UserServices
{
    public interface IUserService
    {
        Task<string> LoginWithBasicUser(Authentication userLoginDTO);
        Task<User> GetUserByUserID(Guid UserID);
        Task<string> GetLanguageByUserLanguage(string key, Guid UserID);
    }
}
