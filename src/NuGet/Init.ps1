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
