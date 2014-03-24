
// GENERATED CODE
// Changes made to this source file will be overwritten

using Fabric.New.Api.Objects.Traversal;

namespace Fabric.New.Api.Objects {

	/*================================================================================================*/
	public class FabAppDefinesMember : FabLink {

		//Timestamp
		//MemberType
		//UserId


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabAppDefinesMember() : base(typeof(FabApp), typeof(FabMember)) {}

	}

	/*================================================================================================*/
	public class FabArtifactUsedAsPrimaryByFactor : FabLink {

		//Timestamp
		//DescriptorType
		//RelatedArtifactId


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabArtifactUsedAsPrimaryByFactor() : base(typeof(FabArtifact), typeof(FabFactor)) {}

	}

	/*================================================================================================*/
	public class FabArtifactUsedAsRelatedByFactor : FabLink {

		//Timestamp
		//DescriptorType
		//PrimaryArtifactId


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabArtifactUsedAsRelatedByFactor() : base(typeof(FabArtifact), typeof(FabFactor)) {}

	}

	/*================================================================================================*/
	public class FabMemberCreatesArtifact : FabLink {

		//Timestamp
		//VertexType


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabMemberCreatesArtifact() : base(typeof(FabMember), typeof(FabArtifact)) {}

	}

	/*================================================================================================*/
	public class FabMemberCreatesFactor : FabLink {

		//Timestamp
		//DescriptorType
		//PrimaryArtifactId
		//RelatedArtifactId


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabMemberCreatesFactor() : base(typeof(FabMember), typeof(FabFactor)) {}

	}

	/*================================================================================================*/
	public class FabUserDefinesMember : FabLink {

		//Timestamp
		//MemberType
		//AppId


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabUserDefinesMember() : base(typeof(FabUser), typeof(FabMember)) {}

	}

}