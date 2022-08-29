using LBMJ.IoC;

namespace LBMJ.Api.Configuration
{
    public static class DependencyInjectorConfiguration
    {

        public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration) =>
            DependencyInjection.Register(services, configuration);
    }
}
    