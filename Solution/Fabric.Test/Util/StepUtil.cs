// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/10/2013 12:55:30 PM

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
				"/InFactorListDescriptorRefinesPrimaryWith",
				"/InFactorListDescriptorRefinesRelatedWith",
				"/InFactorListDescriptorRefinesTypeWith",
				"/InFactorListVectorUsesAxis",
			});

			map.Add("App", new string [] {
				"/InMemberCreates",
				"/InFactorListUsesPrimary",
				"/InFactorListUsesRelated",
				"/InFactorListDescriptorRefinesPrimaryWith",
				"/InFactorListDescriptorRefinesRelatedWith",
				"/InFactorListDescriptorRefinesTypeWith",
				"/InFactorListVectorUsesAxis",
				"/DefinesMemberList",
			});

			map.Add("Class", new string [] {
				"/InMemberCreates",
				"/InFactorListUsesPrimary",
				"/InFactorListUsesRelated",
				"/InFactorListDescriptorRefinesPrimaryWith",
				"/InFactorListDescriptorRefinesRelatedWith",
				"/InFactorListDescriptorRefinesTypeWith",
				"/InFactorListVectorUsesAxis",
			});

			map.Add("Instance", new string [] {
				"/InMemberCreates",
				"/InFactorListUsesPrimary",
				"/InFactorListUsesRelated",
				"/InFactorListDescriptorRefinesPrimaryWith",
				"/InFactorListDescriptorRefinesRelatedWith",
				"/InFactorListDescriptorRefinesTypeWith",
				"/InFactorListVectorUsesAxis",
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
				"/InFactorListDescriptorRefinesPrimaryWith",
				"/InFactorListDescriptorRefinesRelatedWith",
				"/InFactorListDescriptorRefinesTypeWith",
				"/InFactorListVectorUsesAxis",
			});

			map.Add("User", new string [] {
				"/InMemberCreates",
				"/InFactorListUsesPrimary",
				"/InFactorListUsesRelated",
				"/InFactorListDescriptorRefinesPrimaryWith",
				"/InFactorListDescriptorRefinesRelatedWith",
				"/InFactorListDescriptorRefinesTypeWith",
				"/InFactorListVectorUsesAxis",
				"/DefinesMemberList",
			});

			map.Add("Factor", new string [] {
				"/InMemberCreates",
				"/UsesPrimaryArtifact",
				"/UsesRelatedArtifact",
				"/DescriptorRefinesPrimaryWithArtifact",
				"/DescriptorRefinesRelatedWithArtifact",
				"/DescriptorRefinesTypeWithArtifact",
				"/VectorUsesAxisArtifact",
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

		*/
	}

}