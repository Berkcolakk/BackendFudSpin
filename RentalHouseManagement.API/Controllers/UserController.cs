using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalHouseManagement.Services.Services.UserServices;
using RentalHouseManagement.Dto.Users;
using RentalHouseManagement.Api.Models;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using RentalHouseManagement.Entities.Entities.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
        [HttpGet]
        [Route("[controller]/Authentication")]
        public async Task<IActionResult> LoginWithBasicUser(string UserName,string Password)
        {
            if (String.IsNullOrWhiteSpace(UserName) || String.IsNullOrWhiteSpace(Password))
            {
                return BadRequest($"{nameof(UserName)} or {nameof(UserName)} must be not null.");
            }
            string HasUser = await userService.LoginWithBasicUser(new Authentication() { Password = Password,UserName = UserName});

            if (String.IsNullOrEmpty(HasUser))
            {
                return NotFound(new ResponseData()
                {
                    ErrorMessage ="UserName.Password.Invalid"
                }) ;
            }


            return Ok(new ResponseData()
            {
                Message = "UserName.Password.Valid",
                Data = HasUser
            });

            
        }
    }
}
