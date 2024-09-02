using KParfume.Infrastructure;

namespace KParfume_BackEnd
{
    public static class ModulesConfiguration
    {
        public static IServiceCollection RegisterModules(this IServiceCollection services)
        {
            services.ConfigureModule();


            return services;
        }

    }
}
