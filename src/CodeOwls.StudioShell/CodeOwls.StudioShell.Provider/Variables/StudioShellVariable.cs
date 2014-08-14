using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using EnvDTE;
using EnvDTE80;

namespace CodeOwls.StudioShell.Provider.Variables
{
    public class StudioShellVariable : DTEPSVariable
    {
        private readonly StudioShellEnvironment _environment;
        private const string VariableName = "StudioShell";
    
        public StudioShellVariable(DTE2 dte) : base(dte, StudioShellVariable.VariableName)
        {
            _environment = new StudioShellEnvironment(dte);
            
        }
     
        public override object Value
        {
            get
            {
                return _environment;
            }
            set
            {
            }
        }
    }

    public class VsDisplay
    {
        public vsDisplay vsDisplayMDI
        {
            get
            {
                return vsDisplay.vsDisplayMDI;
            }
        }

        public vsDisplay vsDisplayMDITabs
        {
            get
            {
                return vsDisplay.vsDisplayMDITabs;
            }
        }
    }

    public class VsIDEMode
    {
        public vsIDEMode vsIDEModeDesign
        {
            get
            {
                return vsIDEMode.vsIDEModeDesign;
            }
        }

        public vsIDEMode vsIDEModeDebug
        {
            get
            {
                return vsIDEMode.vsIDEModeDebug;
            }
        }
    }

    public class WizardResult
    {
        public wizardResult wizardResultFailure
        {
            get
            {
                return wizardResult.wizardResultFailure;
            }
        }

        public wizardResult wizardResultCancel
        {
            get
            {
                return wizardResult.wizardResultCancel;
            }
        }

        public wizardResult wizardResultBackOut
        {
            get
            {
                return wizardResult.wizardResultBackOut;
            }
        }

        public wizardResult wizardResultSuccess
        {
            get
            {
                return wizardResult.wizardResultSuccess;
            }
        }
    }

    public class VsLinkedWindowType
    {
        public vsLinkedWindowType vsLinkedWindowTypeDocked
        {
            get
            {
                return vsLinkedWindowType.vsLinkedWindowTypeDocked;
            }
        }

        public vsLinkedWindowType vsLinkedWindowTypeTabbed
        {
            get
            {
                return vsLinkedWindowType.vsLinkedWindowTypeTabbed;
            }
        }

        public vsLinkedWindowType vsLinkedWindowTypeVertical
        {
            get
            {
                return vsLinkedWindowType.vsLinkedWindowTypeVertical;
            }
        }

        public vsLinkedWindowType vsLinkedWindowTypeHorizontal
        {
            get
            {
                return vsLinkedWindowType.vsLinkedWindowTypeHorizontal;
            }
        }
    }

    public class VsWindowState
    {
        public vsWindowState vsWindowStateNormal
        {
            get
            {
                return vsWindowState.vsWindowStateNormal;
            }
        }

        public vsWindowState vsWindowStateMinimize
        {
            get
            {
                return vsWindowState.vsWindowStateMinimize;
            }
        }

        public vsWindowState vsWindowStateMaximize
        {
            get
            {
                return vsWindowState.vsWindowStateMaximize;
            }
        }
    }

    public class VsWindowType
    {
        public vsWindowType vsWindowTypeCodeWindow
        {
            get
            {
                return vsWindowType.vsWindowTypeCodeWindow;
            }
        }

        public vsWindowType vsWindowTypeDesigner
        {
            get
            {
                return vsWindowType.vsWindowTypeDesigner;
            }
        }

        public vsWindowType vsWindowTypeBrowser
        {
            get
            {
                return vsWindowType.vsWindowTypeBrowser;
            }
        }

        public vsWindowType vsWindowTypeWatch
        {
            get
            {
                return vsWindowType.vsWindowTypeWatch;
            }
        }

        public vsWindowType vsWindowTypeLocals
        {
            get
            {
                return vsWindowType.vsWindowTypeLocals;
            }
        }

        public vsWindowType vsWindowTypeImmediate
        {
            get
            {
                return vsWindowType.vsWindowTypeImmediate;
            }
        }

        public vsWindowType vsWindowTypeSolutionExplorer
        {
            get
            {
                return vsWindowType.vsWindowTypeSolutionExplorer;
            }
        }

        public vsWindowType vsWindowTypeProperties
        {
            get
            {
                return vsWindowType.vsWindowTypeProperties;
            }
        }

        public vsWindowType vsWindowTypeFind
        {
            get
            {
                return vsWindowType.vsWindowTypeFind;
            }
        }

        public vsWindowType vsWindowTypeFindReplace
        {
            get
            {
                return vsWindowType.vsWindowTypeFindReplace;
            }
        }

        public vsWindowType vsWindowTypeToolbox
        {
            get
            {
                return vsWindowType.vsWindowTypeToolbox;
            }
        }

        public vsWindowType vsWindowTypeLinkedWindowFrame
        {
            get
            {
                return vsWindowType.vsWindowTypeLinkedWindowFrame;
            }
        }

        public vsWindowType vsWindowTypeMainWindow
        {
            get
            {
                return vsWindowType.vsWindowTypeMainWindow;
            }
        }

        public vsWindowType vsWindowTypePreview
        {
            get
            {
                return vsWindowType.vsWindowTypePreview;
            }
        }

        public vsWindowType vsWindowTypeColorPalette
        {
            get
            {
                return vsWindowType.vsWindowTypeColorPalette;
            }
        }

        public vsWindowType vsWindowTypeToolWindow
        {
            get
            {
                return vsWindowType.vsWindowTypeToolWindow;
            }
        }

        public vsWindowType vsWindowTypeDocument
        {
            get
            {
                return vsWindowType.vsWindowTypeDocument;
            }
        }

        public vsWindowType vsWindowTypeOutput
        {
            get
            {
                return vsWindowType.vsWindowTypeOutput;
            }
        }

        public vsWindowType vsWindowTypeTaskList
        {
            get
            {
                return vsWindowType.vsWindowTypeTaskList;
            }
        }

        public vsWindowType vsWindowTypeAutos
        {
            get
            {
                return vsWindowType.vsWindowTypeAutos;
            }
        }

        public vsWindowType vsWindowTypeCallStack
        {
            get
            {
                return vsWindowType.vsWindowTypeCallStack;
            }
        }

        public vsWindowType vsWindowTypeThreads
        {
            get
            {
                return vsWindowType.vsWindowTypeThreads;
            }
        }

        public vsWindowType vsWindowTypeDocumentOutline
        {
            get
            {
                return vsWindowType.vsWindowTypeDocumentOutline;
            }
        }

        public vsWindowType vsWindowTypeRunningDocuments
        {
            get
            {
                return vsWindowType.vsWindowTypeRunningDocuments;
            }
        }
    }

    public class VsSaveChanges
    {
        public vsSaveChanges vsSaveChangesYes
        {
            get
            {
                return vsSaveChanges.vsSaveChangesYes;
            }
        }

        public vsSaveChanges vsSaveChangesNo
        {
            get
            {
                return vsSaveChanges.vsSaveChangesNo;
            }
        }

        public vsSaveChanges vsSaveChangesPrompt
        {
            get
            {
                return vsSaveChanges.vsSaveChangesPrompt;
            }
        }
    }

    public class VsConfigurationType
    {
        public vsConfigurationType vsConfigurationTypeProject
        {
            get
            {
                return vsConfigurationType.vsConfigurationTypeProject;
            }
        }

        public vsConfigurationType vsConfigurationTypeProjectItem
        {
            get
            {
                return vsConfigurationType.vsConfigurationTypeProjectItem;
            }
        }
    }

    public class VsCMAccess
    {
        public vsCMAccess vsCMAccessPublic
        {
            get
            {
                return vsCMAccess.vsCMAccessPublic;
            }
        }

        public vsCMAccess vsCMAccessPrivate
        {
            get
            {
                return vsCMAccess.vsCMAccessPrivate;
            }
        }

        public vsCMAccess vsCMAccessProject
        {
            get
            {
                return vsCMAccess.vsCMAccessProject;
            }
        }

        public vsCMAccess vsCMAccessProtected
        {
            get
            {
                return vsCMAccess.vsCMAccessProtected;
            }
        }

        public vsCMAccess vsCMAccessProjectOrProtected
        {
            get
            {
                return vsCMAccess.vsCMAccessProjectOrProtected;
            }
        }

        public vsCMAccess vsCMAccessDefault
        {
            get
            {
                return vsCMAccess.vsCMAccessDefault;
            }
        }

        public vsCMAccess vsCMAccessAssemblyOrFamily
        {
            get
            {
                return vsCMAccess.vsCMAccessAssemblyOrFamily;
            }
        }

        public vsCMAccess vsCMAccessWithEvents
        {
            get
            {
                return vsCMAccess.vsCMAccessWithEvents;
            }
        }
    }

    public class VsCMFunction
    {
        public vsCMFunction vsCMFunctionOther
        {
            get
            {
                return vsCMFunction.vsCMFunctionOther;
            }
        }

        public vsCMFunction vsCMFunctionConstructor
        {
            get
            {
                return vsCMFunction.vsCMFunctionConstructor;
            }
        }

        public vsCMFunction vsCMFunctionPropertyGet
        {
            get
            {
                return vsCMFunction.vsCMFunctionPropertyGet;
            }
        }

        public vsCMFunction vsCMFunctionPropertyLet
        {
            get
            {
                return vsCMFunction.vsCMFunctionPropertyLet;
            }
        }

        public vsCMFunction vsCMFunctionPropertySet
        {
            get
            {
                return vsCMFunction.vsCMFunctionPropertySet;
            }
        }

        public vsCMFunction vsCMFunctionPutRef
        {
            get
            {
                return vsCMFunction.vsCMFunctionPutRef;
            }
        }

        public vsCMFunction vsCMFunctionPropertyAssign
        {
            get
            {
                return vsCMFunction.vsCMFunctionPropertyAssign;
            }
        }

        public vsCMFunction vsCMFunctionSub
        {
            get
            {
                return vsCMFunction.vsCMFunctionSub;
            }
        }

        public vsCMFunction vsCMFunctionFunction
        {
            get
            {
                return vsCMFunction.vsCMFunctionFunction;
            }
        }

        public vsCMFunction vsCMFunctionTopLevel
        {
            get
            {
                return vsCMFunction.vsCMFunctionTopLevel;
            }
        }

        public vsCMFunction vsCMFunctionDestructor
        {
            get
            {
                return vsCMFunction.vsCMFunctionDestructor;
            }
        }

        public vsCMFunction vsCMFunctionOperator
        {
            get
            {
                return vsCMFunction.vsCMFunctionOperator;
            }
        }

        public vsCMFunction vsCMFunctionVirtual
        {
            get
            {
                return vsCMFunction.vsCMFunctionVirtual;
            }
        }

        public vsCMFunction vsCMFunctionPure
        {
            get
            {
                return vsCMFunction.vsCMFunctionPure;
            }
        }

        public vsCMFunction vsCMFunctionConstant
        {
            get
            {
                return vsCMFunction.vsCMFunctionConstant;
            }
        }

        public vsCMFunction vsCMFunctionShared
        {
            get
            {
                return vsCMFunction.vsCMFunctionShared;
            }
        }

        public vsCMFunction vsCMFunctionInline
        {
            get
            {
                return vsCMFunction.vsCMFunctionInline;
            }
        }

        public vsCMFunction vsCMFunctionComMethod
        {
            get
            {
                return vsCMFunction.vsCMFunctionComMethod;
            }
        }
    }

    public class VsCMElement
    {
        public vsCMElement vsCMElementOther
        {
            get
            {
                return vsCMElement.vsCMElementOther;
            }
        }

        public vsCMElement vsCMElementClass
        {
            get
            {
                return vsCMElement.vsCMElementClass;
            }
        }

        public vsCMElement vsCMElementFunction
        {
            get
            {
                return vsCMElement.vsCMElementFunction;
            }
        }

        public vsCMElement vsCMElementVariable
        {
            get
            {
                return vsCMElement.vsCMElementVariable;
            }
        }

        public vsCMElement vsCMElementProperty
        {
            get
            {
                return vsCMElement.vsCMElementProperty;
            }
        }

        public vsCMElement vsCMElementNamespace
        {
            get
            {
                return vsCMElement.vsCMElementNamespace;
            }
        }

        public vsCMElement vsCMElementParameter
        {
            get
            {
                return vsCMElement.vsCMElementParameter;
            }
        }

        public vsCMElement vsCMElementAttribute
        {
            get
            {
                return vsCMElement.vsCMElementAttribute;
            }
        }

        public vsCMElement vsCMElementInterface
        {
            get
            {
                return vsCMElement.vsCMElementInterface;
            }
        }

        public vsCMElement vsCMElementDelegate
        {
            get
            {
                return vsCMElement.vsCMElementDelegate;
            }
        }

        public vsCMElement vsCMElementEnum
        {
            get
            {
                return vsCMElement.vsCMElementEnum;
            }
        }

        public vsCMElement vsCMElementStruct
        {
            get
            {
                return vsCMElement.vsCMElementStruct;
            }
        }

        public vsCMElement vsCMElementUnion
        {
            get
            {
                return vsCMElement.vsCMElementUnion;
            }
        }

        public vsCMElement vsCMElementLocalDeclStmt
        {
            get
            {
                return vsCMElement.vsCMElementLocalDeclStmt;
            }
        }

        public vsCMElement vsCMElementFunctionInvokeStmt
        {
            get
            {
                return vsCMElement.vsCMElementFunctionInvokeStmt;
            }
        }

        public vsCMElement vsCMElementPropertySetStmt
        {
            get
            {
                return vsCMElement.vsCMElementPropertySetStmt;
            }
        }

        public vsCMElement vsCMElementAssignmentStmt
        {
            get
            {
                return vsCMElement.vsCMElementAssignmentStmt;
            }
        }

        public vsCMElement vsCMElementInheritsStmt
        {
            get
            {
                return vsCMElement.vsCMElementInheritsStmt;
            }
        }

        public vsCMElement vsCMElementImplementsStmt
        {
            get
            {
                return vsCMElement.vsCMElementImplementsStmt;
            }
        }

        public vsCMElement vsCMElementOptionStmt
        {
            get
            {
                return vsCMElement.vsCMElementOptionStmt;
            }
        }

        public vsCMElement vsCMElementVBAttributeStmt
        {
            get
            {
                return vsCMElement.vsCMElementVBAttributeStmt;
            }
        }

        public vsCMElement vsCMElementVBAttributeGroup
        {
            get
            {
                return vsCMElement.vsCMElementVBAttributeGroup;
            }
        }

        public vsCMElement vsCMElementEventsDeclaration
        {
            get
            {
                return vsCMElement.vsCMElementEventsDeclaration;
            }
        }

        public vsCMElement vsCMElementUDTDecl
        {
            get
            {
                return vsCMElement.vsCMElementUDTDecl;
            }
        }

        public vsCMElement vsCMElementDeclareDecl
        {
            get
            {
                return vsCMElement.vsCMElementDeclareDecl;
            }
        }

        public vsCMElement vsCMElementDefineStmt
        {
            get
            {
                return vsCMElement.vsCMElementDefineStmt;
            }
        }

