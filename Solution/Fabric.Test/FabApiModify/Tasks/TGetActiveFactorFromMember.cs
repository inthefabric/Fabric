using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetActiveFactorFromMember : TModifyTasks {

		private static readonly string Query = 
			"g.V('"+typeof(Factor).Name+"Id',{{FactorId}}L)[0]"+
				".has('Deleted',Tokens.T.eq,null)"+
				".as('step2')"+
			".inE('"+typeof(MemberCreatesFactor).Name+"').outV"+
				".has('"+typeof(Member).Name+"Id',Tokens.T.eq,{{MemberId}}L)"+
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

			string expect = Query
				.Replace("{{FactorId}}", vFactorId+"")
				.Replace("{{MemberId}}", vMemberId+"");
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");

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