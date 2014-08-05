using EnvDTE80;

namespace CodeOwls.StudioShell.Provider.Variables
{
    public class StudioShellEnvironment
    {
        private readonly DTE2 _dte;

        public StudioShellEnvironment(DTE2 dte)
        {
            _dte = dte;
        }

        public DTEEventSource Events
        {
            get
            {
                return new DTEEventSource( _dte.Events as Events2 );
            }
        } 
        public VsDisplay VsDisplay
        {
            get
            {
                return new VsDisplay();
            }
        }

        public VsIDEMode VsIDEMode
        {
            get
            {
                return new VsIDEMode();
            }
        }

        public WizardResult WizardResult
        {
            get
            {
                return new WizardResult();
            }
        }

        public VsLinkedWindowType VsLinkedWindowType
        {
            get
            {
                return new VsLinkedWindowType();
            }
        }

        public VsWindowState VsWindowState
        {
            get
            {
                return new VsWindowState();
            }
        }

        public VsWindowType VsWindowType
        {
            get
            {
                return new VsWindowType();
            }
        }

        public VsSaveChanges VsSaveChanges
        {
            get
            {
                return new VsSaveChanges();
            }
        }

        public VsConfigurationType VsConfigurationType
        {
            get
            {
                return new VsConfigurationType();
            }
        }

        public VsCMAccess VsCMAccess
        {
            get
            {
                return new VsCMAccess();
            }
        }

        public VsCMFunction VsCMFunction
        {
            get
            {
                return new VsCMFunction();
            }
        }

        public VsCMElement VsCMElement
        {
            get
            {
                return new VsCMElement();
            }
        }

        public VsCMInfoLocation VsCMInfoLocation
        {
            get
            {
                return new VsCMInfoLocation();
            }
        }

        public VsCMPart VsCMPart
        {
            get
            {
                return new VsCMPart();
            }
        }

        public VsPaneShowHow VsPaneShowHow
        {
            get
            {
                return new VsPaneShowHow();
            }
        }

        public VsSaveStatus VsSaveStatus
        {
            get
            {
                return new VsSaveStatus();
            }
        }

        public VsCaseOptions VsCaseOptions
        {
            get
            {
                return new VsCaseOptions();
            }
        }

        public VsWhitespaceOptions VsWhitespaceOptions
        {
            get
            {
                return new VsWhitespaceOptions();
            }
        }

        public VsStartOfLineOptions VsStartOfLineOptions
        {
            get
            {
                return new VsStartOfLineOptions();
            }
        }

        public VsSelectionMode VsSelectionMode
        {
            get
            {
                return new VsSelectionMode();
            }
        }

        public VsCMTypeRef VsCMTypeRef
        {
            get
            {
                return new VsCMTypeRef();
            }
        }

        public VsContextAttributeType VsContextAttributeType
        {
            get
            {
                return new VsContextAttributeType();
            }
        }

        public VsContextAttributes VsContextAttributes
        {
            get
            {
                return new VsContextAttributes();
            }
        }

        public VsBuildScope VsBuildScope
        {
            get
            {
                return new VsBuildScope();
            }
        }

        public VsBuildAction VsBuildAction
        {
            get
            {
                return new VsBuildAction();
            }
        }

        public VsTaskPriority VsTaskPriority
        {
            get
            {
                return new VsTaskPriority();
            }
        }

        public VsTaskIcon VsTaskIcon
        {
            get
            {
                return new VsTaskIcon();
            }
        }

        public VsFindResult VsFindResult
        {
            get
            {
                return new VsFindResult();
            }
        }

        public VsTaskListColumn VsTaskListColumn
        {
            get
            {
                return new VsTaskListColumn();
            }
        }

        public DbgEventReason DbgEventReason
        {
            get
            {
                return new DbgEventReason();
            }
        }

        public DbgExecutionAction DbgExecutionAction
        {
            get
            {
                return new DbgExecutionAction();
            }
        }

        public DbgExceptionAction DbgExceptionAction
        {
            get
            {
                return new DbgExceptionAction();
            }
        }

        public DbgDebugMode DbgDebugMode
        {
            get
            {
                return new DbgDebugMode();
            }
        }

        public DbgBreakpointConditionType DbgBreakpointConditionType
        {
            get
            {
                return new DbgBreakpointConditionType();
            }
        }

        public DbgHitCountType DbgHitCountType
        {
            get
            {
                return new DbgHitCountType();
            }
        }

        public DbgBreakpointType DbgBreakpointType
        {
            get
            {
                return new DbgBreakpointType();
            }
        }

        public DbgBreakpointLocationType DbgBreakpointLocationType
        {
            get
            {
                return new DbgBreakpointLocationType();
            }
        }

