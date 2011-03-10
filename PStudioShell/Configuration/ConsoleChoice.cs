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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeOwls.StudioShell.Configuration
{
    public enum StartupLogLevel
    {
        None = 0,
        Debug = 1,
        Verbose = 2
    }
    public enum ConsoleChoice
    {
        None = 0,
        StudioShell = 1,
        OldSkool = 2,
        VSCommand = 3
    }
}
