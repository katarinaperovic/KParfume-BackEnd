using KParfume.API.Public;
using KParfume.BuildingBlocks.Core.UseCases;
using KParfume.BuildingBlocks.Infrastructure.Database;
using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;
using KParfume.Core.Mappers;
using KParfume.Core.Services;
using KParfume.Infrastructure.Auth;
using KParfume.Infrastructure.Database;
using KParfume.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace KParfume.Infrastructure
{
    public static class Startup
    {

        public static IServiceCollection ConfigureModule(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile).Assembly);
            SetupCore(services);
            SetupInfrastructure(services);
            return services;
        }

        private static void SetupCore(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenGenerator,JwtGenerator>();

        }

        private static void SetupInfrastructure(IServiceCollection services)
        {
            services.AddScoped(typeof(ICrudRepository<User>), typeof(CrudDatabaseRepository<User, Context>));
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddDbContext<Context>(opt =>
                opt.UseNpgsql(DbConnectionStringBuilder.Build("KParfumeSchema"),
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "KParfumeSchema")));
        }

    }
}
