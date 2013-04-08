// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/8/2013 2:54:24 PM

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
	public interface IInFactorListRefinesPrimaryWith {
		IFactorStep InFactorListRefinesPrimaryWith { get; }
	}

	/*================================================================================================*/
	public interface IInFactorListRefinesRelatedWith {
		IFactorStep InFactorListRefinesRelatedWith { get; }
	}

	/*================================================================================================*/
	public interface IInFactorListRefinesTypeWith {
		IFactorStep InFactorListRefinesTypeWith { get; }
	}

	/*================================================================================================*/
	public interface IInFactorListUsesAxis {
		IFactorStep InFactorListUsesAxis { get; }
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
		INodeStep, IInMemberCreates, IInFactorListUsesPrimary, IInFactorListUsesRelated, IInFactorListRefinesPrimaryWith, IInFactorListRefinesRelatedWith, IInFactorListRefinesTypeWith, IInFactorListUsesAxis {
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
		INodeStep, IInMemberCreates, IUsesPrimaryArtifact, IUsesRelatedArtifact, IReplacesFactor, IRefinesPrimaryWithArtifact, IRefinesRelatedWithArtifact, IRefinesTypeWithArtifact, IUsesAxisArtifact {
	}

}