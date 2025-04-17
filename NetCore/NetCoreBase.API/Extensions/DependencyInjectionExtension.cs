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
            /// different instances created on each request
            services.AddTransient<IItemRepository, ItemRepository>();
            /// one instance per client connection
            services.AddScoped<IItemRepository, ItemRepository>();
            /// same instace used for all requests
            services.AddSingleton<IItemRepository, ItemRepository>();

            return services;
        }
    }
}
