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
        Task<bool> LoginWithBasicUser(UserLoginDTO userLoginDTO);
        Task<User> GetUserByUserID(Guid UserID);
        Task<string> GetLanguageByUserLanguage(Language language, Guid UserID);
    }
}
