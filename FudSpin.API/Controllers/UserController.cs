using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FudSpin.Services.Services.UserServices;
using FudSpin.Dto.Users;
using FudSpin.Api.Models;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Collections.Generic;
using FudSpin.Entities.Entities;

namespace FudSpin.Api.Controllers
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
        [Route("[controller]/Authentication")]
        public async Task<IActionResult> LoginWithBasicUser(Authentication authentication)
        {
            if (String.IsNullOrWhiteSpace(authentication.Password) || String.IsNullOrWhiteSpace(authentication.UserName))
            {
                return BadRequest($"{nameof(authentication.Password)} or {nameof(authentication.UserName)} cannot be null.");
            }
            string HasUser = await userService.LoginWithBasicUser(authentication);

            if (String.IsNullOrEmpty(HasUser))
            {
                return NotFound(new ResponseData()
                {
                    ErrorMessage = "UserName.Password.Invalid"
                });
            }


            return Ok(new ResponseData()
            {
                Message = "UserName.Password.Valid",
                Data = HasUser
            });
        }
        [HttpPost]
        [Route("[controller]/Register")]
        public async Task<IActionResult> CreateUser(CreateUserDTO user)
        {
            if (user is null)
            {
                return BadRequest($"{nameof(user)} cannot be null.");
            }

            bool UserCreated = await userService.UserCreated(new User()
            {
                NameSurname = user.NameSurname,
                Nationality = user.Nationality,
                Password = user.Password,
                DateOfBirth = user.DateOfBirth,
                Description = user.Description,
                Identity = user.Identity,
                UserName = user.UserName
            });

            if (!UserCreated)
            {
                return BadRequest(new ResponseData()
                {
                    Message = "User.Created.Failed",
                    Data = UserCreated
                });
            }

            return Created("User", new ResponseData()
            {
                Message = "User.Created",
                Data = UserCreated
            });
        }
    }
}
