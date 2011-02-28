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
using System.IO;
using System.Management.Automation;
using System.Text;
using System.Windows.Forms;

namespace CodeOwls.PowerShell.WinForms.Utility
{
    public static class Extensions
    {
        public static PSObject ToPSObject( this object o )
        {
            return PSObject.AsPSObject(o);
        }
        public static bool Contains( this Keys item, Keys value )
        {
            return value == (item & value);
        }

        public static string ToDotSource( this FileInfo fileInfo )
        {
            return String.Format(". \"{0}\"", fileInfo.FullName).EscapeTicks();
        }

        public static string EscapeTicks( this string str )
        {
            StringBuilder builder = new StringBuilder(str.Length * 2);
            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                switch (ch)
                {
                    case '`':
                    case '\'':
                        builder.Append('`');
                        break;
                }
                builder.Append(ch);
            }
            string format = builder.ToString();
            return format;
        }
    }
}
