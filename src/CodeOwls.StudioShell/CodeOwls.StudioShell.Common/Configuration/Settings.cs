/*
   Copyright (c) 2011 Code Owls LLC, All Rights Reserved.

   Licensed under the Microsoft Reciprocal License (Ms-RL) (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.opensource.org/licenses/ms-rl

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/


using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CodeOwls.StudioShell.Common.Configuration
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class Settings
    {      
        public Settings()
        {
            StartupLogLevel = StartupLogLevel.None;
            ConsoleChoice = ConsoleChoice.StudioShell;
            AutoManagePerSolutionModules = true;
            LoadStudioShellProfiles = true;
            LoadPowerShellProfiles = true;
            RunStudioShellOnStartup = false;

            var path = Assembly.GetExecutingAssembly().Location;
            var version = FileVersionInfo.GetVersionInfo(path).ProductVersion;
            DefaultPathTopologyVersion = new Version( version );
        }

        public bool RunStudioShellOnStartup { get; set; }
        public bool LoadPowerShellProfiles { get; set; }
        public bool LoadStudioShellProfiles { get; set; }
        public bool AutoManagePerSolutionModules { get; set; }
        public ConsoleChoice ConsoleChoice { get; set; }
        public StartupLogLevel StartupLogLevel{ get; set; }
        public Version DefaultPathTopologyVersion { get; set; }
    }
}
