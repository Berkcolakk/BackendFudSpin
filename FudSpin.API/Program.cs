using FudSpin.Services.Services.UserServices;
using FudSpin.ServiceManagers.UserManagers;
using Microsoft.EntityFrameworkCore;
using FudSpin.Context.Context;
using FudSpin.Core.Repositories;
using FudSpin.Core.UnitOfWork;
using FudSpin.Infrastructure.DatabaseFactory;
using FudSpin.Services.LanguageServices;
using FudSpin.Infrastructure.Cryptography;
using FudSpin.Services.TokenServices;
using FudSpin.Entities.Entities;
using FudSpin.Services.SpinnerMasterServices;
using FudSpin.ServiceManagers.SpinnerMasterManagers;
using FudSpin.Services.SpinnerDetailServices;
using FudSpin.Services.SpinnerDetailSelectionServices;
using FudSpin.Api.Utils;
using FudSpin.Services.Services.AccountServices;
using FudSpin.ServiceManagers.AccountManagers;
using FudSpin.ServiceManagers.SpinnerDetailManagers;
using Newtonsoft.Json.Serialization;
using FudSpin.Business.DependencyResolvers;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Net;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ContractResolver = new DefaultContractResolver());

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDependencies(builder.Configuration);

//Http3
builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.ListenAnyIP(7123, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
        listenOptions.UseHttps();
    });
});

builder.Services.AddRateLimiter(_ =>
{
    _.OnRejected = (context, _) =>
    {
        if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
        {
            context.HttpContext.Response.Headers.RetryAfter =
                ((int)retryAfter.TotalSeconds).ToString(NumberFormatInfo.InvariantInfo);
        }

        context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
        context.HttpContext.Response.WriteAsync("Too many requests. Please try again later.");

        return new ValueTask();
    };
    _.GlobalLimiter = PartitionedRateLimiter.CreateChained(
        PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
        {
            var userAgent = httpContext.Request.Headers.UserAgent.ToString();

            return RateLimitPartition.GetFixedWindowLimiter
            (userAgent, _ =>
                new FixedWindowRateLimiterOptions
                {
                    AutoReplenishment = true,
                    PermitLimit = 4,
                    Window = TimeSpan.FromSeconds(2)
                });
        }),
        PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
        {
            var userAgent = httpContext.Request.Headers.UserAgent.ToString();

            return RateLimitPartition.GetFixedWindowLimiter
            (userAgent, _ =>
                new FixedWindowRateLimiterOptions
                {
                    AutoReplenishment = true,
                    PermitLimit = 20,
                    Window = TimeSpan.FromSeconds(30)
                });
        }));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRateLimiter();

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
