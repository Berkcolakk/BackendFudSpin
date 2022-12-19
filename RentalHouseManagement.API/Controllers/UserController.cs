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
        public async Task<IActionResult> LoginWithBasicUser(UserLoginDTO userLoginDTO)
        {
            bool HasUser = await userService.LoginWithBasicUser(userLoginDTO);

            if (!HasUser)
            {
                return NotFound(new ResponseData()
                {
                    ErrorMessage = "UserName.Password.Invalid",
                });
            }

            return Ok(new ResponseData()
            {
                Message = "UserName.Password.Valid",
                Data = userLoginDTO
            });
        }
    }
}