        public vsCMElement vsCMElementTypeDef
        {
            get
            {
                return vsCMElement.vsCMElementTypeDef;
            }
        }

        public vsCMElement vsCMElementIncludeStmt
        {
            get
            {
                return vsCMElement.vsCMElementIncludeStmt;
            }
        }

        public vsCMElement vsCMElementUsingStmt
        {
            get
            {
                return vsCMElement.vsCMElementUsingStmt;
            }
        }

        public vsCMElement vsCMElementMacro
        {
            get
            {
                return vsCMElement.vsCMElementMacro;
            }
        }

        public vsCMElement vsCMElementMap
        {
            get
            {
                return vsCMElement.vsCMElementMap;
            }
        }

        public vsCMElement vsCMElementIDLImport
        {
            get
            {
                return vsCMElement.vsCMElementIDLImport;
            }
        }

        public vsCMElement vsCMElementIDLImportLib
        {
            get
            {
                return vsCMElement.vsCMElementIDLImportLib;
            }
        }

        public vsCMElement vsCMElementIDLCoClass
        {
            get
            {
                return vsCMElement.vsCMElementIDLCoClass;
            }
        }

        public vsCMElement vsCMElementIDLLibrary
        {
            get
            {
                return vsCMElement.vsCMElementIDLLibrary;
            }
        }

        public vsCMElement vsCMElementImportStmt
        {
            get
            {
                return vsCMElement.vsCMElementImportStmt;
            }
        }

        public vsCMElement vsCMElementMapEntry
        {
            get
            {
                return vsCMElement.vsCMElementMapEntry;
            }
        }

        public vsCMElement vsCMElementVCBase
        {
            get
            {
                return vsCMElement.vsCMElementVCBase;
            }
        }

        public vsCMElement vsCMElementEvent
        {
            get
            {
                return vsCMElement.vsCMElementEvent;
            }
        }

        public vsCMElement vsCMElementModule
        {
            get
            {
                return vsCMElement.vsCMElementModule;
            }
        }
    }

    public class VsCMInfoLocation
    {
        public vsCMInfoLocation vsCMInfoLocationProject
        {
            get
            {
                return vsCMInfoLocation.vsCMInfoLocationProject;
            }
        }

        public vsCMInfoLocation vsCMInfoLocationExternal
        {
            get
            {
                return vsCMInfoLocation.vsCMInfoLocationExternal;
            }
        }

        public vsCMInfoLocation vsCMInfoLocationNone
        {
            get
            {
                return vsCMInfoLocation.vsCMInfoLocationNone;
            }
        }

        public vsCMInfoLocation vsCMInfoLocationVirtual
        {
            get
            {
                return vsCMInfoLocation.vsCMInfoLocationVirtual;
            }
        }
    }

    public class VsCMPart
    {
        public vsCMPart vsCMPartName
        {
            get
            {
                return vsCMPart.vsCMPartName;
            }
        }

        public vsCMPart vsCMPartAttributes
        {
            get
            {
                return vsCMPart.vsCMPartAttributes;
            }
        }

        public vsCMPart vsCMPartHeader
        {
            get
            {
                return vsCMPart.vsCMPartHeader;
            }
        }

        public vsCMPart vsCMPartHeaderWithAttributes
        {
            get
            {
                return vsCMPart.vsCMPartHeaderWithAttributes;
            }
        }

        public vsCMPart vsCMPartWhole
        {
            get
            {
                return vsCMPart.vsCMPartWhole;
            }
        }

        public vsCMPart vsCMPartWholeWithAttributes
        {
            get
            {
                return vsCMPart.vsCMPartWholeWithAttributes;
            }
        }

        public vsCMPart vsCMPartBody
        {
            get
            {
                return vsCMPart.vsCMPartBody;
            }
        }

        public vsCMPart vsCMPartNavigate
        {
            get
            {
                return vsCMPart.vsCMPartNavigate;
            }
        }

        public vsCMPart vsCMPartAttributesWithDelimiter
        {
            get
            {
                return vsCMPart.vsCMPartAttributesWithDelimiter;
            }
        }

        public vsCMPart vsCMPartBodyWithDelimiter
        {
            get
            {
                return vsCMPart.vsCMPartBodyWithDelimiter;
            }
        }
    }

    public class VsPaneShowHow
    {
        public vsPaneShowHow vsPaneShowCentered
        {
            get
            {
                return vsPaneShowHow.vsPaneShowCentered;
            }
        }

        public vsPaneShowHow vsPaneShowTop
        {
            get
            {
                return vsPaneShowHow.vsPaneShowTop;
            }
        }

        public vsPaneShowHow vsPaneShowAsIs
        {
            get
            {
                return vsPaneShowHow.vsPaneShowAsIs;
            }
        }
    }

    public class VsSaveStatus
    {
        public vsSaveStatus vsSaveSucceeded
        {
            get
            {
                return vsSaveStatus.vsSaveSucceeded;
            }
        }

        public vsSaveStatus vsSaveCancelled
        {
            get
            {
                return vsSaveStatus.vsSaveCancelled;
            }
        }
    }

    public class VsCaseOptions
    {
        public vsCaseOptions vsCaseOptionsLowercase
        {
            get
            {
                return vsCaseOptions.vsCaseOptionsLowercase;
            }
        }

        public vsCaseOptions vsCaseOptionsUppercase
        {
            get
            {
                return vsCaseOptions.vsCaseOptionsUppercase;
            }
        }

        public vsCaseOptions vsCaseOptionsCapitalize
        {
            get
            {
                return vsCaseOptions.vsCaseOptionsCapitalize;
            }
        }
    }

    public class VsWhitespaceOptions
    {
        public vsWhitespaceOptions vsWhitespaceOptionsHorizontal
        {
            get
            {
                return vsWhitespaceOptions.vsWhitespaceOptionsHorizontal;
            }
        }

        public vsWhitespaceOptions vsWhitespaceOptionsVertical
        {
            get
            {
                return vsWhitespaceOptions.vsWhitespaceOptionsVertical;
            }
        }
    }

    public class VsStartOfLineOptions
    {
        public vsStartOfLineOptions vsStartOfLineOptionsFirstColumn
        {
            get
            {
                return vsStartOfLineOptions.vsStartOfLineOptionsFirstColumn;
            }
        }

        public vsStartOfLineOptions vsStartOfLineOptionsFirstText
        {
            get
            {
                return vsStartOfLineOptions.vsStartOfLineOptionsFirstText;
            }
        }
    }

    public class VsSelectionMode
    {
        public vsSelectionMode vsSelectionModeStream
        {
            get
            {
                return vsSelectionMode.vsSelectionModeStream;
            }
        }

        public vsSelectionMode vsSelectionModeBox
        {
            get
            {
                return vsSelectionMode.vsSelectionModeBox;
            }
        }
    }

    public class VsCMTypeRef
    {
        public vsCMTypeRef vsCMTypeRefOther
        {
            get
            {
                return vsCMTypeRef.vsCMTypeRefOther;
            }
        }

        public vsCMTypeRef vsCMTypeRefCodeType
        {
            get
            {
                return vsCMTypeRef.vsCMTypeRefCodeType;
            }
        }

        public vsCMTypeRef vsCMTypeRefArray
        {
            get
            {
                return vsCMTypeRef.vsCMTypeRefArray;
            }
        }

        public vsCMTypeRef vsCMTypeRefVoid
        {
            get
            {
                return vsCMTypeRef.vsCMTypeRefVoid;
            }
        }

        public vsCMTypeRef vsCMTypeRefPointer
        {
            get
            {
                return vsCMTypeRef.vsCMTypeRefPointer;
            }
        }

        public vsCMTypeRef vsCMTypeRefString
        {
            get
            {
                return vsCMTypeRef.vsCMTypeRefString;
            }
        }

        public vsCMTypeRef vsCMTypeRefObject
        {
            get
            {
                return vsCMTypeRef.vsCMTypeRefObject;
            }
        }

        public vsCMTypeRef vsCMTypeRefByte
        {
            get
            {
                return vsCMTypeRef.vsCMTypeRefByte;
            }
        }

        public vsCMTypeRef vsCMTypeRefChar
        {
            get
            {
                return vsCMTypeRef.vsCMTypeRefChar;
            }
        }

        public vsCMTypeRef vsCMTypeRefShort
        {
            get
            {
                return vsCMTypeRef.vsCMTypeRefShort;
            }
        }

        public vsCMTypeRef vsCMTypeRefInt
        {
            get
            {
                return vsCMTypeRef.vsCMTypeRefInt;
            }
        }

        public vsCMTypeRef vsCMTypeRefLong
        {
            get
            {
                return vsCMTypeRef.vsCMTypeRefLong;
            }
        }

        public vsCMTypeRef vsCMTypeRefFloat
        {
            get
            {
                return vsCMTypeRef.vsCMTypeRefFloat;
            }
        }

        public vsCMTypeRef vsCMTypeRefDouble
        {
            get
            {
                return vsCMTypeRef.vsCMTypeRefDouble;
            }
        }

        public vsCMTypeRef vsCMTypeRefDecimal
        {
            get
            {
                return vsCMTypeRef.vsCMTypeRefDecimal;
            }
        }

        public vsCMTypeRef vsCMTypeRefBool
        {
            get
            {
                return vsCMTypeRef.vsCMTypeRefBool;
            }
        }

        public vsCMTypeRef vsCMTypeRefVariant
        {
            get
            {
                return vsCMTypeRef.vsCMTypeRefVariant;
            }
        }
    }

    public class VsContextAttributeType
    {
        public vsContextAttributeType vsContextAttributeFilter
        {
            get
            {
                return vsContextAttributeType.vsContextAttributeFilter;
            }
        }

        public vsContextAttributeType vsContextAttributeLookup
        {
            get
            {
                return vsContextAttributeType.vsContextAttributeLookup;
            }
        }

        public vsContextAttributeType vsContextAttributeLookupF1
        {
            get
            {
                return vsContextAttributeType.vsContextAttributeLookupF1;
            }
        }
    }

    public class VsContextAttributes
    {
        public vsContextAttributes vsContextAttributesGlobal
        {
            get
            {
                return vsContextAttributes.vsContextAttributesGlobal;
            }
        }

        public vsContextAttributes vsContextAttributesWindow
        {
            get
            {
                return vsContextAttributes.vsContextAttributesWindow;
            }
        }

        public vsContextAttributes vsContextAttributesHighPriority
        {
            get
            {
                return vsContextAttributes.vsContextAttributesHighPriority;
            }
        }
    }

    public class VsBuildScope
    {
        public vsBuildScope vsBuildScopeSolution
        {
            get
            {
                return vsBuildScope.vsBuildScopeSolution;
            }
        }

        public vsBuildScope vsBuildScopeBatch
        {
            get
            {
                return vsBuildScope.vsBuildScopeBatch;
            }
        }

        public vsBuildScope vsBuildScopeProject
        {
            get
            {
                return vsBuildScope.vsBuildScopeProject;
            }
        }
    }

    public class VsBuildAction
    {
        public vsBuildAction vsBuildActionBuild
        {
            get
            {
                return vsBuildAction.vsBuildActionBuild;
            }
        }

        public vsBuildAction vsBuildActionRebuildAll
        {
            get
            {
                return vsBuildAction.vsBuildActionRebuildAll;
            }
        }

        public vsBuildAction vsBuildActionClean
        {
            get
            {
                return vsBuildAction.vsBuildActionClean;
            }
        }

        public vsBuildAction vsBuildActionDeploy
        {
            get
            {
                return vsBuildAction.vsBuildActionDeploy;
            }
        }
    }

    public class VsTaskPriority
    {
        public vsTaskPriority vsTaskPriorityLow
        {
            get
            {
                return vsTaskPriority.vsTaskPriorityLow;
            }
        }

        public vsTaskPriority vsTaskPriorityMedium
        {
            get
            {
                return vsTaskPriority.vsTaskPriorityMedium;
            }
        }

        public vsTaskPriority vsTaskPriorityHigh
        {
            get
            {
                return vsTaskPriority.vsTaskPriorityHigh;
            }
        }
    }

    public class VsTaskIcon
    {
        public vsTaskIcon vsTaskIconNone
        {
            get
            {
                return vsTaskIcon.vsTaskIconNone;
            }
        }

        public vsTaskIcon vsTaskIconCompile
        {
            get
            {
                return vsTaskIcon.vsTaskIconCompile;
            }
        }

        public vsTaskIcon vsTaskIconSquiggle
        {
            get
            {
                return vsTaskIcon.vsTaskIconSquiggle;
            }
        }

        public vsTaskIcon vsTaskIconComment
        {
            get
            {
                return vsTaskIcon.vsTaskIconComment;
            }
        }

        public vsTaskIcon vsTaskIconShortcut
        {
            get
            {
                return vsTaskIcon.vsTaskIconShortcut;
            }
        }

        public vsTaskIcon vsTaskIconUser
        {
            get
            {
                return vsTaskIcon.vsTaskIconUser;
            }
        }
    }

    public class VsFindResult
    {
        public vsFindResult vsFindResultNotFound
        {
            get
            {
                return vsFindResult.vsFindResultNotFound;
            }
        }

        public vsFindResult vsFindResultFound
        {
            get
            {
                return vsFindResult.vsFindResultFound;
            }
        }

        public vsFindResult vsFindResultReplaceAndNotFound
        {
            get
            {
                return vsFindResult.vsFindResultReplaceAndNotFound;
            }
        }

        public vsFindResult vsFindResultReplaceAndFound
        {
            get
            {
                return vsFindResult.vsFindResultReplaceAndFound;
            }
        }

        public vsFindResult vsFindResultReplaced
        {
            get
            {
                return vsFindResult.vsFindResultReplaced;
            }
        }

        public vsFindResult vsFindResultPending
        {
            get
            {
                return vsFindResult.vsFindResultPending;
            }
        }

        public vsFindResult vsFindResultError
        {
            get
            {
                return vsFindResult.vsFindResultError;
            }
        }
    }

    public class VsTaskListColumn
    {
        public vsTaskListColumn vsTaskListColumnPriority
        {
            get
            {
                return vsTaskListColumn.vsTaskListColumnPriority;
            }
        }

        public vsTaskListColumn vsTaskListColumnGlyph
        {
            get
            {
                return vsTaskListColumn.vsTaskListColumnGlyph;
            }
        }

        public vsTaskListColumn vsTaskListColumnCheck
        {
            get
            {
                return vsTaskListColumn.vsTaskListColumnCheck;
            }
        }

        public vsTaskListColumn vsTaskListColumnDescription
        {
            get
            {
                return vsTaskListColumn.vsTaskListColumnDescription;
            }
        }

        public vsTaskListColumn vsTaskListColumnFile
        {
            get
            {
                return vsTaskListColumn.vsTaskListColumnFile;
            }
        }

        public vsTaskListColumn vsTaskListColumnLine
        {
            get
            {
                return vsTaskListColumn.vsTaskListColumnLine;
            }
        }
    }

    public class DbgEventReason
    {
        public dbgEventReason dbgEventReasonNone
        {
            get
            {
                return dbgEventReason.dbgEventReasonNone;
            }
        }

        public dbgEventReason dbgEventReasonGo
        {
            get
            {
                return dbgEventReason.dbgEventReasonGo;
            }
        }

