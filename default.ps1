# Copyright (c) 2011 Code Owls LLC
# 
# psake build script for StudioShell
#
# valid configurations:
#  Debug
#  Release
#
# notes:
#

properties {
	$config = 'Debug'; 	
	$keyContainer = '';
	$slnFile = @(
		'./src/StudioShell.sln'
	);	
    $targetPath = "./src/CodeOwls.StudioShell/CodeOwls.StudioShell/bin";
    $nugetSource = "./src/NuGet";
    $metadataAssembly = 'CodeOwls.StudioShell.dll'
    $currentReleaseNotesPath = '.\src\CodeOwls.StudioShell\CodeOwls.StudioShell\bin\Module\StudioShell\en-US\about_StudioShell_Version.help.txt'
};

$framework = '4.0'
$private = "this is a private task not meant for external use";

set-alias nuget ( './lib/nuget.exe' | resolve-path | select -expand path );

function get-packageDirectory
{
	return "." | resolve-path | join-path -child "/bin/$config";
}

function get-nugetPackageDirectory
{
    return "." | resolve-path | join-path -child "/bin/$config/NuGet";
}

function create-PackageDirectory( [Parameter(ValueFromPipeline=$true)]$packageDirectory )
{
    process
    {
        write-verbose "checking for package path $packageDirectory ..."
        if( !(Test-Path $packageDirectory ) )
    	{
    		Write-Verbose "creating package directory at $packageDirectory ...";
    		mkdir $packageDirectory | Out-Null;
    	}
    }    
}

task default -depends All;

task All -depends Build;

task __VerifyConfiguration -description $private {
	Assert ( @('Debug', 'Release') -contains $config ) "Unknown configuration, $config; expecting 'Debug' or 'Release'";
	Assert ( Test-Path $slnFile ) "Cannot find solution, $slnFile";

	
	Write-Verbose ("packageDirectory: " + ( get-packageDirectory ));
}

task __CreatePackageDirectory -description $private {
	get-packageDirectory | create-packageDirectory;		
}

task __CreateNuGetPackageDirectory -description $private {
    $p = get-nugetPackageDirectory;
    $p  | create-packageDirectory;
    @( 'tools','lib','content' ) | %{join-path $p -child $_ } | create-packageDirectory;
}

task __CreateLocalDataDirectory -description $private {
	if( -not ( Test-Path ./_local ) )
	{
		mkdir ./_local | Out-Null;
	}
}

task Build -depends __VerifyConfiguration {
	exec { 
		msbuild $slnFile /p:Configuration=$config /p:KeyContainerName=$keyContainer /t:Build 
	}
}

task Clean -depends __VerifyConfiguration,CleanNuGet {
	exec { 
		msbuild $slnFile /p:Configuration=$config /t:Clean 
	}
}

task CleanNuGet -depends __CreateNuGetPackageDirectory -description "clears the nuget package staging area" {
    get-nugetPackageDirectory | 
        ls | 
        ?{ $_.psiscontainer } | 
        ls | 
        remove-item -recurse -force;
}

task Rebuild -depends Clean,Build;

task Package -depends Build,__PackageNuGet,__PackageMSI -description "assembles distributions in the source hive"

task PackageMSI -depends Build,__CreatePackageDirectory -description "assembles the MSI distribution" {

}

task PackageNuGet -depends Build,__CreateNuGetPackageDirectory,CleanNuGet -description "assembles the nuget distribution" {
    $output = get-packageDirectory;
    $ngp = get-nugetPackageDirectory;
    $tools = join-path $ngp 'tools';
    $md = join-path $tools $metadataAssembly;
    $spec = join-path $ngp 'studioshell.nuspec'
    
    ls $targetPath | copy-item -dest $tools -recurse -force;
    ls $nugetSource -filter *.ps1 | copy-item -dest $tools -force;
    ls $nugetSource -filter *.nuspec | copy-item -dest $ngp -force -verbose;
    
    $c = gc $spec;
    $c = $c -replace '\$id\$', ( get-item $md | select -exp versioninfo | select -exp productversion );
    $c = $c -replace '\$relnotes\$', ( gc $currentReleaseNotesPath );
    $c = $c -join "`n";
    $c | out-file $spec -force;
    
    $c | write-debug;
    
    pushd $ngp;
    nuget pack StudioShell.nuspec -outputdirectory $output
    popd;
}

