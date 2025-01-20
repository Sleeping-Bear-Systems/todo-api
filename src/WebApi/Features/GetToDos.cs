using Microsoft.EntityFrameworkCore;
using SleepingBear.ToDo.Database;

namespace SleepingBear.ToDo.WebApi.Features;

internal static class GetToDos
{
    public static void MapGetToDosEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapGet(pattern: "/api/todos", async (ToDoDbContext dbContext) =>
        {
            var todos = await dbContext.ToDos
                .Select(item => new { item.Id, item.Name })
                .ToListAsync()
                .ConfigureAwait(false);

            return Results.Ok(todos);
        });
    }
}