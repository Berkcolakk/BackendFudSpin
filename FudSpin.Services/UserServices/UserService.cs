using FudSpin.Core.Repositories;
using FudSpin.ServiceManagers.UserManagers;
using FudSpin.Dto.Users;
using FudSpin.Services.LanguageServices;
using FudSpin.Entities.Entities;
using FudSpin.Context.ParameterConstant;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using FudSpin.Services.TokenServices;
using FudSpin.Core.UnitOfWork;
using FudSpin.Infrastructure.Cryptography;

namespace FudSpin.Services.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> userService;
        private readonly ILanguageService languageService;
        private readonly IUserManager userManager;
        private readonly ITokenService tokenService;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICryptographyProcessor cryptographyProcessor;

        public UserService(IGenericRepository<User> userService, IUserManager userManager, ILanguageService languageService, ITokenService tokenService, IUnitOfWork unitOfWork, ICryptographyProcessor cryptographyProcessor)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.languageService = languageService;
            this.tokenService = tokenService;
            this.unitOfWork = unitOfWork;
            this.cryptographyProcessor = cryptographyProcessor;
        }

        public async Task<User> GetUserByUserID(Guid UserID)
        {
            try
            {
                if (UserID == Guid.Empty)
                {
                    throw new ArgumentNullException(nameof(UserID));
                }

                User user = await userService.Get(x => x.ID == UserID && x.IsActive);
                return user;
            }
            catch (Exception)
            {
                return null;
                //throw;
            }
        }

        public async Task<string> GetLanguageByUserLanguage(string key, Guid UserID)
        {
            try
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
                    nameof(lang.Lang) => lang.Lang ?? key,
                    _ => key,
                };
            }
            catch (Exception)
            {
                return "";
                throw;
            }
        }

        public async Task Save()
        {
            await unitOfWork.Save();
        }
    }
}
