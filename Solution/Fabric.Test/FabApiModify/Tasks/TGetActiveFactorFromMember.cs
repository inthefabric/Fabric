using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetActiveFactorFromMember : TModifyTasks {

		private const string Query = 
			"g.V('"+PropDbName.Factor_FactorId+"',_P0)"+
				".has('"+PropDbName.Factor_Deleted+"',Tokens.T.eq,_P1)"+
				".as('step2')"+
			".inE('"+RelDbName.MemberCreatesFactor+"').outV"+
				".has('"+PropDbName.Member_MemberId+"',Tokens.T.eq,_P2)"+
			".back('step2');";

		private long vFactorId;
		private long vMemberId;
		private Factor vFactorResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vFactorId = 3456;
			vMemberId = 43266;
			vFactorResult = new Factor();

			MockApiCtx
				.Setup(x => x.DbSingle<Factor>("GetActiveFactorFromMember", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetActiveFactorFromMember(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Factor GetActiveFactorFromMember(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("GetActiveFactorFromMember");

			Assert.AreEqual(Query, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", vFactorId);
			TestUtil.CheckParam(pQuery.Params, "_P1", null);
			TestUtil.CheckParam(pQuery.Params, "_P2", vMemberId);

			return vFactorResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Factor result = Tasks.GetActiveFactorFromMember(MockApiCtx.Object, vFactorId, vMemberId);

			UsageMap.AssertUses("GetActiveFactorFromMember", 1);
			Assert.AreEqual(vFactorResult, result, "Incorrect Result.");
		}

	}

}