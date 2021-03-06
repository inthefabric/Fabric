﻿
// GENERATED CODE
// Changes made to this source file will be overwritten

using System.Collections.Generic;

namespace Fabric.Api.Lang {

	/*================================================================================================*/
	public static partial class SmartLinks {

		private static readonly IDictionary<string, string> VertMap = new Dictionary<string, string> {
			{"App", "FabApp"},
			{"Apps", "FabApp"},
			{"FabApp", "FabApp"},
			{"FabApps", "FabApp"},
			{"CreateFabApp", "FabApp"},
			{"CreateFabApps", "FabApp"},
			{"Artifact", "FabArtifact"},
			{"Artifacts", "FabArtifact"},
			{"FabArtifact", "FabArtifact"},
			{"FabArtifacts", "FabArtifact"},
			{"CreateFabArtifact", "FabArtifact"},
			{"CreateFabArtifacts", "FabArtifact"},
			{"Class", "FabClass"},
			{"Classes", "FabClass"},
			{"FabClass", "FabClass"},
			{"FabClasses", "FabClass"},
			{"CreateFabClass", "FabClass"},
			{"CreateFabClasses", "FabClass"},
			{"Email", "FabEmail"},
			{"Emails", "FabEmail"},
			{"FabEmail", "FabEmail"},
			{"FabEmails", "FabEmail"},
			{"CreateFabEmail", "FabEmail"},
			{"CreateFabEmails", "FabEmail"},
			{"Factor", "FabFactor"},
			{"Factors", "FabFactor"},
			{"FabFactor", "FabFactor"},
			{"FabFactors", "FabFactor"},
			{"CreateFabFactor", "FabFactor"},
			{"CreateFabFactors", "FabFactor"},
			{"Instance", "FabInstance"},
			{"Instances", "FabInstance"},
			{"FabInstance", "FabInstance"},
			{"FabInstances", "FabInstance"},
			{"CreateFabInstance", "FabInstance"},
			{"CreateFabInstances", "FabInstance"},
			{"Member", "FabMember"},
			{"Members", "FabMember"},
			{"FabMember", "FabMember"},
			{"FabMembers", "FabMember"},
			{"CreateFabMember", "FabMember"},
			{"CreateFabMembers", "FabMember"},
			{"OauthAccess", "FabOauthAccess"},
			{"OauthAccesses", "FabOauthAccess"},
			{"FabOauthAccess", "FabOauthAccess"},
			{"FabOauthAccesses", "FabOauthAccess"},
			{"CreateFabOauthAccess", "FabOauthAccess"},
			{"CreateFabOauthAccesses", "FabOauthAccess"},
			{"Url", "FabUrl"},
			{"Urls", "FabUrl"},
			{"FabUrl", "FabUrl"},
			{"FabUrls", "FabUrl"},
			{"CreateFabUrl", "FabUrl"},
			{"CreateFabUrls", "FabUrl"},
			{"User", "FabUser"},
			{"Users", "FabUser"},
			{"FabUser", "FabUser"},
			{"FabUsers", "FabUser"},
			{"CreateFabUser", "FabUser"},
			{"CreateFabUsers", "FabUser"},
			{"Vertex", "FabVertex"},
			{"Vertices", "FabVertex"},
			{"FabVertex", "FabVertex"},
			{"FabVertices", "FabVertex"},
			{"CreateFabVertex", "FabVertex"},
			{"CreateFabVertices", "FabVertex"},
		};

