﻿using FudSpin.Api.Controllers.Base;
using FudSpin.Api.Models;
using FudSpin.Dto.Users;
using FudSpin.Entities.Entities;
using FudSpin.Services.Services.AccountServices;
using FudSpin.Services.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FudSpin.Api.Controllers
{
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost]
        [Route("[controller]/Authentication")]
        public async Task<IActionResult> LoginWithBasicUser(Authentication authentication)
        {
            if (String.IsNullOrWhiteSpace(authentication.Password) || String.IsNullOrWhiteSpace(authentication.UserName))
            {
                return BadRequest($"{nameof(authentication.Password)} or {nameof(authentication.UserName)} cannot be null.");
            }
            string HasUser = await accountService.LoginWithBasicUser(authentication);

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

            bool UserCreated = await accountService.UserCreated(new User()
            {
                NameSurname = user.NameSurname,
                NationalityID = user.NationalityID,
                GenderID = user.GenderID,
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
