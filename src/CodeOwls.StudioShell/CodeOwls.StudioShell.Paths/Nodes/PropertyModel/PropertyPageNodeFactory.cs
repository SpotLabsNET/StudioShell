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
using System.Runtime.InteropServices;
using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.StudioShell.Paths.Items;
using EnvDTE;
using EnvDTE80;
using CodeOwls.PowerShell.Provider.PathNodes;

namespace CodeOwls.StudioShell.Paths.Nodes.PropertyModel
{
    public class PropertyPageNodeFactory : NodeFactoryBase
    {
        private readonly string _category;
        private readonly DTE2 _dte;
        private readonly string _page;

        public PropertyPageNodeFactory(DTE2 dte, string category, string page)
        {
            _dte = dte;
            _category = category;
            _page = page;
        }

        public override string Name
        {
            get { return _page; }
        }

        public override IPathNode GetNodeValue()
        {
            return new PathNode(new ShellContainer(this), Name, true);
        }

        public override IEnumerable<INodeFactory>  GetNodeChildren( IContext context )
        {
            var factories = new List<INodeFactory>();
            var props = _dte.get_Properties(_category, _page);
            foreach (EnvDTE.Property prop in props)
            {
                INodeFactory factory = null;
                try
                {
                    if (null != prop && null != prop.Object && prop.Object is FontsAndColorsItems)
                    {
                        FontsAndColorsItems fci = prop.Object as FontsAndColorsItems;
                        factory = new FontsAndColorsPropertyNodeFactory(_dte, fci);
                    }
                }
                catch
                {
                }

                if (null == factory)
                {
                    factory = new PropertyNodeFactory(prop);
                }

                factories.Add(factory);
            }
            return factories;
        }
    }
}