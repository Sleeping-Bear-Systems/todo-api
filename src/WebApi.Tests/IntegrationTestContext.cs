using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Time.Testing;
using SleepingBear.TemporaryDatabase.Postgres;
using SleepingBear.ToDo.Database;

namespace SleepingBear.ToDo.WebApi.Tests;

internal static class IntegrationTestContext
{
    [SuppressMessage(category: "ReSharper", checkId: "ConvertToUsingDeclaration")]
    public static async Task RunAsync(Func<HttpClient, Task> test, Func<DbContext, Task>? seedDataFunc = null)
    {
        var guard = await TemporaryDatabaseGuard.FromEnvironmentVariableAsync().ConfigureAwait(false);
        await using (var _ = guard.ConfigureAwait(false))
        {
            var dbContext = ToDoDbContext.FromConnectionString(guard.ConnectionString);
            await using (var __ = dbContext.ConfigureAwait(false))
            {
                await dbContext.Database.EnsureCreatedAsync().ConfigureAwait(false);
                if (seedDataFunc is not null)
                {
                    await seedDataFunc(dbContext).ConfigureAwait(false);
                }
            }

            var timeProvider = new FakeTimeProvider();

            var factory = new CustomWebApplicationFactory<Program>(guard.ConnectionString, timeProvider);
            await using (var ___ = factory.ConfigureAwait(false))
            {
                using var client = factory.CreateClient();
                await test(client).ConfigureAwait(false);
            }
        }
    }
}