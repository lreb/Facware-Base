using FluentValidation;
using NetCoreBase.Application.Features.Items.Commands.AddItem;
using NetCoreBase.Application.Features.Items.Commands.DeleteItem;
using NetCoreBase.Application.Features.Items.Commands.UpdateItem;
using NetCoreBase.Application.Features.Items.Queries.GetItemById;
using NetCoreBase.Application.Features.Items.Queries.GetPagedItems;

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
            services.AddScoped<IValidator<AddItemRequest>, AddItemValidator>();
            services.AddScoped<IValidator<UpdateItemRequest>, UpdateItemValidator>();
            services.AddScoped<IValidator<DeleteItemRequest>, DeleteItemValidator>();
            services.AddScoped<IValidator<GetPagedItemsRequest>, GetPagedItemsValidator>();
            return services;
        }
    }
}