        public dbgEventReason dbgEventReasonAttachProgram
        {
            get
            {
                return dbgEventReason.dbgEventReasonAttachProgram;
            }
        }

        public dbgEventReason dbgEventReasonDetachProgram
        {
            get
            {
                return dbgEventReason.dbgEventReasonDetachProgram;
            }
        }

        public dbgEventReason dbgEventReasonLaunchProgram
        {
            get
            {
                return dbgEventReason.dbgEventReasonLaunchProgram;
            }
        }

        public dbgEventReason dbgEventReasonEndProgram
        {
            get
            {
                return dbgEventReason.dbgEventReasonEndProgram;
            }
        }

        public dbgEventReason dbgEventReasonStopDebugging
        {
            get
            {
                return dbgEventReason.dbgEventReasonStopDebugging;
            }
        }

        public dbgEventReason dbgEventReasonStep
        {
            get
            {
                return dbgEventReason.dbgEventReasonStep;
            }
        }

        public dbgEventReason dbgEventReasonBreakpoint
        {
            get
            {
                return dbgEventReason.dbgEventReasonBreakpoint;
            }
        }

        public dbgEventReason dbgEventReasonExceptionThrown
        {
            get
            {
                return dbgEventReason.dbgEventReasonExceptionThrown;
            }
        }

        public dbgEventReason dbgEventReasonExceptionNotHandled
        {
            get
            {
                return dbgEventReason.dbgEventReasonExceptionNotHandled;
            }
        }

        public dbgEventReason dbgEventReasonUserBreak
        {
            get
            {
                return dbgEventReason.dbgEventReasonUserBreak;
            }
        }

        public dbgEventReason dbgEventReasonContextSwitch
        {
            get
            {
                return dbgEventReason.dbgEventReasonContextSwitch;
            }
        }
    }

    public class DbgExecutionAction
    {
        public dbgExecutionAction dbgExecutionActionDefault
        {
            get
            {
                return dbgExecutionAction.dbgExecutionActionDefault;
            }
        }

        public dbgExecutionAction dbgExecutionActionGo
        {
            get
            {
                return dbgExecutionAction.dbgExecutionActionGo;
            }
        }

        public dbgExecutionAction dbgExecutionActionStopDebugging
        {
            get
            {
                return dbgExecutionAction.dbgExecutionActionStopDebugging;
            }
        }

        public dbgExecutionAction dbgExecutionActionStepInto
        {
            get
            {
                return dbgExecutionAction.dbgExecutionActionStepInto;
            }
        }

        public dbgExecutionAction dbgExecutionActionStepOut
        {
            get
            {
                return dbgExecutionAction.dbgExecutionActionStepOut;
            }
        }

        public dbgExecutionAction dbgExecutionActionStepOver
        {
            get
            {
                return dbgExecutionAction.dbgExecutionActionStepOver;
            }
        }

        public dbgExecutionAction dbgExecutionActionRunToCursor
        {
            get
            {
                return dbgExecutionAction.dbgExecutionActionRunToCursor;
            }
        }
    }

    public class DbgExceptionAction
    {
        public dbgExceptionAction dbgExceptionActionDefault
        {
            get
            {
                return dbgExceptionAction.dbgExceptionActionDefault;
            }
        }

        public dbgExceptionAction dbgExceptionActionIgnore
        {
            get
            {
                return dbgExceptionAction.dbgExceptionActionIgnore;
            }
        }

        public dbgExceptionAction dbgExceptionActionBreak
        {
            get
            {
                return dbgExceptionAction.dbgExceptionActionBreak;
            }
        }

        public dbgExceptionAction dbgExceptionActionContinue
        {
            get
            {
                return dbgExceptionAction.dbgExceptionActionContinue;
            }
        }
    }

    public class DbgDebugMode
    {
        public dbgDebugMode dbgDesignMode
        {
            get
            {
                return dbgDebugMode.dbgDesignMode;
            }
        }

        public dbgDebugMode dbgBreakMode
        {
            get
            {
                return dbgDebugMode.dbgBreakMode;
            }
        }

        public dbgDebugMode dbgRunMode
        {
            get
            {
                return dbgDebugMode.dbgRunMode;
            }
        }
    }

    public class DbgBreakpointConditionType
    {
        public dbgBreakpointConditionType dbgBreakpointConditionTypeWhenTrue
        {
            get
            {
                return dbgBreakpointConditionType.dbgBreakpointConditionTypeWhenTrue;
            }
        }

        public dbgBreakpointConditionType dbgBreakpointConditionTypeWhenChanged
        {
            get
            {
                return dbgBreakpointConditionType.dbgBreakpointConditionTypeWhenChanged;
            }
        }
    }

    public class DbgHitCountType
    {
        public dbgHitCountType dbgHitCountTypeNone
        {
            get
            {
                return dbgHitCountType.dbgHitCountTypeNone;
            }
        }

        public dbgHitCountType dbgHitCountTypeEqual
        {
            get
            {
                return dbgHitCountType.dbgHitCountTypeEqual;
            }
        }

        public dbgHitCountType dbgHitCountTypeGreaterOrEqual
        {
            get
            {
                return dbgHitCountType.dbgHitCountTypeGreaterOrEqual;
            }
        }

        public dbgHitCountType dbgHitCountTypeMultiple
        {
            get
            {
                return dbgHitCountType.dbgHitCountTypeMultiple;
            }
        }
    }

    public class DbgBreakpointType
    {
        public dbgBreakpointType dbgBreakpointTypePending
        {
            get
            {
                return dbgBreakpointType.dbgBreakpointTypePending;
            }
        }

        public dbgBreakpointType dbgBreakpointTypeBound
        {
            get
            {
                return dbgBreakpointType.dbgBreakpointTypeBound;
            }
        }
    }

    public class DbgBreakpointLocationType
    {
        public dbgBreakpointLocationType dbgBreakpointLocationTypeNone
        {
            get
            {
                return dbgBreakpointLocationType.dbgBreakpointLocationTypeNone;
            }
        }

        public dbgBreakpointLocationType dbgBreakpointLocationTypeFunction
        {
            get
            {
                return dbgBreakpointLocationType.dbgBreakpointLocationTypeFunction;
            }
        }

        public dbgBreakpointLocationType dbgBreakpointLocationTypeFile
        {
            get
            {
                return dbgBreakpointLocationType.dbgBreakpointLocationTypeFile;
            }
        }

        public dbgBreakpointLocationType dbgBreakpointLocationTypeData
        {
            get
            {
                return dbgBreakpointLocationType.dbgBreakpointLocationTypeData;
            }
        }

        public dbgBreakpointLocationType dbgBreakpointLocationTypeAddress
        {
            get
            {
                return dbgBreakpointLocationType.dbgBreakpointLocationTypeAddress;
            }
        }
    }

    public class VsBuildState
    {
        public vsBuildState vsBuildStateNotStarted
        {
            get
            {
                return vsBuildState.vsBuildStateNotStarted;
            }
        }

        public vsBuildState vsBuildStateInProgress
        {
            get
            {
                return vsBuildState.vsBuildStateInProgress;
            }
        }

        public vsBuildState vsBuildStateDone
        {
            get
            {
                return vsBuildState.vsBuildStateDone;
            }
        }
    }

    public class VsCommandBarType
    {
        public vsCommandBarType vsCommandBarTypePopup
        {
            get
            {
                return vsCommandBarType.vsCommandBarTypePopup;
            }
        }

        public vsCommandBarType vsCommandBarTypeToolbar
        {
            get
            {
                return vsCommandBarType.vsCommandBarTypeToolbar;
            }
        }

        public vsCommandBarType vsCommandBarTypeMenu
        {
            get
            {
                return vsCommandBarType.vsCommandBarTypeMenu;
            }
        }
    }

    public class VsFindAction
    {
        public vsFindAction vsFindActionFind
        {
            get
            {
                return vsFindAction.vsFindActionFind;
            }
        }

        public vsFindAction vsFindActionFindAll
        {
            get
            {
                return vsFindAction.vsFindActionFindAll;
            }
        }

        public vsFindAction vsFindActionReplace
        {
            get
            {
                return vsFindAction.vsFindActionReplace;
            }
        }

        public vsFindAction vsFindActionReplaceAll
        {
            get
            {
                return vsFindAction.vsFindActionReplaceAll;
            }
        }

        public vsFindAction vsFindActionBookmarkAll
        {
            get
            {
                return vsFindAction.vsFindActionBookmarkAll;
            }
        }
    }

    public class VsFindPatternSyntax
    {
        public vsFindPatternSyntax vsFindPatternSyntaxLiteral
        {
            get
            {
                return vsFindPatternSyntax.vsFindPatternSyntaxLiteral;
            }
        }

        public vsFindPatternSyntax vsFindPatternSyntaxRegExpr
        {
            get
            {
                return vsFindPatternSyntax.vsFindPatternSyntaxRegExpr;
            }
        }

        public vsFindPatternSyntax vsFindPatternSyntaxWildcards
        {
            get
            {
                return vsFindPatternSyntax.vsFindPatternSyntaxWildcards;
            }
        }
    }

    public class VsFindTarget
    {
        public vsFindTarget vsFindTargetCurrentDocument
        {
            get
            {
                return vsFindTarget.vsFindTargetCurrentDocument;
            }
        }

        public vsFindTarget vsFindTargetCurrentDocumentSelection
        {
            get
            {
                return vsFindTarget.vsFindTargetCurrentDocumentSelection;
            }
        }

        public vsFindTarget vsFindTargetCurrentDocumentFunction
        {
            get
            {
                return vsFindTarget.vsFindTargetCurrentDocumentFunction;
            }
        }

        public vsFindTarget vsFindTargetOpenDocuments
        {
            get
            {
                return vsFindTarget.vsFindTargetOpenDocuments;
            }
        }

        public vsFindTarget vsFindTargetCurrentProject
        {
            get
            {
                return vsFindTarget.vsFindTargetCurrentProject;
            }
        }

        public vsFindTarget vsFindTargetSolution
        {
            get
            {
                return vsFindTarget.vsFindTargetSolution;
            }
        }

        public vsFindTarget vsFindTargetFiles
        {
            get
            {
                return vsFindTarget.vsFindTargetFiles;
            }
        }
    }

    public class VsFindResultsLocation
    {
        public vsFindResultsLocation vsFindResultsNone
        {
            get
            {
                return vsFindResultsLocation.vsFindResultsNone;
            }
        }

        public vsFindResultsLocation vsFindResults1
        {
            get
            {
                return vsFindResultsLocation.vsFindResults1;
            }
        }

        public vsFindResultsLocation vsFindResults2
        {
            get
            {
                return vsFindResultsLocation.vsFindResults2;
            }
        }
    }

    public class VsNavigateOptions
    {
        public vsNavigateOptions vsNavigateOptionsDefault
        {
            get
            {
                return vsNavigateOptions.vsNavigateOptionsDefault;
            }
        }

        public vsNavigateOptions vsNavigateOptionsNewWindow
        {
            get
            {
                return vsNavigateOptions.vsNavigateOptionsNewWindow;
            }
        }
    }

    public class VsPromptResult
    {
        public vsPromptResult vsPromptResultYes
        {
            get
            {
                return vsPromptResult.vsPromptResultYes;
            }
        }

        public vsPromptResult vsPromptResultNo
        {
            get
            {
                return vsPromptResult.vsPromptResultNo;
            }
        }

        public vsPromptResult vsPromptResultCancelled
        {
            get
            {
                return vsPromptResult.vsPromptResultCancelled;
            }
        }
    }

    public class VsToolBoxItemFormat
    {
        public vsToolBoxItemFormat vsToolBoxItemFormatText
        {
            get
            {
                return vsToolBoxItemFormat.vsToolBoxItemFormatText;
            }
        }

        public vsToolBoxItemFormat vsToolBoxItemFormatHTML
        {
            get
            {
                return vsToolBoxItemFormat.vsToolBoxItemFormatHTML;
            }
        }

        public vsToolBoxItemFormat vsToolBoxItemFormatGUID
        {
            get
            {
                return vsToolBoxItemFormat.vsToolBoxItemFormatGUID;
            }
        }

        public vsToolBoxItemFormat vsToolBoxItemFormatDotNETComponent
        {
            get
            {
                return vsToolBoxItemFormat.vsToolBoxItemFormatDotNETComponent;
            }
        }
    }

    public class VsFilterProperties
    {
        public vsFilterProperties vsFilterPropertiesNone
        {
            get
            {
                return vsFilterProperties.vsFilterPropertiesNone;
            }
        }

        public vsFilterProperties vsFilterPropertiesAll
        {
            get
            {
                return vsFilterProperties.vsFilterPropertiesAll;
            }
        }

        public vsFilterProperties vsFilterPropertiesSet
        {
            get
            {
                return vsFilterProperties.vsFilterPropertiesSet;
            }
        }
    }

    public class VsUISelectionType
    {
        public vsUISelectionType vsUISelectionTypeSelect
        {
            get
            {
                return vsUISelectionType.vsUISelectionTypeSelect;
            }
        }

        public vsUISelectionType vsUISelectionTypeToggle
        {
            get
            {
                return vsUISelectionType.vsUISelectionTypeToggle;
            }
        }

        public vsUISelectionType vsUISelectionTypeExtend
        {
            get
            {
                return vsUISelectionType.vsUISelectionTypeExtend;
            }
        }

        public vsUISelectionType vsUISelectionTypeSetCaret
        {
            get
            {
                return vsUISelectionType.vsUISelectionTypeSetCaret;
            }
        }
    }

    public class VsCMPrototype
    {
        public vsCMPrototype vsCMPrototypeFullname
        {
            get
            {
                return vsCMPrototype.vsCMPrototypeFullname;
            }
        }

        public vsCMPrototype vsCMPrototypeNoName
        {
            get
            {
                return vsCMPrototype.vsCMPrototypeNoName;
            }
        }

        public vsCMPrototype vsCMPrototypeClassName
        {
            get
            {
                return vsCMPrototype.vsCMPrototypeClassName;
            }
        }

        public vsCMPrototype vsCMPrototypeParamTypes
        {
            get
            {
                return vsCMPrototype.vsCMPrototypeParamTypes;
            }
        }

        public vsCMPrototype vsCMPrototypeParamNames
        {
            get
            {
                return vsCMPrototype.vsCMPrototypeParamNames;
            }
        }

        public vsCMPrototype vsCMPrototypeParamDefaultValues
        {
            get
            {
                return vsCMPrototype.vsCMPrototypeParamDefaultValues;
            }
        }

        public vsCMPrototype vsCMPrototypeUniqueSignature
        {
            get
            {
                return vsCMPrototype.vsCMPrototypeUniqueSignature;
            }
        }

        public vsCMPrototype vsCMPrototypeType
        {
            get
            {
                return vsCMPrototype.vsCMPrototypeType;
            }
        }

        public vsCMPrototype vsCMPrototypeInitExpression
        {
            get
            {
                return vsCMPrototype.vsCMPrototypeInitExpression;
            }
        }
    }

    public class VsNavigateBrowser
    {
        public vsNavigateBrowser vsNavigateBrowserDefault
        {
            get
            {
                return vsNavigateBrowser.vsNavigateBrowserDefault;
            }
        }

