using MediatR;
using System.Reflection;
using NetCoreBase.Application.Queries.GetItemById;

namespace NetCoreBase.Extensions
{
    /// <summary>
    /// CQRS extension, to register all commands and queries
    /// </summary>
    public static class CQRSExtension
    {
        public static IServiceCollection RegisterServicesFromAssemblies(this IServiceCollection services, params Assembly[] assemblies)
        {
            var handlerTypes = assemblies.SelectMany(a => a.DefinedTypes)
                .Where(type => type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                .ToList();

            foreach (var handlerType in handlerTypes)
            {
                var interfaces = handlerType.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))
                    .ToList();

                foreach (var handlerInterface in interfaces)
                {
                    services.AddTransient(handlerInterface, handlerType);
                }
            }

            return services;
        }

        /// <summary>
        /// Register all commands and queries
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection RegisterCommandsAndQueries(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetItemByIdRequest).GetTypeInfo().Assembly));

            return services;
        }
    }
}
