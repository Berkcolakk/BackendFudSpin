using Microsoft.AspNetCore.Mvc;
using FudSpin.Services.Services.UserServices;

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
