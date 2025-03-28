using Asp.Versioning;

namespace NetCoreBase.API.Extensions
{
    public static class ApiVersioningExtension
    {
        public static IServiceCollection AddAspApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0); // Default version: v1.0
                options.AssumeDefaultVersionWhenUnspecified = true; // Use default if version not specified
                options.ReportApiVersions = true; // Include version info in responses
                options.ApiVersionReader = new UrlSegmentApiVersionReader(); // Read version from URL (e.g., /v1/)
            }).AddApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'V"; // Format as "v1", "v2", etc.
                    options.SubstituteApiVersionInUrl = true; // Replace {version} in routes
                }
            );

            return services;
        }
    }
}
