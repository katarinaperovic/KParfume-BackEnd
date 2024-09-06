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
            services.AddScoped<IFabrikaService,FabrikaService>();
            services.AddScoped<IParfemService,ParfemService>();
            services.AddScoped<ISvojstvaParfemaService, SvojstvaParfemaService>();
            services.AddScoped<IVestService, VestService>();
            services.AddScoped<IKomentarService, KomentarService>();

        }

        private static void SetupInfrastructure(IServiceCollection services)
        {
            services.AddScoped(typeof(ICrudRepository<User>), typeof(CrudDatabaseRepository<User, Context>));
            services.AddScoped(typeof(ICrudRepository<Fabrika>), typeof(CrudDatabaseRepository<Fabrika, Context>));
            services.AddScoped(typeof(ICrudRepository<Parfem>), typeof(CrudDatabaseRepository<Parfem, Context>));
            services.AddScoped(typeof(ICrudRepository<VrstaParfema>), typeof(CrudDatabaseRepository<VrstaParfema, Context>));
            services.AddScoped(typeof(ICrudRepository<TipParfema>), typeof(CrudDatabaseRepository<TipParfema, Context>));
            services.AddScoped(typeof(ICrudRepository<KategorijaParfema>), typeof(CrudDatabaseRepository<KategorijaParfema, Context>));
            services.AddScoped(typeof(ICrudRepository<Vest>), typeof(CrudDatabaseRepository<Vest, Context>));
            services.AddScoped(typeof(ICrudRepository<Komentar>), typeof(CrudDatabaseRepository<Komentar, Context>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFabrikaRepository, FabrikaRepository>();
            services.AddScoped<IParfemRepository, ParfemRepository>();
            services.AddScoped<IVrstaParfemaRepository, VrstaParfemaRepository>();
            services.AddScoped<ITipParfemaRepository, TipParfemaRepository>();
            services.AddScoped<IKategorijaParfemaRepository, KategorijaParfemaRepository>();
            services.AddScoped<IVestRepository, VestRepository>();
            services.AddScoped<IKomentarRepository, KomentarRepository>();

            services.AddDbContext<Context>(opt =>
                opt.UseNpgsql(DbConnectionStringBuilder.Build("KParfumeSchema"),
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "KParfumeSchema")));
        }

    }
}
