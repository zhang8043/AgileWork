. ".\common.ps1"

# Upgrade all solutions(nuget & npm)

dotnet tool install dotnet-ef -g

foreach ($solutionPath in $efUpdatePaths) {    
    $solutionAbsPath = (Join-Path $rootFolder $solutionPath)
    Set-Location $solutionAbsPath
    dotnet ef database update
    if (-Not $?) {
        Write-Host ("Update failed for the solution: " + $solutionPath)
        Set-Location $rootFolder
        exit $LASTEXITCODE
    }
}

Set-Location $rootFolder
