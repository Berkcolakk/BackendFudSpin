using RentalHouseManagement.Core.Repositories;
using RentalHouseManagement.Entities.Entities.Users;
using RentalHouseManagement.ServiceManagers.UserManagers;
using RentalHouseManagement.Dto.Users;
using RentalHouseManagement.Services.LanguageServices;
using RentalHouseManagement.Entities.Entities;
using RentalHouseManagement.Context.ParameterConstant;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using RentalHouseManagement.Services.TokenServices;

namespace RentalHouseManagement.Services.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> userService;
        private readonly ILanguageService languageService;
        private readonly IUserManager userManager;
        private readonly ITokenService tokenService;
        public UserService(IGenericRepository<User> userService, IUserManager userManager, ILanguageService languageService, ITokenService tokenService)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.languageService = languageService;
            this.tokenService = tokenService;
        }
        public async Task<string> LoginWithBasicUser(Authentication userLoginDTO)
        {
            if (string.IsNullOrWhiteSpace(userLoginDTO.UserName))
            {
                throw new ArgumentException($"'{nameof(userLoginDTO.UserName)}' cannot be null or whitespace.", nameof(userLoginDTO.UserName));
            }

            if (string.IsNullOrWhiteSpace(userLoginDTO.Password))
            {
                throw new ArgumentException($"'{nameof(userLoginDTO.Password)}' cannot be null or whitespace.", nameof(userLoginDTO.Password));
            }

            User HasUser = await userManager.Authentication(userLoginDTO, UserConstant.BasicUser);
            return tokenService.GenerateToken(HasUser);
        }
        

        public async Task<User> GetUserByUserID(Guid UserID)
        {
            if (UserID == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(UserID));
            }

            User user = await userService.Get(x => x.ID == UserID && x.IsActive);
            return user;
        }

        public async Task<string> GetLanguageByUserLanguage(string key, Guid UserID)
        {
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (UserID == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(UserID));
            }

            User user = await GetUserByUserID(UserID);

            Language lang = await languageService.GetLanguage(key);

            return user.Language switch
            {
                nameof(lang.EN) => lang.EN ?? key,
                nameof(lang.TR) => lang.TR ?? key,
                _ => key,
            };
        }

    }
}
