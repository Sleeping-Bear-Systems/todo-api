using System.CommandLine;
using SleepingBear.Functional.Common;
using SleepingBear.ToDo.Database;

// root command
var rootCommand = new RootCommand("Database CLI");

// database command
var databaseCommand = new Command("database");

rootCommand.Add(databaseCommand);

// options
var connectionStringOption =
    new Option<string>(["-c", "--connection-string"], description: "The connection string to the database.");

var forceOption = new Option<bool>(["-f", "--force"], description: "Force the creation of the database.");

var datasetOption = new Option<string>(["-d", "--dataset"], description: "The dataset to use.");

// create database command
var createDatabaseCommand = new Command(name: "create", description: "Create a new database.")
{
    connectionStringOption,
    forceOption,
    datasetOption
};
createDatabaseCommand.SetHandler(async (connectionString, force, dataset) =>
    {
        var dbContext = ToDoDbContext.FromConnectionString(connectionString);
        // ReSharper disable once ConvertToUsingDeclaration
        await using (var _ = dbContext.ConfigureAwait(true))
        {
            if (force)
            {
                Console.WriteLine("Dropping database...");
                await dbContext.Database.EnsureDeletedAsync().ConfigureAwait(true);
            }

            Console.WriteLine("Creating database...");
            await dbContext.Database.EnsureCreatedAsync().ConfigureAwait(true);

            var validDataset = dataset.IfNull().Trim().ToUpperInvariant();
            switch (validDataset)
            {
                case "TEST":
                    Console.WriteLine("Applying test dataset...");
                    await TestDataSet.ApplyAsync(dbContext).ConfigureAwait(true);
                    break;
            }
        }
    },
    connectionStringOption,
    forceOption,
    datasetOption);
databaseCommand.Add(createDatabaseCommand);

// drop database command
var dropDatabaseCommand = new Command(name: "drop", description: "Drop an existing database.")
    { connectionStringOption };
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