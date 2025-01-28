
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetCoreBase.Application.Queries.GetByIdItemHandler;
using NetCoreBase.Domain.Interfaces;
using NetCoreBase.Extensions;
using NetCoreBase.Infrastructure.Data.Postgresql;
using System.Reflection;
using static NetCoreBase.Application.Queries.GetByIdItemHandler.ItemGetByIdQuery;
using NetCoreBase.Infrastructure.DataAccess;

namespace NetCoreBase
{
    public class Program
    {
        //public IConfiguration _configuration { get; }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //Host.CreateDefaultBuilder(args)
        //    .ConfigureAppConfiguration((hostingContext, config) =>
        //    {
        //        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        config.AddEnvironmentVariables();
        //    })
        //    .ConfigureServices((hostContext, services) =>
        //    {
        //        // Register your services here
        //    });

        public static void Main(string[] args)
        {
            //string myVariable = Environment.GetEnvironmentVariable("BASENETCORE_CONNECTION_STRING");

            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

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


            //builder.Services.AddOptions();
            //register MediatR Handlers
            //builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetByIdItemHandler).GetTypeInfo().Assembly));

            // register DI
            builder.Services.AddDependencyInjectionReferences();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("NetCoreBase.Infrastructure")));

            //automapper
            builder.Services.AddAutoMapper(typeof(CustomMappingProfile).Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
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