        public vsNavigateBrowser vsNavigateBrowserHelp
        {
            get
            {
                return vsNavigateBrowser.vsNavigateBrowserHelp;
            }
        }

        public vsNavigateBrowser vsNavigateBrowserNewWindow
        {
            get
            {
                return vsNavigateBrowser.vsNavigateBrowserNewWindow;
            }
        }
    }

    public class VsCommandDisabledFlags
    {
        public vsCommandDisabledFlags vsCommandDisabledFlagsEnabled
        {
            get
            {
                return vsCommandDisabledFlags.vsCommandDisabledFlagsEnabled;
            }
        }

        public vsCommandDisabledFlags vsCommandDisabledFlagsGrey
        {
            get
            {
                return vsCommandDisabledFlags.vsCommandDisabledFlagsGrey;
            }
        }

        public vsCommandDisabledFlags vsCommandDisabledFlagsHidden
        {
            get
            {
                return vsCommandDisabledFlags.vsCommandDisabledFlagsHidden;
            }
        }
    }

    public class VsInitializeMode
    {
        public vsInitializeMode vsInitializeModeStartup
        {
            get
            {
                return vsInitializeMode.vsInitializeModeStartup;
            }
        }

        public vsInitializeMode vsInitializeModeReset
        {
            get
            {
                return vsInitializeMode.vsInitializeModeReset;
            }
        }
    }

    public class VsCommandStatusTextWanted
    {
        public vsCommandStatusTextWanted vsCommandStatusTextWantedNone
        {
            get
            {
                return vsCommandStatusTextWanted.vsCommandStatusTextWantedNone;
            }
        }

        public vsCommandStatusTextWanted vsCommandStatusTextWantedName
        {
            get
            {
                return vsCommandStatusTextWanted.vsCommandStatusTextWantedName;
            }
        }

        public vsCommandStatusTextWanted vsCommandStatusTextWantedStatus
        {
            get
            {
                return vsCommandStatusTextWanted.vsCommandStatusTextWantedStatus;
            }
        }
    }

    public class VsCommandStatus
    {
        public vsCommandStatus vsCommandStatusUnsupported
        {
            get
            {
                return vsCommandStatus.vsCommandStatusUnsupported;
            }
        }

        public vsCommandStatus vsCommandStatusSupported
        {
            get
            {
                return vsCommandStatus.vsCommandStatusSupported;
            }
        }

        public vsCommandStatus vsCommandStatusEnabled
        {
            get
            {
                return vsCommandStatus.vsCommandStatusEnabled;
            }
        }

        public vsCommandStatus vsCommandStatusLatched
        {
            get
            {
                return vsCommandStatus.vsCommandStatusLatched;
            }
        }

        public vsCommandStatus vsCommandStatusNinched
        {
            get
            {
                return vsCommandStatus.vsCommandStatusNinched;
            }
        }

        public vsCommandStatus vsCommandStatusInvisible
        {
            get
            {
                return vsCommandStatus.vsCommandStatusInvisible;
            }
        }
    }

    public class VsCommandExecOption
    {
        public vsCommandExecOption vsCommandExecOptionDoDefault
        {
            get
            {
                return vsCommandExecOption.vsCommandExecOptionDoDefault;
            }
        }

        public vsCommandExecOption vsCommandExecOptionPromptUser
        {
            get
            {
                return vsCommandExecOption.vsCommandExecOptionPromptUser;
            }
        }

        public vsCommandExecOption vsCommandExecOptionDoPromptUser
        {
            get
            {
                return vsCommandExecOption.vsCommandExecOptionDoPromptUser;
            }
        }

        public vsCommandExecOption vsCommandExecOptionShowHelp
        {
            get
            {
                return vsCommandExecOption.vsCommandExecOptionShowHelp;
            }
        }
    }

    public class VsBuildKind
    {
        public vsBuildKind vsBuildKindSolution
        {
            get
            {
                return vsBuildKind.vsBuildKindSolution;
            }
        }

        public vsBuildKind vsBuildKindProject
        {
            get
            {
                return vsBuildKind.vsBuildKindProject;
            }
        }

        public vsBuildKind vsBuildKindProjectItem
        {
            get
            {
                return vsBuildKind.vsBuildKindProjectItem;
            }
        }
    }

    public class VsTextChanged
    {
        public vsTextChanged vsTextChangedMultiLine
        {
            get
            {
                return vsTextChanged.vsTextChangedMultiLine;
            }
        }

        public vsTextChanged vsTextChangedSave
        {
            get
            {
                return vsTextChanged.vsTextChangedSave;
            }
        }

        public vsTextChanged vsTextChangedCaretMoved
        {
            get
            {
                return vsTextChanged.vsTextChangedCaretMoved;
            }
        }

        public vsTextChanged vsTextChangedReplaceAll
        {
            get
            {
                return vsTextChanged.vsTextChangedReplaceAll;
            }
        }

        public vsTextChanged vsTextChangedNewline
        {
            get
            {
                return vsTextChanged.vsTextChangedNewline;
            }
        }

        public vsTextChanged vsTextChangedFindStarting
        {
            get
            {
                return vsTextChanged.vsTextChangedFindStarting;
            }
        }
    }

    public class VsStatusAnimation
    {
        public vsStatusAnimation vsStatusAnimationGeneral
        {
            get
            {
                return vsStatusAnimation.vsStatusAnimationGeneral;
            }
        }

        public vsStatusAnimation vsStatusAnimationPrint
        {
            get
            {
                return vsStatusAnimation.vsStatusAnimationPrint;
            }
        }

        public vsStatusAnimation vsStatusAnimationSave
        {
            get
            {
                return vsStatusAnimation.vsStatusAnimationSave;
            }
        }

        public vsStatusAnimation vsStatusAnimationDeploy
        {
            get
            {
                return vsStatusAnimation.vsStatusAnimationDeploy;
            }
        }

        public vsStatusAnimation vsStatusAnimationSync
        {
            get
            {
                return vsStatusAnimation.vsStatusAnimationSync;
            }
        }

        public vsStatusAnimation vsStatusAnimationBuild
        {
            get
            {
                return vsStatusAnimation.vsStatusAnimationBuild;
            }
        }

        public vsStatusAnimation vsStatusAnimationFind
        {
            get
            {
                return vsStatusAnimation.vsStatusAnimationFind;
            }
        }
    }

    public class VsStartUp
    {
        public vsStartUp vsStartUpShowHomePage
        {
            get
            {
                return vsStartUp.vsStartUpShowHomePage;
            }
        }

        public vsStartUp vsStartUpLoadLastSolution
        {
            get
            {
                return vsStartUp.vsStartUpLoadLastSolution;
            }
        }

        public vsStartUp vsStartUpOpenProjectDialog
        {
            get
            {
                return vsStartUp.vsStartUpOpenProjectDialog;
            }
        }

        public vsStartUp vsStartUpNewProjectDialog
        {
            get
            {
                return vsStartUp.vsStartUpNewProjectDialog;
            }
        }

        public vsStartUp vsStartUpEmptyEnvironment
        {
            get
            {
                return vsStartUp.vsStartUpEmptyEnvironment;
            }
        }
    }

    public class VsFontCharSet
    {
        public vsFontCharSet vsFontCharSetANSI
        {
            get
            {
                return vsFontCharSet.vsFontCharSetANSI;
            }
        }

        public vsFontCharSet vsFontCharSetDefault
        {
            get
            {
                return vsFontCharSet.vsFontCharSetDefault;
            }
        }

        public vsFontCharSet vsFontCharSetSymbol
        {
            get
            {
                return vsFontCharSet.vsFontCharSetSymbol;
            }
        }

        public vsFontCharSet vsFontCharSetMac
        {
            get
            {
                return vsFontCharSet.vsFontCharSetMac;
            }
        }

        public vsFontCharSet vsFontCharSetShiftJIS
        {
            get
            {
                return vsFontCharSet.vsFontCharSetShiftJIS;
            }
        }

        public vsFontCharSet vsFontCharSetHangeul
        {
            get
            {
                return vsFontCharSet.vsFontCharSetHangeul;
            }
        }

        public vsFontCharSet vsFontCharSetJohab
        {
            get
            {
                return vsFontCharSet.vsFontCharSetJohab;
            }
        }

        public vsFontCharSet vsFontCharSetGB2312
        {
            get
            {
                return vsFontCharSet.vsFontCharSetGB2312;
            }
        }

        public vsFontCharSet vsFontCharSetChineseBig5
        {
            get
            {
                return vsFontCharSet.vsFontCharSetChineseBig5;
            }
        }

        public vsFontCharSet vsFontCharSetGreek
        {
            get
            {
                return vsFontCharSet.vsFontCharSetGreek;
            }
        }

        public vsFontCharSet vsFontCharSetTurkish
        {
            get
            {
                return vsFontCharSet.vsFontCharSetTurkish;
            }
        }

        public vsFontCharSet vsFontCharSetVietnamese
        {
            get
            {
                return vsFontCharSet.vsFontCharSetVietnamese;
            }
        }

        public vsFontCharSet vsFontCharSetHebrew
        {
            get
            {
                return vsFontCharSet.vsFontCharSetHebrew;
            }
        }

        public vsFontCharSet vsFontCharSetArabic
        {
            get
            {
                return vsFontCharSet.vsFontCharSetArabic;
            }
        }

        public vsFontCharSet vsFontCharSetBaltic
        {
            get
            {
                return vsFontCharSet.vsFontCharSetBaltic;
            }
        }

        public vsFontCharSet vsFontCharSetRussian
        {
            get
            {
                return vsFontCharSet.vsFontCharSetRussian;
            }
        }

        public vsFontCharSet vsFontCharSetThai
        {
            get
            {
                return vsFontCharSet.vsFontCharSetThai;
            }
        }

        public vsFontCharSet vsFontCharSetEastEurope
        {
            get
            {
                return vsFontCharSet.vsFontCharSetEastEurope;
            }
        }

        public vsFontCharSet vsFontCharSetOEM
        {
            get
            {
                return vsFontCharSet.vsFontCharSetOEM;
            }
        }
    }

    public class VsBrowserViewSource
    {
        public vsBrowserViewSource vsBrowserViewSourceSource
        {
            get
            {
                return vsBrowserViewSource.vsBrowserViewSourceSource;
            }
        }

        public vsBrowserViewSource vsBrowserViewSourceDesign
        {
            get
            {
                return vsBrowserViewSource.vsBrowserViewSourceDesign;
            }
        }

        public vsBrowserViewSource vsBrowserViewSourceExternal
        {
            get
            {
                return vsBrowserViewSource.vsBrowserViewSourceExternal;
            }
        }
    }

    public class VsFindOptions
    {
        public vsFindOptions vsFindOptionsNone
        {
            get
            {
                return vsFindOptions.vsFindOptionsNone;
            }
        }

        public vsFindOptions vsFindOptionsMatchWholeWord
        {
            get
            {
                return vsFindOptions.vsFindOptionsMatchWholeWord;
            }
        }

        public vsFindOptions vsFindOptionsMatchCase
        {
            get
            {
                return vsFindOptions.vsFindOptionsMatchCase;
            }
        }

        public vsFindOptions vsFindOptionsRegularExpression
        {
            get
            {
                return vsFindOptions.vsFindOptionsRegularExpression;
            }
        }

        public vsFindOptions vsFindOptionsBackwards
        {
            get
            {
                return vsFindOptions.vsFindOptionsBackwards;
            }
        }

        public vsFindOptions vsFindOptionsFromStart
        {
            get
            {
                return vsFindOptions.vsFindOptionsFromStart;
            }
        }

        public vsFindOptions vsFindOptionsMatchInHiddenText
        {
            get
            {
                return vsFindOptions.vsFindOptionsMatchInHiddenText;
            }
        }

        public vsFindOptions vsFindOptionsWildcards
        {
            get
            {
                return vsFindOptions.vsFindOptionsWildcards;
            }
        }

        public vsFindOptions vsFindOptionsSearchSubfolders
        {
            get
            {
                return vsFindOptions.vsFindOptionsSearchSubfolders;
            }
        }

        public vsFindOptions vsFindOptionsKeepModifiedDocumentsOpen
        {
            get
            {
                return vsFindOptions.vsFindOptionsKeepModifiedDocumentsOpen;
            }
        }
    }

    public class VsMovementOptions
    {
        public vsMovementOptions vsMovementOptionsMove
        {
            get
            {
                return vsMovementOptions.vsMovementOptionsMove;
            }
        }

        public vsMovementOptions vsMovementOptionsExtend
        {
            get
            {
                return vsMovementOptions.vsMovementOptionsExtend;
            }
        }
    }

    public class VsGoToLineOptions
    {
        public vsGoToLineOptions vsGoToLineOptionsFirst
        {
            get
            {
                return vsGoToLineOptions.vsGoToLineOptionsFirst;
            }
        }

        public vsGoToLineOptions vsGoToLineOptionsLast
        {
            get
            {
                return vsGoToLineOptions.vsGoToLineOptionsLast;
            }
        }
    }

    public class VsSmartFormatOptions
    {
        public vsSmartFormatOptions vsSmartFormatOptionsNone
        {
            get
            {
                return vsSmartFormatOptions.vsSmartFormatOptionsNone;
            }
        }

        public vsSmartFormatOptions vsSmartFormatOptionsBlock
        {
            get
            {
                return vsSmartFormatOptions.vsSmartFormatOptionsBlock;
            }
        }

        public vsSmartFormatOptions vsSmartFormatOptionsSmart
        {
            get
            {
                return vsSmartFormatOptions.vsSmartFormatOptionsSmart;
            }
        }
    }

    public class VsInsertFlags
    {
        public vsInsertFlags vsInsertFlagsCollapseToEnd
        {
            get
            {
                return vsInsertFlags.vsInsertFlagsCollapseToEnd;
            }
        }

        public vsInsertFlags vsInsertFlagsCollapseToStart
        {
            get
            {
                return vsInsertFlags.vsInsertFlagsCollapseToStart;
            }
        }

        public vsInsertFlags vsInsertFlagsContainNewText
        {
            get
            {
                return vsInsertFlags.vsInsertFlagsContainNewText;
            }
        }

        public vsInsertFlags vsInsertFlagsInsertAtEnd
        {
            get
            {
                return vsInsertFlags.vsInsertFlagsInsertAtEnd;
            }
        }

        public vsInsertFlags vsInsertFlagsInsertAtStart
        {
            get
            {
                return vsInsertFlags.vsInsertFlagsInsertAtStart;
            }
        }
    }

    public class VsMoveToColumnLine
    {
        public vsMoveToColumnLine vsMoveToColumnLineFirst
        {
            get
            {
                return vsMoveToColumnLine.vsMoveToColumnLineFirst;
            }
        }

        public vsMoveToColumnLine vsMoveToColumnLineLast
        {
            get
            {
                return vsMoveToColumnLine.vsMoveToColumnLineLast;
            }
        }
    }

    public class VsEPReplaceTextOptions
    {
        public vsEPReplaceTextOptions vsEPReplaceTextKeepMarkers
        {
            get
            {
                return vsEPReplaceTextOptions.vsEPReplaceTextKeepMarkers;
            }
        }

