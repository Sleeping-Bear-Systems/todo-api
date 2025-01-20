using Microsoft.EntityFrameworkCore;

namespace SleepingBear.ToDo.Database;

/// <summary>
/// ToDo database context.
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
}