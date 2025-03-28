using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NetCoreBase.API.Extensions;
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
            // Add services to the container.
            builder.Services.AddControllers();

            //builder.Services.AddApiVersioning(options =>
            //{
            //    options.DefaultApiVersion = new ApiVersion(1, 0); // Default version: v1.0
            //    options.AssumeDefaultVersionWhenUnspecified = true; // Use default if version not specified
            //    options.ReportApiVersions = true; // Include version info in responses
            //    options.ApiVersionReader = new UrlSegmentApiVersionReader(); // Read version from URL (e.g., /v1/)
            //}).AddApiExplorer(
            //    options => 
            //    {
            //        options.GroupNameFormat = "'v'V"; // Format as "v1", "v2", etc.
            //        options.SubstituteApiVersionInUrl = true; // Replace {version} in routes
            //    }
            //);
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

            app.UseCors("AllowSpecificOrigins");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
