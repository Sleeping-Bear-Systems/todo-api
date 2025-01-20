using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SleepingBear.ToDo.Database;

/// <summary>
/// Extension methods.
/// </summary>
public static class DatabaseExtensions
{
    /// <summary>
    /// Registers the EntityFramework database context.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ToDoDbContext>(options => options.UseNpgsql(connectionString));
        return services;
    }
}