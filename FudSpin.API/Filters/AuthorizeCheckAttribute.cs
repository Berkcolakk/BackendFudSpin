using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using FudSpin.Services.TokenServices;
using FudSpin.Dto.Tokens;

namespace FudSpin.Api.Filters
{
    public class AuthorizeCheckAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var allowAnonymous = filterContext.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;


            var context = filterContext.HttpContext;
            string jwtToken = context.Request.Headers.Authorization;
            if (String.IsNullOrWhiteSpace(jwtToken))
            {
                filterContext.Result = new UnauthorizedResult();
                return;
            }

            var tokenService = filterContext.HttpContext.RequestServices.GetService<ITokenService>();
            TokenDTO token = tokenService.ValidationToken(jwtToken);
            if (!token.IsValid)
            {
                filterContext.Result = new UnauthorizedResult();
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
