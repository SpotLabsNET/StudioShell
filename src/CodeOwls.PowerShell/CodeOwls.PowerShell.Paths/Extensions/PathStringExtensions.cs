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
using System.Text.RegularExpressions;

namespace CodeOwls.PowerShell.Paths.Extensions
{
    public static class PathStringExtensions
    {        
        public static string MakeSafeForPath( this string path )
        {
            return String.IsNullOrEmpty(path)
                       ? path
                       : path.Replace('\\', '-')
                             .Replace('/', '-')
                             .Replace("&", "")
                             .Replace("…", "");
        }

        public static bool ContainsNodeName( this string path, string nodeName )
        {
            var pattern = String.Format(@"(?:^|[:\\\\/]){0}(?:[\\\\/]+|$)", Regex.Escape(nodeName));
            return Regex.IsMatch(path, pattern, RegexOptions.IgnoreCase);
        }
    }
}
