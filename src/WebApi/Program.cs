using SleepingBear.ToDo.WebApi.Common;
using SleepingBear.ToDo.WebApi.Features;

var builder = WebApplication.CreateBuilder(args);

var connectionString = string.Empty;

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