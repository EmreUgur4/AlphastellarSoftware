using EmreUgur.BackedProject.Business.Concrete;
using EmreUgur.BackedProject.Business.Interfaces;
using EmreUgur.BackedProject.Business.Tools.JWTTool;
using EmreUgur.BackedProject.Business.ValidationRules.FluentValidation;
using EmreUgur.BackedProject.DataAccess.Concrete.Context;
using EmreUgur.BackedProject.DataAccess.Concrete.Repositories;
using EmreUgur.BackedProject.DataAccess.Interfaces;
using EmreUgur.BackedProject.DTO.Dtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmreUgur.BackedProject.Business.Containers.MicrosoftIOC
{
    public static class CustomIOCExtensions
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("db1"), conf =>
                {
                    conf.MigrationsAssembly("EmreUgur.BackedProject.WebApi");
                });
            });

            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<ICarDal, EfCarRepository>();
            services.AddScoped<IBusDal, EfBusRepository>();
            services.AddScoped<IBoatDal, EfBoatRepository>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppRoleService, AppRoleManager>();
            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();
            services.AddScoped<IBoatService, BoatManager>();
            services.AddScoped<IBusService, BusManager>();
            services.AddScoped<ICarService, CarManager>();
            services.AddScoped<IColorService, ColorManager>();
            services.AddScoped<IHeadlightService, HeadlightManager>();
            services.AddScoped<IVehicleService, VehicleManager>();
            services.AddScoped<IWheelService, WheelManager>();

            services.AddScoped<ITokenService, TokenManager>();

            services.AddTransient<IValidator<AppUserSignInDto>, AppUserSignInDtoValidator>();
        }
    }
}
