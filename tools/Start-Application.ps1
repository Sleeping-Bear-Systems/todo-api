#Requires -Version 7

<#
.SYNOPSIS
Run the web API using the supplied environment file.

.PARAMETER EnvironmentFile
The path to the environment file to use.

#>

[CmdletBinding()]
param(
    [string]$EnvironmentFile = $null
)

Set-StrictMode -Version Latest

$projectPath = Join-Path $PSScriptRoot '../src/WebApi/SleepingBear.ToDo.WebApi.csproj'

# use current environment
if (-not $EnvironmentFile) {
    Write-Host 'Using current environment'
    dotnet run --project $projectPath
}
else {
    Write-Host "Using environment file: $EnvironmentFile"

    # check environment file exists
    if (-not (Test-Path $EnvironmentFile)) {
        Write-Error 'Environment file not found!'
        exit 1;
    }

    # run web API
    op run --no-masking --env-file $EnvironmentFile -- dotnet run --project $projectPath
}
