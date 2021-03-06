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
using CodeOwls.StudioShell.Paths.Items.PropertyModel;
using EnvDTE;
using CodeOwls.PowerShell.Provider.PathNodes;

namespace CodeOwls.StudioShell.Paths.Nodes.PropertyModel
{
    public class PropertyNodeFactory : NodeFactoryBase, ISetItem
    {
        private readonly Property _property;

        public PropertyNodeFactory(EnvDTE.Property property)
        {
            _property = property;
        }

        public override string Name
        {
            get { return _property.Name; }
        }

        #region Implementation of ISetItem

        public object SetItemParameters
        {
            get { return null; }
        }

        public IPathNode SetItem(IContext context, string path, object value)
        {
            _property.Value = value;
            return GetNodeValue();
        }

        #endregion

        public override IPathNode GetNodeValue()
        {
            return new PathNode(
                new ShellProperty(_property),
                Name,
                false
                );
        }

        public override IEnumerable<INodeFactory>  GetNodeChildren( IContext context )
        {
            return null;
        }
    }
}