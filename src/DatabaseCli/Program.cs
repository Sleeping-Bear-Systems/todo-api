using System.CommandLine;

var rootCommand = new RootCommand("Database CLI");

var databaseCommand = new Command("database");
rootCommand.Add(databaseCommand);

var createDatabaseCommand = new Command("create", "Create a new database.");
databaseCommand.Add(createDatabaseCommand);

var forceOption = new Option<bool>("--force", "Force the creation of the database.");
createDatabaseCommand.Add(forceOption);

var dropDatabaseCommand = new Command("drop", "Drop an existing database.");
databaseCommand.Add(dropDatabaseCommand);

await rootCommand.InvokeAsync(args).ConfigureAwait(false);