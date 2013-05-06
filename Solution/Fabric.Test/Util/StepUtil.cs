// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 5/5/2013 9:20:44 PM

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
			TestStep("Artifact", PropDbName.Artifact_ArtifactId, tn => new ArtifactStep(tn));
		}*/

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void AppStep() {
			TestStep("App", PropDbName.App_AppId, tn => new AppStep(tn));
		}*/

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void ClassStep() {
			TestStep("Class", PropDbName.Class_ClassId, tn => new ClassStep(tn));
		}*/

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void InstanceStep() {
			TestStep("Instance", PropDbName.Instance_InstanceId, tn => new InstanceStep(tn));
		}*/

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void MemberStep() {
			TestStep("Member", PropDbName.Member_MemberId, tn => new MemberStep(tn));
		}*/

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void MemberTypeAssignStep() {
			TestStep("MemberTypeAssign", PropDbName.MemberTypeAssign_MemberTypeAssignId, tn => new MemberTypeAssignStep(tn));
		}*/

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void UrlStep() {
			TestStep("Url", PropDbName.Url_UrlId, tn => new UrlStep(tn));
		}*/

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void UserStep() {
			TestStep("User", PropDbName.User_UserId, tn => new UserStep(tn));
		}*/

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void FactorStep() {
			TestStep("Factor", PropDbName.Factor_FactorId, tn => new FactorStep(tn));
		}*/

	}

}