using System.Net;

namespace FudSpin.Api.Utils
{
    public static class GlobalExceptionConfiguration
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            //app.UseExceptionHandler(x => x.Run(context =>
            //{
            //    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //    context.Response.ContentType = "application/json";
            //    //exception logging here.
            //}));
        }
    }
}
