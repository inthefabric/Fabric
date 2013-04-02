// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/2/2013 1:27:06 PM

namespace Fabric.Api.Traversal.Steps.Nodes {
	
	/*================================================================================================*/
	public interface IContainsAppList {
		IAppStep ContainsAppList { get; }
	}

	/*================================================================================================*/
	public interface IContainsClassList {
		IClassStep ContainsClassList { get; }
	}

	/*================================================================================================*/
	public interface IContainsInstanceList {
		IInstanceStep ContainsInstanceList { get; }
	}

	/*================================================================================================*/
	public interface IContainsMemberList {
		IMemberStep ContainsMemberList { get; }
	}

	/*================================================================================================*/
	public interface IContainsMemberTypeList {
		IMemberTypeStep ContainsMemberTypeList { get; }
	}

	/*================================================================================================*/
	public interface IContainsMemberTypeAssignList {
		IMemberTypeAssignStep ContainsMemberTypeAssignList { get; }
	}

	/*================================================================================================*/
	public interface IContainsUrlList {
		IUrlStep ContainsUrlList { get; }
	}

	/*================================================================================================*/
	public interface IContainsUserList {
		IUserStep ContainsUserList { get; }
	}

	/*================================================================================================*/
	public interface IContainsFactorList {
		IFactorStep ContainsFactorList { get; }
	}

	/*================================================================================================*/
	public interface IContainsFactorAssertionList {
		IFactorAssertionStep ContainsFactorAssertionList { get; }
	}

	/*================================================================================================*/
	public interface IContainsDescriptorList {
		IDescriptorStep ContainsDescriptorList { get; }
	}

	/*================================================================================================*/
	public interface IContainsDescriptorTypeList {
		IDescriptorTypeStep ContainsDescriptorTypeList { get; }
	}

	/*================================================================================================*/
	public interface IContainsDirectorList {
		IDirectorStep ContainsDirectorList { get; }
	}

	/*================================================================================================*/
	public interface IContainsDirectorTypeList {
		IDirectorTypeStep ContainsDirectorTypeList { get; }
	}

	/*================================================================================================*/
	public interface IContainsDirectorActionList {
		IDirectorActionStep ContainsDirectorActionList { get; }
	}

	/*================================================================================================*/
	public interface IContainsEventorList {
		IEventorStep ContainsEventorList { get; }
	}

	/*================================================================================================*/
	public interface IContainsEventorTypeList {
		IEventorTypeStep ContainsEventorTypeList { get; }
	}

	/*================================================================================================*/
	public interface IContainsEventorPrecisionList {
		IEventorPrecisionStep ContainsEventorPrecisionList { get; }
	}

	/*================================================================================================*/
	public interface IContainsIdentorList {
		IIdentorStep ContainsIdentorList { get; }
	}

	/*================================================================================================*/
	public interface IContainsIdentorTypeList {
		IIdentorTypeStep ContainsIdentorTypeList { get; }
	}

	/*================================================================================================*/
	public interface IContainsLocatorList {
		ILocatorStep ContainsLocatorList { get; }
	}

	/*================================================================================================*/
	public interface IContainsLocatorTypeList {
		ILocatorTypeStep ContainsLocatorTypeList { get; }
	}

	/*================================================================================================*/
	public interface IContainsVectorList {
		IVectorStep ContainsVectorList { get; }
	}

	/*================================================================================================*/
	public interface IContainsVectorTypeList {
		IVectorTypeStep ContainsVectorTypeList { get; }
	}

	/*================================================================================================*/
	public interface IContainsVectorRangeList {
		IVectorRangeStep ContainsVectorRangeList { get; }
	}

	/*================================================================================================*/
	public interface IContainsVectorRangeLevelList {
		IVectorRangeLevelStep ContainsVectorRangeLevelList { get; }
	}

	/*================================================================================================*/
	public interface IContainsVectorUnitList {
		IVectorUnitStep ContainsVectorUnitList { get; }
	}

	/*================================================================================================*/
	public interface IContainsVectorUnitPrefixList {
		IVectorUnitPrefixStep ContainsVectorUnitPrefixList { get; }
	}

