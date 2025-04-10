using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreBase.Domain.Interfaces;
using NetCoreBase.Infrastructure.Data.Postgresql;
using NetCoreBase.Infrastructure.Repositories;

namespace NetCoreBase.Test
{
    public class TestFixture : IDisposable
    {
        public IServiceProvider ServiceProvider { get; private set; }

        private readonly string Environment = "Local"; // TODO: get this value from bash script or variables for CI/CD

        public TestFixture()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                //.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true) // TODO: get this value from bash script or variables for CI/CD
                .AddJsonFile($"appsettings.{Environment}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Register ApplicationDbContext with an in-memory database
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("NetCoreBase.Infrastructure")));


                    // Register services here
                    services.AddTransient<IItemRepository, ItemRepository>();
                })
                .Build();

            ServiceProvider = host.Services;
        }

        public void Dispose()
        {
            // Clean up resources if needed
            //throw new NotImplementedException();
        }
    }
}
