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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE;

namespace CodeOwls.StudioShell.PathNodes.PropertyModel
{
    class PropertyCollectionNodeFactory : CollectionNodeFactoryBase
    {
        private Properties _properties;

        public PropertyCollectionNodeFactory(Properties properties)
        {
            _properties = properties;
        }

        public override IEnumerable<INodeFactory> GetNodeChildren()
        {
            foreach( Property property in _properties)
            {
                yield return new PropertyNodeFactory(property);
            }
        }
        public override string Name
        {
            get { return "Properties"; }
        }
    }
}