        public VsBuildState VsBuildState
        {
            get
            {
                return new VsBuildState();
            }
        }

        public VsCommandBarType VsCommandBarType
        {
            get
            {
                return new VsCommandBarType();
            }
        }

        public VsFindAction VsFindAction
        {
            get
            {
                return new VsFindAction();
            }
        }

        public VsFindPatternSyntax VsFindPatternSyntax
        {
            get
            {
                return new VsFindPatternSyntax();
            }
        }

        public VsFindTarget VsFindTarget
        {
            get
            {
                return new VsFindTarget();
            }
        }

        public VsFindResultsLocation VsFindResultsLocation
        {
            get
            {
                return new VsFindResultsLocation();
            }
        }

        public VsNavigateOptions VsNavigateOptions
        {
            get
            {
                return new VsNavigateOptions();
            }
        }

        public VsPromptResult VsPromptResult
        {
            get
            {
                return new VsPromptResult();
            }
        }

        public VsToolBoxItemFormat VsToolBoxItemFormat
        {
            get
            {
                return new VsToolBoxItemFormat();
            }
        }

        public VsFilterProperties VsFilterProperties
        {
            get
            {
                return new VsFilterProperties();
            }
        }

        public VsUISelectionType VsUISelectionType
        {
            get
            {
                return new VsUISelectionType();
            }
        }

        public VsCMPrototype VsCMPrototype
        {
            get
            {
                return new VsCMPrototype();
            }
        }

        public VsNavigateBrowser VsNavigateBrowser
        {
            get
            {
                return new VsNavigateBrowser();
            }
        }

        public VsCommandDisabledFlags VsCommandDisabledFlags
        {
            get
            {
                return new VsCommandDisabledFlags();
            }
        }

        public VsInitializeMode VsInitializeMode
        {
            get
            {
                return new VsInitializeMode();
            }
        }

        public VsCommandStatusTextWanted VsCommandStatusTextWanted
        {
            get
            {
                return new VsCommandStatusTextWanted();
            }
        }

        public VsCommandStatus VsCommandStatus
        {
            get
            {
                return new VsCommandStatus();
            }
        }

        public VsCommandExecOption VsCommandExecOption
        {
            get
            {
                return new VsCommandExecOption();
            }
        }

        public VsBuildKind VsBuildKind
        {
            get
            {
                return new VsBuildKind();
            }
        }

        public VsTextChanged VsTextChanged
        {
            get
            {
                return new VsTextChanged();
            }
        }

        public VsStatusAnimation VsStatusAnimation
        {
            get
            {
                return new VsStatusAnimation();
            }
        }

        public VsStartUp VsStartUp
        {
            get
            {
                return new VsStartUp();
            }
        }

        public VsFontCharSet VsFontCharSet
        {
            get
            {
                return new VsFontCharSet();
            }
        }

        public VsBrowserViewSource VsBrowserViewSource
        {
            get
            {
                return new VsBrowserViewSource();
            }
        }

        public VsFindOptions VsFindOptions
        {
            get
            {
                return new VsFindOptions();
            }
        }

        public VsMovementOptions VsMovementOptions
        {
            get
            {
                return new VsMovementOptions();
            }
        }

        public VsGoToLineOptions VsGoToLineOptions
        {
            get
            {
                return new VsGoToLineOptions();
            }
        }

        public VsSmartFormatOptions VsSmartFormatOptions
        {
            get
            {
                return new VsSmartFormatOptions();
            }
        }

        public VsInsertFlags VsInsertFlags
        {
            get
            {
                return new VsInsertFlags();
            }
        }

        public VsMoveToColumnLine VsMoveToColumnLine
        {
            get
            {
                return new VsMoveToColumnLine();
            }
        }

        public VsEPReplaceTextOptions VsEPReplaceTextOptions
        {
            get
            {
                return new VsEPReplaceTextOptions();
            }
        }

        public VsIndentStyle VsIndentStyle
        {
            get
            {
                return new VsIndentStyle();
            }
        }

        public _vsIndentStyle _vsIndentStyle
        {
            get
            {
                return new _vsIndentStyle();
            }
        }

        public Vsext_FontCharSet Vsext_FontCharSet
        {
            get
            {
                return new Vsext_FontCharSet();
            }
        }

        public Vs_exec_Result Vs_exec_Result
        {
            get
            {
                return new Vs_exec_Result();
            }
        }

        public VSEXECRESULT VSEXECRESULT
        {
            get
            {
                return new VSEXECRESULT();
            }
        }

        public Vsext_DisplayMode Vsext_DisplayMode
        {
            get
            {
                return new Vsext_DisplayMode();
            }
        }

        public Vsext_WindowType Vsext_WindowType
        {
            get
            {
                return new Vsext_WindowType();
            }
        }

