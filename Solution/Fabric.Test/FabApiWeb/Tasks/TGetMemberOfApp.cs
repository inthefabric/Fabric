using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetMemberOfApp : TWebTasks {

		private static readonly string Query =
			"g.V('"+typeof(App).Name+"Id',_P0)[0]"+
			".outE('"+typeof(AppDefinesMember).Name+"').inV"+
				".has('"+typeof(Member).Name+"Id',Tokens.T.eq,_P1);";

		private long vAppId;
		private long vMemberId;
		private Member vMemberResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 3456;
			vMemberId = 438643;
			vMemberResult = new Member();

			MockApiCtx
				.Setup(x => x.DbSingle<Member>("GetMemberOfApp", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetMemberOfApp(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Member GetMemberOfApp(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("GetMemberOfApp");

			Assert.AreEqual(Query, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", vAppId);
			TestUtil.CheckParam(pQuery.Params, "_P1", vMemberId);

			return vMemberResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Member result = Tasks.GetMemberOfApp(MockApiCtx.Object, vAppId, vMemberId);

			UsageMap.AssertUses("GetMemberOfApp", 1);
			Assert.AreEqual(vMemberResult, result, "Incorrect Result.");
		}

	}

}