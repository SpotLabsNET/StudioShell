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

function assert-throw( [scriptblock] $that )
{
    $result = $false;
    try { & $that | out-null } catch { $result = $true }
        
    $result;
}

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

function get-randomName 
{ 
    "_" + [guid]::newGuid().ToString("N").Trim() 
}

function new-project
{
    $name = get-randomname;
    new-item dte:/solution/projects/$name -type classlibrary -language csharp;
}