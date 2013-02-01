<#
utility functions for StudioShell unit tests
#>

function arrange( [scriptblock] $code )
{
    # swallow output, but propagate exceptions
    try { $result = & $code } catch { throw $_ }    
}

function assert-true( [scriptblock] $that )
{
    try { $result = & $that } catch { throw $_ }
    
    if( ! $result )
    {
        throw "{ $that }"
    }
    
    $result;
}

function assert-false( [scriptblock] $that )
{
    try { $result = & $that } catch { throw $_ }
    
    if( $result )
    {
        throw "-not{ $that }"
    }
    
    -not $result;
}

function assert-error ([scriptblock] $that )
{
    $epf = $ErrorActionPreference;
    $erroractionpreference = 'silentlycontinue';
    $global:error.Clear();

    try { & $that | out-null; } catch { }
    
    $ErrorActionPreference = $epf;
    0 -ne $global:error.Count
}

function assert-throw( [scriptblock] $that )
{
    $result = $false;
    try { & $that | out-null } catch { $result = $true }
        
    $result;
}

function verify( [scriptblock] $that ) { arrange $that }

set-alias assert assert-true;

function new-solution
{
    if( $dte.solution )
    {
        delete-solution
    }
    $path = get-solutionPath;
    $name = split-path $path -leaf;
    $path = split-path $path;
    
    mkdir $path -force | out-null;
    
    $dte.solution.create( $path, $name );
    $dte.solution.saveas( (get-solutionPath) );
}

function delete-solution
{
    if( $dte.solution )
    {
        $dte.solution.close( $false );
    }
    $path = get-solutionpath | split-path;
    if( test-path $path ) { remove-item $path -recurse -force }
}

function get-solutionPath 
{ 
    $script:solutionName = 'studioshell.unittests';
    $script:solutionPath = join-path ([io.path]::GetTempPath()) $script:solutionName;
    
     
    join-path $script:solutionPath ($script:solutionName + ".sln")
}

function get-randomName( $prefix = '_' ) 
{ 
    $prefix + [guid]::newGuid().ToString("N").Trim() 
}

function new-project( $template = 'classlibrary', $language = 'csharp' )
{
    $name = get-randomname;
    new-item "dte:/solution/projects/$name" -type $template -language $language;
}