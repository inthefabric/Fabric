// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 1/25/2013 1:38:46 PM

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
			});

			map.Add("App", new [] {
				"/HasArtifact",
				"/DefinesMemberList",
			});

			map.Add("Artifact", new [] {
				"/InAppHas",
				"/UsesArtifactType",
				"/InMemberCreates",
				"/InThingHas",
				"/InUrlHas",
				"/InUserHas",
				"/InFactorListUsesPrimary",
				"/InFactorListUsesRelated",
				"/InDescriptorListRefinesPrimaryWith",
				"/InDescriptorListRefinesRelatedWith",
				"/InDescriptorListRefinesTypeWith",
				"/InVectorListUsesAxis",
			});

			map.Add("ArtifactType", new [] {
				"/InArtifactListUses",
			});

			map.Add("Member", new [] {
				"/InAppDefines",
				"/HasMemberTypeAssign",
				"/HasHistoricMemberTypeAssignList",
				"/CreatesArtifactList",
				"/CreatesMemberTypeAssignList",
				"/CreatesFactorList",
				"/InUserDefines",
			});

			map.Add("MemberType", new [] {
				"/InMemberTypeAssignListUses",
			});

			map.Add("MemberTypeAssign", new [] {
				"/InMemberHas",
				"/InMemberHasHistoric",
				"/InMemberCreates",
				"/UsesMemberType",
			});

			map.Add("Thing", new [] {
				"/HasArtifact",
			});

			map.Add("Url", new [] {
				"/HasArtifact",
			});

			map.Add("User", new [] {
				"/HasArtifact",
				"/DefinesMemberList",
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
				"/UsesVector",
			});

			map.Add("FactorAssertion", new [] {
				"/InFactorListUses",
			});

			map.Add("Descriptor", new [] {
				"/InFactorListUses",
				"/UsesDescriptorType",
				"/RefinesPrimaryWithArtifact",
				"/RefinesRelatedWithArtifact",
				"/RefinesTypeWithArtifact",
			});

			map.Add("DescriptorType", new [] {
				"/InDescriptorListUses",
			});

			map.Add("Director", new [] {
				"/InFactorListUses",
				"/UsesDirectorType",
				"/UsesPrimaryDirectorAction",
				"/UsesRelatedDirectorAction",
			});

			map.Add("DirectorType", new [] {
				"/InDirectorListUses",
			});

			map.Add("DirectorAction", new [] {
				"/InDirectorListUsesPrimary",
				"/InDirectorListUsesRelated",
			});

			map.Add("Eventor", new [] {
				"/InFactorListUses",
				"/UsesEventorType",
				"/UsesEventorPrecision",
			});

			map.Add("EventorType", new [] {
				"/InEventorListUses",
			});

			map.Add("EventorPrecision", new [] {
				"/InEventorListUses",
			});

			map.Add("Identor", new [] {
				"/InFactorListUses",
				"/UsesIdentorType",
			});

			map.Add("IdentorType", new [] {
				"/InIdentorListUses",
			});

			map.Add("Locator", new [] {
				"/InFactorListUses",
				"/UsesLocatorType",
			});

			map.Add("LocatorType", new [] {
				"/InLocatorListUses",
			});

			map.Add("Vector", new [] {
				"/InFactorListUses",
				"/UsesAxisArtifact",
				"/UsesVectorType",
				"/UsesVectorUnit",
				"/UsesVectorUnitPrefix",
			});

			map.Add("VectorType", new [] {
				"/InVectorListUses",
				"/UsesVectorRange",
			});

			map.Add("VectorRange", new [] {
				"/InVectorTypeListUses",
				"/UsesVectorRangeLevelList",
			});

			map.Add("VectorRangeLevel", new [] {
				"/InVectorRangeListUses",
			});

			map.Add("VectorUnit", new [] {
				"/InVectorListUses",
				"/InVectorUnitDerivedListDefines",
				"/InVectorUnitDerivedListRaisesToExp",
			});

			map.Add("VectorUnitPrefix", new [] {
				"/InVectorListUses",
				"/InVectorUnitDerivedListUses",
			});

			map.Add("VectorUnitDerived", new [] {
				"/DefinesVectorUnit",
				"/RaisesToExpVectorUnit",
				"/UsesVectorUnitPrefix",
			});

			return map;
		}
		
		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void RootStep() {
			TestStep("Root", (tn, p) => new RootStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void AppStep() {
			TestStep("App", (tn, p) => new AppStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void ArtifactStep() {
			TestStep("Artifact", (tn, p) => new ArtifactStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void ArtifactTypeStep() {
			TestStep("ArtifactType", (tn, p) => new ArtifactTypeStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void MemberStep() {
			TestStep("Member", (tn, p) => new MemberStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void MemberTypeStep() {
			TestStep("MemberType", (tn, p) => new MemberTypeStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void MemberTypeAssignStep() {
			TestStep("MemberTypeAssign", (tn, p) => new MemberTypeAssignStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void ThingStep() {
			TestStep("Thing", (tn, p) => new ThingStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void UrlStep() {
			TestStep("Url", (tn, p) => new UrlStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void UserStep() {
			TestStep("User", (tn, p) => new UserStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void FactorStep() {
			TestStep("Factor", (tn, p) => new FactorStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void FactorAssertionStep() {
			TestStep("FactorAssertion", (tn, p) => new FactorAssertionStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void DescriptorStep() {
			TestStep("Descriptor", (tn, p) => new DescriptorStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void DescriptorTypeStep() {
			TestStep("DescriptorType", (tn, p) => new DescriptorTypeStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void DirectorStep() {
			TestStep("Director", (tn, p) => new DirectorStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void DirectorTypeStep() {
			TestStep("DirectorType", (tn, p) => new DirectorTypeStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void DirectorActionStep() {
			TestStep("DirectorAction", (tn, p) => new DirectorActionStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void EventorStep() {
			TestStep("Eventor", (tn, p) => new EventorStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void EventorTypeStep() {
			TestStep("EventorType", (tn, p) => new EventorTypeStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void EventorPrecisionStep() {
			TestStep("EventorPrecision", (tn, p) => new EventorPrecisionStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void IdentorStep() {
			TestStep("Identor", (tn, p) => new IdentorStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void IdentorTypeStep() {
			TestStep("IdentorType", (tn, p) => new IdentorTypeStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void LocatorStep() {
			TestStep("Locator", (tn, p) => new LocatorStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void LocatorTypeStep() {
			TestStep("LocatorType", (tn, p) => new LocatorTypeStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void VectorStep() {
			TestStep("Vector", (tn, p) => new VectorStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void VectorTypeStep() {
			TestStep("VectorType", (tn, p) => new VectorTypeStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void VectorRangeStep() {
			TestStep("VectorRange", (tn, p) => new VectorRangeStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void VectorRangeLevelStep() {
			TestStep("VectorRangeLevel", (tn, p) => new VectorRangeLevelStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void VectorUnitStep() {
			TestStep("VectorUnit", (tn, p) => new VectorUnitStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void VectorUnitPrefixStep() {
			TestStep("VectorUnitPrefix", (tn, p) => new VectorUnitPrefixStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void VectorUnitDerivedStep() {
			TestStep("VectorUnitDerived", (tn, p) => new VectorUnitDerivedStep(tn, p));
		}

		*/
	}

}