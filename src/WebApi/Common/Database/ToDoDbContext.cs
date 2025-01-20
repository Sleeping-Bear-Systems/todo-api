using Microsoft.EntityFrameworkCore;

namespace SleepingBear.ToDo.WebApi.Common.Database;

internal sealed class ToDoDbContext : DbContext
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
        : base(options)
    {
    }
}