	/*================================================================================================*/
	public interface IContainsVectorUnitDerivedList {
		IVectorUnitDerivedStep ContainsVectorUnitDerivedList { get; }
	}

	/*================================================================================================*/
	public interface IInMemberCreates {
		IMemberStep InMemberCreates { get; }
	}

	/*================================================================================================*/
	public interface IInFactorListUsesPrimary {
		IFactorStep InFactorListUsesPrimary { get; }
	}

	/*================================================================================================*/
	public interface IInFactorListUsesRelated {
		IFactorStep InFactorListUsesRelated { get; }
	}

	/*================================================================================================*/
	public interface IInDescriptorListRefinesPrimaryWith {
		IDescriptorStep InDescriptorListRefinesPrimaryWith { get; }
	}

	/*================================================================================================*/
	public interface IInDescriptorListRefinesRelatedWith {
		IDescriptorStep InDescriptorListRefinesRelatedWith { get; }
	}

	/*================================================================================================*/
	public interface IInDescriptorListRefinesTypeWith {
		IDescriptorStep InDescriptorListRefinesTypeWith { get; }
	}

	/*================================================================================================*/
	public interface IInVectorListUsesAxis {
		IVectorStep InVectorListUsesAxis { get; }
	}

	/*================================================================================================*/
	public interface IInRootContains {
		IRootStep InRootContains { get; }
	}

	/*================================================================================================*/
	public interface IDefinesMemberList {
		IMemberStep DefinesMemberList { get; }
	}

	/*================================================================================================*/
	public interface IInAppUses {
		IAppStep InAppUses { get; }
	}

	/*================================================================================================*/
	public interface IInUserUses {
		IUserStep InUserUses { get; }
	}

	/*================================================================================================*/
	public interface IInAppDefines {
		IAppStep InAppDefines { get; }
	}

	/*================================================================================================*/
	public interface IHasMemberTypeAssign {
		IMemberTypeAssignStep HasMemberTypeAssign { get; }
	}

	/*================================================================================================*/
	public interface IHasHistoricMemberTypeAssignList {
		IMemberTypeAssignStep HasHistoricMemberTypeAssignList { get; }
	}

	/*================================================================================================*/
	public interface ICreatesArtifactList {
		IArtifactStep CreatesArtifactList { get; }
	}

	/*================================================================================================*/
	public interface ICreatesMemberTypeAssignList {
		IMemberTypeAssignStep CreatesMemberTypeAssignList { get; }
	}

	/*================================================================================================*/
	public interface ICreatesFactorList {
		IFactorStep CreatesFactorList { get; }
	}

	/*================================================================================================*/
	public interface IInUserDefines {
		IUserStep InUserDefines { get; }
	}

	/*================================================================================================*/
	public interface IInMemberTypeAssignListUses {
		IMemberTypeAssignStep InMemberTypeAssignListUses { get; }
	}

	/*================================================================================================*/
	public interface IInMemberHas {
		IMemberStep InMemberHas { get; }
	}

	/*================================================================================================*/
	public interface IInMemberHasHistoric {
		IMemberStep InMemberHasHistoric { get; }
	}

	/*================================================================================================*/
	public interface IUsesMemberType {
		IMemberTypeStep UsesMemberType { get; }
	}

	/*================================================================================================*/
	public interface IUsesPrimaryArtifact {
		IArtifactStep UsesPrimaryArtifact { get; }
	}

	/*================================================================================================*/
	public interface IUsesRelatedArtifact {
		IArtifactStep UsesRelatedArtifact { get; }
	}

	/*================================================================================================*/
	public interface IUsesFactorAssertion {
		IFactorAssertionStep UsesFactorAssertion { get; }
	}

	/*================================================================================================*/
	public interface IReplacesFactor {
		IFactorStep ReplacesFactor { get; }
	}

	/*================================================================================================*/
	public interface IUsesDescriptor {
		IDescriptorStep UsesDescriptor { get; }
	}

	/*================================================================================================*/
	public interface IUsesDirector {
		IDirectorStep UsesDirector { get; }
	}

	/*================================================================================================*/
	public interface IUsesEventor {
		IEventorStep UsesEventor { get; }
	}

