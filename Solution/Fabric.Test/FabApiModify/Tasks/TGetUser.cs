using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetUser : TModifyTasks {

		private static readonly string Query =
			"g.V('"+typeof(User).Name+"Id',{{UserId}}L)[0];";

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

			string expect = Query.Replace("{{UserId}}", vUserId+"");
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");

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