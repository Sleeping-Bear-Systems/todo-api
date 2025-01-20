namespace SleepingBear.ToDo.WebApi.Features;

/// <summary>
///     Ping feature.
/// </summary>
internal static class Ping
{
    /// <summary>
    ///     Maps the "Ping" endpoint.
    /// </summary>
    // ReSharper disable once UnusedMethodReturnValue.Global
    public static IEndpointRouteBuilder MapPingEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/ping", () => Results.Ok());

        return endpoints;
    }
}