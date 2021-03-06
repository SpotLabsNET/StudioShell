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
using System.Text.RegularExpressions;
using CodeOwls.PowerShell.Paths.Processors;
using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.PowerShell.Provider.PathNodes;
using CodeOwls.StudioShell.Paths.Nodes.DTE;
using EnvDTE80;

namespace CodeOwls.StudioShell.Provider
{
	public class PathNodeProcessor : PathNodeProcessorBase
	{
		private DTE2 _dte;
		private INodeFactory _factory;

		public PathNodeProcessor(DTE2 dte)
		{
			_dte = dte;
			_factory = new RootNodeFactory(_dte);
		}

	    protected override INodeFactory Root
	    {
            get { return _factory; }
	    }	    
	}
}
