#Requires -Version 7

<#
.SYNOPSIS
Run the web API using the supplied environment file.

.PARAMETER EnvironmentFile
The path to the environment file to use. If not provided, the default environment file is used.

.PARAMETER UseCurrentEnvironment
Switch indicating the script should use the current environment.
#>

[CmdletBinding()]
param(
    [string]$EnvironmentFile = $null,
    [switch]$UseCurrentEnvironment
)

Set-StrictMode -Version Latest

$projectPath = Join-Path $PSScriptRoot '../src/WebApi/SleepingBear.ToDo.WebApi.csproj'

# use current environment
if ($UseCurrentEnvironment) {
    Write-Host 'Using current environment'
    dotnet run --project $projectPath
}
else {
    # use default environment file if not provided
    if (-not $EnvironmentFile) {
        $EnvironmentFile = Resolve-Path (Join-Path $PSScriptRoot '../.env')
    }
    Write-Host "Using environment file: $EnvironmentFile"

    # check environment file exists
    if (-not (Test-Path $EnvironmentFile)) {
        Write-Error 'Environment file not found!'
        exit 1;
    }

    # run web API
    op run --no-masking --env-file $EnvironmentFile -- dotnet run --project $projectPath
}