        public vsEPReplaceTextOptions vsEPReplaceTextNormalizeNewlines
        {
            get
            {
                return vsEPReplaceTextOptions.vsEPReplaceTextNormalizeNewlines;
            }
        }

        public vsEPReplaceTextOptions vsEPReplaceTextTabsSpaces
        {
            get
            {
                return vsEPReplaceTextOptions.vsEPReplaceTextTabsSpaces;
            }
        }

        public vsEPReplaceTextOptions vsEPReplaceTextAutoformat
        {
            get
            {
                return vsEPReplaceTextOptions.vsEPReplaceTextAutoformat;
            }
        }
    }

    public class VsIndentStyle
    {
        public vsIndentStyle vsIndentStyleNone
        {
            get
            {
                return vsIndentStyle.vsIndentStyleNone;
            }
        }

        public vsIndentStyle vsIndentStyleDefault
        {
            get
            {
                return vsIndentStyle.vsIndentStyleDefault;
            }
        }

        public vsIndentStyle vsIndentStyleSmart
        {
            get
            {
                return vsIndentStyle.vsIndentStyleSmart;
            }
        }
    }

    public class _vsIndentStyle
    {
        public EnvDTE._vsIndentStyle vsIndentStyleNone
        {
            get
            {
                return EnvDTE._vsIndentStyle.vsIndentStyleNone;
            }
        }

        public EnvDTE._vsIndentStyle vsIndentStyleDefault
        {
            get
            {
                return EnvDTE._vsIndentStyle.vsIndentStyleDefault;
            }
        }

        public EnvDTE._vsIndentStyle vsIndentStyleSmart
        {
            get { return EnvDTE._vsIndentStyle.vsIndentStyleSmart; }
        }
    }

    public class Vsext_FontCharSet
    {
        public vsext_FontCharSet vsext_fontcs_ANSI
        {
            get
            {
                return vsext_FontCharSet.vsext_fontcs_ANSI;
            }
        }

        public vsext_FontCharSet vsext_fontcs_DEFAULT
        {
            get
            {
                return vsext_FontCharSet.vsext_fontcs_DEFAULT;
            }
        }

        public vsext_FontCharSet vsext_fontcs_SYMBOL
        {
            get
            {
                return vsext_FontCharSet.vsext_fontcs_SYMBOL;
            }
        }

        public vsext_FontCharSet vsext_fontcs_MAC
        {
            get
            {
                return vsext_FontCharSet.vsext_fontcs_MAC;
            }
        }

        public vsext_FontCharSet vsext_fontcs_SHIFTJIS
        {
            get
            {
                return vsext_FontCharSet.vsext_fontcs_SHIFTJIS;
            }
        }

        public vsext_FontCharSet vsext_fontcs_HANGEUL
        {
            get
            {
                return vsext_FontCharSet.vsext_fontcs_HANGEUL;
            }
        }

        public vsext_FontCharSet vsext_fontcs_JOHAB
        {
            get
            {
                return vsext_FontCharSet.vsext_fontcs_JOHAB;
            }
        }

        public vsext_FontCharSet vsext_fontcs_GB2312
        {
            get
            {
                return vsext_FontCharSet.vsext_fontcs_GB2312;
            }
        }

        public vsext_FontCharSet vsext_fontcs_CHINESEBIG5
        {
            get
            {
                return vsext_FontCharSet.vsext_fontcs_CHINESEBIG5;
            }
        }

        public vsext_FontCharSet vsext_fontcs_GREEK
        {
            get
            {
                return vsext_FontCharSet.vsext_fontcs_GREEK;
            }
        }

        public vsext_FontCharSet vsext_fontcs_TURKISH
        {
            get
            {
                return vsext_FontCharSet.vsext_fontcs_TURKISH;
            }
        }

        public vsext_FontCharSet vsext_fontcs_VIETNAMESE
        {
            get
            {
                return vsext_FontCharSet.vsext_fontcs_VIETNAMESE;
            }
        }

        public vsext_FontCharSet vsext_fontcs_HEBREW
        {
            get
            {
                return vsext_FontCharSet.vsext_fontcs_HEBREW;
            }
        }

        public vsext_FontCharSet vsext_fontcs_ARABIC
        {
            get
            {
                return vsext_FontCharSet.vsext_fontcs_ARABIC;
            }
        }

        public vsext_FontCharSet vsext_fontcs_BALTIC
        {
            get
            {
                return vsext_FontCharSet.vsext_fontcs_BALTIC;
            }
        }

        public vsext_FontCharSet vsext_fontcs_RUSSIAN
        {
            get
            {
                return vsext_FontCharSet.vsext_fontcs_RUSSIAN;
            }
        }

        public vsext_FontCharSet vsext_fontcs_THAI
        {
            get
            {
                return vsext_FontCharSet.vsext_fontcs_THAI;
            }
        }

        public vsext_FontCharSet vsext_fontcs_EASTEUROPE
        {
            get
            {
                return vsext_FontCharSet.vsext_fontcs_EASTEUROPE;
            }
        }

        public vsext_FontCharSet vsext_fontcs_OEM
        {
            get
            {
                return vsext_FontCharSet.vsext_fontcs_OEM;
            }
        }
    }

    public class Vs_exec_Result
    {
        public vs_exec_Result RESULT_Failure
        {
            get
            {
                return vs_exec_Result.RESULT_Failure;
            }
        }

        public vs_exec_Result RESULT_Cancel
        {
            get
            {
                return vs_exec_Result.RESULT_Cancel;
            }
        }

        public vs_exec_Result RESULT_Success
        {
            get
            {
                return vs_exec_Result.RESULT_Success;
            }
        }
    }

    public class VSEXECRESULT
    {
        public EnvDTE.VSEXECRESULT RESULT_Failure
        {
            get
            {
                return default(EnvDTE.VSEXECRESULT);
            }
        }

        public EnvDTE.VSEXECRESULT RESULT_Cancel
        {
            get
            {
                return default(EnvDTE.VSEXECRESULT);
            }
        }

        public EnvDTE.VSEXECRESULT RESULT_Success
        {
            get
            {
                return default(EnvDTE.VSEXECRESULT);
            }
        }
    }

    public class Vsext_DisplayMode
    {
        public vsext_DisplayMode vsext_dm_SDI
        {
            get
            {
                return vsext_DisplayMode.vsext_dm_SDI;
            }
        }

        public vsext_DisplayMode vsext_dm_MDI
        {
            get
            {
                return vsext_DisplayMode.vsext_dm_MDI;
            }
        }
    }

    public class Vsext_WindowType
    {
        public vsext_WindowType vsext_wt_CodeWindow
        {
            get
            {
                return vsext_WindowType.vsext_wt_CodeWindow;
            }
        }

        public vsext_WindowType vsext_wt_Designer
        {
            get
            {
                return vsext_WindowType.vsext_wt_Designer;
            }
        }

        public vsext_WindowType vsext_wt_Browser
        {
            get
            {
                return vsext_WindowType.vsext_wt_Browser;
            }
        }

        public vsext_WindowType vsext_wt_Watch
        {
            get
            {
                return vsext_WindowType.vsext_wt_Watch;
            }
        }

        public vsext_WindowType vsext_wt_Locals
        {
            get
            {
                return vsext_WindowType.vsext_wt_Locals;
            }
        }

        public vsext_WindowType vsext_wt_Immediate
        {
            get
            {
                return vsext_WindowType.vsext_wt_Immediate;
            }
        }

        public vsext_WindowType vsext_wt_ProjectWindow
        {
            get
            {
                return vsext_WindowType.vsext_wt_ProjectWindow;
            }
        }

        public vsext_WindowType vsext_wt_PropertyWindow
        {
            get
            {
                return vsext_WindowType.vsext_wt_PropertyWindow;
            }
        }

        public vsext_WindowType vsext_wt_Find
        {
            get
            {
                return vsext_WindowType.vsext_wt_Find;
            }
        }

        public vsext_WindowType vsext_wt_FindReplace
        {
            get
            {
                return vsext_WindowType.vsext_wt_FindReplace;
            }
        }

        public vsext_WindowType vsext_wt_Toolbox
        {
            get
            {
                return vsext_WindowType.vsext_wt_Toolbox;
            }
        }

        public vsext_WindowType vsext_wt_LinkedWindowFrame
        {
            get
            {
                return vsext_WindowType.vsext_wt_LinkedWindowFrame;
            }
        }

        public vsext_WindowType vsext_wt_MainWindow
        {
            get
            {
                return vsext_WindowType.vsext_wt_MainWindow;
            }
        }

        public vsext_WindowType vsext_wt_Preview
        {
            get
            {
                return vsext_WindowType.vsext_wt_Preview;
            }
        }

        public vsext_WindowType vsext_wt_ColorPalette
        {
            get
            {
                return vsext_WindowType.vsext_wt_ColorPalette;
            }
        }

        public vsext_WindowType vsext_wt_ToolWindow
        {
            get
            {
                return vsext_WindowType.vsext_wt_ToolWindow;
            }
        }

        public vsext_WindowType vsext_wt_Document
        {
            get
            {
                return vsext_WindowType.vsext_wt_Document;
            }
        }

        public vsext_WindowType vsext_wt_OutPutWindow
        {
            get
            {
                return vsext_WindowType.vsext_wt_OutPutWindow;
            }
        }

        public vsext_WindowType vsext_wt_TaskList
        {
            get
            {
                return vsext_WindowType.vsext_wt_TaskList;
            }
        }

        public vsext_WindowType vsext_wt_Autos
        {
            get
            {
                return vsext_WindowType.vsext_wt_Autos;
            }
        }

        public vsext_WindowType vsext_wt_CallStack
        {
            get
            {
                return vsext_WindowType.vsext_wt_CallStack;
            }
        }

        public vsext_WindowType vsext_wt_Threads
        {
            get
            {
                return vsext_WindowType.vsext_wt_Threads;
            }
        }

        public vsext_WindowType vsext_wt_DocumentOutline
        {
            get
            {
                return vsext_WindowType.vsext_wt_DocumentOutline;
            }
        }

        public vsext_WindowType vsext_wt_RunningDocuments
        {
            get
            {
                return vsext_WindowType.vsext_wt_RunningDocuments;
            }
        }
    }

    public class Vsext_WindowState
    {
        public vsext_WindowState vsext_ws_Normal
        {
            get
            {
                return vsext_WindowState.vsext_ws_Normal;
            }
        }

        public vsext_WindowState vsext_ws_Minimize
        {
            get
            {
                return vsext_WindowState.vsext_ws_Minimize;
            }
        }

        public vsext_WindowState vsext_ws_Maximize
        {
            get
            {
                return vsext_WindowState.vsext_ws_Maximize;
            }
        }
    }

    public class Vsext_LinkedWindowType
    {
        public vsext_LinkedWindowType vsext_lwt_Docked
        {
            get
            {
                return vsext_LinkedWindowType.vsext_lwt_Docked;
            }
        }

        public vsext_LinkedWindowType vsext_lwt_Tabbed
        {
            get
            {
                return vsext_LinkedWindowType.vsext_lwt_Tabbed;
            }
        }
    }

    public class Vsext_StartUp
    {
        public vsext_StartUp vsext_su_EMPTY_ENVIRONMENT
        {
            get
            {
                return vsext_StartUp.vsext_su_EMPTY_ENVIRONMENT;
            }
        }

        public vsext_StartUp vsext_su_NEW_SOLUTION_DIALOG
        {
            get
            {
                return vsext_StartUp.vsext_su_NEW_SOLUTION_DIALOG;
            }
        }

        public vsext_StartUp vsext_su_LOAD_LAST_SOLUTION
        {
            get
            {
                return vsext_StartUp.vsext_su_LOAD_LAST_SOLUTION;
            }
        }
    }

    public class Vsext_Build
    {
        public vsext_Build vsext_bld_SAVE_CHANGES
        {
            get
            {
                return vsext_Build.vsext_bld_SAVE_CHANGES;
            }
        }

        public vsext_Build vsext_bld_CONFIRM_SAVE
        {
            get
            {
                return vsext_Build.vsext_bld_CONFIRM_SAVE;
            }
        }

        public vsext_Build vsext_bld_NO_SAVE
        {
            get
            {
                return vsext_Build.vsext_bld_NO_SAVE;
            }
        }
    }

    public class DsTextSearchOptions
    {
        public EnvDTE.DsTextSearchOptions dsMatchNoRegExp
        {
            get
            {
                return default(EnvDTE.DsTextSearchOptions);
            }
        }

        public EnvDTE.DsTextSearchOptions dsMatchForward
        {
            get
            {
                return default(EnvDTE.DsTextSearchOptions);
            }
        }

        public EnvDTE.DsTextSearchOptions dsMatchWord
        {
            get
            {
                return default(EnvDTE.DsTextSearchOptions);
            }
        }

        public EnvDTE.DsTextSearchOptions dsMatchCase
        {
            get
            {
                return default(EnvDTE.DsTextSearchOptions);
            }
        }

        public EnvDTE.DsTextSearchOptions dsMatchRegExp
        {
            get
            {
                return default(EnvDTE.DsTextSearchOptions);
            }
        }

        public EnvDTE.DsTextSearchOptions dsMatchRegExpB
        {
            get
            {
                return default(EnvDTE.DsTextSearchOptions);
            }
        }

        public EnvDTE.DsTextSearchOptions dsMatchRegExpE
        {
            get
            {
                return default(EnvDTE.DsTextSearchOptions);
            }
        }

        public EnvDTE.DsTextSearchOptions dsMatchRegExpCur
        {
            get
            {
                return default(EnvDTE.DsTextSearchOptions);
            }
        }

        public EnvDTE.DsTextSearchOptions dsMatchBackward
        {
            get
            {
                return default(EnvDTE.DsTextSearchOptions);
            }
        }

        public EnvDTE.DsTextSearchOptions dsMatchFromStart
        {
            get
            {
                return default(EnvDTE.DsTextSearchOptions);
            }
        }
    }

    public class DsSaveChanges
    {
        public EnvDTE.DsSaveChanges dsSaveChangesYes
        {
            get
            {
                return default(EnvDTE.DsSaveChanges);
            }
        }

        public EnvDTE.DsSaveChanges dsSaveChangesNo
        {
            get
            {
                return default(EnvDTE.DsSaveChanges);
            }
        }

        public EnvDTE.DsSaveChanges dsSaveChangesPrompt
        {
            get
            {
                return default(EnvDTE.DsSaveChanges);
            }
        }
    }

    public class DsGoToLineOptions
    {
        public EnvDTE.DsGoToLineOptions dsLastLine
        {
            get
            {
                return default(EnvDTE.DsGoToLineOptions);
            }
        }
    }

    public class DsStartOfLineOptions
    {
        public EnvDTE.DsStartOfLineOptions dsFirstColumn
        {
            get
            {
                return default(EnvDTE.DsStartOfLineOptions);
            }
        }

        public EnvDTE.DsStartOfLineOptions dsFirstText
        {
            get
            {
                return default(EnvDTE.DsStartOfLineOptions);
            }
        }
    }

    public class DsMovementOptions
    {
        public EnvDTE.DsMovementOptions dsMove
        {
            get
            {
                return default(EnvDTE.DsMovementOptions);
            }
        }

