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
using CodeOwls.StudioShell.DTE.PropertyModel;
using CodeOwls.StudioShell.Utility;
using EnvDTE;
using EnvDTE80;

namespace CodeOwls.StudioShell.PathNodes
{
    public class ColorableItemFontsAndColorsPropertyNodeFactory : NodeFactoryBase
    {
        private readonly DTE2 _dte;
        private readonly FontsAndColorsItems _collection;
        private readonly ColorableItems _property;

        public ColorableItemFontsAndColorsPropertyNodeFactory(DTE2 dte, FontsAndColorsItems collection, ColorableItems property)
        {
            _dte = dte;
            _collection = collection;
            _property = property;
        }

        
        public override IPathNode GetNodeValue()
        {
            return new PathNode(
                new ShellColorableItem(_property),
                Name,
                false
                );
        }

        public override IEnumerable<INodeFactory> GetNodeChildren()
        {
            return null;
        }

        public override string Name
        {
            get { return _property.Name.MakeSafeForPath(); }
        }
    }
}
