using Microsoft.EntityFrameworkCore;

namespace SleepingBear.ToDo.Database;

/// <summary>
///     ToDo database context.
/// </summary>
public sealed class ToDoDbContext : DbContext
{
    /// <summary>
    ///     Constructor.
    /// </summary>
    public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    ///     Factory method for creating a <see cref="ToDoDbContext" /> from a connection string.
    /// </summary>
    public static ToDoDbContext FromConnectionString(string connectionString)
    {
        var options = new DbContextOptionsBuilder<ToDoDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        return new ToDoDbContext(options);
    }
}