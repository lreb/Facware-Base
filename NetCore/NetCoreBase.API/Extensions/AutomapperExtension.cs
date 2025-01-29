using NetCoreBase.Application.Features.Items;

namespace NetCoreBase.API.Extensions
{
    /// <summary>
    /// Register all automapper profiles
    /// </summary>
    public static class AutoMapperExtension
    {
        /// <summary>
        /// Register all automapper profiles 
        /// </summary>
        /// <param name="services">Service collections</param>
        /// <returns>Service collections <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ItemMappingProfile).Assembly);
            return services;
        }
    }
}
