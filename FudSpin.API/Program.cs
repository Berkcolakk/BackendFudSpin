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

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddNewtonsoftJson(x =>x.SerializerSettings.ContractResolver = new DefaultContractResolver());

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDependencies(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
