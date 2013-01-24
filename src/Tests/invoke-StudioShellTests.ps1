param( $fixture = '*.Tests.ps1', [switch] $keepSolution )

if( -not( get-module -list pester ) )
{
    throw "StudioShell tests require the Pester module"
}

# dotsource helper functions for tests
. ./helpers.ps1

# use pester
ipmo pester;

# run the tests
invoke-pester $fixture

# remove the dangling solution if necessary
if( ! $keepSolution ) { delete-solution; }

# focus the studioshell console if we're in VS
if( [environment]::commandline -match 'devenv\.exe' ) 
{ 
    invoke-item dte:/windows/studioshell 
};

