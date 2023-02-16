using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

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
                throw new ArgumentNullException("Authorization key cannot be null.");
            bool x = ValidateToken(jwtToken);
            //string redirectTo = "~/Account/Login";
            //filterContext.Result = ;

            //if (SessionContextExtensions.Current == null || SessionContextExtensions.Current.ActiveUser == null)
            //{
            //    var ck = StaticHttpAccessor.Current.Request.Cookies["YP2020"];

            //    if (!string.IsNullOrEmpty(ck))
            //    {

            //        var oldTicket = JwtUtils.ValidateToken(ck);
            //        if (oldTicket == null)
            //        {
            //            filterContext.Result = new RedirectResult(redirectTo);
            //        }
            //    }
            //}

            //if (!context.Request.IsAjaxRequest() && SessionContextExtensions.IsSessionNull())
            //{
            //    filterContext.Result = new RedirectResult(redirectTo);
            //}

            base.OnActionExecuting(filterContext);
        }
        public bool ValidateToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("*G-KaPdSgUkXp2s5v8y/B?E(H+MbQeTh");
            tokenHandler.ValidateToken(jwtToken,new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);
            var jwt = (JwtSecurityToken)validatedToken;
            return true;
        }
    }
}
