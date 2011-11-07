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
		'./StudioShell.sln'
	);	
};

$framework = '4.0'
$private = "this is a private task not meant for external use";

function get-packageDirectory
{
	return "." | resolve-path | join-path -child "/bin/$config";
}

task default -depends All;

task All -depends Build;

task __VerifyConfiguration -description $private {
	Assert ( @('Debug', 'Release') -contains $config ) "Unknown configuration, $config; expecting 'Debug' or 'Release'";
	Assert ( Test-Path $slnFile ) "Cannot find solution, $slnFile";

	
	Write-Verbose ("packageDirectory: " + ( get-packageDirectory ));
}

task __CreatePackageDirectory -description $private {
	$packageDirectory = get-packageDirectory;
	
	if( !(Test-Path $packageDirectory ) )
	{
		Write-Verbose "creating package directory at $packageDirectory ...";
		mkdir $packageDirectory | Out-Null;
	}
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

task Clean -depends __VerifyConfiguration {
	exec { 
		msbuild $slnFile /p:Configuration=$config /t:Clean 
	}
}

task Rebuild -depends Clean,Build;

task Package -depends Build,__CreatePackageDirectory,__CleanPackageDirectory,__PackageNuGet,__PackageMSI -description "assembles distributions in the source hive"  {
	
}

