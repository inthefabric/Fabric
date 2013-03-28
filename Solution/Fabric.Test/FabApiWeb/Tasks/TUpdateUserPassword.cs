using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TUpdateUserPassword : TWebTasks {

		private static readonly string Query =
			"g.V('"+typeof(User).Name+"Id',_P0)[0]"+
				".sideEffect{it.setProperty('Password',_P1)};";

		private long vUserId;
		private string vPassword;
		private User vUserResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vUserId = 3456;
			vPassword = "MyTestPass";
			vUserResult = new User();

			MockApiCtx
				.Setup(x => x.DbSingle<User>("UpdateUserPassword", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => UpdateUserPassword(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private User UpdateUserPassword(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("UpdateUserPassword");

			Assert.AreEqual(Query, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", vUserId);
			TestUtil.CheckParam(pQuery.Params, "_P1", FabricUtil.HashPassword(vPassword));

			return vUserResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			User result = Tasks.UpdateUserPassword(MockApiCtx.Object, vUserId, vPassword);

			UsageMap.AssertUses("UpdateUserPassword", 1);
			Assert.AreEqual(vUserResult, result, "Incorrect Result.");
		}

	}

}