        public EnvDTE.DsMovementOptions dsExtend
        {
            get
            {
                return default(EnvDTE.DsMovementOptions);
            }
        }
    }

    public class DsWhitespaceOptions
    {
        public EnvDTE.DsWhitespaceOptions dsHorizontal
        {
            get
            {
                return default(EnvDTE.DsWhitespaceOptions);
            }
        }

        public EnvDTE.DsWhitespaceOptions dsVertical
        {
            get
            {
                return default(EnvDTE.DsWhitespaceOptions);
            }
        }
    }

    public class DsCaseOptions
    {
        public EnvDTE.DsCaseOptions dsLowercase
        {
            get
            {
                return default(EnvDTE.DsCaseOptions);
            }
        }

        public EnvDTE.DsCaseOptions dsUppercase
        {
            get
            {
                return default(EnvDTE.DsCaseOptions);
            }
        }

        public EnvDTE.DsCaseOptions dsCapitalize
        {
            get
            {
                return default(EnvDTE.DsCaseOptions);
            }
        }
    }

    public class DsSaveStatus
    {
        public dsSaveStatus dsSaveSucceeded
        {
            get
            {
                return dsSaveStatus.dsSaveSucceeded;
            }
        }

        public dsSaveStatus dsSaveCancelled
        {
            get
            {
                return dsSaveStatus.dsSaveCancelled;
            }
        }
    }

    public class VsHTMLTabs
    {
        public vsHTMLTabs vsHTMLTabsSource
        {
            get
            {
                return vsHTMLTabs.vsHTMLTabsSource;
            }
        }

        public vsHTMLTabs vsHTMLTabsDesign
        {
            get
            {
                return vsHTMLTabs.vsHTMLTabsDesign;
            }
        }
    }

    public class VsCommandControlType
    {
        public vsCommandControlType vsCommandControlTypeButton
        {
            get
            {
                return vsCommandControlType.vsCommandControlTypeButton;
            }
        }

        public vsCommandControlType vsCommandControlTypeDropDownCombo
        {
            get
            {
                return vsCommandControlType.vsCommandControlTypeDropDownCombo;
            }
        }

        public vsCommandControlType vsCommandControlTypeMRUCombo
        {
            get
            {
                return vsCommandControlType.vsCommandControlTypeMRUCombo;
            }
        }

        public vsCommandControlType vsCommandControlTypeMRUButton
        {
            get
            {
                return vsCommandControlType.vsCommandControlTypeMRUButton;
            }
        }
    }

    public class VsSourceControlCheckOutOptions
    {
        public vsSourceControlCheckOutOptions vsSourceControlCheckOutOptionLatestVersion
        {
            get
            {
                return vsSourceControlCheckOutOptions.vsSourceControlCheckOutOptionLatestVersion;
            }
        }

        public vsSourceControlCheckOutOptions vsSourceControlCheckOutOptionLocalVersion
        {
            get
            {
                return vsSourceControlCheckOutOptions.vsSourceControlCheckOutOptionLocalVersion;
            }
        }
    }

    public class VsBuildErrorLevel
    {
        public vsBuildErrorLevel vsBuildErrorLevelLow
        {
            get
            {
                return vsBuildErrorLevel.vsBuildErrorLevelLow;
            }
        }

        public vsBuildErrorLevel vsBuildErrorLevelMedium
        {
            get
            {
                return vsBuildErrorLevel.vsBuildErrorLevelMedium;
            }
        }

        public vsBuildErrorLevel vsBuildErrorLevelHigh
        {
            get
            {
                return vsBuildErrorLevel.vsBuildErrorLevelHigh;
            }
        }
    }

    public class VsCMFunction2
    {
        public vsCMFunction2 vsCMFunctionAddHandler
        {
            get
            {
                return vsCMFunction2.vsCMFunctionAddHandler;
            }
        }

        public vsCMFunction2 vsCMFunctionRemoveHandler
        {
            get
            {
                return vsCMFunction2.vsCMFunctionRemoveHandler;
            }
        }

        public vsCMFunction2 vsCMFunctionRaiseEvent
        {
            get
            {
                return vsCMFunction2.vsCMFunctionRaiseEvent;
            }
        }
    }

    public class VsCMElement2
    {
        public vsCMElement2 vsCMElementUnknown
        {
            get
            {
                return vsCMElement2.vsCMElementUnknown;
            }
        }

        public vsCMElement2 vsCMElementAttributeArgument
        {
            get
            {
                return vsCMElement2.vsCMElementAttributeArgument;
            }
        }
    }

    public class VsCMTypeRef2
    {
        public vsCMTypeRef2 vsCMTypeRefUnsignedChar
        {
            get
            {
                return vsCMTypeRef2.vsCMTypeRefUnsignedChar;
            }
        }

        public vsCMTypeRef2 vsCMTypeRefUnsignedShort
        {
            get
            {
                return vsCMTypeRef2.vsCMTypeRefUnsignedShort;
            }
        }

        public vsCMTypeRef2 vsCMTypeRefUnsignedInt
        {
            get
            {
                return vsCMTypeRef2.vsCMTypeRefUnsignedInt;
            }
        }

        public vsCMTypeRef2 vsCMTypeRefUnsignedLong
        {
            get
            {
                return vsCMTypeRef2.vsCMTypeRefUnsignedLong;
            }
        }

        public vsCMTypeRef2 vsCMTypeRefReference
        {
            get
            {
                return vsCMTypeRef2.vsCMTypeRefReference;
            }
        }

        public vsCMTypeRef2 vsCMTypeRefMCBoxedReference
        {
            get
            {
                return vsCMTypeRef2.vsCMTypeRefMCBoxedReference;
            }
        }

        public vsCMTypeRef2 vsCMTypeRefSByte
        {
            get
            {
                return vsCMTypeRef2.vsCMTypeRefSByte;
            }
        }
    }

    public class VsCMParseStatus
    {
        public vsCMParseStatus vsCMParseStatusError
        {
            get
            {
                return vsCMParseStatus.vsCMParseStatusError;
            }
        }

        public vsCMParseStatus vsCMParseStatusComplete
        {
            get
            {
                return vsCMParseStatus.vsCMParseStatusComplete;
            }
        }
    }

    public class VsCMClassKind
    {
        public vsCMClassKind vsCMClassKindMainClass
        {
            get
            {
                return vsCMClassKind.vsCMClassKindMainClass;
            }
        }

        public vsCMClassKind vsCMClassKindBlueprint
        {
            get
            {
                return vsCMClassKind.vsCMClassKindBlueprint;
            }
        }

        public vsCMClassKind vsCMClassKindPartialClass
        {
            get
            {
                return vsCMClassKind.vsCMClassKindPartialClass;
            }
        }

        public vsCMClassKind vsCMClassKindModule
        {
            get
            {
                return vsCMClassKind.vsCMClassKindModule;
            }
        }
    }

    public class VsCMDataTypeKind
    {
        public vsCMDataTypeKind vsCMDataTypeKindMain
        {
            get
            {
                return vsCMDataTypeKind.vsCMDataTypeKindMain;
            }
        }

        public vsCMDataTypeKind vsCMDataTypeKindBlueprint
        {
            get
            {
                return vsCMDataTypeKind.vsCMDataTypeKindBlueprint;
            }
        }

        public vsCMDataTypeKind vsCMDataTypeKindPartial
        {
            get
            {
                return vsCMDataTypeKind.vsCMDataTypeKindPartial;
            }
        }

        public vsCMDataTypeKind vsCMDataTypeKindModule
        {
            get
            {
                return vsCMDataTypeKind.vsCMDataTypeKindModule;
            }
        }
    }

    public class VsCMChangeKind
    {
        public vsCMChangeKind vsCMChangeKindRename
        {
            get
            {
                return vsCMChangeKind.vsCMChangeKindRename;
            }
        }

        public vsCMChangeKind vsCMChangeKindUnknown
        {
            get
            {
                return vsCMChangeKind.vsCMChangeKindUnknown;
            }
        }

        public vsCMChangeKind vsCMChangeKindSignatureChange
        {
            get
            {
                return vsCMChangeKind.vsCMChangeKindSignatureChange;
            }
        }

        public vsCMChangeKind vsCMChangeKindTypeRefChange
        {
            get
            {
                return vsCMChangeKind.vsCMChangeKindTypeRefChange;
            }
        }

        public vsCMChangeKind vsCMChangeKindBaseChange
        {
            get
            {
                return vsCMChangeKind.vsCMChangeKindBaseChange;
            }
        }

        public vsCMChangeKind vsCMChangeKindArgumentChange
        {
            get
            {
                return vsCMChangeKind.vsCMChangeKindArgumentChange;
            }
        }
    }

    public class VsCMInheritanceKind
    {
        public vsCMInheritanceKind vsCMInheritanceKindNone
        {
            get
            {
                return vsCMInheritanceKind.vsCMInheritanceKindNone;
            }
        }

        public vsCMInheritanceKind vsCMInheritanceKindAbstract
        {
            get
            {
                return vsCMInheritanceKind.vsCMInheritanceKindAbstract;
            }
        }

        public vsCMInheritanceKind vsCMInheritanceKindSealed
        {
            get
            {
                return vsCMInheritanceKind.vsCMInheritanceKindSealed;
            }
        }

        public vsCMInheritanceKind vsCMInheritanceKindNew
        {
            get
            {
                return vsCMInheritanceKind.vsCMInheritanceKindNew;
            }
        }
    }

    public class VsCMParameterKind
    {
        public vsCMParameterKind vsCMParameterKindNone
        {
            get
            {
                return vsCMParameterKind.vsCMParameterKindNone;
            }
        }

        public vsCMParameterKind vsCMParameterKindIn
        {
            get
            {
                return vsCMParameterKind.vsCMParameterKindIn;
            }
        }

        public vsCMParameterKind vsCMParameterKindRef
        {
            get
            {
                return vsCMParameterKind.vsCMParameterKindRef;
            }
        }

        public vsCMParameterKind vsCMParameterKindOut
        {
            get
            {
                return vsCMParameterKind.vsCMParameterKindOut;
            }
        }

        public vsCMParameterKind vsCMParameterKindOptional
        {
            get
            {
                return vsCMParameterKind.vsCMParameterKindOptional;
            }
        }

        public vsCMParameterKind vsCMParameterKindParamArray
        {
            get
            {
                return vsCMParameterKind.vsCMParameterKindParamArray;
            }
        }
    }

    public class VsCMOverrideKind
    {
        public vsCMOverrideKind vsCMOverrideKindNone
        {
            get
            {
                return vsCMOverrideKind.vsCMOverrideKindNone;
            }
        }

        public vsCMOverrideKind vsCMOverrideKindAbstract
        {
            get
            {
                return vsCMOverrideKind.vsCMOverrideKindAbstract;
            }
        }

        public vsCMOverrideKind vsCMOverrideKindVirtual
        {
            get
            {
                return vsCMOverrideKind.vsCMOverrideKindVirtual;
            }
        }

        public vsCMOverrideKind vsCMOverrideKindOverride
        {
            get
            {
                return vsCMOverrideKind.vsCMOverrideKindOverride;
            }
        }

        public vsCMOverrideKind vsCMOverrideKindNew
        {
            get
            {
                return vsCMOverrideKind.vsCMOverrideKindNew;
            }
        }

        public vsCMOverrideKind vsCMOverrideKindSealed
        {
            get
            {
                return vsCMOverrideKind.vsCMOverrideKindSealed;
            }
        }
    }

    public class VsCMConstKind
    {
        public vsCMConstKind vsCMConstKindNone
        {
            get
            {
                return vsCMConstKind.vsCMConstKindNone;
            }
        }

        public vsCMConstKind vsCMConstKindConst
        {
            get
            {
                return vsCMConstKind.vsCMConstKindConst;
            }
        }

        public vsCMConstKind vsCMConstKindReadOnly
        {
            get
            {
                return vsCMConstKind.vsCMConstKindReadOnly;
            }
        }
    }

    public class VsCMPropertyKind
    {
        public vsCMPropertyKind vsCMPropertyKindReadWrite
        {
            get
            {
                return vsCMPropertyKind.vsCMPropertyKindReadWrite;
            }
        }

        public vsCMPropertyKind vsCMPropertyKindReadOnly
        {
            get
            {
                return vsCMPropertyKind.vsCMPropertyKindReadOnly;
            }
        }

        public vsCMPropertyKind vsCMPropertyKindWriteOnly
        {
            get
            {
                return vsCMPropertyKind.vsCMPropertyKindWriteOnly;
            }
        }
    }

    public class DbgMinidumpOption
    {
        public dbgMinidumpOption dbgMinidumpNormal
        {
            get
            {
                return dbgMinidumpOption.dbgMinidumpNormal;
            }
        }

        public dbgMinidumpOption dbgMinidumpFull
        {
            get
            {
                return dbgMinidumpOption.dbgMinidumpFull;
            }
        }
    }

    public class DbgEventReason2
    {
        public dbgEventReason2 dbgEventReason2None
        {
            get
            {
                return dbgEventReason2.dbgEventReason2None;
            }
        }

        public dbgEventReason2 dbgEventReason2Go
        {
            get
            {
                return dbgEventReason2.dbgEventReason2Go;
            }
        }

        public dbgEventReason2 dbgEventReason2AttachProgram
        {
            get
            {
                return dbgEventReason2.dbgEventReason2AttachProgram;
            }
        }

        public dbgEventReason2 dbgEventReason2DetachProgram
        {
            get
            {
                return dbgEventReason2.dbgEventReason2DetachProgram;
            }
        }

        public dbgEventReason2 dbgEventReason2LaunchProgram
        {
            get
            {
                return dbgEventReason2.dbgEventReason2LaunchProgram;
            }
        }

        public dbgEventReason2 dbgEventReason2EndProgram
        {
            get
            {
                return dbgEventReason2.dbgEventReason2EndProgram;
            }
        }

        public dbgEventReason2 dbgEventReason2StopDebugging
        {
            get
            {
                return dbgEventReason2.dbgEventReason2StopDebugging;
            }
        }

        public dbgEventReason2 dbgEventReason2Step
        {
            get
            {
                return dbgEventReason2.dbgEventReason2Step;
            }
        }

        public dbgEventReason2 dbgEventReason2Breakpoint
        {
            get
            {
                return dbgEventReason2.dbgEventReason2Breakpoint;
            }
        }

        public dbgEventReason2 dbgEventReason2ExceptionThrown
        {
            get
            {
                return dbgEventReason2.dbgEventReason2ExceptionThrown;
            }
        }

        public dbgEventReason2 dbgEventReason2ExceptionNotHandled
        {
            get
            {
                return dbgEventReason2.dbgEventReason2ExceptionNotHandled;
            }
        }

        public dbgEventReason2 dbgEventReason2UserBreak
        {
            get
            {
                return dbgEventReason2.dbgEventReason2UserBreak;
            }
        }

        public dbgEventReason2 dbgEventReason2ContextSwitch
        {
            get
            {
                return dbgEventReason2.dbgEventReason2ContextSwitch;
            }
        }

