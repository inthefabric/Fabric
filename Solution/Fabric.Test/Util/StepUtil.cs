// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/8/2013 2:54:23 PM

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
				"/InFactorListRefinesPrimaryWith",
				"/InFactorListRefinesRelatedWith",
				"/InFactorListRefinesTypeWith",
				"/InFactorListUsesAxis",
			});

			map.Add("App", new string [] {
				"/InMemberCreates",
				"/InFactorListUsesPrimary",
				"/InFactorListUsesRelated",
				"/InFactorListRefinesPrimaryWith",
				"/InFactorListRefinesRelatedWith",
				"/InFactorListRefinesTypeWith",
				"/InFactorListUsesAxis",
				"/DefinesMemberList",
			});

			map.Add("Class", new string [] {
				"/InMemberCreates",
				"/InFactorListUsesPrimary",
				"/InFactorListUsesRelated",
				"/InFactorListRefinesPrimaryWith",
				"/InFactorListRefinesRelatedWith",
				"/InFactorListRefinesTypeWith",
				"/InFactorListUsesAxis",
			});

			map.Add("Instance", new string [] {
				"/InMemberCreates",
				"/InFactorListUsesPrimary",
				"/InFactorListUsesRelated",
				"/InFactorListRefinesPrimaryWith",
				"/InFactorListRefinesRelatedWith",
				"/InFactorListRefinesTypeWith",
				"/InFactorListUsesAxis",
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
				"/InFactorListRefinesPrimaryWith",
				"/InFactorListRefinesRelatedWith",
				"/InFactorListRefinesTypeWith",
				"/InFactorListUsesAxis",
			});

			map.Add("User", new string [] {
				"/InMemberCreates",
				"/InFactorListUsesPrimary",
				"/InFactorListUsesRelated",
				"/InFactorListRefinesPrimaryWith",
				"/InFactorListRefinesRelatedWith",
				"/InFactorListRefinesTypeWith",
				"/InFactorListUsesAxis",
				"/DefinesMemberList",
			});

			map.Add("Factor", new string [] {
				"/InMemberCreates",
				"/UsesPrimaryArtifact",
				"/UsesRelatedArtifact",
				"/ReplacesFactor",
				"/RefinesPrimaryWithArtifact",
				"/RefinesRelatedWithArtifact",
				"/RefinesTypeWithArtifact",
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

		*/
	}

}