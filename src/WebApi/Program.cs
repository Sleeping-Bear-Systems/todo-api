using SleepingBear.Functional.Monads;
using SleepingBear.Functional.Validation;
using SleepingBear.ToDo.WebApi.Common;
using SleepingBear.ToDo.WebApi.Features;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["ConnectionStrings:Postgres"]
    .AsToken()
    .MatchOrThrow(() => new InvalidOperationException("Connection string not found."));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCommon(TimeProvider.System, connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPing();

app.Run();

