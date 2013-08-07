using Fabric.Api.Dto;
using Fabric.Api.Traversal;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Weaver;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiTraversal {

	/*================================================================================================*/
	[TestFixture]
	public class XPathRouter : IntegTestBase {

		private FabResponse vResp;
		private string vUri;

		private TraversalModel vModel;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;

			vResp = new FabResponse();
			vUri = "";
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void TestPath() {
			TraversalBuilder tb = new TraversalBuilder(ApiCtx, vResp, vUri);
			vModel = tb.BuildModel();
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Root() {
			vUri = "/";
			TestPath();
			Assert.Null(vModel.Resp.Error, "Model.Resp.Error should be null.");
			Assert.Null(vModel.DtoList, "Model.DtoList should be null.");
			Assert.NotNull(vModel.Resp.Functions, "Model.Resp.Functions should be filled.");
			Assert.NotNull(vModel.Resp.Links, "Model.Resp.Links should be filled.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void IdIndex() {
			vUri = "/AppId("+(long)SetupArtifacts.ArtifactId.App_KinPhoGal+")";
			TestPath();
			CheckSuccess<App>(1);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExactIndex() {
			vUri = "/UserName(zachKINSTNER)";
			TestPath();
			CheckSuccess<User>(1);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("kinstner")]
		[TestCase("kinstner PHOTO gallery")]
		public void ElasticIndexAppContains(string pValue) {
			vUri = "/AppNameContains("+pValue+")";
			TestPath();
			CheckSuccess<App>(1);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("f-stop")]
		[TestCase("f stop")]
		public void ElasticIndexClassContains(string pValue) {
			vUri = "/ClassNameContains("+pValue+")";
			TestPath();
			CheckSuccess<Class>(1);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("gt", 500, 20)]
		[TestCase("lt", 500, 0)]
		public void ElasticIndexArtifactHas(string pOperator, long pValue, int pExpect) {
			vUri = "/ArtifactCreated("+pOperator+","+pValue+")";
			TestPath();

			Assert.Null(vModel.Resp.Error, "Model.Resp.Error should be null.");
			Assert.NotNull(vModel.DtoList, "Model.DtoList should be filled.");
			Assert.NotNull(vModel.Resp.Functions, "Model.Resp.Functions should be filled.");
			Assert.NotNull(vModel.Resp.Links, "Model.Resp.Links should be filled.");

			Assert.AreEqual(pExpect, vModel.DtoList.Count, "Incorrect Model.DtoList count.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ActiveApp() {
			ApiCtx.SetAppUserId((long)SetupUsers.AppId.KinPhoGal, null);
			vUri = "/ActiveApp";
			TestPath();
			CheckSuccess<App>(1);
			CheckTypeId(vModel.DtoList[0], PropDbName.Artifact_ArtifactId, ApiCtx.AppId);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ActiveUser() {
			ApiCtx.SetAppUserId(null, (long)SetupUsers.UserId.Zach);
			vUri = "/ActiveUser";
			TestPath();
			CheckSuccess<User>(1);
			CheckTypeId(vModel.DtoList[0], PropDbName.Artifact_ArtifactId, ApiCtx.UserId);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ActiveMember() {
			ApiCtx.SetAppUserId((long)SetupUsers.AppId.KinPhoGal, (long)SetupUsers.UserId.Zach);
			vUri = "/ActiveMember";
			TestPath();
			CheckSuccess<Member>(1);
			CheckTypeId(vModel.DtoList[0],
				PropDbName.Member_MemberId, (long)SetupUsers.MemberId.GalZach);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FactorsWithMelAsPrimary() {
			vUri = "/UserId("+(long)SetupArtifacts.ArtifactId.User_Mel+")/InFactorListUsesPrimary";
			TestPath();
			CheckSuccess<Factor>(10);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FactorsWithMelAsPrimaryCreatedByMel() {
			vUri = "/UserId("+(long)SetupArtifacts.ArtifactId.User_Mel+")/InFactorListUsesPrimary/"+
				"As(F)/InMemberCreates/InUserDefines/HasId(4)/Back(F)";
			TestPath();
			CheckSuccess<Factor>(9);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0, 4)]
		[TestCase(3, 50)]
		[TestCase(0, 50)]
		[TestCase(20, 32)]
		[TestCase(52, 1)]
		public void Limit(int pStart, int pCount) {
			vUri = "/AppId("+(long)SetupArtifacts.ArtifactId.App_FabSys+")/DefinesMemberList/"+
				"CreatesFactorList/Limit("+pStart+","+pCount+")";

			TestPath();
			CheckSuccess<Factor>(pCount);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void CheckSuccess<T>(int pDtoCount) where T : IVertex {
			Assert.Null(vModel.Resp.Error, "Model.Resp.Error should be null.");
			Assert.NotNull(vModel.DtoList, "Model.DtoList should be filled.");
			Assert.NotNull(vModel.Resp.Functions, "Model.Resp.Functions should be filled.");
			Assert.NotNull(vModel.Resp.Links, "Model.Resp.Links should be filled.");

			Assert.AreEqual(pDtoCount, vModel.DtoList.Count, "Incorrect Model.DtoList count.");

			foreach ( IDataDto dto in vModel.DtoList ) {
				Assert.AreEqual(typeof(T).Name, dto.Class, "Incorrect DbDto.Class.");
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void CheckTypeId(IDataDto pDto, string pIdProp, long pId) {
			Assert.True(pDto.Properties.ContainsKey(pIdProp),
				"DbDto does not contain key '"+pIdProp+"'.");

			string val = pDto.Properties[pIdProp];
			long valId = long.Parse(val);
			Assert.AreEqual(pId, valId, "Incorrect DbDto.Data['"+pIdProp+"'].");
		}

	}

}