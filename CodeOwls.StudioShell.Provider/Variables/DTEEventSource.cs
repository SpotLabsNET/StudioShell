using EnvDTE;
using EnvDTE80;

namespace CodeOwls.StudioShell.Provider.Variables
{
    public class DTEEventSource
    {
        private DebuggerEvents _debuggerEvents;
        private DebuggerExpressionEvaluationEvents _debuggerExpressionEvaluationEvents;
        private BuildEvents _buildEvents;
        private DTEEvents _dteEvents;
        private FindEvents _findEvents;
        private ProjectItemsEvents _miscFileEvents;
        private ProjectItemsEvents _projectItemsEvents;
        private ProjectsEvents _projectEvents;
        private PublishEvents _publishEvents;
        private SelectionEvents _selectionEvents;
        private SolutionEvents _solutionEvents;
        private ProjectItemsEvents _solutionItemEvents;
        private DebuggerProcessEvents _debuggerProcessEvents;

        public DTEEventSource( Events2 events)
        {
            _buildEvents = events.BuildEvents;
            _dteEvents = events.DTEEvents;
            _debuggerEvents = events.DebuggerEvents;
            _debuggerProcessEvents = events.DebuggerProcessEvents;
            _debuggerExpressionEvaluationEvents = events.DebuggerExpressionEvaluationEvents;
            _findEvents = events.FindEvents;
            _miscFileEvents = events.MiscFilesEvents;
            _projectItemsEvents = events.ProjectItemsEvents;
            _projectEvents = events.ProjectsEvents;
            _publishEvents = events.PublishEvents;
            _selectionEvents = events.SelectionEvents;
            _solutionEvents = events.SolutionEvents;
            _solutionItemEvents = events.SolutionItemsEvents;            
        }

        public DebuggerProcessEvents DebuggerProcessEvents
        {
            get { return _debuggerProcessEvents; }
        }

        public ProjectItemsEvents SolutionItemEvents
        {
            get { return _solutionItemEvents; }
        }

        public SolutionEvents SolutionEvents
        {
            get { return _solutionEvents; }
        }

        public SelectionEvents SelectionEvents
        {
            get { return _selectionEvents; }
        }

        public PublishEvents PublishEvents
        {
            get { return _publishEvents; }
        }

        public ProjectsEvents ProjectEvents
        {
            get { return _projectEvents; }
        }

        public ProjectItemsEvents ProjectItemsEvents
        {
            get { return _projectItemsEvents; }
        }

        public ProjectItemsEvents MiscFileEvents
        {
            get { return _miscFileEvents; }
        }

        public FindEvents FindEvents
        {
            get { return _findEvents; }
        }

        public DTEEvents DteEvents
        {
            get { return _dteEvents; }
        }

        public BuildEvents BuildEvents
        {
            get { return _buildEvents; }
        }

        public DebuggerExpressionEvaluationEvents DebuggerExpressionEvaluationEvents
        {
            get { return _debuggerExpressionEvaluationEvents; }
        }

        public DebuggerEvents DebuggerEvents
        {
            get { return _debuggerEvents; }
        }
    }
}
