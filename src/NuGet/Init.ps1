#
#   Copyright (c) 2014 Code Owls LLC, All Rights Reserved.
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

# verify Visual Studio version support
$vsversion = ( [environment]::getCommandLineArgs() | 
        select -first 1 | 
        get-item |
        select -exp VersionInfo |
        select -exp ProductVersion 
    ) -split '\.' | select -first 1
    
if( 9,10,11,12 -notcontains $vsversion )
{
    uninstall-package $package.id
    write-error "The current version of Visual Studio ($vsversion) is not supported";
    return;
}

$modulePath = join-path $toolspath -child "StudioShell.Provider";
$packageVersion = $package.version.version;
    
Write-Debug "Module Path: $modulePath"
Write-Debug "Package Version: $pacakgeVersion"

Write-Debug "Importing StudioShell.provider module from path: $modulePath";
import-module $modulePath;
Write-Debug "registering solution events";
#import-module $modulePath/InitializationScripts/register-solutionevents.ps1 -global;
. $modulePath/InitializationScripts/register-solutionevents.ps1;

