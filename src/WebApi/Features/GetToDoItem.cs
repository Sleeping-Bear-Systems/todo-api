using Microsoft.EntityFrameworkCore;
using SleepingBear.Functional.Monads;
using SleepingBear.ToDo.Database;

namespace SleepingBear.ToDo.WebApi.Features;

internal static class GetToDoItem
{
    public static void MapGetToDoItemEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapGet(
            pattern: "/api/todo-items/{id:guid}",
            async (ToDoDbContext dbContext, Guid id) =>
            {
                return await dbContext.ToDoItems
                    .Where(item => item.Id == id)
                    .FirstOrDefaultAsync()
                    .ToOptionAsync()
                    .MatchAsync(
                        item => Results.Ok(new { item.Id, item.Name }),
                        () => Results.NotFound())
                    .ConfigureAwait(false);
            });
    }
}