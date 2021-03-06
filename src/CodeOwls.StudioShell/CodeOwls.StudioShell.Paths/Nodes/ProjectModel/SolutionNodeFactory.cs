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
using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.PowerShell.Provider.PathNodes;
using CodeOwls.StudioShell.Common.Configuration;
using CodeOwls.StudioShell.Common.Utility;
using CodeOwls.StudioShell.Paths.Items;
using CodeOwls.StudioShell.Paths.Nodes.Configurations;
using EnvDTE80;

namespace CodeOwls.StudioShell.Paths.Nodes.ProjectModel
{
    public class SolutionNodeFactory : NodeFactoryBase
    {
        private readonly DTE2 _dte;
        private readonly ShellSolution _shellObject;

        public SolutionNodeFactory(DTE2 dte)
        {
            _dte = dte;
            _shellObject = new ShellSolution(_dte.Solution as Solution2);
        }

        public override string Name
        {
            get { return NodeNames.Solution; }
        }

        public override IPathNode GetNodeValue()
        {
            return new PathNode(_shellObject, Name, true);
        }

        public override IEnumerable<INodeFactory>  GetNodeChildren( IContext context )
        {
            var factories = new List<INodeFactory>();

            if (null != _dte.Solution && null != _dte.Solution.SolutionBuild)
            {
                factories.Add(new SolutionBuildNodeFactory(_dte.Solution.SolutionBuild));
            }

            factories.Add(new SolutionProjectsNodeFactory(_dte));

            if (PathTopologyVersions.SupportsSolutionCodeModel(context))
            {
                factories.Add(new SolutionCodeModelNodeFactory(_dte));
            }

            return factories;
        }
    }
}