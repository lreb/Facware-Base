using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NetCoreBase.API.ActionFilter;
using NetCoreBase.API.Extensions;
using NetCoreBase.API.Middleware;
using NetCoreBase.Infrastructure.Data.Postgresql;

namespace NetCoreBase.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Load environment-specific configuration
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            //builder.Logging.ClearProviders();
            //builder.Logging.AddConsole();
            //builder.Logging.AddDebug();
            //builder.Logging.AddEventSourceLogger();
            //builder.Logging.AddFile(builder.Configuration.GetSection("Logging:File"));
            //builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

            // Add logging (default configuration includes console logging)
            builder.Services.AddLogging(logging =>
            {
                logging.AddConsole(); // Logs to console
                logging.AddDebug();   // Logs to debug output
                                      // Optionally add other providers, e.g., file or external services
                                      // logging.AddFile("logs/app.log"); // Requires a third-party package
            });


            // Add services to the container.
            builder.Services.AddControllers(option=> 
            {
                option.Filters.Add<StatusCodeWrapperFilter>(); // Add the custom action filter globally
            });

            // Add versioning
            builder.Services.AddAspApiVersioning();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            // Add Swagger
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); // Add version 1
                options.SwaggerDoc("v2", new OpenApiInfo { Title = "My API", Version = "v2" }); // Add version 2
            });
            // add cors extension and Load CORS origins from appsettings.json
            var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();
            if (allowedOrigins == null || allowedOrigins.Length == 0)
            {
                throw new ArgumentException("AllowedOrigin configuration is missing or empty.");
            }
            builder.Services.AddCorsCustom("AllowSpecificOrigins", allowedOrigins);
            //register MediatR Handlers
            builder.Services.RegisterCommandsAndQueries();
            // Register DI
            builder.Services.AddDependencyInjectionReferences();
            // Register database context
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("NetCoreBase.Infrastructure")));
            // Automapper
            builder.Services.AddAutoMapperProfiles();
            // Fluent Validation
            builder.Services.AddFluentValidation();

            var app = builder.Build();

            

            app.Logger.LogInformation("Adding Swagger");
            // Configure the HTTP request pipeline.
            if (app.Environment.IsLocal())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    // Dynamically add endpoints for each version
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"); // Add version 1
                    options.SwaggerEndpoint("/swagger/v2/swagger.json", "My API v2"); // Add version 2
                });
                app.UseDeveloperExceptionPage();
            }
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }
            if (app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.Logger.LogInformation("Adding CORS");
            app.UseCors("AllowSpecificOrigins");

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
