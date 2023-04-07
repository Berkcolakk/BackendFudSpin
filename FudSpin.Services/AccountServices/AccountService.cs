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
using FudSpin.ServiceManagers.AccountManagers;

namespace FudSpin.Services.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly IGenericRepository<User> userService;
        private readonly ILanguageService languageService;
        private readonly IAccountManager accountManager;
        private readonly ITokenService tokenService;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICryptographyProcessor cryptographyProcessor;

        public AccountService(IGenericRepository<User> userService, IAccountManager accountManager, ILanguageService languageService, ITokenService tokenService, IUnitOfWork unitOfWork, ICryptographyProcessor cryptographyProcessor)
        {
            this.userService = userService;
            this.accountManager = accountManager;
            this.languageService = languageService;
            this.tokenService = tokenService;
            this.unitOfWork = unitOfWork;
            this.cryptographyProcessor = cryptographyProcessor;
        }
        public async Task<string> LoginWithBasicUser(Authentication userLoginDTO)
        {
            try
            {
                User HasUser = await accountManager.Authentication(userLoginDTO, UserConstant.BasicUser);
                string result = tokenService.GenerateToken(HasUser);
                return await Task.FromResult(result).ConfigureAwait(false);
            }
            catch (Exception)
            {
                return "";
                //throw;
            }
        }
        public async Task<bool> UserCreated(User user)
        {
            try
            {
                user.Password = cryptographyProcessor.GenerateHash(user.Password);
                await userService.Insert(user);
                await Save();
                return await Task.FromResult(true).ConfigureAwait(false);
            }
            catch (Exception)
            {
                return await Task.FromResult(false).ConfigureAwait(false);
            }
        }
        public async Task Save()
        {
            await Task.FromResult(unitOfWork.Save()).ConfigureAwait(false);
        }
    }
}
