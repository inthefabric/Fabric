
// GENERATED CODE
// Changes made to this source file will be overwritten

namespace Fabric.New.Api.Objects {

	/*================================================================================================*/
	public class FabAppDefinesMember : FabLink<FabApp, FabMember> {
		//Timestamp
		//MemberType
		//UserId
	}

	/*================================================================================================*/
	public class FabArtifactUsedAsPrimaryByFactor : FabLink<FabArtifact, FabFactor> {
		//Timestamp
		//DescriptorType
		//RelatedArtifactId
	}

	/*================================================================================================*/
	public class FabArtifactUsedAsRelatedByFactor : FabLink<FabArtifact, FabFactor> {
		//Timestamp
		//DescriptorType
		//PrimaryArtifactId
	}

	/*================================================================================================*/
	public class FabMemberAuthenticatedByOauthAccess : FabLink<FabMember, FabOauthAccess> {
		//Timestamp
	}

	/*================================================================================================*/
	public class FabMemberCreatesArtifact : FabLink<FabMember, FabArtifact> {
		//Timestamp
		//VertexType
	}

	/*================================================================================================*/
	public class FabMemberCreatesFactor : FabLink<FabMember, FabFactor> {
		//Timestamp
		//DescriptorType
		//PrimaryArtifactId
		//RelatedArtifactId
	}

	/*================================================================================================*/
	public class FabUserDefinesMember : FabLink<FabUser, FabMember> {
		//Timestamp
		//MemberType
		//AppId
	}

}