		private static readonly IDictionary<string, string> EdgeMap = new Dictionary<string, string> {
			{"AppDefinesMember", "FabAppDefinesMember"},
			{"FabAppDefinesMember", "FabAppDefinesMember"},
			{"ArtifactCreatedByMember", "FabArtifactCreatedByMember"},
			{"FabArtifactCreatedByMember", "FabArtifactCreatedByMember"},
			{"ArtifactUsedAsPrimaryByFactor", "FabArtifactUsedAsPrimaryByFactor"},
			{"FabArtifactUsedAsPrimaryByFactor", "FabArtifactUsedAsPrimaryByFactor"},
			{"ArtifactUsedAsRelatedByFactor", "FabArtifactUsedAsRelatedByFactor"},
			{"FabArtifactUsedAsRelatedByFactor", "FabArtifactUsedAsRelatedByFactor"},
			{"ArtifactUsesEmail", "FabArtifactUsesEmail"},
			{"FabArtifactUsesEmail", "FabArtifactUsesEmail"},
			{"EmailUsedByArtifact", "FabEmailUsedByArtifact"},
			{"FabEmailUsedByArtifact", "FabEmailUsedByArtifact"},
			{"FactorCreatedByMember", "FabFactorCreatedByMember"},
			{"FabFactorCreatedByMember", "FabFactorCreatedByMember"},
			{"FactorDescriptorRefinesPrimaryWithArtifact", "FabFactorRefinesPrimaryWithArtifact"},
			{"FabFactorRefinesPrimaryWithArtifact", "FabFactorRefinesPrimaryWithArtifact"},
			{"FactorDescriptorRefinesRelatedWithArtifact", "FabFactorRefinesRelatedWithArtifact"},
			{"FabFactorRefinesRelatedWithArtifact", "FabFactorRefinesRelatedWithArtifact"},
			{"FactorDescriptorRefinesTypeWithArtifact", "FabFactorRefinesTypeWithArtifact"},
			{"FabFactorRefinesTypeWithArtifact", "FabFactorRefinesTypeWithArtifact"},
			{"FactorUsesPrimaryArtifact", "FabFactorUsesPrimaryArtifact"},
			{"FabFactorUsesPrimaryArtifact", "FabFactorUsesPrimaryArtifact"},
			{"FactorUsesRelatedArtifact", "FabFactorUsesRelatedArtifact"},
			{"FabFactorUsesRelatedArtifact", "FabFactorUsesRelatedArtifact"},
			{"FactorVectorUsesAxisArtifact", "FabFactorUsesAxisArtifact"},
			{"FabFactorUsesAxisArtifact", "FabFactorUsesAxisArtifact"},
			{"MemberAuthenticatedByOauthAccess", "FabMemberAuthenticatedByOauthAccess"},
			{"FabMemberAuthenticatedByOauthAccess", "FabMemberAuthenticatedByOauthAccess"},
			{"MemberCreatesArtifact", "FabMemberCreatesArtifact"},
			{"FabMemberCreatesArtifact", "FabMemberCreatesArtifact"},
			{"MemberCreatesFactor", "FabMemberCreatesFactor"},
			{"FabMemberCreatesFactor", "FabMemberCreatesFactor"},
			{"MemberDefinedByApp", "FabMemberDefinedByApp"},
			{"FabMemberDefinedByApp", "FabMemberDefinedByApp"},
			{"MemberDefinedByUser", "FabMemberDefinedByUser"},
			{"FabMemberDefinedByUser", "FabMemberDefinedByUser"},
			{"OauthAccessAuthenticatesMember", "FabOauthAccessAuthenticatesMember"},
			{"FabOauthAccessAuthenticatesMember", "FabOauthAccessAuthenticatesMember"},
			{"UserDefinesMember", "FabUserDefinesMember"},
			{"FabUserDefinesMember", "FabUserDefinesMember"},
		};

		private static readonly IDictionary<string, string> EnumMap = new Dictionary<string, string> {
			{"DescriptorType", "DescriptorType"},
			{"DirectorAction", "DirectorAction"},
			{"DirectorType", "DirectorType"},
			{"EventorType", "EventorType"},
			{"FactorAssertion", "FactorAssertion"},
			{"IdentorType", "IdentorType"},
			{"LocatorType", "LocatorType"},
			{"MemberType", "MemberType"},
			{"VectorRangeLevel", "VectorRangeLevel"},
			{"VectorRange", "VectorRange"},
			{"VectorType", "VectorType"},
			{"VectorUnitDerived", "VectorUnitDerived"},
			{"VectorUnitPrefix", "VectorUnitPrefix"},
			{"VectorUnit", "VectorUnit"},
			{"VertexType", "VertexType"},
		};

	}

}