﻿// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 12/17/2012 4:53:37 PM

using System.Collections.Generic;

namespace Fabric.Test.Util {
	
	/*================================================================================================*/
	public static class StepUtil {

		public static Dictionary<string, string[]> NodeStepMap = BuildNodeStepMap();
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static Dictionary<string, string[]> BuildNodeStepMap() {
			var map = new Dictionary<string, string[]>();

			map.Add("Root", new [] {
				"/ContainsAppList",
				"/ContainsArtifactList",
				"/ContainsArtifactTypeList",
				"/ContainsCrowdList",
				"/ContainsCrowdianList",
				"/ContainsCrowdianTypeList",
				"/ContainsCrowdianTypeAssignList",
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
				"/ContainsVectorUnitDerivedList"
			});

			map.Add("App", new [] {
				"/HasArtifact",
				"/DefinesMemberList"
			});

			map.Add("Artifact", new [] {
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

			map.Add("ArtifactType", new [] {
				"/InArtifactListUses"
			});

			map.Add("Crowd", new [] {
				"/HasArtifact",
				"/DefinesCrowdianList"
			});

			map.Add("Crowdian", new [] {
				"/InCrowdDefines",
				"/HasCrowdianTypeAssign",
				"/HasHistoricCrowdianTypeAssignList",
				"/InUserDefines"
			});

			map.Add("CrowdianType", new [] {
				"/InCrowdianTypeAssignListUses"
			});

			map.Add("CrowdianTypeAssign", new [] {
				"/InCrowdianHas",
				"/InCrowdianHasHistoric",
				"/UsesCrowdianType",
				"/InUserCreates"
			});

			map.Add("Label", new [] {
				"/HasArtifact"
			});

			map.Add("Member", new [] {
				"/InAppDefines",
				"/HasMemberTypeAssign",
				"/HasHistoricMemberTypeAssignList",
				"/CreatesArtifactList",
				"/CreatesMemberTypeAssignList",
				"/CreatesFactorList",
				"/InUserDefines"
			});

			map.Add("MemberType", new [] {
				"/InMemberTypeAssignListUses"
			});

			map.Add("MemberTypeAssign", new [] {
				"/InMemberHas",
				"/InMemberHasHistoric",
				"/InMemberCreates",
				"/UsesMemberType"
			});

			map.Add("Thing", new [] {
				"/HasArtifact"
			});

			map.Add("Url", new [] {
				"/HasArtifact"
			});

			map.Add("User", new [] {
				"/HasArtifact",
				"/CreatesCrowdianTypeAssignList",
				"/DefinesCrowdianList",
				"/DefinesMemberList"
			});

			map.Add("Factor", new [] {
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

			map.Add("FactorAssertion", new [] {
				"/InFactorListUses"
			});

			map.Add("Descriptor", new [] {
				"/InFactorListUses",
				"/UsesDescriptorType",
				"/RefinesPrimaryWithArtifact",
				"/RefinesRelatedWithArtifact",
				"/RefinesTypeWithArtifact"
			});

			map.Add("DescriptorType", new [] {
				"/InDescriptorListUses"
			});

			map.Add("Director", new [] {
				"/InFactorListUses",
				"/UsesDirectorType",
				"/UsesPrimaryDirectorAction",
				"/UsesRelatedDirectorAction"
			});

			map.Add("DirectorType", new [] {
				"/InDirectorListUses"
			});

			map.Add("DirectorAction", new [] {
				"/InDirectorListUsesPrimary",
				"/InDirectorListUsesRelated"
			});

			map.Add("Eventor", new [] {
				"/InFactorListUses",
				"/UsesEventorType",
				"/UsesEventorPrecision"
			});

			map.Add("EventorType", new [] {
				"/InEventorListUses"
			});

			map.Add("EventorPrecision", new [] {
				"/InEventorListUses"
			});

			map.Add("Identor", new [] {
				"/InFactorListUses",
				"/UsesIdentorType"
			});

			map.Add("IdentorType", new [] {
				"/InIdentorListUses"
			});

			map.Add("Locator", new [] {
				"/InFactorListUses",
				"/UsesLocatorType"
			});

			map.Add("LocatorType", new [] {
				"/InLocatorListUses"
			});

			map.Add("Vector", new [] {
				"/InFactorListUses",
				"/UsesAxisArtifact",
				"/UsesVectorType",
				"/UsesVectorUnit",
				"/UsesVectorUnitPrefix"
			});

			map.Add("VectorType", new [] {
				"/InVectorListUses",
				"/UsesVectorRange"
			});

			map.Add("VectorRange", new [] {
				"/InVectorTypeListUses",
				"/UsesVectorRangeLevelList"
			});

			map.Add("VectorRangeLevel", new [] {
				"/InVectorRangeListUses"
			});

			map.Add("VectorUnit", new [] {
				"/InVectorListUses",
				"/InVectorUnitDerivedListDefines",
				"/InVectorUnitDerivedListRaisesToExp"
			});

			map.Add("VectorUnitPrefix", new [] {
				"/InVectorListUses",
				"/InVectorUnitDerivedListUses"
			});

			map.Add("VectorUnitDerived", new [] {
				"/DefinesVectorUnit",
				"/RaisesToExpVectorUnit",
				"/UsesVectorUnitPrefix"
			});

			return map;
		}
		
	}

}