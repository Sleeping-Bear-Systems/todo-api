namespace SleepingBear.ToDo.WebApi.Features;

/// <summary>
///     Ping feature.
/// </summary>
internal static class Ping
{
    /// <summary>
    ///     Maps the "Ping" endpoint.
    /// </summary>
    public static void MapPingEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapGet(pattern: "/api/ping", () => Results.Ok());
    }
}