        public Vsext_WindowState Vsext_WindowState
        {
            get
            {
                return new Vsext_WindowState();
            }
        }

        public Vsext_LinkedWindowType Vsext_LinkedWindowType
        {
            get
            {
                return new Vsext_LinkedWindowType();
            }
        }

        public Vsext_StartUp Vsext_StartUp
        {
            get
            {
                return new Vsext_StartUp();
            }
        }

        public Vsext_Build Vsext_Build
        {
            get
            {
                return new Vsext_Build();
            }
        }

        public DsTextSearchOptions DsTextSearchOptions
        {
            get
            {
                return new DsTextSearchOptions();
            }
        }

        public DsSaveChanges DsSaveChanges
        {
            get
            {
                return new DsSaveChanges();
            }
        }

        public DsGoToLineOptions DsGoToLineOptions
        {
            get
            {
                return new DsGoToLineOptions();
            }
        }

        public DsStartOfLineOptions DsStartOfLineOptions
        {
            get
            {
                return new DsStartOfLineOptions();
            }
        }

        public DsMovementOptions DsMovementOptions
        {
            get
            {
                return new DsMovementOptions();
            }
        }

        public DsWhitespaceOptions DsWhitespaceOptions
        {
            get
            {
                return new DsWhitespaceOptions();
            }
        }

        public DsCaseOptions DsCaseOptions
        {
            get
            {
                return new DsCaseOptions();
            }
        }

        public DsSaveStatus DsSaveStatus
        {
            get
            {
                return new DsSaveStatus();
            }
        }

        public VsHTMLTabs VsHTMLTabs
        {
            get
            {
                return new VsHTMLTabs();
            }
        }

        public VsCommandControlType VsCommandControlType
        {
            get
            {
                return new VsCommandControlType();
            }
        }

        public VsSourceControlCheckOutOptions VsSourceControlCheckOutOptions
        {
            get
            {
                return new VsSourceControlCheckOutOptions();
            }
        }

        public VsBuildErrorLevel VsBuildErrorLevel
        {
            get
            {
                return new VsBuildErrorLevel();
            }
        }

        public VsCMFunction2 VsCMFunction2
        {
            get
            {
                return new VsCMFunction2();
            }
        }

        public VsCMElement2 VsCMElement2
        {
            get
            {
                return new VsCMElement2();
            }
        }

        public VsCMTypeRef2 VsCMTypeRef2
        {
            get
            {
                return new VsCMTypeRef2();
            }
        }

        public VsCMParseStatus VsCMParseStatus
        {
            get
            {
                return new VsCMParseStatus();
            }
        }

        public VsCMClassKind VsCMClassKind
        {
            get
            {
                return new VsCMClassKind();
            }
        }

        public VsCMDataTypeKind VsCMDataTypeKind
        {
            get
            {
                return new VsCMDataTypeKind();
            }
        }

        public VsCMChangeKind VsCMChangeKind
        {
            get
            {
                return new VsCMChangeKind();
            }
        }

        public VsCMInheritanceKind VsCMInheritanceKind
        {
            get
            {
                return new VsCMInheritanceKind();
            }
        }

        public VsCMParameterKind VsCMParameterKind
        {
            get
            {
                return new VsCMParameterKind();
            }
        }

        public VsCMOverrideKind VsCMOverrideKind
        {
            get
            {
                return new VsCMOverrideKind();
            }
        }

        public VsCMConstKind VsCMConstKind
        {
            get
            {
                return new VsCMConstKind();
            }
        }

        public VsCMPropertyKind VsCMPropertyKind
        {
            get
            {
                return new VsCMPropertyKind();
            }
        }

        public DbgMinidumpOption DbgMinidumpOption
        {
            get
            {
                return new DbgMinidumpOption();
            }
        }

        public DbgEventReason2 DbgEventReason2
        {
            get
            {
                return new DbgEventReason2();
            }
        }

        public DbgProcessState DbgProcessState
        {
            get
            {
                return new DbgProcessState();
            }
        }

        public DbgExpressionEvaluationState DbgExpressionEvaluationState
        {
            get
            {
                return new DbgExpressionEvaluationState();
            }
        }

        public VsCommandStyle VsCommandStyle
        {
            get
            {
                return new VsCommandStyle();
            }
        }

        public VsThemeColors VsThemeColors
        {
            get
            {
                return new VsThemeColors();
            }
        }

        public VsFindOptions2 VsFindOptions2
        {
            get
            {
                return new VsFindOptions2();
            }
        }

        public VsIncrementalSearchResult VsIncrementalSearchResult
        {
            get
            {
                return new VsIncrementalSearchResult();
            }
        }

        public VsPublishState VsPublishState
        {
            get
            {
                return new VsPublishState();
            }
        }
    }
}