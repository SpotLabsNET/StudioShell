using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CodeOwls.StudioShell.Common.Configuration
{
    public static class PathTopologyVersions
    {
        static readonly Version V1 = new Version( 1,0,1 );

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
