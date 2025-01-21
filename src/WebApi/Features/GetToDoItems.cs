using Microsoft.EntityFrameworkCore;
using SleepingBear.ToDo.Database;

namespace SleepingBear.ToDo.WebApi.Features;

internal static class GetToDoItems
{
    public static void MapGetToDoItemsEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapGet(pattern: "/api/todo-items", async (ToDoDbContext dbContext) =>
        {
            var todos = await dbContext.ToDoItems
                .Select(item => new { item.Id, item.Name })
                .ToListAsync()
                .ConfigureAwait(false);

            return Results.Ok(todos);
        });
    }
}