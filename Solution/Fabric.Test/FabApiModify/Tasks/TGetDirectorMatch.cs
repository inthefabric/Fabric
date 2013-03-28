using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetDirectorMatch : TModifyTasks {

		private static readonly string Query = 
			"g.V('"+typeof(Root).Name+"Id',_P0)[0]"+
				".outE('"+typeof(RootContainsDirector).Name+"').inV"+
					".as('step3')"+
				".outE('"+typeof(DirectorUsesDirectorType).Name+"').inV"+
					".has('"+typeof(DirectorType).Name+"Id',Tokens.T.eq,_P1)"+
				".back('step3')"+
				".outE('"+typeof(DirectorUsesPrimaryDirectorAction).Name+"').inV"+
					".has('"+typeof(DirectorAction).Name+"Id',Tokens.T.eq,_P2)"+
				".back('step3')"+
				".outE('"+typeof(DirectorUsesRelatedDirectorAction).Name+"').inV"+
					".has('"+typeof(DirectorAction).Name+"Id',Tokens.T.eq,_P3)"+
				".back('step3');";

		private long vDirTypeId;
		private long vPrimActId;
		private long vRelActId;
		private Director vDirectorResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vDirTypeId = 9;
			vPrimActId = 14365126;
			vRelActId = 2575275;
			vDirectorResult = new Director();

			MockApiCtx
				.Setup(x => x.DbSingle<Director>("GetDirectorMatch", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetDirectorMatch(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Director GetDirectorMatch(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("GetDirectorMatch");

			Assert.AreEqual(Query, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", 0);
			TestUtil.CheckParam(pQuery.Params, "_P1", vDirTypeId);
			TestUtil.CheckParam(pQuery.Params, "_P2", vPrimActId);
			TestUtil.CheckParam(pQuery.Params, "_P3", vRelActId);

			return vDirectorResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Director result = Tasks.GetDirectorMatch(
				MockApiCtx.Object, vDirTypeId, vPrimActId, vRelActId);

			UsageMap.AssertUses("GetDirectorMatch", 1);
			Assert.AreEqual(vDirectorResult, result, "Incorrect Result.");
		}

	}

}