	/*================================================================================================*/
	public interface IUsesIdentor {
		IIdentorStep UsesIdentor { get; }
	}

	/*================================================================================================*/
	public interface IUsesLocator {
		ILocatorStep UsesLocator { get; }
	}

	/*================================================================================================*/
	public interface IUsesVector {
		IVectorStep UsesVector { get; }
	}

	/*================================================================================================*/
	public interface IInFactorListUses {
		IFactorStep InFactorListUses { get; }
	}

	/*================================================================================================*/
	public interface IUsesDescriptorType {
		IDescriptorTypeStep UsesDescriptorType { get; }
	}

	/*================================================================================================*/
	public interface IRefinesPrimaryWithArtifact {
		IArtifactStep RefinesPrimaryWithArtifact { get; }
	}

	/*================================================================================================*/
	public interface IRefinesRelatedWithArtifact {
		IArtifactStep RefinesRelatedWithArtifact { get; }
	}

	/*================================================================================================*/
	public interface IRefinesTypeWithArtifact {
		IArtifactStep RefinesTypeWithArtifact { get; }
	}

	/*================================================================================================*/
	public interface IInDescriptorListUses {
		IDescriptorStep InDescriptorListUses { get; }
	}

	/*================================================================================================*/
	public interface IUsesDirectorType {
		IDirectorTypeStep UsesDirectorType { get; }
	}

	/*================================================================================================*/
	public interface IUsesPrimaryDirectorAction {
		IDirectorActionStep UsesPrimaryDirectorAction { get; }
	}

	/*================================================================================================*/
	public interface IUsesRelatedDirectorAction {
		IDirectorActionStep UsesRelatedDirectorAction { get; }
	}

	/*================================================================================================*/
	public interface IInDirectorListUses {
		IDirectorStep InDirectorListUses { get; }
	}

	/*================================================================================================*/
	public interface IInDirectorListUsesPrimary {
		IDirectorStep InDirectorListUsesPrimary { get; }
	}

	/*================================================================================================*/
	public interface IInDirectorListUsesRelated {
		IDirectorStep InDirectorListUsesRelated { get; }
	}

	/*================================================================================================*/
	public interface IUsesEventorType {
		IEventorTypeStep UsesEventorType { get; }
	}

	/*================================================================================================*/
	public interface IUsesEventorPrecision {
		IEventorPrecisionStep UsesEventorPrecision { get; }
	}

	/*================================================================================================*/
	public interface IInEventorListUses {
		IEventorStep InEventorListUses { get; }
	}

	/*================================================================================================*/
	public interface IUsesIdentorType {
		IIdentorTypeStep UsesIdentorType { get; }
	}

	/*================================================================================================*/
	public interface IInIdentorListUses {
		IIdentorStep InIdentorListUses { get; }
	}

	/*================================================================================================*/
	public interface IUsesLocatorType {
		ILocatorTypeStep UsesLocatorType { get; }
	}

	/*================================================================================================*/
	public interface IInLocatorListUses {
		ILocatorStep InLocatorListUses { get; }
	}

	/*================================================================================================*/
	public interface IUsesAxisArtifact {
		IArtifactStep UsesAxisArtifact { get; }
	}

	/*================================================================================================*/
	public interface IUsesVectorType {
		IVectorTypeStep UsesVectorType { get; }
	}

	/*================================================================================================*/
	public interface IUsesVectorUnit {
		IVectorUnitStep UsesVectorUnit { get; }
	}

	/*================================================================================================*/
	public interface IUsesVectorUnitPrefix {
		IVectorUnitPrefixStep UsesVectorUnitPrefix { get; }
	}

	/*================================================================================================*/
	public interface IInVectorListUses {
		IVectorStep InVectorListUses { get; }
	}

	/*================================================================================================*/
	public interface IUsesVectorRange {
		IVectorRangeStep UsesVectorRange { get; }
	}

	/*================================================================================================*/
	public interface IInVectorTypeListUses {
		IVectorTypeStep InVectorTypeListUses { get; }
	}

	/*================================================================================================*/
	public interface IUsesVectorRangeLevelList {
		IVectorRangeLevelStep UsesVectorRangeLevelList { get; }
	}

