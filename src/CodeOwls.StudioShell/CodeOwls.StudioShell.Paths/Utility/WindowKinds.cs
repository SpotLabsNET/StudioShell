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


using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Utility
{
    internal static class VSWindowKinds
    {
        public static string AutoLocals = Constants.vsWindowKindAutoLocals;
        public static string CallStack = Constants.vsWindowKindCallStack;
        public static string ClassView = Constants.vsWindowKindClassView;
        public static string CommandWindow = Constants.vsWindowKindCommandWindow;
        public static string DocumentOutline = Constants.vsWindowKindDocumentOutline;
        public static string DynamicHelp = Constants.vsWindowKindDynamicHelp;
        public static string FindReplace = Constants.vsWindowKindFindReplace;
        public static string FindResults1 = Constants.vsWindowKindFindResults1;
        public static string FindResults2 = Constants.vsWindowKindFindResults2;
        public static string FindSymbol = Constants.vsWindowKindFindSymbol;
        public static string FindSymbolResults = Constants.vsWindowKindFindSymbolResults;
        public static string LinkedWindowFrame = Constants.vsWindowKindLinkedWindowFrame;
        public static string Locals = Constants.vsWindowKindLocals;
        public static string MacroExplorer = Constants.vsWindowKindMacroExplorer;
        public static string MainWindow = Constants.vsWindowKindMainWindow;
        public static string ObjectBrowser = Constants.vsWindowKindObjectBrowser;
        public static string Output = Constants.vsWindowKindOutput;
        public static string Properties = Constants.vsWindowKindProperties;
        public static string ResourceView = Constants.vsWindowKindResourceView;
        public static string ServerExplorer = Constants.vsWindowKindServerExplorer;
        public static string SolutionExplorer = Constants.vsWindowKindSolutionExplorer;
        public static string TaskList = Constants.vsWindowKindTaskList;
        public static string Thread = Constants.vsWindowKindThread;
        public static string Toolbox = Constants.vsWindowKindToolbox;
        public static string Watch = Constants.vsWindowKindWatch;
        public static string WebBrowser = Constants.vsWindowKindWebBrowser;

        public static string[] All
        {
            get
            {
                return new[]

                           {
                               AutoLocals,
                               CallStack,
                               ClassView,
                               CommandWindow,
                               DocumentOutline,
                               DynamicHelp,
                               FindReplace,
                               FindResults1,
                               FindResults2,
                               //FindSymbol,
                               FindSymbolResults,
                               //LinkedWindowFrame,
                               Locals,
                               MacroExplorer,
                               //MainWindow,
                               ObjectBrowser,
                               Output,
                               Properties,
                               ResourceView,
                               ServerExplorer,
                               SolutionExplorer,
                               TaskList,
                               Thread,
                               Toolbox,
                               //Watch,
                               WebBrowser
                           };
            }
        }
    }
}