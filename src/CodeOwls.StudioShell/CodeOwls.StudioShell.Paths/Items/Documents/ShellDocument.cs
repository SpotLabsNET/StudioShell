using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeOwls.StudioShell.Paths.Items.ProjectModel;
using CodeOwls.StudioShell.Paths.Items.UI;
using EnvDTE;
using EnvDTE80;

namespace CodeOwls.StudioShell.Paths.Items.ShellDocuments
{
    public class ShellDocument
    {
        private readonly Document _document;

        public ShellDocument(Document document)
        {
            _document = document;
        }

        public void Activate()
        {
            _document.Activate();
        }

        public void Close(vsSaveChanges Save = vsSaveChanges.vsSaveChangesPrompt)
        {
            _document.Close(Save);
        }

        public ShellWindow NewWindow()
        {
            return new ShellWindow( (Window2) _document.NewWindow() );
        }

        public bool Redo()
        {
            return _document.Redo();
        }

        public bool Undo()
        {
            return _document.Undo();
        }

        public vsSaveStatus Save(string FileName = "")
        {
            return _document.Save(FileName);
        }

        public object Object(string ModelKind = "")
        {
            return _document.Object(ModelKind);
        }

        public void PrintOut()
        {
            _document.PrintOut();
        }

        public void ClearBookmarks()
        {
            _document.ClearBookmarks();
        }

        public bool MarkText(string Pattern, int Flags = 0)
        {
            return _document.MarkText(Pattern, Flags);
        }

        public bool ReplaceText(string FindText, string ReplaceText, int Flags = 0)
        {
            return _document.ReplaceText(FindText, ReplaceText, Flags);
        }

        /*public DTE DTE
        {
            get { return _document.DTE; }
        }*/

        public string Kind
        {
            get { return _document.Kind; }
        }

        /*public EnvDTE.Documents Collection
        {
            get { return _document.Collection; }
        }*/

        public ShellWindow ActiveWindow
        {
            get { return new ShellWindow( (Window2) _document.ActiveWindow ); }
        }

        public string FullName
        {
            get { return _document.FullName; }
        }

        public string Name
        {
            get { return _document.Name; }
        }

        public string Path
        {
            get { return _document.Path; }
        }

        public bool ReadOnly
        {
            get { return _document.ReadOnly; }
            set { _document.ReadOnly = value; }
        }

        public bool Saved
        {
            get { return _document.Saved; }
            set { _document.Saved = value; }
        }

        public IList Windows
        {
            get
            {
                var list = new ArrayList();
                foreach (var window in _document.Windows)
                {
                    list.Add(new ShellWindow((Window2) window));
                }
                return list;
            }
        }

        public ShellProjectItem ProjectItem
        {
            get { return new ShellProjectItem( _document.ProjectItem ); }
        }

        public object Selection
        {
            get { return _document.Selection; }
        }

        /*public object get_Extender(string ExtenderName)
        {
            return _document.get_Extender(ExtenderName);
        }

        public object ExtenderNames
        {
            get { return _document.ExtenderNames; }
        }

        public string ExtenderCATID
        {
            get { return _document.ExtenderCATID; }
        }*/

        public int IndentSize
        {
            get { return _document.IndentSize; }
        }

        public string Language
        {
            get { return _document.Language; }
            set { _document.Language = value; }
        }

        public int TabSize
        {
            get { return _document.TabSize; }
        }

        public string Type
        {
            get { return _document.Type; }
        }
    }
}
