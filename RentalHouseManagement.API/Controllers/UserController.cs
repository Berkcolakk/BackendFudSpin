using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalHouseManagement.Services.Services.UserServices;
using RentalHouseManagement.Dto.Users;
using RentalHouseManagement.Api.Models;

namespace RentalHouseManagement.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        [Route("[controller]/Login")]
        public async Task<IActionResult> LoginWithBasicUser(Authentication userLoginDTO)
        {
            AuthenticationResponse HasUser = await userService.LoginWithBasicUser(userLoginDTO);

            if (HasUser is null)
            {
                return NotFound(new ResponseData()
                {
                    ErrorMessage = await userService.GetLanguageByUserLanguage("UserName.Password.Invalid", HasUser.UserID)
                }) ;
            }

            return Ok(new ResponseData()
            {
                Message = await userService.GetLanguageByUserLanguage("UserName.Password.Valid", HasUser.UserID),
                Data = HasUser
            });
        }
    }
}
