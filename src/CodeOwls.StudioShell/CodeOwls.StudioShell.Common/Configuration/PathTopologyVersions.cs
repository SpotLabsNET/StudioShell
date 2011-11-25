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
using System.Reflection;
using System.Text;

namespace CodeOwls.StudioShell.Common.Configuration
{
    public static class PathTopologyVersions
    {
        static readonly Version V1 = new Version( 1,0 );

        static readonly Version Current = SettingsManager.Settings.DefaultPathTopologyVersion;

        public static Version[] GetAll()
        {
            return new[] {V1, Current};
        }

        /// <summary>
        /// Identifies whether the specified path topology version supports the solution-level code model
        /// </summary>
        /// <param name="version">The path topology version.</param>
        /// <returns>True if the path topology version supports a solution-level code model; false if it does not.</returns>
        public static bool SupportsSolutionCodeModel( Version version )
        {
            return version > V1;
        }

        /// <summary>
        /// Identifies whether the specified path topology version supports the project item-level code model
        /// </summary>
        /// <param name="version">The path topology version.</param>
        /// <returns>True if the path topology version supports a project item code model; false if it does not.</returns>
        public static bool SupportsProjectItemCodeModel(Version version)
        {
            return version <= V1;
        }
    }
}
