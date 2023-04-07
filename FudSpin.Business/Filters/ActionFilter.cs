using Microsoft.AspNetCore.Mvc.Filters;

namespace FudSpin.Api.Filters
{
    public class ActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string controller = (string)context.RouteData.Values["Controller"];
            string action = (string)context.RouteData.Values["action"];
            string authKey = context.HttpContext.Request.Headers["Authorization"];
            await next();
        }
    }
}
