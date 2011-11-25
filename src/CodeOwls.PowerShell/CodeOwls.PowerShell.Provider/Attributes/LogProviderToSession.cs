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
using System.Management.Automation;
using System.Management.Automation.Provider;
using System.Text;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace CodeOwls.PowerShell.Provider.Attributes
{
    [Serializable]
    [MulticastAttributeUsage(
        MulticastTargets.Method,
        TargetMemberAttributes = MulticastAttributes.Protected,
        Inheritance = MulticastInheritance.Multicast)]
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class LogProviderToSession : OnMethodBoundaryAspect
    {
        public override bool CompileTimeValidate(System.Reflection.MethodBase method)
        {
            return (null != method.DeclaringType.GetProperty("SessionState"));
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var cmdlet = args.Instance as CmdletProvider;
            if( null == cmdlet )
            {
                return;
            }

            string parameters = "";
            if( null != args.Arguments && args.Arguments.Any() )
            {
                parameters = String.Join("; ", args.Arguments.ToList().ConvertAll(a => (a ?? "null").ToString()).ToArray());
            }
            try
            {
                var s = String.Format(
                    "[{0}] >> Entering [{1}] ( [{2}] )",
                    args.Instance.GetType().FullName,
                    args.Method.Name,
                    parameters);
                cmdlet.WriteDebug(s);
            }
            catch
            {               
            }
        }

        public override void OnExit(MethodExecutionArgs args)
        {            
            var cmdlet = args.Instance as CmdletProvider;
            if (null == cmdlet )
            {
                return;
            }

            try
            {
                var s = String.Format(
                    "[{0}] << Returning [{2}] from [{1}]",
                    args.Instance.GetType().FullName,
                    args.Method.Name,
                    args.ReturnValue ?? "null");
                cmdlet.WriteDebug( s );
            }
            catch
            {

            }
        }

        public override void OnException(MethodExecutionArgs args)
        {
            var cmdlet = args.Instance as CmdletProvider;
            if (null == cmdlet)
            {
                return;
            }

            try
            {
                cmdlet.WriteDebug(
                    String.Format(
                        "[{0}] !! Exception in [{1}]: [{2}]",
                        args.Instance.GetType().FullName,
                        args.Method.Name,
                        args.Exception));
            }
            catch
            {                
            }
        }
    }
}
