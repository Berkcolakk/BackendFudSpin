using FudSpin.Dto.Tokens;
using FudSpin.Entities.Entities;
using FudSpin.Services.Services.AccountServices;
using FudSpin.Services.TokenServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FudSpin.Api.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        public User GetUserByJWTToken()
        {
            var tokenService = HttpContext.RequestServices.GetService<ITokenService>();
            TokenDTO token = tokenService.ValidationToken(HttpContext.Request.Headers.Authorization);
            if (!token.IsValid)
            {
                throw new NullReferenceException(nameof(token));
            }
            return new Entities.Entities.User()
            {
                ID = token.ID,
            };
        }
    }
}