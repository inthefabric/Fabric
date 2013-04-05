using Fabric.Api.Dto;
using Fabric.Api.Traversal;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Db;
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
		public void ContainsAppList() {
			vUri = "/ContainsAppList";
			TestPath();
			CheckSuccess<App>(SetupUsers.NumApps);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ActiveApp() {
			ApiCtx.SetAppUserId((long)SetupUsers.AppId.KinPhoGal, null);
			vUri = "/ActiveApp";
			TestPath();
			CheckSuccess<App>(1);
			CheckTypeId<App>(vModel.DtoList[0], ApiCtx.AppId);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ActiveUser() {
			ApiCtx.SetAppUserId(null, (long)SetupUsers.UserId.Zach);
			vUri = "/ActiveUser";
			TestPath();
			CheckSuccess<User>(1);
			CheckTypeId<User>(vModel.DtoList[0], ApiCtx.UserId);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ActiveMember() {
			ApiCtx.SetAppUserId((long)SetupUsers.AppId.KinPhoGal, (long)SetupUsers.UserId.Zach);
			vUri = "/ActiveMember";
			TestPath();
			CheckSuccess<Member>(1);
			CheckTypeId<Member>(vModel.DtoList[0], (long)SetupUsers.MemberId.GalZach);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FactorsWithMelAsPrimary() {
			vUri = "/ContainsFactorList/As(F)/UsesPrimaryArtifact/WhereId("+
				(long)SetupUsers.UserId.Mel+")/Back(F)";
			TestPath();
			CheckSuccess<Factor>(10);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FactorsWithMelAsPrimaryCreatedByMel() {
			vUri = "/ContainsFactorList/As(F)/UsesPrimaryArtifact/WhereId("+
				(long)SetupUsers.UserId.Mel+")/Back(F)/InMemberCreates/InUserDefines/WhereId("+
				(long)SetupUsers.UserId.Mel+")/Back(F)";
			TestPath();
			CheckSuccess<Factor>(9);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0, 4)]
		[TestCase(10, 50)]
		[TestCase(20, 32)]
		[TestCase(99, 1)]
		public void Limit(int pStart, int pCount) {
			vUri = "/ContainsFactorList/Limit("+pStart+","+pCount+")";
			TestPath();
			CheckSuccess<Factor>(pCount);
			CheckTypeId<Factor>(vModel.DtoList[0], pStart+1);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void CheckSuccess<T>(int pDtoCount) where T : INode {
			Assert.Null(vModel.Resp.Error, "Model.Resp.Error should be null.");
			Assert.NotNull(vModel.DtoList, "Model.DtoList should be filled.");
			Assert.NotNull(vModel.Resp.Functions, "Model.Resp.Functions should be filled.");
			Assert.NotNull(vModel.Resp.Links, "Model.Resp.Links should be filled.");

			Assert.AreEqual(pDtoCount, vModel.DtoList.Count, "Incorrect Model.DtoList count.");

			foreach ( IDbDto dbDto in vModel.DtoList ) {
				Assert.AreEqual(typeof(T).Name, dbDto.Class, "Incorrect DbDto.Class.");
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void CheckTypeId<T>(IDbDto pDbDto, long pId) where T : INode {
			string key = typeof(T).Name+"Id";
			Assert.True(pDbDto.Data.ContainsKey(key), "DbDto does not contain key '"+key+"'.");

			string val = pDbDto.Data[key];
			long valId = long.Parse(val);
			Assert.AreEqual(pId, valId, "Incorrect DbDto.Data['"+key+"'].");
		}

	}

}