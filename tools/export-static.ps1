<#
.SYNOPSIS
    Exports the portfolio as plain HTML into docs/ for GitHub Pages.

.DESCRIPTION
    Builds the app, runs it against a throwaway SQLite database (so the committed
    Data/portfolio.db is never touched), crawls every internal page starting from "/",
    saves each one as <path>/index.html, copies the static assets from wwwroot, and
    prefixes root-relative links with the GitHub Pages base path.

    Run it after changing any content (seed data, pages, CSS, resume PDF), then commit docs/.

.EXAMPLE
    powershell -ExecutionPolicy Bypass -File tools\export-static.ps1
#>
param(
    # Path the site is served under. "" for devanarayanan09.github.io (a <user>.github.io repository).
    # Use e.g. "/PortfolioSite" if the site is served from a project repository instead.
    [string]$BasePath = "",
    [int]$Port = 5111
)

$ErrorActionPreference = "Stop"
$projectDir = Split-Path -Parent $PSScriptRoot
$outDir = Join-Path $projectDir "docs"
$baseUrl = "http://localhost:$Port"
$utf8 = New-Object System.Text.UTF8Encoding $false

Write-Host "Building..."
& dotnet build (Join-Path $projectDir "PortfolioSite.csproj") -c Release -nologo -v q | Out-Null
if ($LASTEXITCODE -ne 0) { throw "Build failed." }

$tempDb = Join-Path ([System.IO.Path]::GetTempPath()) "portfolio-export-$([guid]::NewGuid().ToString('N')).db"
$env:ConnectionStrings__PortfolioDb = "Data Source=$tempDb"
$env:ASPNETCORE_ENVIRONMENT = "Production"

$dll = Join-Path $projectDir "bin\Release\net8.0\PortfolioSite.dll"
$server = Start-Process dotnet -ArgumentList "`"$dll`" --urls $baseUrl" -WorkingDirectory $projectDir -PassThru -WindowStyle Hidden

try {
    $client = New-Object System.Net.WebClient
    $ready = $false
    for ($i = 0; $i -lt 60 -and -not $ready; $i++) {
        try { $null = $client.DownloadData("$baseUrl/"); $ready = $true } catch { Start-Sleep -Milliseconds 500 }
    }
    if (-not $ready) { throw "The app did not start on $baseUrl." }

    # Start clean, but keep a CNAME file if a custom domain is ever added.
    $cname = Join-Path $outDir "CNAME"
    $cnameText = if (Test-Path $cname) { Get-Content $cname -Raw } else { $null }
    if (Test-Path $outDir) { Remove-Item $outDir -Recurse -Force }
    New-Item -ItemType Directory $outDir | Out-Null
    if ($cnameText) { [System.IO.File]::WriteAllText($cname, $cnameText, $utf8) }

    # Crawl internal page links (root-relative, no file extension).
    $queue = New-Object System.Collections.Generic.Queue[string]
    $seen = New-Object System.Collections.Generic.HashSet[string]
    $queue.Enqueue("/"); [void]$seen.Add("/")

    while ($queue.Count -gt 0) {
        $path = $queue.Dequeue()
        $html = $utf8.GetString($client.DownloadData("$baseUrl$path"))

        foreach ($m in [regex]::Matches($html, 'href="(/[^"#?]*)')) {
            $link = $m.Groups[1].Value
            if ($link -ne "/") { $link = $link.TrimEnd('/') }
            if ($link -match '\.[A-Za-z0-9]+$' -or $link.StartsWith("//")) { continue }
            if ($seen.Add($link)) { $queue.Enqueue($link) }
        }

        if ($BasePath) {
            $html = [regex]::Replace($html, '(href|src|action)="/(?!/)', "`$1=`"$BasePath/")
        }

        $target = if ($path -eq "/") { $outDir } else { Join-Path $outDir ($path.TrimStart('/').Replace('/', '\')) }
        New-Item -ItemType Directory $target -Force | Out-Null
        [System.IO.File]::WriteAllText((Join-Path $target "index.html"), $html, $utf8)
        Write-Host "  page  $path"
    }

    # Static assets. wwwroot/lib (Bootstrap/jQuery) is no longer used by any page.
    $wwwroot = Join-Path $projectDir "wwwroot"
    Get-ChildItem $wwwroot -Force | Where-Object { $_.Name -ne "lib" } |
        ForEach-Object { Copy-Item $_.FullName -Destination $outDir -Recurse -Force }

    # Tell GitHub Pages not to run Jekyll over the output.
    [System.IO.File]::WriteAllText((Join-Path $outDir ".nojekyll"), "", $utf8)

    Write-Host "Exported $($seen.Count) pages to $outDir"
}
finally {
    if ($server -and -not $server.HasExited) { Stop-Process -Id $server.Id -Force }
    Remove-Item "$tempDb*" -Force -ErrorAction SilentlyContinue
    Remove-Item Env:ConnectionStrings__PortfolioDb, Env:ASPNETCORE_ENVIRONMENT -ErrorAction SilentlyContinue
}

