using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetUserByName : TWebTasks {

		private const string Query =
			"g.V('"+PropDbName.Node_FabType+"',_P0)"+
				".filter{"+
					"it.getProperty('"+PropDbName.User_Name+"').toLowerCase()==_P1"+
				"};";

		private string vName;
		private User vUserResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "TestUser";
			vUserResult = new User();

			MockApiCtx
				.Setup(x => x.DbSingle<User>("GetUserByName", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetUser(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private User GetUser(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("GetUserByName");

			Assert.AreEqual(Query, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", (int)NodeFabType.User);
			TestUtil.CheckParam(pQuery.Params, "_P1", vName.ToLower());

			return vUserResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			User result = Tasks.GetUserByName(MockApiCtx.Object, vName);

			UsageMap.AssertUses("GetUserByName", 1);
			Assert.AreEqual(vUserResult, result, "Incorrect Result.");
		}

	}

}