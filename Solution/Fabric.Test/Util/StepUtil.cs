// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/4/2013 5:12:45 PM

using System.Collections.Generic;

namespace Fabric.Test.Util {
	
	/*================================================================================================*/
	public static class StepUtil {

		public static Dictionary<string, string[]> NodeStepMap = BuildNodeStepMap();
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static Dictionary<string, string[]> BuildNodeStepMap() {
			var map = new Dictionary<string, string[]>();
			
			map.Add("Artifact", new string [] {
				"/InMemberCreates",
				"/InFactorListUsesPrimary",
				"/InFactorListUsesRelated",
				"/InDescriptorListRefinesPrimaryWith",
				"/InDescriptorListRefinesRelatedWith",
				"/InDescriptorListRefinesTypeWith",
				"/InVectorListUsesAxis",
			});

			map.Add("App", new string [] {
				"/InMemberCreates",
				"/InFactorListUsesPrimary",
				"/InFactorListUsesRelated",
				"/InDescriptorListRefinesPrimaryWith",
				"/InDescriptorListRefinesRelatedWith",
				"/InDescriptorListRefinesTypeWith",
				"/InVectorListUsesAxis",
				"/DefinesMemberList",
			});

			map.Add("Class", new string [] {
				"/InMemberCreates",
				"/InFactorListUsesPrimary",
				"/InFactorListUsesRelated",
				"/InDescriptorListRefinesPrimaryWith",
				"/InDescriptorListRefinesRelatedWith",
				"/InDescriptorListRefinesTypeWith",
				"/InVectorListUsesAxis",
			});

			map.Add("Instance", new string [] {
				"/InMemberCreates",
				"/InFactorListUsesPrimary",
				"/InFactorListUsesRelated",
				"/InDescriptorListRefinesPrimaryWith",
				"/InDescriptorListRefinesRelatedWith",
				"/InDescriptorListRefinesTypeWith",
				"/InVectorListUsesAxis",
			});

			map.Add("Member", new string [] {
				"/InAppDefines",
				"/HasMemberTypeAssign",
				"/HasHistoricMemberTypeAssignList",
				"/CreatesArtifactList",
				"/CreatesMemberTypeAssignList",
				"/CreatesFactorList",
				"/InUserDefines",
			});

			map.Add("MemberType", new string [] {
				"/InMemberTypeAssignListUses",
			});

			map.Add("MemberTypeAssign", new string [] {
				"/InMemberHas",
				"/InMemberHasHistoric",
				"/InMemberCreates",
				"/UsesMemberType",
			});

			map.Add("Url", new string [] {
				"/InMemberCreates",
				"/InFactorListUsesPrimary",
				"/InFactorListUsesRelated",
				"/InDescriptorListRefinesPrimaryWith",
				"/InDescriptorListRefinesRelatedWith",
				"/InDescriptorListRefinesTypeWith",
				"/InVectorListUsesAxis",
			});

			map.Add("User", new string [] {
				"/InMemberCreates",
				"/InFactorListUsesPrimary",
				"/InFactorListUsesRelated",
				"/InDescriptorListRefinesPrimaryWith",
				"/InDescriptorListRefinesRelatedWith",
				"/InDescriptorListRefinesTypeWith",
				"/InVectorListUsesAxis",
				"/DefinesMemberList",
			});

			map.Add("Factor", new string [] {
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

			map.Add("FactorAssertion", new string [] {
				"/InFactorListUses",
			});

			map.Add("Descriptor", new string [] {
				"/InFactorListUses",
				"/UsesDescriptorType",
				"/RefinesPrimaryWithArtifact",
				"/RefinesRelatedWithArtifact",
				"/RefinesTypeWithArtifact",
			});

			map.Add("DescriptorType", new string [] {
				"/InDescriptorListUses",
			});

			map.Add("Director", new string [] {
				"/InFactorListUses",
				"/UsesDirectorType",
				"/UsesPrimaryDirectorAction",
				"/UsesRelatedDirectorAction",
			});

			map.Add("DirectorType", new string [] {
				"/InDirectorListUses",
			});

			map.Add("DirectorAction", new string [] {
				"/InDirectorListUsesPrimary",
				"/InDirectorListUsesRelated",
			});

			map.Add("Eventor", new string [] {
				"/InFactorListUses",
				"/UsesEventorType",
				"/UsesEventorPrecision",
			});

			map.Add("EventorType", new string [] {
				"/InEventorListUses",
			});

			map.Add("EventorPrecision", new string [] {
				"/InEventorListUses",
			});

			map.Add("Identor", new string [] {
				"/InFactorListUses",
				"/UsesIdentorType",
			});

			map.Add("IdentorType", new string [] {
				"/InIdentorListUses",
			});

			map.Add("Locator", new string [] {
				"/InFactorListUses",
				"/UsesLocatorType",
			});

			map.Add("LocatorType", new string [] {
				"/InLocatorListUses",
			});

			map.Add("Vector", new string [] {
				"/InFactorListUses",
				"/UsesAxisArtifact",
				"/UsesVectorType",
				"/UsesVectorUnit",
				"/UsesVectorUnitPrefix",
			});

			map.Add("VectorType", new string [] {
				"/InVectorListUses",
				"/UsesVectorRange",
			});

			map.Add("VectorRange", new string [] {
				"/InVectorTypeListUses",
				"/UsesVectorRangeLevelList",
			});

			map.Add("VectorRangeLevel", new string [] {
				"/InVectorRangeListUses",
			});

			map.Add("VectorUnit", new string [] {
				"/InVectorListUses",
				"/InVectorUnitDerivedListDefines",
				"/InVectorUnitDerivedListRaisesToExp",
			});

			map.Add("VectorUnitPrefix", new string [] {
				"/InVectorListUses",
				"/InVectorUnitDerivedListUses",
			});

			map.Add("VectorUnitDerived", new string [] {
				"/DefinesVectorUnit",
				"/RaisesToExpVectorUnit",
				"/UsesVectorUnitPrefix",
			});

			return map;
		}
		
		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void ArtifactStep() {
			TestStep("Artifact", (tn, p) => new ArtifactStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void AppStep() {
			TestStep("App", (tn, p) => new AppStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void ClassStep() {
			TestStep("Class", (tn, p) => new ClassStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void InstanceStep() {
			TestStep("Instance", (tn, p) => new InstanceStep(tn, p));
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