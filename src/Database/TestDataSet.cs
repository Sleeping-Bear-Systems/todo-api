namespace SleepingBear.ToDo.Database;

/// <summary>
///     Test data for the "To-Do" web API.
/// </summary>
public static class TestDataSet
{
    /// <summary>
    ///     Seeds the database with test data.
    /// </summary>
    /// <param name="dbContext"></param>
    public static async Task Apply(ToDoDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);

        await dbContext.ToDoItems
            .AddRangeAsync(
                new ToDoItem { Id = new Guid("2D98B786-D490-4545-872C-64C787D74D11"), Name = "Item #1" },
                new ToDoItem { Id = new Guid("658F298B-2C47-41F9-A352-4E1C465FB1D6"), Name = "Item #2" },
                new ToDoItem { Id = new Guid("32051639-6A88-43AB-B028-E2CB3C57A943"), Name = "Item #3" }
            )
            .ConfigureAwait(false);

        await dbContext.SaveChangesAsync().ConfigureAwait(false);
    }
}