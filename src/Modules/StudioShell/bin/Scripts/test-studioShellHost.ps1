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

if( -not( [environment]::commandLine -match "devenv.exe" ) )
{
	return $false;
}

try
{
	[CodeOwls.StudioShell.Connect] | out-null;
}
catch
{
	return $false;
}

return( ( $null -ne $host.Runspace ) );

<#
.SYNOPSIS 
Indicates whether the current PowerShell host and process can support StudioShell features.

.DESCRIPTION
This script verifies the following host features:

    * the host is running inside of the Visual Studio process;
    * the StudioShell add-in is loaded;
    * the PowerShell host exposes the public Runspace property.
    
.INPUTS
None.

.OUTPUTS
$true if StudioShell can be used in the current host and process.  $false otherwise.

.EXAMPLE
C:\PS> test-studioShellHost.ps1
True

.LINK
about_StudioShell
about_StudioShell_Host_Requirements

#>
