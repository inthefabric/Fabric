// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/8/2013 1:22:15 PM

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

			map.Add("MemberTypeAssign", new string [] {
				"/InMemberHas",
				"/InMemberHasHistoric",
				"/InMemberCreates",
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
				"/ReplacesFactor",
				"/UsesDescriptor",
				"/UsesDirector",
				"/UsesEventor",
				"/UsesIdentor",
				"/UsesLocator",
				"/UsesVector",
			});

			map.Add("Descriptor", new string [] {
				"/InFactorListUses",
				"/RefinesPrimaryWithArtifact",
				"/RefinesRelatedWithArtifact",
				"/RefinesTypeWithArtifact",
			});

			map.Add("Director", new string [] {
				"/InFactorListUses",
			});

			map.Add("Eventor", new string [] {
				"/InFactorListUses",
			});

			map.Add("Identor", new string [] {
				"/InFactorListUses",
			});

			map.Add("Locator", new string [] {
				"/InFactorListUses",
			});

			map.Add("Vector", new string [] {
				"/InFactorListUses",
				"/UsesAxisArtifact",
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
		public void DescriptorStep() {
			TestStep("Descriptor", (tn, p) => new DescriptorStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void DirectorStep() {
			TestStep("Director", (tn, p) => new DirectorStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void EventorStep() {
			TestStep("Eventor", (tn, p) => new EventorStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void IdentorStep() {
			TestStep("Identor", (tn, p) => new IdentorStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void LocatorStep() {
			TestStep("Locator", (tn, p) => new LocatorStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void VectorStep() {
			TestStep("Vector", (tn, p) => new VectorStep(tn, p));
		}

		*/
	}

}