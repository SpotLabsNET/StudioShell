#
#   Copyright (c) 2011 Code Owls LLC, All Rights Reserved.
#
#   Licensed under the Microsoft Reciprocal License (Ms-RL) (the "License");
#   you may not use this file except in compliance with the License.
#   You may obtain a copy of the License at
#
#     http://www.opensource.org/licenses/ms-rl
#
#   Unless required by applicable law or agreed to in writing, software
#   distributed under the License is distributed on an "AS IS" BASIS,
#   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
#   See the License for the specific language governing permissions and
#   limitations under the License.
#
param($installPath, $toolsPath, $package, $project)

try
{
	pushd $env:HOMEDRIVE;

	try
	{
		add-type -reference EnvDTE -typedef @'
			/*
				Necessary to prevent Visual Studio from crashing when accessing 
				some of the AddIn object properties from PowerShell.  
				In particular, the Instance property seems to set off Visual Studio.
			*/
				public class AddInConnector
				{
					public static void Connect(object dte)
					{
						EnvDTE.DTE _dte = dte as EnvDTE.DTE;
						_dte.AddIns.Update();
						foreach( EnvDTE.AddIn addIn in _dte.AddIns )
						{
							if( addIn.Name.Contains( "StudioShell" ) && ! addIn.Connected )
							{
								addIn.Connected = true;
							}
						}
					}
						
					public static void Disconnect(object dte)
					{
						EnvDTE.DTE _dte = dte as EnvDTE.DTE;
				            
						foreach( EnvDTE.AddIn addIn in _dte.AddIns )
						{
							if( addIn.Name.Contains( "StudioShell" ) )
							{
								addIn.Connected = false;
								
								_dte.AddIns.Update();
								return;
							}
						}				
					}
				}    
'@;
	}
	catch
	{
	}
	
		$modulePath = $toolsPath;
		#$modulePath = $env:PSModulePath | where {$_ -match (Resolve-Path ~)} | select -First 1;
		#if( -not $modulePath )
		#{
		#	$modulePath = "~/documents/windowspowershell/modules";
		#	if( -not( Test-Path $modulePath ) )
		#	{
		#		mkdir $modulePath;
		#	}
		#	
		#	$modulePath = Resolve-Path $modulePath;
		#	$env:PSModulePath = '"{0}";{1}' -f $modulePath,$env:PSModulePath;
		#}
		
		$addinSpec = join-path $toolspath -child "StudioShell/bin/StudioShell.VS2010.AddIn";
		$settingsSpec = join-path $toolspath -child "StudioShell/bin/UserProfile/settings.txt";
		$profileSpec = join-path $toolspath -child "StudioShell/bin/UserProfile/profile.ps1";
		$addinAssemblyPath = join-path $modulePath -child "StudioShell/bin/CodeOwls.StudioShell.dll";

		$addinFolder = "~/Documents/Visual Studio 2010/Addins";
		$addinFilePath = join-path $addinFolder -child "StudioShell.addin";
		$studioShellProfileFolder = "~/Documents/CodeOwlsLLC.StudioShell";
		$profilePath = "~/Documents/CodeOwlsLLC.StudioShell/profile.ps1";
		$settingsPath = "~/Documents/CodeOwlsLLC.StudioShell/settings.txt";

		Write-Debug "Tools Path: $toolspath"
		Write-Debug "Module Path: $modulePath"
		Write-Debug "AddIn Folder: $addinFolder"
		Write-Debug "AddIn File Path: $addinFilePath"
		Write-Debug "StudioShell Profile Folder: $studioShellProfileFolder"
		Write-Debug "StudioShell Profile Path: $profilePath"
		Write-Debug "Settings Path: $settingsPath"

		if( Get-Module StudioShell )
		{
			Write-Debug "Disconnecting StudioShell Add-In";
			[AddInConnector]::Disconnect( $dte );
			
			Write-Debug "Removing existing StudioShell module";
			#Get-Module "StudioShell" | select -expand ModuleBase | Remove-Item -Recurse -Force;
			Remove-Module studioshell;
		}
		
		Write-Debug "Installing StudioShell module version $($package.Version)..."

		$modulePath,$studioShellProfileFolder,$addinFolder | where { -not( test-path $_ ) } | mkdir -erroraction silentlycontinue;
		
		( gc $addinSpec ) -replace '<Assembly>.+?</Assembly>',"<Assembly>$addinAssemblyPath</Assembly>" | out-file $addinFilePath;
		
		#cp "$toolsPath/StudioShell" -Destination $modulePath -container -Recurse -force
		
		if( -not( Test-Path $settingsPath ) )
		{
			cp $settingsSpec $settingsPath;
		}
		if( -not( Test-Path $profilePath ) )
		{
			cp $profileSpec $profilePath
		}

		Write-Debug 'Connecting StudioShell Add-In'
		[AddInConnector]::Connect( $dte );	
}
finally
{
	popd;
}

Write-Debug 'Importing StudioShell module'
import-module "$modulePath/StudioShell";

