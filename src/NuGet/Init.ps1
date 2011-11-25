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

add-type -reference EnvDTE -typedef @'
/*
    Necessary to prevent Visual Studio from crashing when accessing 
    some of the AddIn object properties.  In particular, the Instance
    property seems to set off the crash bit in Visual Studio.
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
    }    
'@;

$addinSpec = join-path $toolspath -child "StudioShell.VS2010.AddIn";
$settingsSpec = join-path $toolspath -child "UserProfile/settings.txt";
$profileSpec = join-path $toolspath -child "UserProfile/profile.ps1";
$addinAssemblyPath = join-path $toolspath -child "CodeOwls.StudioShell.dll";

$addinFolder = "~/Documents/Visual Studio 2010/Addins";
$addinFilePath = join-path $addinFolder -child "StudioShell.addin";
$studioShellProfileFolder = "~/Documents/CodeOwlsLLC.StudioShell";
$profilePath = "~/Documents/CodeOwlsLLC.StudioShell/profile.ps1";
$settingsPath = "~/Documents/CodeOwlsLLC.StudioShell/settings.txt";

mkdir $studioShellProfileFolder,$addinFolder -erroraction silentlycontinue;
( gc $addinSpec ) -replace '<Assembly>.+?</Assembly>',"<Assembly>$addinAssemblyPath</Assembly>" | out-file $addinFilePath;

cp $settingsSpec $settingsPath;
cp $profileSpec $profilePath

[AddInConnector]::Connect( $dte );
