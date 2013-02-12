using Fabric.Api.Oauth.Tasks;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetDataProv {

		private readonly static string QueryGetUser =
			"g.V('"+typeof(User).Name+"Id',{{UserId}}L)[0]"+
				".as('step1')"+
			".outE('"+typeof(UserDefinesMember).Name+"').inV"+
				".as('step4')"+
			".inE('"+typeof(AppDefinesMember).Name+"').outV"+
				".has('"+typeof(App).Name+"Id',Tokens.T.eq,{{AppId}}L)"+
			".back('step4')"+
			".outE('"+typeof(MemberHasMemberTypeAssign).Name+"').inV"+
			".outE('"+typeof(MemberTypeAssignUsesMemberType).Name+"').inV"+
				".has('"+typeof(MemberType).Name+"Id',Tokens.T.eq,{{MemberTypeId}}L)"+
			".back('step1');";

		private long vAppId;
		private long vDataProvUserId;
		private Mock<IApiContext> vMockCtx;
		private User vGetUserResult;
		private UsageMap vUsageMap;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vAppId = 23525;
			vDataProvUserId = 3875;
			vUsageMap = new UsageMap();

			vGetUserResult = new User();

			vMockCtx = new Mock<IApiContext>();

			vMockCtx
				.Setup(x => x.DbSingle<User>(
					GetDataProv.Query.GetUser+"", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetUser(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private User TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().GetDataProv(vAppId, vDataProvUserId, vMockCtx.Object);
			}

			var task = new GetDataProv(vAppId, vDataProvUserId);
			return task.Go(vMockCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private User GetUser(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			vUsageMap.Increment(GetDataProv.Query.GetUser+"");
			string expect = QueryGetUser
				.Replace("{{AppId}}", vAppId+"")
				.Replace("{{UserId}}", vDataProvUserId+"")
				.Replace("{{MemberTypeId}}", ((long)MemberTypeId.DataProvider)+"");

			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");

			return vGetUserResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pViaTask) {
			User result = TestGo(pViaTask);

			vUsageMap.AssertUses(GetDataProv.Query.GetUser+"", 1);
			Assert.AreEqual(vGetUserResult, result, "Incorrect Result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrInvalidAppId() {
			vAppId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrInvalidDataProvUserId() {
			vDataProvUserId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

	}

}