using Microsoft.EntityFrameworkCore;
using SleepingBear.ToDo.WebApi.Common.Database;

namespace SleepingBear.ToDo.WebApi.Common;

internal static class CommonExtensions
{
    /// <summary>
    /// Register the Common services.
    /// </summary>
    public static IServiceCollection AddCommon(
        this IServiceCollection services,
        TimeProvider timeProvider,
        string connectionString)
    {
        services.AddSingleton(timeProvider);
        services.AddDbContext<ToDoDbContext>(options => options.UseNpgsql(connectionString));
        return services;
    }
}