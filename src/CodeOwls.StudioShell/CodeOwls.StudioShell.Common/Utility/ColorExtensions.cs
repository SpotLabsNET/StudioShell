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


using System.Drawing;

namespace CodeOwls.StudioShell.Common.Utility 
{
    public static class ColorExtensions
    {
        public static uint ToUInt32( this Color color)
        {
            int value = 0;
            value = (color.B << 16) | (color.G << 8) | color.R;
            return (uint) value;
        }

        public static Color ToColor(this uint value)
        {
            Color color = Color.FromArgb((int) value);
            return color;
        }
    }
}
