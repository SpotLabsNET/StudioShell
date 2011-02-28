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

namespace CodeOwls.PowerShell.WinForms.Configuration
{
    public class UISettings
    {
        public Color ForegroundColor;
        public Color BackgroundColor;
        public Color ErrorForegroundColor;
        public Color ErrorBackgroundColor;
        public Color WarningForegroundColor;
        public Color WarningBackgroundColor;
        public Color VerboseForegroundColor;
        public Color VerboseBackgroundColor;
        public Color DebugForegroundColor;
        public Color DebugBackgroundColor;

        public FontFamily FontName;
        public int FontSize;
        public FontStyle FontStyle;

        public bool PromptForCredentialsInConsole;

        public UISettings()
        {
            BackgroundColor = Color.White;

            ForegroundColor = Color.Black;
            ErrorForegroundColor = Color.Red;
            WarningForegroundColor = Color.Yellow;
            VerboseForegroundColor = Color.Green;
            DebugForegroundColor = Color.DarkBlue;

            FontName = FontFamily.GenericMonospace;
            FontSize = 10;
            FontStyle = FontStyle.Bold;

            PromptForCredentialsInConsole = true;
        }
    }
}
