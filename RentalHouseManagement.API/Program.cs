using RentalHouseManagement.Services.Services.UserServices;
using RentalHouseManagement.ServiceManagers.UserManagers;
using Microsoft.EntityFrameworkCore;
using RentalHouseManagement.Context.Context;
using RentalHouseManagement.Core.Repositories;
using RentalHouseManagement.Core.UnitOfWork;
using RentalHouseManagement.Infrastructure.DatabaseFactory;
using RentalHouseManagement.Services.LanguageServices;
using RentalHouseManagement.Infrastructure.Cryptography;
using RentalHouseManagement.Services.TokenServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ProjectContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);
builder.Services.AddDbContext<ProjectContext>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IDatabaseFactory, DatabaseFactory>();
builder.Services.AddTransient<ICryptographyProcessor, CryptographyProcessor>();
builder.Services.AddScoped<UnitOfWork>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserManager, UserManager>();
builder.Services.AddTransient<ILanguageService, LanguageService>();
builder.Services.AddTransient<ITokenService,TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
