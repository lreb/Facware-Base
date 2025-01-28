
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NetCoreBase.Extensions
{
    /// <summary>
	/// Extension to setup CORS configuration
	/// </summary>
    public static class CorsExtension
    {
        /// <summary>
		/// Policy cors name
		/// </summary>
		public static readonly string AllowSpecificOrigins = "AllowSpecificOrigins";

        /// <summary>
		/// CORS configurations
		/// </summary>
		/// <param name="services">application service <see cref="IServiceCollection"/></param>
		/// <param name="configuration">app settings configuration <see cref="IConfiguration"/></param>
        public static IServiceCollection AddCorsCustom(this IServiceCollection services, string policyName, string[] origins)
        {
            return services.AddCors(options => options.AddPolicy(policyName,
                 builder => builder
                     .WithOrigins(origins)
                     .AllowCredentials() // Allow credentials
                     .AllowAnyHeader()
                     .AllowAnyMethod()));
        }
    }
}
