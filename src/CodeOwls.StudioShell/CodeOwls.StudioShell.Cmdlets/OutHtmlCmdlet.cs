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
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using CodeOwls.StudioShell.Common.IoC;
using EnvDTE;
using EnvDTE80;

namespace CodeOwls.StudioShell.Cmdlets
{
    [Cmdlet(VerbsData.Out, "html")]
    public class OutHtmlCmdlet : PSCmdlet
    {
        private List<PSObject> _data;
        private static List<string> _tempFiles;

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject Input { get; set; }

        protected override void BeginProcessing()
        {
            _data = new List<PSObject>();
        }

        protected override void ProcessRecord()
        {
            _data.Add(Input);
        }

        protected override void EndProcessing()
        {
            string path = Path.GetTempFileName() + ".html";
            string html = GetHtml();

            File.WriteAllText(path, html);
            var url = new Uri("file://" + path).AbsoluteUri;

            DTE2 dte2 = Locator.Get<DTE2>();

            var win = dte2.DTE.ItemOperations.Navigate(
                url,
                vsNavigateOptions.vsNavigateOptionsDefault
                );

            if (null == _tempFiles)
            {
                _tempFiles = new List<string>();
                dte2.Events.DTEEvents.OnBeginShutdown += OnDteEventsOnOnBeginShutdown;
            }

            _tempFiles.Add(path);
        }

        string GetHtml()
        {
            List<PSObject> inputs = null;
            string html = null;
            foreach( PSObject data in _data.Take( 15 ))
            {
                var a = data.ToString();
                if (a.Contains("<html") )
                {
                    inputs = _data;
                    break;
                }
            }

            if (null == inputs)
            {
                inputs = new List<PSObject>(
                    InvokeCommand.InvokeScript(
                        "$input | convertto-html",
                        true,
                        PipelineResultTypes.None,
                        _data)
                    );
            }

            var sb = new StringBuilder();
            inputs.ToList().ForEach(i => sb.Append(i.ToString()));
            html = sb.ToString();
            
            return html;
        }

        static void OnDteEventsOnOnBeginShutdown()
        {
            _tempFiles.ForEach(s =>
                                   {
                                       try
                                       {
                                           if (File.Exists(s))
                                           {
                                               File.Delete(s);
                                           }
                                       }
                                       catch
                                       {
                                       }
                                   });
        }
    }
}
