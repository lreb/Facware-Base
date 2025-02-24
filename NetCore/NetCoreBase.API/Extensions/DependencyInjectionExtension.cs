using NetCoreBase.Domain.Interfaces;
using NetCoreBase.Infrastructure.Repositories;

namespace NetCoreBase.API.Extensions
{
    /// <summary>
    /// Dependency injection extension, to register all services
    /// </summary>
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjectionReferences(this IServiceCollection services)
        {
            // register all DI services here
            services.AddScoped<IItemRepository, ItemRepository>();

            return services;
        }
    }
}
