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


using System.Collections.Generic;
using System.Text;
using EnvDTE80;
using CodeOwls.StudioShell.DTE.Debugger;

namespace CodeOwls.StudioShell.PathNodes
{
    public class DebuggerNodeFactory : CollectionNodeFactoryBase
    {
        private readonly DTE2 _dte;

        public DebuggerNodeFactory(DTE2 dte)
        {
            _dte = dte;
        }

        public override IEnumerable<INodeFactory> GetNodeChildren()
        {
            var factories = new List<INodeFactory>
                       {
                           new BreakpointCollectionNodeFactory(_dte.Debugger.Breakpoints),
                           new ProcessCollectionNodeFactory( _dte.Debugger.DebuggedProcesses, "DebuggedProcesses"),
                           new ProcessCollectionNodeFactory( _dte.Debugger.LocalProcesses, "LocalProcesses")
                       };

            return factories;
        }

        public override IPathNode GetNodeValue()
        {
            return new PathNode( new ShellDebugger( _dte.Debugger as Debugger2 ), Name, true );
        }

        public override string Name
        {
            get { return "Debugger"; }
        }
    }
}