        public dbgEventReason2 dbgEventReason2Evaluation
        {
            get
            {
                return dbgEventReason2.dbgEventReason2Evaluation;
            }
        }

        public dbgEventReason2 dbgEventReason2UnwindFromException
        {
            get
            {
                return dbgEventReason2.dbgEventReason2UnwindFromException;
            }
        }
    }

    public class DbgProcessState
    {
        public dbgProcessState dbgProcessStateRun
        {
            get
            {
                return dbgProcessState.dbgProcessStateRun;
            }
        }

        public dbgProcessState dbgProcessStateStop
        {
            get
            {
                return dbgProcessState.dbgProcessStateStop;
            }
        }
    }

    public class DbgExpressionEvaluationState
    {
        public dbgExpressionEvaluationState dbgExpressionEvaluationStateStart
        {
            get
            {
                return dbgExpressionEvaluationState.dbgExpressionEvaluationStateStart;
            }
        }

        public dbgExpressionEvaluationState dbgExpressionEvaluationStateStop
        {
            get
            {
                return dbgExpressionEvaluationState.dbgExpressionEvaluationStateStop;
            }
        }
    }

    public class VsCommandStyle
    {
        public vsCommandStyle vsCommandStylePict
        {
            get
            {
                return vsCommandStyle.vsCommandStylePict;
            }
        }

        public vsCommandStyle vsCommandStyleText
        {
            get
            {
                return vsCommandStyle.vsCommandStyleText;
            }
        }

        public vsCommandStyle vsCommandStylePictAndText
        {
            get
            {
                return vsCommandStyle.vsCommandStylePictAndText;
            }
        }

        public vsCommandStyle vsCommandStyleComboNoAutoComplete
        {
            get
            {
                return vsCommandStyle.vsCommandStyleComboNoAutoComplete;
            }
        }

        public vsCommandStyle vsCommandStyleComboCaseSensitive
        {
            get
            {
                return vsCommandStyle.vsCommandStyleComboCaseSensitive;
            }
        }
    }

    public class VsThemeColors
    {
        public vsThemeColors vsThemeColorAccentBorder
        {
            get
            {
                return vsThemeColors.vsThemeColorAccentBorder;
            }
        }

        public vsThemeColors vsThemeColorAccentDark
        {
            get
            {
                return vsThemeColors.vsThemeColorAccentDark;
            }
        }

        public vsThemeColors vsThemeColorAccentLight
        {
            get
            {
                return vsThemeColors.vsThemeColorAccentLight;
            }
        }

        public vsThemeColors vsThemeColorAccentMedium
        {
            get
            {
                return vsThemeColors.vsThemeColorAccentMedium;
            }
        }

        public vsThemeColors vsThemeColorAccentPale
        {
            get
            {
                return vsThemeColors.vsThemeColorAccentPale;
            }
        }

        public vsThemeColors vsThemeColorCommandbarBorder
        {
            get
            {
                return vsThemeColors.vsThemeColorCommandbarBorder;
            }
        }

        public vsThemeColors vsThemeColorCommandbarDraghandle
        {
            get
            {
                return vsThemeColors.vsThemeColorCommandbarDraghandle;
            }
        }

        public vsThemeColors vsThemeColorCommandbarDraghandleShadow
        {
            get
            {
                return vsThemeColors.vsThemeColorCommandbarDraghandleShadow;
            }
        }

        public vsThemeColors vsThemeColorCommandbarGradientBegin
        {
            get
            {
                return vsThemeColors.vsThemeColorCommandbarGradientBegin;
            }
        }

        public vsThemeColors vsThemeColorCommandbarGradientEnd
        {
            get
            {
                return vsThemeColors.vsThemeColorCommandbarGradientEnd;
            }
        }

        public vsThemeColors vsThemeColorCommandbarGradientMiddle
        {
            get
            {
                return vsThemeColors.vsThemeColorCommandbarGradientMiddle;
            }
        }

        public vsThemeColors vsThemeColorCommandbarHover
        {
            get
            {
                return vsThemeColors.vsThemeColorCommandbarHover;
            }
        }

        public vsThemeColors vsThemeColorCommandbarHoveroverSelected
        {
            get
            {
                return vsThemeColors.vsThemeColorCommandbarHoveroverSelected;
            }
        }

        public vsThemeColors vsThemeColorCommandbarHoveroverSelectedicon
        {
            get
            {
                return vsThemeColors.vsThemeColorCommandbarHoveroverSelectedicon;
            }
        }

        public vsThemeColors vsThemeColorCommandbarSelected
        {
            get
            {
                return vsThemeColors.vsThemeColorCommandbarSelected;
            }
        }

        public vsThemeColors vsThemeColorCommandbarShadow
        {
            get
            {
                return vsThemeColors.vsThemeColorCommandbarShadow;
            }
        }

        public vsThemeColors vsThemeColorCommandbarTextActive
        {
            get
            {
                return vsThemeColors.vsThemeColorCommandbarTextActive;
            }
        }

        public vsThemeColors vsThemeColorCommandbarTextHover
        {
            get
            {
                return vsThemeColors.vsThemeColorCommandbarTextHover;
            }
        }

        public vsThemeColors vsThemeColorCommandbarTextInactive
        {
            get
            {
                return vsThemeColors.vsThemeColorCommandbarTextInactive;
            }
        }

        public vsThemeColors vsThemeColorCommandbarTextSelected
        {
            get
            {
                return vsThemeColors.vsThemeColorCommandbarTextSelected;
            }
        }

        public vsThemeColors vsThemeColorControlEditHintText
        {
            get
            {
                return vsThemeColors.vsThemeColorControlEditHintText;
            }
        }

        public vsThemeColors vsThemeColorControlEditRequiredBackground
        {
            get
            {
                return vsThemeColors.vsThemeColorControlEditRequiredBackground;
            }
        }

        public vsThemeColors vsThemeColorControlEditRequiredHintText
        {
            get
            {
                return vsThemeColors.vsThemeColorControlEditRequiredHintText;
            }
        }

        public vsThemeColors vsThemeColorControlLinkText
        {
            get
            {
                return vsThemeColors.vsThemeColorControlLinkText;
            }
        }

        public vsThemeColors vsThemeColorControlLinkTextHover
        {
            get
            {
                return vsThemeColors.vsThemeColorControlLinkTextHover;
            }
        }

        public vsThemeColors vsThemeColorControlLinkTextPressed
        {
            get
            {
                return vsThemeColors.vsThemeColorControlLinkTextPressed;
            }
        }

        public vsThemeColors vsThemeColorControlOutline
        {
            get
            {
                return vsThemeColors.vsThemeColorControlOutline;
            }
        }

        public vsThemeColors vsThemeColorDebuggerDatatipActiveBackground
        {
            get
            {
                return vsThemeColors.vsThemeColorDebuggerDatatipActiveBackground;
            }
        }

        public vsThemeColors vsThemeColorDebuggerDatatipActiveBorder
        {
            get
            {
                return vsThemeColors.vsThemeColorDebuggerDatatipActiveBorder;
            }
        }

        public vsThemeColors vsThemeColorDebuggerDatatipActiveHighlight
        {
            get
            {
                return vsThemeColors.vsThemeColorDebuggerDatatipActiveHighlight;
            }
        }

        public vsThemeColors vsThemeColorDebuggerDatatipActiveHighlightText
        {
            get
            {
                return vsThemeColors.vsThemeColorDebuggerDatatipActiveHighlightText;
            }
        }

        public vsThemeColors vsThemeColorDebuggerDatatipActiveSeparator
        {
            get
            {
                return vsThemeColors.vsThemeColorDebuggerDatatipActiveSeparator;
            }
        }

        public vsThemeColors vsThemeColorDebuggerDatatipActiveText
        {
            get
            {
                return vsThemeColors.vsThemeColorDebuggerDatatipActiveText;
            }
        }

        public vsThemeColors vsThemeColorDebuggerDatatipInactiveBackground
        {
            get
            {
                return vsThemeColors.vsThemeColorDebuggerDatatipInactiveBackground;
            }
        }

        public vsThemeColors vsThemeColorDebuggerDatatipInactiveBorder
        {
            get
            {
                return vsThemeColors.vsThemeColorDebuggerDatatipInactiveBorder;
            }
        }

        public vsThemeColors vsThemeColorDebuggerDatatipInactiveHighlight
        {
            get
            {
                return vsThemeColors.vsThemeColorDebuggerDatatipInactiveHighlight;
            }
        }

        public vsThemeColors vsThemeColorDebuggerDatatipInactiveHighlightText
        {
            get
            {
                return vsThemeColors.vsThemeColorDebuggerDatatipInactiveHighlightText;
            }
        }

        public vsThemeColors vsThemeColorDebuggerDatatipInactiveSeparator
        {
            get
            {
                return vsThemeColors.vsThemeColorDebuggerDatatipInactiveSeparator;
            }
        }

        public vsThemeColors vsThemeColorDebuggerDatatipInactiveText
        {
            get
            {
                return vsThemeColors.vsThemeColorDebuggerDatatipInactiveText;
            }
        }

        public vsThemeColors vsThemeColorDesignerBackground
        {
            get
            {
                return vsThemeColors.vsThemeColorDesignerBackground;
            }
        }

        public vsThemeColors vsThemeColorDesignerSelectionDots
        {
            get
            {
                return vsThemeColors.vsThemeColorDesignerSelectionDots;
            }
        }

        public vsThemeColors vsThemeColorDesignerTray
        {
            get
            {
                return vsThemeColors.vsThemeColorDesignerTray;
            }
        }

        public vsThemeColors vsThemeColorDesignerWatermark
        {
            get
            {
                return vsThemeColors.vsThemeColorDesignerWatermark;
            }
        }

        public vsThemeColors vsThemeColorEnvironmentBackground
        {
            get
            {
                return vsThemeColors.vsThemeColorEnvironmentBackground;
            }
        }

        public vsThemeColors vsThemeColorEnvironmentBackgroundGradientBegin
        {
            get
            {
                return vsThemeColors.vsThemeColorEnvironmentBackgroundGradientBegin;
            }
        }

        public vsThemeColors vsThemeColorEnvironmentBackgroundGradientEnd
        {
            get
            {
                return vsThemeColors.vsThemeColorEnvironmentBackgroundGradientEnd;
            }
        }

        public vsThemeColors vsThemeColorFileTabBorder
        {
            get
            {
                return vsThemeColors.vsThemeColorFileTabBorder;
            }
        }

        public vsThemeColors vsThemeColorFileTabChannelBackground
        {
            get
            {
                return vsThemeColors.vsThemeColorFileTabChannelBackground;
            }
        }

        public vsThemeColors vsThemeColorFileTabGradientDark
        {
            get
            {
                return vsThemeColors.vsThemeColorFileTabGradientDark;
            }
        }

        public vsThemeColors vsThemeColorFileTabGradientLight
        {
            get
            {
                return vsThemeColors.vsThemeColorFileTabGradientLight;
            }
        }

        public vsThemeColors vsThemeColorFileTabSelectedBackground
        {
            get
            {
                return vsThemeColors.vsThemeColorFileTabSelectedBackground;
            }
        }

        public vsThemeColors vsThemeColorFileTabSelectedBorder
        {
            get
            {
                return vsThemeColors.vsThemeColorFileTabSelectedBorder;
            }
        }

        public vsThemeColors vsThemeColorFileTabSelectedText
        {
            get
            {
                return vsThemeColors.vsThemeColorFileTabSelectedText;
            }
        }

        public vsThemeColors vsThemeColorFileTabText
        {
            get
            {
                return vsThemeColors.vsThemeColorFileTabText;
            }
        }

        public vsThemeColors vsThemeColorFormSmartTagActiontagBorder
        {
            get
            {
                return vsThemeColors.vsThemeColorFormSmartTagActiontagBorder;
            }
        }

        public vsThemeColors vsThemeColorFormSmartTagActiontagFill
        {
            get
            {
                return vsThemeColors.vsThemeColorFormSmartTagActiontagFill;
            }
        }

        public vsThemeColors vsThemeColorFormSmartTagObjecttagBorder
        {
            get
            {
                return vsThemeColors.vsThemeColorFormSmartTagObjecttagBorder;
            }
        }

        public vsThemeColors vsThemeColorFormSmartTagObjecttagFill
        {
            get
            {
                return vsThemeColors.vsThemeColorFormSmartTagObjecttagFill;
            }
        }

        public vsThemeColors vsThemeColorGridHeadingBackground
        {
            get
            {
                return vsThemeColors.vsThemeColorGridHeadingBackground;
            }
        }

        public vsThemeColors vsThemeColorGridHeadingText
        {
            get
            {
                return vsThemeColors.vsThemeColorGridHeadingText;
            }
        }

        public vsThemeColors vsThemeColorGridLine
        {
            get
            {
                return vsThemeColors.vsThemeColorGridLine;
            }
        }

