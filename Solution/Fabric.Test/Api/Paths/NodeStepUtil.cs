// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 12/11/2012 4:55:48 PM

using System.Collections.Generic;

namespace Fabric.Test.Api.Paths {
	
	/*================================================================================================*/
	public static class NodeStepUtil {

		public static Dictionary<string, string[]> NodeStepMap = BuildNodeStepMap();
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static Dictionary<string, string[]> BuildNodeStepMap() {
			var map = new Dictionary<string, string[]>();

			map.Add("Root", new string[] {
				"/ContainsAppList",
				"/ContainsArtifactList",
				"/ContainsArtifactTypeList",
				"/ContainsCrowdList",
				"/ContainsCrowdianList",
				"/ContainsCrowdianTypeList",
				"/ContainsCrowdianTypeAssignList",
				"/ContainsEmailList",
				"/ContainsLabelList",
				"/ContainsMemberList",
				"/ContainsMemberTypeList",
				"/ContainsMemberTypeAssignList",
				"/ContainsThingList",
				"/ContainsUrlList",
				"/ContainsUserList",
				"/ContainsFactorList",
				"/ContainsFactorAssertionList",
				"/ContainsDescriptorList",
				"/ContainsDescriptorTypeList",
				"/ContainsDirectorList",
				"/ContainsDirectorTypeList",
				"/ContainsDirectorActionList",
				"/ContainsEventorList",
				"/ContainsEventorTypeList",
				"/ContainsEventorPrecisionList",
				"/ContainsIdentorList",
				"/ContainsIdentorTypeList",
				"/ContainsLocatorList",
				"/ContainsLocatorTypeList",
				"/ContainsVectorList",
				"/ContainsVectorTypeList",
				"/ContainsVectorRangeList",
				"/ContainsVectorRangeLevelList",
				"/ContainsVectorUnitList",
				"/ContainsVectorUnitPrefixList",
				"/ContainsVectorUnitDerivedList",
				"/ContainsOauthAccessList",
				"/ContainsOauthDomainList",
				"/ContainsOauthGrantList",
				"/ContainsOauthScopeList"
			});

			map.Add("App", new string[] {
				"/HasArtifact",
				"/UsesEmail",
				"/InMemberListUses",
				"/InOauthAccessListUses",
				"/InOauthDomainListUses",
				"/InOauthGrantListUses",
				"/InOauthScopeListUses"
			});

			map.Add("Artifact", new string[] {
				"/InAppHas",
				"/UsesArtifactType",
				"/InCrowdHas",
				"/InLabelHas",
				"/InMemberCreates",
				"/InThingHas",
				"/InUrlHas",
				"/InUserHas",
				"/InFactorListUsesPrimary",
				"/InFactorListUsesRelated",
				"/InDescriptorListRefinesPrimaryWith",
				"/InDescriptorListRefinesRelatedWith",
				"/InDescriptorListRefinesTypeWith",
				"/InVectorListUsesAxis"
			});

			map.Add("ArtifactType", new string[] {
				"/InArtifactListUses"
			});

			map.Add("Crowd", new string[] {
				"/HasArtifact",
				"/InCrowdianListUses"
			});

			map.Add("Crowdian", new string[] {
				"/UsesCrowd",
				"/UsesUser",
				"/HasCrowdianTypeAssign",
				"/HasHistoricCrowdianTypeAssignList"
			});

			map.Add("CrowdianType", new string[] {
				"/InCrowdianTypeAssignListUses"
			});

			map.Add("CrowdianTypeAssign", new string[] {
				"/InCrowdianHas",
				"/InCrowdianHasHistoric",
				"/UsesCrowdianType",
				"/InUserCreates"
			});

			map.Add("Email", new string[] {
				"/InAppUses",
				"/InUserUses"
			});

			map.Add("Label", new string[] {
				"/HasArtifact"
			});

			map.Add("Member", new string[] {
				"/UsesApp",
				"/UsesUser",
				"/HasMemberTypeAssign",
				"/HasHistoricMemberTypeAssignList",
				"/CreatesArtifactList",
				"/CreatesMemberTypeAssignList",
				"/CreatesFactorList"
			});

			map.Add("MemberType", new string[] {
				"/InMemberTypeAssignListUses"
			});

			map.Add("MemberTypeAssign", new string[] {
				"/InMemberHas",
				"/InMemberHasHistoric",
				"/InMemberCreates",
				"/UsesMemberType"
			});

			map.Add("Thing", new string[] {
				"/HasArtifact"
			});

			map.Add("Url", new string[] {
				"/HasArtifact"
			});

			map.Add("User", new string[] {
				"/InCrowdianListUses",
				"/InMemberListUses",
				"/HasArtifact",
				"/UsesEmail",
				"/CreatesCrowdianTypeAssignList",
				"/InOauthAccessListUses",
				"/InOauthGrantListUses",
				"/InOauthScopeListUses"
			});

			map.Add("Factor", new string[] {
				"/InMemberCreates",
				"/UsesPrimaryArtifact",
				"/UsesRelatedArtifact",
				"/UsesFactorAssertion",
				"/ReplacesFactor",
				"/UsesDescriptor",
				"/UsesDirector",
				"/UsesEventor",
				"/UsesIdentor",
				"/UsesLocator",
				"/UsesVector"
			});

			map.Add("FactorAssertion", new string[] {
				"/InFactorListUses"
			});

			map.Add("Descriptor", new string[] {
				"/InFactorListUses",
				"/UsesDescriptorType",
				"/RefinesPrimaryWithArtifact",
				"/RefinesRelatedWithArtifact",
				"/RefinesTypeWithArtifact"
			});

			map.Add("DescriptorType", new string[] {
				"/InDescriptorListUses"
			});

			map.Add("Director", new string[] {
				"/InFactorListUses",
				"/UsesDirectorType",
				"/UsesPrimaryDirectorAction",
				"/UsesRelatedDirectorAction"
			});

			map.Add("DirectorType", new string[] {
				"/InDirectorListUses"
			});

			map.Add("DirectorAction", new string[] {
				"/InDirectorListUsesPrimary",
				"/InDirectorListUsesRelated"
			});

			map.Add("Eventor", new string[] {
				"/InFactorListUses",
				"/UsesEventorType",
				"/UsesEventorPrecision"
			});

			map.Add("EventorType", new string[] {
				"/InEventorListUses"
			});

			map.Add("EventorPrecision", new string[] {
				"/InEventorListUses"
			});

			map.Add("Identor", new string[] {
				"/InFactorListUses",
				"/UsesIdentorType"
			});

			map.Add("IdentorType", new string[] {
				"/InIdentorListUses"
			});

			map.Add("Locator", new string[] {
				"/InFactorListUses",
				"/UsesLocatorType"
			});

			map.Add("LocatorType", new string[] {
				"/InLocatorListUses"
			});

			map.Add("Vector", new string[] {
				"/InFactorListUses",
				"/UsesAxisArtifact",
				"/UsesVectorType",
				"/UsesVectorUnit",
				"/UsesVectorUnitPrefix"
			});

			map.Add("VectorType", new string[] {
				"/InVectorListUses",
				"/UsesVectorRange"
			});

			map.Add("VectorRange", new string[] {
				"/InVectorTypeListUses",
				"/UsesVectorRangeLevelList"
			});

			map.Add("VectorRangeLevel", new string[] {
				"/InVectorRangeListUses"
			});

			map.Add("VectorUnit", new string[] {
				"/InVectorListUses",
				"/InVectorUnitDerivedListDefines",
				"/InVectorUnitDerivedListRaisesToExp"
			});

			map.Add("VectorUnitPrefix", new string[] {
				"/InVectorListUses",
				"/InVectorUnitDerivedListUses"
			});

			map.Add("VectorUnitDerived", new string[] {
				"/DefinesVectorUnit",
				"/RaisesToExpVectorUnit",
				"/UsesVectorUnitPrefix"
			});

			map.Add("OauthAccess", new string[] {
				"/UsesApp",
				"/UsesUser"
			});

			map.Add("OauthDomain", new string[] {
				"/UsesApp"
			});

			map.Add("OauthGrant", new string[] {
				"/UsesApp",
				"/UsesUser"
			});

			map.Add("OauthScope", new string[] {
				"/UsesApp",
				"/UsesUser"
			});

			return map;
		}
	}
}