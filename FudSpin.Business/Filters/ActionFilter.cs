using Microsoft.AspNetCore.Mvc.Filters;

namespace FudSpin.Api.Filters
{
    public class ActionFilter : IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string authKey = context.HttpContext.Request.Headers["Authorization"];
            next();
            return Task.CompletedTask;
        }
    }
}
