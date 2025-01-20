# todo-api

## Updating Dependencies

```powershell
dotnet-outdated -t -td 5
```

## Starting the Development Environment

This creates a local PowerShell session with the environment variables in the `.env` file and starts
the Rider IDE.

```powershell
./tools/Start-Development.ps1
rider .
```

⚠️In order to use the correct environment variables, all development tools should be started from the
PowerShell command line using the development session.

### Exiting the Development Environment

To exit the development environment, close the Rider IDE and run the following command in the PowerShell session.

```powershell
exit
```

## Running the Web API

```powershell
./tools/Start-Application.ps1
```

If starting the application from a development environment session, specify the `-UseCurrentEnvironment` parameter
to use current environment variables.

```powershell
./tools/Start-Application.ps1 -UseCurrentEnvironment
```

### References

[1Password inject](https://developer.1password.com/docs/cli/reference/commands/inject/)
[1Password run](https://developer.1password.com/docs/cli/reference/commands/run)
