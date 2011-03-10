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


import-module preferencestack;
get-studioShellSettings.ps1 | push-preference;

if( -not( [environment]::commandLine -match "devenv.exe" ) )
{
	throw "The StudioShell module is only available from a PowerShell session hosted by Visual Studio.";
}

try
{
	write-debug 'testing for presence of StudioShell add-in...';
	[CodeOwls.StudioShell.Connect] | out-null;
}
catch
{
	throw "The StudioShell Add-In is not loaded.  Please make sure you have the add-in enabled.";
}

$local:root = $myInvocation.MyCommand.Path | split-path;
write-debug "local module root path is $local:root"

# import the assembly into the module session so we can register the runspace with the add-in
write-debug "connecting to StudioShell add in instance";
[CodeOwls.StudioShell.Connect]::RegisterRunspace( $host.runspace );

# create module commands for each script under the scripts directory
# content of each script file becomes a unique exported module function
write-debug "generating module commands";

ls $local:root/scripts | foreach {
	$local:c = ( get-content -path $_.pspath ) -join "`n";	
	$local:n = $_.Name -replace '.{4}$','';
	
	$local:fxn = "function $local:n`n{`n$local:c`n}";
	
	write-verbose $local:fxn
	invoke-expression $local:fxn;
}

write-host "Studio" -back darkblue -fore darkyellow -nonewline;
write-host "Shell" -fore darkblue -back darkyellow;
write-host "Copyright (c) 2011 Code Owls LLC, All Rights Reserved.";

pop-preference;
remove-module preferencestack;

