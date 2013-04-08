// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/8/2013 1:22:16 PM

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
	public interface IInMemberHas {
		IMemberStep InMemberHas { get; }
	}

	/*================================================================================================*/
	public interface IInMemberHasHistoric {
		IMemberStep InMemberHasHistoric { get; }
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
	public interface IUsesAxisArtifact {
		IArtifactStep UsesAxisArtifact { get; }
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
	public interface IMemberTypeAssignStep :
		INodeForActionStep, IInMemberHas, IInMemberHasHistoric, IInMemberCreates {
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
		INodeStep, IInMemberCreates, IUsesPrimaryArtifact, IUsesRelatedArtifact, IReplacesFactor, IUsesDescriptor, IUsesDirector, IUsesEventor, IUsesIdentor, IUsesLocator, IUsesVector {
	}

	/*================================================================================================*/
	public interface IFactorElementNodeStep :
		INodeStep {
	}

	/*================================================================================================*/
	public interface IDescriptorStep :
		IFactorElementNodeStep, IInFactorListUses, IRefinesPrimaryWithArtifact, IRefinesRelatedWithArtifact, IRefinesTypeWithArtifact {
	}

	/*================================================================================================*/
	public interface IDirectorStep :
		IFactorElementNodeStep, IInFactorListUses {
	}

	/*================================================================================================*/
	public interface IEventorStep :
		IFactorElementNodeStep, IInFactorListUses {
	}

	/*================================================================================================*/
	public interface IIdentorStep :
		IFactorElementNodeStep, IInFactorListUses {
	}

	/*================================================================================================*/
	public interface ILocatorStep :
		IFactorElementNodeStep, IInFactorListUses {
	}

	/*================================================================================================*/
	public interface IVectorStep :
		IFactorElementNodeStep, IInFactorListUses, IUsesAxisArtifact {
	}

}