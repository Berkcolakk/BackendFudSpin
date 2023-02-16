using FudSpin.Dto.Users;
using FudSpin.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Services.Services.UserServices
{
    public interface IUserService
    {
        Task<User> GetUserByUserID(Guid UserID);
        Task<string> GetLanguageByUserLanguage(string key, Guid UserID);
    }
}
