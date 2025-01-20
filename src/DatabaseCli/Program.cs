using System.CommandLine;
using SleepingBear.ToDo.Database;

// root command
var rootCommand = new RootCommand("Database CLI");

// database command
var databaseCommand = new Command("database");

rootCommand.Add(databaseCommand);

// options
var connectionStringOption = new Option<string>("--connection-string", "The connection string to the database.");
connectionStringOption.AddAlias("-c");
var forceOption = new Option<bool>("--force", "Force the creation of the database.");
connectionStringOption.AddAlias("-f");

// create database command
var createDatabaseCommand = new Command("create", "Create a new database.")
{
    connectionStringOption,
    forceOption
};
createDatabaseCommand.SetHandler(async (connectionString, force) =>
    {
        var dbContext = ToDoDbContext.FromConnectionString(connectionString);
        // ReSharper disable once ConvertToUsingDeclaration
        await using (var _ = dbContext.ConfigureAwait(true))
        {
            await dbContext.Database.EnsureCreatedAsync().ConfigureAwait(true);
        }
    },
    connectionStringOption,
    forceOption);
databaseCommand.Add(createDatabaseCommand);

// drop database command
var dropDatabaseCommand = new Command("drop", "Drop an existing database.") { connectionStringOption };
dropDatabaseCommand.SetHandler(async connectionString =>
    {
        var dbContext = ToDoDbContext.FromConnectionString(connectionString);
        // ReSharper disable once ConvertToUsingDeclaration
        await using (var _ = dbContext.ConfigureAwait(true))
        {
            await dbContext.Database.EnsureDeletedAsync().ConfigureAwait(true);
        }
    },
    connectionStringOption);
databaseCommand.Add(dropDatabaseCommand);

// run
await rootCommand.InvokeAsync(args).ConfigureAwait(false);