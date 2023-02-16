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
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
    }
}
