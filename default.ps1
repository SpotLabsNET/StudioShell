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
	$local = './_local';
	$keyContainer = '';
	$slnFile = @(
		'./src/StudioShell.sln'
	);	
    $targetPath = "./src/CodeOwls.StudioShell/CodeOwls.StudioShell/bin";
    $nugetSource = "./src/NuGet";
	$moduleSource = "./src/Modules";
    $metadataAssembly = 'CodeOwls.StudioShell.dll'
    $currentReleaseNotesPath = '.\src\Modules\StudioShell\en-US\about_StudioShell_Version.help.txt'
	$wixResourcePath = ".\src\Installer\Resources";
	$wixProjectPath = ".\src\Installer";
};

$framework = '4.0'
$private = "this is a private task not meant for external use";

set-alias nuget ( './lib/nuget.exe' | resolve-path | select -expand path );
set-alias light ( './lib/wix/light.exe' | resolve-path | select -expand path );
set-alias candle ( './lib/wix/candle.exe' | resolve-path | select -expand path );

function get-packageDirectory
{
	return "." | resolve-path | join-path -child "/bin/$config";
}

function get-nugetPackageDirectory
{
    return "." | resolve-path | join-path -child "/bin/$config/NuGet";
}

function get-modulePackageDirectory
{
    return "." | resolve-path | join-path -child "/bin/$config/Modules";
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

function get-StudioShellVersion
{
	$p = get-modulePackageDirectory;    
    $md = join-path $p "StudioShell\bin\$metadataAssembly";
    ( get-item $md | select -exp versioninfo | select -exp productversion );
}

task default -depends Install;

# private tasks

task __VerifyConfiguration -description $private {
	Assert ( @('Debug', 'Release') -contains $config ) "Unknown configuration, $config; expecting 'Debug' or 'Release'";
	Assert ( Test-Path $slnFile ) "Cannot find solution, $slnFile";
	
	Write-Verbose ("packageDirectory: " + ( get-packageDirectory ));
}

task __CreatePackageDirectory -description $private {
	get-packageDirectory | create-packageDirectory;		
}

task __CreateModulePackageDirectory -description $private {
	get-modulePackageDirectory | create-packageDirectory;		
}

task __CreateNuGetPackageDirectory -description $private {
    $p = get-nugetPackageDirectory;
    $p  | create-packageDirectory;
    @( 'tools','lib','content' ) | %{join-path $p -child $_ } | create-packageDirectory;
}

task __CreateLocalDataDirectory -description $private {
	if( -not ( Test-Path $local ) )
	{
		mkdir $local | Out-Null;
	}
}

function assemble-moduleDocumentation
{
	$helpPath = get-modulePackageDirectory | Join-Path -ChildPath "StudioShell\en-US";
	$cmdletTopicPath = $helpPath | Join-Path -ChildPath "ProviderCmdlets";
	$providerHelpPath = $helpPath | Join-Path -ChildPath "CodeOwls.StudioShell.Provider.dll-help.xml";

	$help = New-Object xml;
	$help.Load( $providerHelpPath );
	$helpNode = $help.selectSingleNode( '//CmdletHelpPaths' );
	
	ls $cmdletTopicPath | %{ 
		$node = [xml] ($_ | gc);
		$node = $help.importNode( $node.CmdletHelpPath, $true );
		$helpNode.AppendChild( $node ) | Out-Null;		
	};
	
	ri $cmdletTopicPath -Force -Recurse;
	$help.Save( $providerHelpPath );
}

# primary targets

task Build -depends __VerifyConfiguration -description "builds any outdated dependencies from source" {
	exec { 
		msbuild $slnFile /p:Configuration=$config /p:KeyContainerName=$keyContainer /t:Build 
	}
}

task Clean -depends __VerifyConfiguration,CleanNuGet,CleanModule -description "deletes all temporary build artifacts" {
	exec { 
		msbuild $slnFile /p:Configuration=$config /t:Clean 
	}
}

task Rebuild -depends Clean,Build -description "runs a clean build";

task Package -depends __PackageModule,__PackageNuGet,__PackageMSI -description "assembles distributions in the source hive"

# clean tasks

task CleanNuGet -depends __CreateNuGetPackageDirectory -description "clears the nuget package staging area" {
    get-nugetPackageDirectory | 
        ls | 
        ?{ $_.psiscontainer } | 
        ls | 
        remove-item -recurse -force;
}

task CleanModule -depends __CreateModulePackageDirectory -description "clears the module package staging area" {
    get-modulePackageDirectory | 
        remove-item -recurse -force;
}

# package tasks

task PackageModule -depends CleanModule,Build,__CreateModulePackageDirectory -description "assembles module distribution file hive" -action {
	$mp = get-modulePackageDirectory;
	
	# copy module src hive to distribution hive
	Copy-Item $moduleSource -container -recurse -Destination $mp -Force;
	
	# copy bins to module bin area
	ls $targetPath | copy-item -dest "$mp\StudioShell\bin" -recurse -force;
} -postaction {
	assemble-moduleDocumentation;
}

task PackageMSI -depends PackageModule -description "assembles the MSI distribution" {
	$mp = get-modulePackageDirectory | Join-Path -ChildPath StudioShell;
	$md = join-path $targetPath -ChildPath $metadataAssembly;
	$version = ( get-item $md | select -exp versioninfo | select -exp productversion )
	$varFilePath = Join-Path $wixProjectPath -ChildPath 'Variables.wxi';
	$output = get-packageDirectory;
	$resPath = $wixResourcePath | Resolve-Path;
	
@'
<?xml version="1.0" encoding="utf-8"?>
<Include>
  <?define StudioShellModuleRootPath = "{0}" ?>
  <?define ResourcePath = "{1}" ?>
  <?define StudioShellVersion = "{2}" ?>
</Include>
'@ -f $mp,$resPath,$version | Out-File $varFilePath -Encoding UTF8;

	#candle.exe -dDebug -d"DevEnvDir=c:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\\" -dSolutionDir=C:\Users\beefarino\Documents\Project\cppstest\src\ -dSolutionExt=.sln -dSolutionFileName=StudioShell.sln -dSolutionName=StudioShell -dSolutionPath=C:\Users\beefarino\Documents\Project\cppstest\src\StudioShell.sln -dConfiguration=Debug -dOutDir=bin\Debug\ -dPlatform=x86 -dProjectDir=C:\Users\beefarino\Documents\Project\cppstest\src\CodeOwls.StudioShell.Setup.Wix\ -dProjectExt=.wixproj -dProjectFileName=CodeOwls.StudioShell.Setup.Wix.wixproj -dProjectName=CodeOwls.StudioShell.Setup.Wix -dProjectPath=C:\Users\beefarino\Documents\Project\cppstest\src\CodeOwls.StudioShell.Setup.Wix\CodeOwls.StudioShell.Setup.Wix.wixproj -dTargetDir=C:\Users\beefarino\Documents\Project\cppstest\src\CodeOwls.StudioShell.Setup.Wix\bin\Debug\ -dTargetExt=.msi -dTargetFileName=CodeOwls.StudioShell.Setup.Wix.msi -dTargetName=CodeOwls.StudioShell.Setup.Wix -dTargetPath=C:\Users\beefarino\Documents\Project\cppstest\src\CodeOwls.StudioShell.Setup.Wix\bin\Debug\CodeOwls.StudioShell.Setup.Wix.msi -out obj\Debug\ -arch x86 Components.wxs Product.wxs obj\Debug\Product.Generated.wxs
	pushd $wixProjectPath
	$wxs = ( ls *.wxs | select -ExpandProperty Name );
	$wixobj = ( ls *.wxs | select -ExpandProperty Name | foreach { "obj\$config\$_" -replace 'wxs$','wixobj' } )

	exec {
		candle -out "obj\$config\" $wxs
	}
	exec {
		light -out "$output\StudioShell.$version.msi" -pdbout "$output\CodeOwls.StudioShell.Setup.Wix.wixpdb" -sice:ICE91 $wixobj 
	}
	popd
}

task PackageNuGet -depends PackageModule,__CreateNuGetPackageDirectory,CleanNuGet -description "assembles the nuget distribution" {
    $output = get-packageDirectory;
    $mp = get-modulePackageDirectory;
	$ngp = get-nugetPackageDirectory;
    $tools = join-path $ngp 'tools';
    $md = join-path $tools "StudioShell\bin\$metadataAssembly";
    $spec = join-path $ngp 'studioshell.nuspec'
    
	#prepare the nuget distribution area
	Write-Verbose "preparing nuget distribution hive ...";
	
	# copy module distribution hive to nuget tools folder
    ls $mp | copy-item -dest $tools -recurse -force;
	# copy nuget source scripts to tools folder
    ls $nugetSource -filter *.ps1 | copy-item -dest $tools -force;
	# copy nuget nuspec file to nuget package folder
    ls $nugetSource -filter *.nuspec | copy-item -dest $ngp -force;
    
	#update the releasenotes and version info in the nuspec file
	Write-Verbose "updating release notes and version info in nuspec file...";
	
	# load the nuspec file contents
    $c = gc $spec;
	# replace $id$ placeholder with assembly version info from addin assembly
    $c = $c -replace '\$id\$', ( get-item $md | select -exp versioninfo | select -exp productversion );
	# replace $relnotes$ token with contents of current release notes help topic
    $c = $c -replace '\$relnotes\$', ( gc $currentReleaseNotesPath );
	# reformat the spec file contents and write nuspec file
    $c = $c -join "`n";
    $c | out-file $spec -force;
    
    # pack the nuget distribution   
	Write-Verbose "packing nuget distribution ...";
    pushd $ngp;
    nuget pack StudioShell.nuspec -outputdirectory $output
    popd;
}

# install tasks

task Uninstall -description "uninstalls the module from the local user module repository" {
	$modulePath = $Env:PSModulePath -split ';' | select -First 1 | Join-Path -ChildPath 'studioshell';
	if( Test-Path $modulePath )
	{
		Write-Verbose "uninstalling StudioShell from local module repository at $modulePath";
		
		$modulePath | ri -Recurse -force;
	}

	$addinFolder = "~/Documents/Visual Studio 2010/Addins";
	$addinFilePath = join-path $addinFolder -child "StudioShell.addin";

	if( Test-Path $addinFilePath )
	{
		Remove-Item $addinFilePath -force;
	}
	
	if( test-path 'HKCU:\software\Microsoft\VisualStudio\10.0\PreloadAddinStateManaged' )
	{				
		Remove-ItemProperty -Path 'HKCU:\software\Microsoft\VisualStudio\10.0\PreloadAddinStateManaged' -Name *StudioShell*;
	}
}

task Install -depends InstallModule,InstallAddin -description "installs the module and add-in to the local machine";

task InstallModule -depends PackageModule -description "installs the module to the local user module repository" {
	$packagePath = get-modulePackageDirectory;
	$modulePath = $Env:PSModulePath -split ';' | select -First 1;
	Write-Verbose "installing StudioShell from local module repository at $modulePath";
	
	ls $packagePath | Copy-Item -recurse -Destination $modulePath -Force;	
}

task InstallAddin -depends InstallModule -description "installs the VS 2010 add-in to the local machine" {
	$addInInstallPath = $Env:PSModulePath -split ';' | select -First 1 | Join-Path -ChildPath "StudioShell\bin";
	
	$addinSpec = join-path $addInInstallPath -child "StudioShell.VS2010.AddIn";
	$settingsSpec = join-path $addInInstallPath -child "UserProfile/settings.txt";
	$profileSpec = join-path $addInInstallPath -child "UserProfile/profile.ps1";
	$addinAssemblyPath = join-path $addInInstallPath -child "CodeOwls.StudioShell.dll";

	$addinFolder = "~/Documents/Visual Studio 2010/Addins";
	$addinFilePath = join-path $addinFolder -child "StudioShell.addin";
	$studioShellProfileFolder = "~/Documents/CodeOwlsLLC.StudioShell";
	$profilePath = "~/Documents/CodeOwlsLLC.StudioShell/profile.ps1";
	$settingsPath = "~/Documents/CodeOwlsLLC.StudioShell/settings.txt";

	mkdir $studioShellProfileFolder,$addinFolder -erroraction silentlycontinue;
	( gc $addinSpec ) -replace '<Assembly>.+?</Assembly>',"<Assembly>$addinAssemblyPath</Assembly>" | out-file $addinFilePath;

	cp $settingsSpec $settingsPath;
	cp $profileSpec $profilePath
	
	if( test-path 'HKCU:\software\Microsoft\VisualStudio\10.0\PreloadAddinStateManaged' )
	{
		# reset addin registry flags to force a reload of UI extensions
		Remove-ItemProperty -Path 'HKCU:\software\Microsoft\VisualStudio\10.0\PreloadAddinStateManaged' -Name *StudioShell*;
	}
}
