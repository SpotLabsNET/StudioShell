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
using System.Linq;
using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.PowerShell.Provider.PathNodes;
using CodeOwls.StudioShell.Common.Configuration;
using CodeOwls.StudioShell.Common.Utility;
using EnvDTE80;

namespace CodeOwls.StudioShell.Paths.Nodes.DTE
{
    internal class SelectedItemsNodeFactory : CollectionNodeFactoryBase
    {
        private readonly DTE2 _dte;

        public SelectedItemsNodeFactory(DTE2 dte)
        {
            _dte = dte;
        }

        #region Overrides of NodeFactoryBase

        public override string Name
        {
            get { return NodeNames.SelectedItems; }
        }

        public override IEnumerable<INodeFactory>  GetNodeChildren( IContext context )
        {
            List<INodeFactory> factories = new List<INodeFactory>
                                               {
                                                   new SelectedProjectItemsNodeFactory(_dte.SelectedItems),
                                                   new SelectedProjectsNodeFactory(_dte.SelectedItems)
                                               };
            
            var codeModel = new SelectedCodeModelItemsCollectionNodeFactory(_dte);

            if( PathTopologyVersions.SupportsSelectedCodeModelItemContainer( context ) )
            {
                factories.Add(codeModel);
            }
            else
            {
                factories.AddRange( codeModel.GetNodeChildren( context ));
            }

            if (null != _dte.ActiveDocument)
            {
                factories.Add(new DocumentNodeFactory(_dte.ActiveDocument, "ActiveDocument"));
            }
            
            

            return factories;
        }

        #endregion
    }
}