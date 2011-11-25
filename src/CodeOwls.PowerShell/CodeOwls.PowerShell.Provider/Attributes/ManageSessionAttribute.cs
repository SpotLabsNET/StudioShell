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
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace CodeOwls.PowerShell.Provider.Attributes
{
    [Serializable]
    [MulticastAttributeUsage( 
        MulticastTargets.Method, 
        TargetMemberAttributes = MulticastAttributes.Protected, 
        Inheritance = MulticastInheritance.Multicast)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class ManageSessionAttribute : MethodInterceptionAspect
    {
        public override bool CompileTimeValidate(System.Reflection.MethodBase method)
        {            
            if( ! typeof(IProvideNewSession).IsAssignableFrom(method.DeclaringType))
            {
                Message.Write( 
                    SeverityType.Error, 
                    "ManageSessionAttribute001", 
                    "Cannot apply [ManageSession] to method {0} because it is not a member of a type derived from IProvideNewSession.", 
                    method
                );

                return false;
            }

            return true;
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            if( args.Method.IsConstructor || args.Method.Name == "NewSession")
            {
                args.Proceed();
            }

            var c = args.Instance as IProvideNewSession;

            using( c.NewSession() )
            {
                args.Proceed();
            }
        }
    }
}
