using NetCoreBase.Domain.Interfaces;
using NetCoreBase.Infrastructure.DataAccess;

namespace NetCoreBase.Extensions
{
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