        public vsThemeColors vsThemeColorHelpHowDoIPaneBackground
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpHowDoIPaneBackground;
            }
        }

        public vsThemeColors vsThemeColorHelpHowDoIPaneBorder
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpHowDoIPaneBorder;
            }
        }

        public vsThemeColors vsThemeColorHelpHowDoIPaneLink
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpHowDoIPaneLink;
            }
        }

        public vsThemeColors vsThemeColorHelpHowDoIPaneText
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpHowDoIPaneText;
            }
        }

        public vsThemeColors vsThemeColorHelpHowDoITaskBackground
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpHowDoITaskBackground;
            }
        }

        public vsThemeColors vsThemeColorHelpHowDoITaskLink
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpHowDoITaskLink;
            }
        }

        public vsThemeColors vsThemeColorHelpHowDoITaskText
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpHowDoITaskText;
            }
        }

        public vsThemeColors vsThemeColorHelpSearchBackground
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpSearchBackground;
            }
        }

        public vsThemeColors vsThemeColorHelpSearchBorder
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpSearchBorder;
            }
        }

        public vsThemeColors vsThemeColorHelpSearchFitlerBackground
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpSearchFitlerBackground;
            }
        }

        public vsThemeColors vsThemeColorHelpSearchFitlerBorder
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpSearchFitlerBorder;
            }
        }

        public vsThemeColors vsThemeColorHelpSearchGradientBegin
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpSearchGradientBegin;
            }
        }

        public vsThemeColors vsThemeColorHelpSearchGradientEnd
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpSearchGradientEnd;
            }
        }

        public vsThemeColors vsThemeColorHelpSearchNavigationDisabled
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpSearchNavigationDisabled;
            }
        }

        public vsThemeColors vsThemeColorHelpSearchNavigationEnabled
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpSearchNavigationEnabled;
            }
        }

        public vsThemeColors vsThemeColorHelpSearchPanelRules
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpSearchPanelRules;
            }
        }

        public vsThemeColors vsThemeColorHelpSearchProviderBackground
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpSearchProviderBackground;
            }
        }

        public vsThemeColors vsThemeColorHelpSearchProviderIcon
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpSearchProviderIcon;
            }
        }

        public vsThemeColors vsThemeColorHelpSearchProviderText
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpSearchProviderText;
            }
        }

        public vsThemeColors vsThemeColorHelpSearchResultLinkSelected
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpSearchResultLinkSelected;
            }
        }

        public vsThemeColors vsThemeColorHelpSearchResultLinkUnselected
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpSearchResultLinkUnselected;
            }
        }

        public vsThemeColors vsThemeColorHelpSearchResultSelectedBackground
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpSearchResultSelectedBackground;
            }
        }

        public vsThemeColors vsThemeColorHelpSearchResultSelectedText
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpSearchResultSelectedText;
            }
        }

        public vsThemeColors vsThemeColorHelpSearchText
        {
            get
            {
                return vsThemeColors.vsThemeColorHelpSearchText;
            }
        }

        public vsThemeColors vsThemeColorPanelBorder
        {
            get
            {
                return vsThemeColors.vsThemeColorPanelBorder;
            }
        }

        public vsThemeColors vsThemeColorPanelGradientDark
        {
            get
            {
                return vsThemeColors.vsThemeColorPanelGradientDark;
            }
        }

        public vsThemeColors vsThemeColorPanelGradientLight
        {
            get
            {
                return vsThemeColors.vsThemeColorPanelGradientLight;
            }
        }

        public vsThemeColors vsThemeColorPanelHoveroverCloseBorder
        {
            get
            {
                return vsThemeColors.vsThemeColorPanelHoveroverCloseBorder;
            }
        }

        public vsThemeColors vsThemeColorPanelHoveroverCloseFill
        {
            get
            {
                return vsThemeColors.vsThemeColorPanelHoveroverCloseFill;
            }
        }

        public vsThemeColors vsThemeColorPanelHyperlink
        {
            get
            {
                return vsThemeColors.vsThemeColorPanelHyperlink;
            }
        }

        public vsThemeColors vsThemeColorPanelHyperlinkHover
        {
            get
            {
                return vsThemeColors.vsThemeColorPanelHyperlinkHover;
            }
        }

        public vsThemeColors vsThemeColorPanelHyperlinkPressed
        {
            get
            {
                return vsThemeColors.vsThemeColorPanelHyperlinkPressed;
            }
        }

        public vsThemeColors vsThemeColorPanelSeparator
        {
            get
            {
                return vsThemeColors.vsThemeColorPanelSeparator;
            }
        }

        public vsThemeColors vsThemeColorPanelSubGroupSeparator
        {
            get
            {
                return vsThemeColors.vsThemeColorPanelSubGroupSeparator;
            }
        }

        public vsThemeColors vsThemeColorPanelText
        {
            get
            {
                return vsThemeColors.vsThemeColorPanelText;
            }
        }

        public vsThemeColors vsThemeColorPanelTitlebar
        {
            get
            {
                return vsThemeColors.vsThemeColorPanelTitlebar;
            }
        }

        public vsThemeColors vsThemeColorPanelTitlebarText
        {
            get
            {
                return vsThemeColors.vsThemeColorPanelTitlebarText;
            }
        }

        public vsThemeColors vsThemeColorPanelTitlebarUnselected
        {
            get
            {
                return vsThemeColors.vsThemeColorPanelTitlebarUnselected;
            }
        }

        public vsThemeColors vsThemeColorProjectDesignerBackgroundGradientBegin
        {
            get
            {
                return vsThemeColors.vsThemeColorProjectDesignerBackgroundGradientBegin;
            }
        }

        public vsThemeColors vsThemeColorProjectDesignerBackgroundGradientEnd
        {
            get
            {
                return vsThemeColors.vsThemeColorProjectDesignerBackgroundGradientEnd;
            }
        }

        public vsThemeColors vsThemeColorProjectDesignerBorderOutside
        {
            get
            {
                return vsThemeColors.vsThemeColorProjectDesignerBorderOutside;
            }
        }

        public vsThemeColors vsThemeColorProjectDesignerBorderInside
        {
            get
            {
                return vsThemeColors.vsThemeColorProjectDesignerBorderInside;
            }
        }

        public vsThemeColors vsThemeColorProjectDesignerContentsBackground
        {
            get
            {
                return vsThemeColors.vsThemeColorProjectDesignerContentsBackground;
            }
        }

        public vsThemeColors vsThemeColorProjectDesignerTabBackgroundGradientBegin
        {
            get
            {
                return vsThemeColors.vsThemeColorProjectDesignerTabBackgroundGradientBegin;
            }
        }

        public vsThemeColors vsThemeColorProjectDesignerTabBackgroundGradientEnd
        {
            get
            {
                return vsThemeColors.vsThemeColorProjectDesignerTabBackgroundGradientEnd;
            }
        }

        public vsThemeColors vsThemeColorProjectDesignerTabSelectedInsideborder
        {
            get
            {
                return vsThemeColors.vsThemeColorProjectDesignerTabSelectedInsideborder;
            }
        }

        public vsThemeColors vsThemeColorProjectDesignerTabSelectedBorder
        {
            get
            {
                return vsThemeColors.vsThemeColorProjectDesignerTabSelectedBorder;
            }
        }

        public vsThemeColors vsThemeColorProjectDesignerTabSelectedHighlight1
        {
            get
            {
                return vsThemeColors.vsThemeColorProjectDesignerTabSelectedHighlight1;
            }
        }

        public vsThemeColors vsThemeColorProjectDesignerTabSelectedHighlight2
        {
            get
            {
                return vsThemeColors.vsThemeColorProjectDesignerTabSelectedHighlight2;
            }
        }

        public vsThemeColors vsThemeColorProjectDesignerTabSelectedBackground
        {
            get
            {
                return vsThemeColors.vsThemeColorProjectDesignerTabSelectedBackground;
            }
        }

        public vsThemeColors vsThemeColorProjectDesignerTabSepBottomGradientBegin
        {
            get
            {
                return vsThemeColors.vsThemeColorProjectDesignerTabSepBottomGradientBegin;
            }
        }

        public vsThemeColors vsThemeColorProjectDesignerTabSepBottomGradientEnd
        {
            get
            {
                return vsThemeColors.vsThemeColorProjectDesignerTabSepBottomGradientEnd;
            }
        }

        public vsThemeColors vsThemeColorProjectDesignerTabSepTopGradientBegin
        {
            get
            {
                return vsThemeColors.vsThemeColorProjectDesignerTabSepTopGradientBegin;
            }
        }

        public vsThemeColors vsThemeColorProjectDesignerTabSepTopGradientEnd
        {
            get
            {
                return vsThemeColors.vsThemeColorProjectDesignerTabSepTopGradientEnd;
            }
        }

        public vsThemeColors vsThemeColorScreentipBorder
        {
            get
            {
                return vsThemeColors.vsThemeColorScreentipBorder;
            }
        }

        public vsThemeColors vsThemeColorScreentipBackground
        {
            get
            {
                return vsThemeColors.vsThemeColorScreentipBackground;
            }
        }

        public vsThemeColors vsThemeColorScreentipText
        {
            get
            {
                return vsThemeColors.vsThemeColorScreentipText;
            }
        }

        public vsThemeColors vsThemeColorSidebarBackground
        {
            get
            {
                return vsThemeColors.vsThemeColorSidebarBackground;
            }
        }

        public vsThemeColors vsThemeColorSidebarGradientdark
        {
            get
            {
                return vsThemeColors.vsThemeColorSidebarGradientdark;
            }
        }

        public vsThemeColors vsThemeColorSidebarGradientlight
        {
            get
            {
                return vsThemeColors.vsThemeColorSidebarGradientlight;
            }
        }

        public vsThemeColors vsThemeColorSidebarText
        {
            get
            {
                return vsThemeColors.vsThemeColorSidebarText;
            }
        }

        public vsThemeColors vsThemeColorSmartTagBorder
        {
            get
            {
                return vsThemeColors.vsThemeColorSmartTagBorder;
            }
        }

        public vsThemeColors vsThemeColorSmartTagFill
        {
            get
            {
                return vsThemeColors.vsThemeColorSmartTagFill;
            }
        }

        public vsThemeColors vsThemeColorSmartTagHoverBorder
        {
            get
            {
                return vsThemeColors.vsThemeColorSmartTagHoverBorder;
            }
        }

        public vsThemeColors vsThemeColorSmartTagHoverFill
        {
            get
            {
                return vsThemeColors.vsThemeColorSmartTagHoverFill;
            }
        }

        public vsThemeColors vsThemeColorSmartTagHoverText
        {
            get
            {
                return vsThemeColors.vsThemeColorSmartTagHoverText;
            }
        }

        public vsThemeColors vsThemeColorSmartTagText
        {
            get
            {
                return vsThemeColors.vsThemeColorSmartTagText;
            }
        }

        public vsThemeColors vsThemeColorSnaplines
        {
            get
            {
                return vsThemeColors.vsThemeColorSnaplines;
            }
        }

        public vsThemeColors vsThemeColorSnaplinesTextBaseline
        {
            get
            {
                return vsThemeColors.vsThemeColorSnaplinesTextBaseline;
            }
        }

        public vsThemeColors vsThemeColorTasklistGridlines
        {
            get
            {
                return vsThemeColors.vsThemeColorTasklistGridlines;
            }
        }

        public vsThemeColors vsThemeColorTitlebarActive
        {
            get
            {
                return vsThemeColors.vsThemeColorTitlebarActive;
            }
        }

        public vsThemeColors vsThemeColorTitlebarActiveGradientBegin
        {
            get
            {
                return vsThemeColors.vsThemeColorTitlebarActiveGradientBegin;
            }
        }

        public vsThemeColors vsThemeColorTitlebarActiveGradientEnd
        {
            get
            {
                return vsThemeColors.vsThemeColorTitlebarActiveGradientEnd;
            }
        }

        public vsThemeColors vsThemeColorTitlebarActiveText
        {
            get
            {
                return vsThemeColors.vsThemeColorTitlebarActiveText;
            }
        }

        public vsThemeColors vsThemeColorTitlebarInactive
        {
            get
            {
                return vsThemeColors.vsThemeColorTitlebarInactive;
            }
        }

        public vsThemeColors vsThemeColorTitlebarInactiveGradientBegin
        {
            get
            {
                return vsThemeColors.vsThemeColorTitlebarInactiveGradientBegin;
            }
        }

        public vsThemeColors vsThemeColorTitlebarInactiveGradientEnd
        {
            get
            {
                return vsThemeColors.vsThemeColorTitlebarInactiveGradientEnd;
            }
        }

        public vsThemeColors vsThemeColorTitlebarInactiveText
        {
            get
            {
                return vsThemeColors.vsThemeColorTitlebarInactiveText;
            }
        }

        public vsThemeColors vsThemeColorToolboxBackground
        {
            get
            {
                return vsThemeColors.vsThemeColorToolboxBackground;
            }
        }

        public vsThemeColors vsThemeColorToolboxDivider
        {
            get
            {
                return vsThemeColors.vsThemeColorToolboxDivider;
            }
        }

        public vsThemeColors vsThemeColorToolboxGradientDark
        {
            get
            {
                return vsThemeColors.vsThemeColorToolboxGradientDark;
            }
        }

        public vsThemeColors vsThemeColorToolboxGradientLight
        {
            get
            {
                return vsThemeColors.vsThemeColorToolboxGradientLight;
            }
        }

        public vsThemeColors vsThemeColorToolboxHeadingAccent
        {
            get
            {
                return vsThemeColors.vsThemeColorToolboxHeadingAccent;
            }
        }

        public vsThemeColors vsThemeColorToolboxHeadingBegin
        {
            get
            {
                return vsThemeColors.vsThemeColorToolboxHeadingBegin;
            }
        }

        public vsThemeColors vsThemeColorToolboxHeadingEnd
        {
            get
            {
                return vsThemeColors.vsThemeColorToolboxHeadingEnd;
            }
        }

        public vsThemeColors vsThemeColorToolboxIconHighlight
        {
            get
            {
                return vsThemeColors.vsThemeColorToolboxIconHighlight;
            }
        }

        public vsThemeColors vsThemeColorToolboxIconShadow
        {
            get
            {
                return vsThemeColors.vsThemeColorToolboxIconShadow;
            }
        }

        public vsThemeColors vsThemeColorToolWindowBackground
        {
            get
            {
                return vsThemeColors.vsThemeColorToolWindowBackground;
            }
        }

        public vsThemeColors vsThemeColorToolWindowBorder
        {
            get
            {
                return vsThemeColors.vsThemeColorToolWindowBorder;
            }
        }

        public vsThemeColors vsThemeColorToolWindowTabSelectedtab
        {
            get
            {
                return vsThemeColors.vsThemeColorToolWindowTabSelectedtab;
            }
        }

        public vsThemeColors vsThemeColorToolWindowTabBorder
        {
            get
            {
                return vsThemeColors.vsThemeColorToolWindowTabBorder;
            }
        }

        public vsThemeColors vsThemeColorToolWindowTabGradientBegin
        {
            get
            {
                return vsThemeColors.vsThemeColorToolWindowTabGradientBegin;
            }
        }

        public vsThemeColors vsThemeColorToolWindowTabGradientEnd
        {
            get
            {
                return vsThemeColors.vsThemeColorToolWindowTabGradientEnd;
            }
        }

        public vsThemeColors vsThemeColorToolWindowTabText
        {
            get
            {
                return vsThemeColors.vsThemeColorToolWindowTabText;
            }
        }

        public vsThemeColors vsThemeColorToolWindowTabSelectedtext
        {
            get
            {
                return vsThemeColors.vsThemeColorToolWindowTabSelectedtext;
            }
        }

        public vsThemeColors vsThemeColorWizardOrientationPanelBackground
        {
            get
            {
                return vsThemeColors.vsThemeColorWizardOrientationPanelBackground;
            }
        }

        public vsThemeColors vsThemeColorWizardOrientationPanelText
        {
            get
            {
                return vsThemeColors.vsThemeColorWizardOrientationPanelText;
            }
        }
    }

    public class VsFindOptions2
    {
        public vsFindOptions2 vsFindOptionsWaitForFindToComplete
        {
            get
            {
                return vsFindOptions2.vsFindOptionsWaitForFindToComplete;
            }
        }
    }

    public class VsIncrementalSearchResult
    {
        public vsIncrementalSearchResult vsIncrementalSearchResultFound
        {
            get
            {
                return vsIncrementalSearchResult.vsIncrementalSearchResultFound;
            }
        }

        public vsIncrementalSearchResult vsIncrementalSearchResultPassedEOB
        {
            get
            {
                return vsIncrementalSearchResult.vsIncrementalSearchResultPassedEOB;
            }
        }

        public vsIncrementalSearchResult vsIncrementalSearchResultPassedStart
        {
            get
            {
                return vsIncrementalSearchResult.vsIncrementalSearchResultPassedStart;
            }
        }

        public vsIncrementalSearchResult vsIncrementalSearchResultFailed
        {
            get
            {
                return vsIncrementalSearchResult.vsIncrementalSearchResultFailed;
            }
        }
    }

    public class VsPublishState
    {
        public vsPublishState vsPublishStateDone
        {
            get
            {
                return vsPublishState.vsPublishStateDone;
            }
        }

        public vsPublishState vsPublishStateInProgress
        {
            get
            {
                return vsPublishState.vsPublishStateInProgress;
            }
        }   

        public vsPublishState vsPublishStateNotStarted
        {
            get
            {
                return vsPublishState.vsPublishStateNotStarted;
            }
        }
    }
    

}
        