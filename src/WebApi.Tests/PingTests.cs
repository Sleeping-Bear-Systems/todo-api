namespace SleepingBear.ToDo.WebApi.Tests;

/// <summary>
///     Integration test for the "Ping" endpoint.
/// </summary>
internal static class PingTests
{
    [Test]
    public static async Task PingEndpoint_ReturnsOk()
    {
        await IntegrationTestContext
            .RunAsync(async client =>
            {
                var uri = new Uri(uriString: "/api/ping", UriKind.Relative);
                var response = await client.GetAsync(uri).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            })
            .ConfigureAwait(false);
    }
}