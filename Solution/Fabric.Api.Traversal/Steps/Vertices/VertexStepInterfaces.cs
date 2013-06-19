﻿// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 6/18/2013 3:43:36 PM

namespace Fabric.Api.Traversal.Steps.Vertices {
	
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
	public interface IInFactorListDescriptorRefinesPrimaryWith {
		IFactorStep InFactorListDescriptorRefinesPrimaryWith { get; }
	}

	/*================================================================================================*/
	public interface IInFactorListDescriptorRefinesRelatedWith {
		IFactorStep InFactorListDescriptorRefinesRelatedWith { get; }
	}

	/*================================================================================================*/
	public interface IInFactorListDescriptorRefinesTypeWith {
		IFactorStep InFactorListDescriptorRefinesTypeWith { get; }
	}

	/*================================================================================================*/
	public interface IInFactorListVectorUsesAxis {
		IFactorStep InFactorListVectorUsesAxis { get; }
	}

	/*================================================================================================*/
	public interface IDefinesMemberList {
		IMemberStep DefinesMemberList { get; }
	}

	/*================================================================================================*/
	public interface IInAppListUses {
		IAppStep InAppListUses { get; }
	}

	/*================================================================================================*/
	public interface IInUserListUses {
		IUserStep InUserListUses { get; }
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
	public interface IDescriptorRefinesPrimaryWithArtifact {
		IArtifactStep DescriptorRefinesPrimaryWithArtifact { get; }
	}

	/*================================================================================================*/
	public interface IDescriptorRefinesRelatedWithArtifact {
		IArtifactStep DescriptorRefinesRelatedWithArtifact { get; }
	}

	/*================================================================================================*/
	public interface IDescriptorRefinesTypeWithArtifact {
		IArtifactStep DescriptorRefinesTypeWithArtifact { get; }
	}

	/*================================================================================================*/
	public interface IVectorUsesAxisArtifact {
		IArtifactStep VectorUsesAxisArtifact { get; }
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
	public interface IVertexForActionStep :
		IVertexStep {
	}

	/*================================================================================================*/
	public interface IArtifactStep :
		IVertexStep, IInMemberCreates, IInFactorListUsesPrimary, IInFactorListUsesRelated, IInFactorListDescriptorRefinesPrimaryWith, IInFactorListDescriptorRefinesRelatedWith, IInFactorListDescriptorRefinesTypeWith, IInFactorListVectorUsesAxis {
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
		IVertexStep, IInAppDefines, IHasMemberTypeAssign, IHasHistoricMemberTypeAssignList, ICreatesArtifactList, ICreatesMemberTypeAssignList, ICreatesFactorList, IInUserDefines {
	}

	/*================================================================================================*/
	public interface IMemberTypeAssignStep :
		IVertexForActionStep, IInMemberHas, IInMemberHasHistoric, IInMemberCreates {
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
		IVertexStep, IInMemberCreates, IUsesPrimaryArtifact, IUsesRelatedArtifact, IDescriptorRefinesPrimaryWithArtifact, IDescriptorRefinesRelatedWithArtifact, IDescriptorRefinesTypeWithArtifact, IVectorUsesAxisArtifact {
	}

}