	/*================================================================================================*/
	public interface IInVectorRangeListUses {
		IVectorRangeStep InVectorRangeListUses { get; }
	}

	/*================================================================================================*/
	public interface IInVectorUnitDerivedListDefines {
		IVectorUnitDerivedStep InVectorUnitDerivedListDefines { get; }
	}

	/*================================================================================================*/
	public interface IInVectorUnitDerivedListRaisesToExp {
		IVectorUnitDerivedStep InVectorUnitDerivedListRaisesToExp { get; }
	}

	/*================================================================================================*/
	public interface IInVectorUnitDerivedListUses {
		IVectorUnitDerivedStep InVectorUnitDerivedListUses { get; }
	}

	/*================================================================================================*/
	public interface IDefinesVectorUnit {
		IVectorUnitStep DefinesVectorUnit { get; }
	}

	/*================================================================================================*/
	public interface IRaisesToExpVectorUnit {
		IVectorUnitStep RaisesToExpVectorUnit { get; }
	}

	/*================================================================================================*/
	public interface IUsesApp {
		IAppStep UsesApp { get; }
	}

	/*================================================================================================*/
	public interface IUsesUser {
		IUserStep UsesUser { get; }
	}

	/*================================================================================================*/
	public interface INodeForTypeStep :
		INodeStep {
	}

	/*================================================================================================*/
	public interface INodeForActionStep :
		INodeStep {
	}

	/*================================================================================================*/
	public interface IRootStep :
		INodeStep, IFinalStep, IContainsAppList, IContainsClassList, IContainsInstanceList, IContainsMemberList, IContainsMemberTypeList, IContainsMemberTypeAssignList, IContainsUrlList, IContainsUserList, IContainsFactorList, IContainsFactorAssertionList, IContainsDescriptorList, IContainsDescriptorTypeList, IContainsDirectorList, IContainsDirectorTypeList, IContainsDirectorActionList, IContainsEventorList, IContainsEventorTypeList, IContainsEventorPrecisionList, IContainsIdentorList, IContainsIdentorTypeList, IContainsLocatorList, IContainsLocatorTypeList, IContainsVectorList, IContainsVectorTypeList, IContainsVectorRangeList, IContainsVectorRangeLevelList, IContainsVectorUnitList, IContainsVectorUnitPrefixList, IContainsVectorUnitDerivedList {
	}

	/*================================================================================================*/
	public interface IArtifactStep :
		INodeStep, IInMemberCreates, IInFactorListUsesPrimary, IInFactorListUsesRelated, IInDescriptorListRefinesPrimaryWith, IInDescriptorListRefinesRelatedWith, IInDescriptorListRefinesTypeWith, IInVectorListUsesAxis {
	}

	/*================================================================================================*/
	public interface IAppStep :
		IArtifactStep, IInRootContains, IDefinesMemberList {
	}

	/*================================================================================================*/
	public interface IClassStep :
		IArtifactStep, IInRootContains {
	}

	/*================================================================================================*/
	public interface IInstanceStep :
		IArtifactStep, IInRootContains {
	}

	/*================================================================================================*/
	public interface IMemberStep :
		INodeStep, IInRootContains, IInAppDefines, IHasMemberTypeAssign, IHasHistoricMemberTypeAssignList, ICreatesArtifactList, ICreatesMemberTypeAssignList, ICreatesFactorList, IInUserDefines {
	}

	/*================================================================================================*/
	public interface IMemberTypeStep :
		INodeForTypeStep, IInRootContains, IInMemberTypeAssignListUses {
	}

	/*================================================================================================*/
	public interface IMemberTypeAssignStep :
		INodeForActionStep, IInRootContains, IInMemberHas, IInMemberHasHistoric, IInMemberCreates, IUsesMemberType {
	}

	/*================================================================================================*/
	public interface IUrlStep :
		IArtifactStep, IInRootContains {
	}

	/*================================================================================================*/
	public interface IUserStep :
		IArtifactStep, IInRootContains, IDefinesMemberList {
	}

