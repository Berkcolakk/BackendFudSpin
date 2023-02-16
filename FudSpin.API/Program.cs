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

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ProjectContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);
builder.Services.AddDbContext<ProjectContext>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IDatabaseFactory, DatabaseFactory>();
builder.Services.AddTransient<ICryptographyProcessor, CryptographyProcessor>();
builder.Services.AddScoped<UnitOfWork>();

//UserServices
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserManager, UserManager>();

builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IAccountManager, AccountManager>();

//LanguageServices
builder.Services.AddTransient<ILanguageService, LanguageService>();
builder.Services.AddTransient<ITokenService,TokenService>();
//SpinnerMasterServices
builder.Services.AddTransient<ISpinnerMasterService, SpinnerMasterService>();
builder.Services.AddTransient<ISpinnerMasterManager, SpinnerMasterManager>();
//SpinnerDetailServices
builder.Services.AddTransient<ISpinnerDetailService, SpinnerDetailService>();
//builder.Services.AddTransient<ISpinnerDetailManager, SpinnerDetailManager>();
//SpinnerDetailSelectionServices
builder.Services.AddTransient<ISpinnerDetailSelectionService, SpinnerDetailSelectionService>();
//builder.Services.AddTransient<ISpinnerDetailSelectionManager, SpinnerDetailSelectionManager>();
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
