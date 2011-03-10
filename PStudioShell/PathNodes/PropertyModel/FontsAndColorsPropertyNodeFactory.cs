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
using CodeOwls.StudioShell.DTE;
using EnvDTE;
using EnvDTE80;

namespace CodeOwls.StudioShell.PathNodes
{
    public class FontsAndColorsPropertyNodeFactory : NodeFactoryBase
    {
        private readonly DTE2 _dte;
        private readonly FontsAndColorsItems _property;

        public FontsAndColorsPropertyNodeFactory(DTE2 dte, FontsAndColorsItems property)
        {
            _dte = dte;
            _property = property;
        }

        public override IPathNode GetNodeValue()
        {
            return new PathNode(
                new ShellContainer( this ),
                Name,
                true
                );
        }

        public override IEnumerable<INodeFactory> GetNodeChildren()
        {
            List<INodeFactory> factories = new List<INodeFactory>();
            foreach (ColorableItems ci in _property )
            {
                factories.Add(new ColorableItemFontsAndColorsPropertyNodeFactory(_dte, _property, ci));
            }
            return factories;
        }

        public override string Name
        {
            get { return "FontsAndColors"; }
        }
    }
}