	/*================================================================================================*/
	public interface IFactorStep :
		INodeStep, IInRootContains, IInMemberCreates, IUsesPrimaryArtifact, IUsesRelatedArtifact, IUsesFactorAssertion, IReplacesFactor, IUsesDescriptor, IUsesDirector, IUsesEventor, IUsesIdentor, IUsesLocator, IUsesVector {
	}

	/*================================================================================================*/
	public interface IFactorAssertionStep :
		INodeForTypeStep, IInRootContains, IInFactorListUses {
	}

	/*================================================================================================*/
	public interface IFactorElementNodeStep :
		INodeStep {
	}

	/*================================================================================================*/
	public interface IDescriptorStep :
		IFactorElementNodeStep, IInRootContains, IInFactorListUses, IUsesDescriptorType, IRefinesPrimaryWithArtifact, IRefinesRelatedWithArtifact, IRefinesTypeWithArtifact {
	}

	/*================================================================================================*/
	public interface IDescriptorTypeStep :
		INodeForTypeStep, IInRootContains, IInDescriptorListUses {
	}

	/*================================================================================================*/
	public interface IDirectorStep :
		IFactorElementNodeStep, IInRootContains, IInFactorListUses, IUsesDirectorType, IUsesPrimaryDirectorAction, IUsesRelatedDirectorAction {
	}

	/*================================================================================================*/
	public interface IDirectorTypeStep :
		INodeForTypeStep, IInRootContains, IInDirectorListUses {
	}

	/*================================================================================================*/
	public interface IDirectorActionStep :
		INodeForTypeStep, IInRootContains, IInDirectorListUsesPrimary, IInDirectorListUsesRelated {
	}

	/*================================================================================================*/
	public interface IEventorStep :
		IFactorElementNodeStep, IInRootContains, IInFactorListUses, IUsesEventorType, IUsesEventorPrecision {
	}

	/*================================================================================================*/
	public interface IEventorTypeStep :
		INodeForTypeStep, IInRootContains, IInEventorListUses {
	}

	/*================================================================================================*/
	public interface IEventorPrecisionStep :
		INodeForTypeStep, IInRootContains, IInEventorListUses {
	}

	/*================================================================================================*/
	public interface IIdentorStep :
		IFactorElementNodeStep, IInRootContains, IInFactorListUses, IUsesIdentorType {
	}

	/*================================================================================================*/
	public interface IIdentorTypeStep :
		INodeForTypeStep, IInRootContains, IInIdentorListUses {
	}

	/*================================================================================================*/
	public interface ILocatorStep :
		IFactorElementNodeStep, IInRootContains, IInFactorListUses, IUsesLocatorType {
	}

	/*================================================================================================*/
	public interface ILocatorTypeStep :
		INodeForTypeStep, IInRootContains, IInLocatorListUses {
	}

	/*================================================================================================*/
	public interface IVectorStep :
		IFactorElementNodeStep, IInRootContains, IInFactorListUses, IUsesAxisArtifact, IUsesVectorType, IUsesVectorUnit, IUsesVectorUnitPrefix {
	}

	/*================================================================================================*/
	public interface IVectorTypeStep :
		INodeForTypeStep, IInRootContains, IInVectorListUses, IUsesVectorRange {
	}

	/*================================================================================================*/
	public interface IVectorRangeStep :
		INodeForTypeStep, IInRootContains, IInVectorTypeListUses, IUsesVectorRangeLevelList {
	}

	/*================================================================================================*/
	public interface IVectorRangeLevelStep :
		INodeForTypeStep, IInRootContains, IInVectorRangeListUses {
	}

	/*================================================================================================*/
	public interface IVectorUnitStep :
		INodeForTypeStep, IInRootContains, IInVectorListUses, IInVectorUnitDerivedListDefines, IInVectorUnitDerivedListRaisesToExp {
	}

	/*================================================================================================*/
	public interface IVectorUnitPrefixStep :
		INodeForTypeStep, IInRootContains, IInVectorListUses, IInVectorUnitDerivedListUses {
	}

	/*================================================================================================*/
	public interface IVectorUnitDerivedStep :
		INodeForTypeStep, IInRootContains, IDefinesVectorUnit, IRaisesToExpVectorUnit, IUsesVectorUnitPrefix {
	}

}