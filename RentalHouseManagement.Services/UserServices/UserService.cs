using RentalHouseManagement.Core.Repositories;
using RentalHouseManagement.Entities.Entities.Users;
using RentalHouseManagement.ServiceManagers.UserManagers;
using RentalHouseManagement.Dto.Users;
using RentalHouseManagement.Services.LanguageServices;
using RentalHouseManagement.Entities.Entities;

namespace RentalHouseManagement.Services.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> userService;
        private readonly ILanguageService languageService;
        private readonly IUserManager userManager;
        public UserService(IGenericRepository<User> userService, IUserManager userManager, ILanguageService languageService)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.languageService = languageService;
        }
        public async Task<bool> LoginWithBasicUser(UserLoginDTO userLoginDTO)
        {
            if (string.IsNullOrWhiteSpace(userLoginDTO.UserName))
            {
                throw new ArgumentException($"'{nameof(userLoginDTO.UserName)}' cannot be null or whitespace.", nameof(userLoginDTO.UserName));
            }

            if (string.IsNullOrWhiteSpace(userLoginDTO.Password))
            {
                throw new ArgumentException($"'{nameof(userLoginDTO.Password)}' cannot be null or whitespace.", nameof(userLoginDTO.Password));
            }

            User HasUser = await userManager.LoginWithBasicUser(userLoginDTO);
            if (HasUser is not null)
            {
                return true;
            }
            return false;
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

        public async Task<string> GetLanguageByUserLanguage(Language language, Guid UserID)
        {
            if (language is null)
            {
                throw new ArgumentNullException(nameof(language));
            }

            if (UserID == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(UserID));
            }

            User user = await GetUserByUserID(UserID);

            Language lang = await languageService.GetLanguage(language);

            return user.Language switch
            {
                nameof(lang.EN) => lang.EN ?? language.Key,
                nameof(lang.TR) => lang.TR ?? language.Key,
                _ => language.Key,
            };
        }
    }
}
