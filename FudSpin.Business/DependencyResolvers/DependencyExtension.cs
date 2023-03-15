using FudSpin.Context.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FudSpin.Infrastructure.DatabaseFactory;
using FudSpin.Services.LanguageServices;
using FudSpin.Infrastructure.Cryptography;
using FudSpin.Services.TokenServices;
using FudSpin.Services.SpinnerMasterServices;
using FudSpin.ServiceManagers.SpinnerMasterManagers;
using FudSpin.Services.SpinnerDetailServices;
using FudSpin.Services.SpinnerDetailSelectionServices;
using FudSpin.Services.Services.AccountServices;
using FudSpin.ServiceManagers.AccountManagers;
using FudSpin.ServiceManagers.SpinnerDetailManagers;
using FudSpin.Core.Repositories;
using FudSpin.Core.UnitOfWork;
using FudSpin.Services.Services.UserServices;
using FudSpin.ServiceManagers.UserManagers;

namespace FudSpin.Business.DependencyResolvers
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ProjectContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);
            services.AddDbContext<ProjectContext>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IDatabaseFactory, DatabaseFactory>();
            services.AddTransient<ICryptographyProcessor, CryptographyProcessor>();
            services.AddScoped<UnitOfWork>();

            //UserServices
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserManager, UserManager>();

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAccountManager, AccountManager>();

            //LanguageServices
            services.AddTransient<ILanguageService, LanguageService>();
            services.AddTransient<ITokenService, TokenService>();
            //SpinnerMasterServices
            services.AddTransient<ISpinnerMasterService, SpinnerMasterService>();
            services.AddTransient<ISpinnerMasterManager, SpinnerMasterManager>();
            //SpinnerDetailServices
            services.AddTransient<ISpinnerDetailService, SpinnerDetailService>();
            services.AddTransient<ISpinnerDetailManager, SpinnerDetailManager>();
            //SpinnerDetailSelectionServices
            services.AddTransient<ISpinnerDetailSelectionService, SpinnerDetailSelectionService>();
            //services.AddTransient<ISpinnerDetailSelectionManager, SpinnerDetailSelectionManager>();
        }
    }
}
