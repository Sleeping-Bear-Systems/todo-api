# todo-api

## Updating Dependencies

```powershell
dotnet-outdated -t -td 5
```

## Starting the Development Environment

This creates a local PowerShell session with the environment variables in the `.env` file.

```powershell
./tools/Start-Development.ps1
```

## Running the Web API

⚠️ The development environment must be started before running the web API in order to set the environment variables.

```powershell
./tools/Start-Application.ps1
```

### References

[1Password inject](https://developer.1password.com/docs/cli/reference/commands/inject/)
[1Password run](https://developer.1password.com/docs/cli/reference/commands/run)
