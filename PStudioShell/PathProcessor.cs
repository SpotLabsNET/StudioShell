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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using CodeOwls.StudioShell.PathNodes;

namespace CodeOwls.StudioShell
{
	public class PathProcessor
	{
		private Dictionary<Type, Delegate> _nameMap = new Dictionary<Type, Delegate>();
		
		public PathNode MapPathOnObject( string path, object item )
		{
			Regex re = new Regex(@"^[-_a-zA-Z0-9]+:[\\/]?");
			Type typeOfIEnumerable = typeof (IEnumerable);
			path = re.Replace(path, "");

			var parts = path.Split(new []{'/', '\\'}, StringSplitOptions.RemoveEmptyEntries );
			foreach( var part in parts )
			{
				var type = item.GetType();

				if( ! IsSpelunkable( type ))
				{
					return null;
				}
				
				if ( IsCollection(item))
				{
					bool matchFound = false;
					IEnumerable en = item as IEnumerable;
					foreach (object e in en)
					{
						if (!_nameMap.ContainsKey(e.GetType()))
						{
							continue;
						}

						string itemname = _nameMap[e.GetType()].DynamicInvoke(e).ToString();
						if (itemname.ToLowerInvariant() == part.ToLowerInvariant())
						{
							item = e;
							matchFound = true;

							break;
						}
					}

					if (!matchFound)
					{
						return null;
					}
				}
				else
				{
					var pi = type.GetProperty(part, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
					if( null == pi)
					{
						return null;
					}

					item = pi.GetValue(item, null);
				}
			}

			string name = _nameMap.ContainsKey(item.GetType())
			              	? _nameMap[item.GetType()].DynamicInvoke(item).ToString()
			              	: parts.Any() ? parts.Last() : item.GetType().Name;
			return new PathNode(item, name, IsContainerItem(item ));
		}

		public IEnumerable<PathNode> GetChildPathNodes( PathNode node )
		{
            List<PathNode> nodes = new List<PathNode>();
			if( ! node.IsCollection )
			{
				return nodes;
			}

			foreach( var item in (IEnumerable) node.Item )
			{
				string name = item.GetHashCode().ToString();
				if (_nameMap.ContainsKey(item.GetType()))
				{
					name = _nameMap[item.GetType()].DynamicInvoke(item).ToString();
				}

				nodes.Add( new PathNode( item, name, IsContainerItem( item )));
			}
			return nodes;
		}
		public PathProcessor AddNameTransform<T>(Expression< Func< T, string > > func)
		{			
			_nameMap[typeof (T)] = func.Compile();
			return this;
		}

		public PathProcessor AddNonSpelunkerableType<T>()
		{
			return AddNonSpelunkerableType(typeof (T));
		}

		public PathProcessor AddNonSpelunkerableType(Type type)
		{
			_nonspelunkableTypes.Add(type);
			return this;
		}

		public PathProcessor AddNonEnumerableType<T>()
		{
			return AddNonEnumerableType(typeof(T));
		}

		public PathProcessor AddNonEnumerableType(Type type)
		{
			_nonenumerableTypes.Add(type);
			return this;
		}

		private List<Type> _nonenumerableTypes = new List<Type>
		                                           	{
		                                           		typeof (string)
		                                           	};
		private List<Type> _nonspelunkableTypes = new List<Type>
		                                           	{
		                                           		typeof (string)
		                                           	};
		private bool IsSpelunkable(Type type)
		{
			return !_nonspelunkableTypes.Contains(type);
		}

		private bool IsContainerItem( object item )
		{
			var properties = from pi in item.GetType().GetProperties()
			                 where IsSpelunkable(pi.PropertyType)
			                 select pi;

			return IsCollection( item ) || properties.Any();

		}
		private bool IsCollection(object item)
		{
			return item is IEnumerable && !_nonenumerableTypes.Contains(item.GetType());
		}
	}
}
