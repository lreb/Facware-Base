using FluentValidation;
using NetCoreBase.Application.Features.Items.Queries.GetItemById;

namespace NetCoreBase.API.Extensions
{
    /// <summary>
    /// Register FluentValidation validators for requests in the application layer with the DI container 
    /// </summary>
    public static class FluentValidatorExtension
    {
        /// <summary>
        /// Register FluentValidation validators for requests in the application layer with the DI container
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <returns>Service Colletion</returns>
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetItemByIdRequest>, GetByIdItemValidator>();
            return services;
        }
    }
}
