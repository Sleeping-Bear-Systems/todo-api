#Requires -Version 7

<#
.SYNOPSIS
Runs a local PowerShell session using the supplied environment file.

.PARAMETER EnvironmentFile 
The path to the environment file to use. If not provided, the default environment file is used.
#>

[CmdletBinding()]
param(
    [string]$EnvironmentFile = $null
)

Set-StrictMode -Version Latest

# use default environment file if not provided
if (-not $EnvironmentFile) {
    $EnvironmentFile = Resolve-Path (Join-Path $PSScriptRoot '../.env')
}
Write-Host "Using environment template file: $EnvironmentFile"

# check environment file exists
if (-not (Test-Path $EnvironmentFile)) {
    Write-Error 'Environment file not found!'
    exit 1;
}

# run web API
op run --no-masking --env-file=$EnvironmentFile -- pwsh
