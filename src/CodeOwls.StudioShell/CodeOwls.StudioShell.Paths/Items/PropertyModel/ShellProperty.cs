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

namespace CodeOwls.StudioShell.Paths.Items.PropertyModel
{
    public class ShellProperty
    {
        private readonly Property _property;

        internal ShellProperty(Property property)
        {
            _property = property;
        }

        public object Value
        {
            get { return _property.Value; }
            set { _property.Value = value; }
        }

        public short NumIndices
        {
            get { return _property.NumIndices; }
        }

        public string Name
        {
            get { return _property.Name; }
        }

        public object get_IndexedValue(object Index1, object Index2, object Index3, object Index4)
        {
            return _property.get_IndexedValue(Index1, Index2, Index3, Index4);
        }

        public void set_IndexedValue(object Index1, object Index2, object Index3, object Index4, object Val)
        {
            _property.set_IndexedValue(Index1, Index2, Index3, Index4, Val);
        }
    }
}