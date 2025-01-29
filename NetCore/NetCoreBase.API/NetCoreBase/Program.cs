using Microsoft.EntityFrameworkCore;
using NetCoreBase.Application.Queries.GetItemById;
using NetCoreBase.Extensions;
using NetCoreBase.Infrastructure.Data.Postgresql;
using FluentValidation;

namespace NetCoreBase
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
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // add cors extension and Load CORS origins from appsettings.json
            var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();
            if (allowedOrigins == null || allowedOrigins.Length == 0)
            {
                throw new ArgumentException("AllowedOrigin configuration is missing or empty.");
            }
            builder.Services.AddCorsCustom("AllowSpecificOrigins", allowedOrigins);
            //register MediatR Handlers
            builder.Services.RegisterCommandsAndQueries();
            // register DI
            builder.Services.AddDependencyInjectionReferences();
            // register database context
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("NetCoreBase.Infrastructure")));
            //automapper
            builder.Services.AddAutoMapper(typeof(CustomMappingProfile).Assembly);
            // fluent validation
            builder.Services.AddScoped<IValidator<GetItemByIdRequest>, GetByIdItemValidator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsLocal())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
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

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
