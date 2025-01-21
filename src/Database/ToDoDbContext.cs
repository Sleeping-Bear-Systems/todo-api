using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace SleepingBear.ToDo.Database;

/// <summary>
///     ToDo database context.
/// </summary>
[SuppressMessage(category: "ReSharper", checkId: "NullableWarningSuppressionIsUsed")]
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
    ///     To-Do items.
    /// </summary>
    public DbSet<ToDoItem> ToDoItems { get; set; } = null!;

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