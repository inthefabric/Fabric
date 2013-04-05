// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/4/2013 5:12:46 PM

namespace Fabric.Api.Traversal.Steps.Nodes {
	
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
	public interface IArtifactStep :
		INodeStep, IInMemberCreates, IInFactorListUsesPrimary, IInFactorListUsesRelated, IInDescriptorListRefinesPrimaryWith, IInDescriptorListRefinesRelatedWith, IInDescriptorListRefinesTypeWith, IInVectorListUsesAxis {
	}

	/*================================================================================================*/
	public interface IAppStep :
		IArtifactStep, IDefinesMemberList {
	}

	/*================================================================================================*/
	public interface IClassStep :
		IArtifactStep {
	}

	/*================================================================================================*/
	public interface IInstanceStep :
		IArtifactStep {
	}

	/*================================================================================================*/
	public interface IMemberStep :
		INodeStep, IInAppDefines, IHasMemberTypeAssign, IHasHistoricMemberTypeAssignList, ICreatesArtifactList, ICreatesMemberTypeAssignList, ICreatesFactorList, IInUserDefines {
	}

	/*================================================================================================*/
	public interface IMemberTypeStep :
		INodeForTypeStep, IInMemberTypeAssignListUses {
	}

	/*================================================================================================*/
	public interface IMemberTypeAssignStep :
		INodeForActionStep, IInMemberHas, IInMemberHasHistoric, IInMemberCreates, IUsesMemberType {
	}

	/*================================================================================================*/
	public interface IUrlStep :
		IArtifactStep {
	}

	/*================================================================================================*/
	public interface IUserStep :
		IArtifactStep, IDefinesMemberList {
	}

	/*================================================================================================*/
	public interface IFactorStep :
		INodeStep, IInMemberCreates, IUsesPrimaryArtifact, IUsesRelatedArtifact, IUsesFactorAssertion, IReplacesFactor, IUsesDescriptor, IUsesDirector, IUsesEventor, IUsesIdentor, IUsesLocator, IUsesVector {
	}

	/*================================================================================================*/
	public interface IFactorAssertionStep :
		INodeForTypeStep, IInFactorListUses {
	}

	/*================================================================================================*/
	public interface IFactorElementNodeStep :
		INodeStep {
	}

	/*================================================================================================*/
	public interface IDescriptorStep :
		IFactorElementNodeStep, IInFactorListUses, IUsesDescriptorType, IRefinesPrimaryWithArtifact, IRefinesRelatedWithArtifact, IRefinesTypeWithArtifact {
	}

	/*================================================================================================*/
	public interface IDescriptorTypeStep :
		INodeForTypeStep, IInDescriptorListUses {
	}

	/*================================================================================================*/
	public interface IDirectorStep :
		IFactorElementNodeStep, IInFactorListUses, IUsesDirectorType, IUsesPrimaryDirectorAction, IUsesRelatedDirectorAction {
	}

	/*================================================================================================*/
	public interface IDirectorTypeStep :
		INodeForTypeStep, IInDirectorListUses {
	}

	/*================================================================================================*/
	public interface IDirectorActionStep :
		INodeForTypeStep, IInDirectorListUsesPrimary, IInDirectorListUsesRelated {
	}

	/*================================================================================================*/
	public interface IEventorStep :
		IFactorElementNodeStep, IInFactorListUses, IUsesEventorType, IUsesEventorPrecision {
	}

	/*================================================================================================*/
	public interface IEventorTypeStep :
		INodeForTypeStep, IInEventorListUses {
	}

	/*================================================================================================*/
	public interface IEventorPrecisionStep :
		INodeForTypeStep, IInEventorListUses {
	}

	/*================================================================================================*/
	public interface IIdentorStep :
		IFactorElementNodeStep, IInFactorListUses, IUsesIdentorType {
	}

	/*================================================================================================*/
	public interface IIdentorTypeStep :
		INodeForTypeStep, IInIdentorListUses {
	}

	/*================================================================================================*/
	public interface ILocatorStep :
		IFactorElementNodeStep, IInFactorListUses, IUsesLocatorType {
	}

	/*================================================================================================*/
	public interface ILocatorTypeStep :
		INodeForTypeStep, IInLocatorListUses {
	}

	/*================================================================================================*/
	public interface IVectorStep :
		IFactorElementNodeStep, IInFactorListUses, IUsesAxisArtifact, IUsesVectorType, IUsesVectorUnit, IUsesVectorUnitPrefix {
	}

	/*================================================================================================*/
	public interface IVectorTypeStep :
		INodeForTypeStep, IInVectorListUses, IUsesVectorRange {
	}

	/*================================================================================================*/
	public interface IVectorRangeStep :
		INodeForTypeStep, IInVectorTypeListUses, IUsesVectorRangeLevelList {
	}

	/*================================================================================================*/
	public interface IVectorRangeLevelStep :
		INodeForTypeStep, IInVectorRangeListUses {
	}

	/*================================================================================================*/
	public interface IVectorUnitStep :
		INodeForTypeStep, IInVectorListUses, IInVectorUnitDerivedListDefines, IInVectorUnitDerivedListRaisesToExp {
	}

	/*================================================================================================*/
	public interface IVectorUnitPrefixStep :
		INodeForTypeStep, IInVectorListUses, IInVectorUnitDerivedListUses {
	}

	/*================================================================================================*/
	public interface IVectorUnitDerivedStep :
		INodeForTypeStep, IDefinesVectorUnit, IRaisesToExpVectorUnit, IUsesVectorUnitPrefix {
	}

}