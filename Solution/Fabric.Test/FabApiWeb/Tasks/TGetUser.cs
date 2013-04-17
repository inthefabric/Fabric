using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetUser : TWebTasks {

		private const string Query =
			"g.V('"+PropDbName.User_UserId+"',_P0);";

		private long vUserId;
		private User vUserResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vUserId = 3456;
			vUserResult = new User();

			MockApiCtx
				.Setup(x => x.DbSingle<User>("GetUser", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetUser(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private User GetUser(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("GetUser");

			Assert.AreEqual(Query, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", vUserId);

			return vUserResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			User result = Tasks.GetUser(MockApiCtx.Object, vUserId);

			UsageMap.AssertUses("GetUser", 1);
			Assert.AreEqual(vUserResult, result, "Incorrect Result.");
		}

	}

}