using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SleepingBear.ToDo.Database;

/// <summary>
///     Extension methods.
/// </summary>
public static class DatabaseExtensions
{
    /// <summary>
    ///     Registers the EntityFramework database context.
    /// </summary>
    public static void AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ToDoDbContext>(options => options.UseNpgsql(connectionString));
    }
}