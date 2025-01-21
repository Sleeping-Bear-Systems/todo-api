using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SleepingBear.ToDo.Database;

namespace SleepingBear.ToDo.WebApi.Tests;

internal sealed class CustomWebApplicationFactory<T> : WebApplicationFactory<T> where T : class
{
    private readonly string _connectionString;
    private readonly TimeProvider _timeProvider;

    /// <summary>
    ///     Constructor.
    /// </summary>
    public CustomWebApplicationFactory(string connectionString, TimeProvider timeProvider)
    {
        this._connectionString = connectionString;
        this._timeProvider = timeProvider;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            RemoveService<DbContextOptions<ToDoDbContext>>(services);
            services.AddDbContext<ToDoDbContext>(options => options.UseNpgsql(this._connectionString));
            RemoveService<TimeProvider>(services);
            services.AddSingleton(this._timeProvider);
        });
    }

    private static void RemoveService<TService>(IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(TService));
        if (descriptor is not null)
        {
            services.Remove(descriptor);
        }
    }
}