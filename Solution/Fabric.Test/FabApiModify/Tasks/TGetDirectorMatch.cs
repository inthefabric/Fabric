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
			"g.V('"+typeof(Root).Name+"Id',0)[0]"+
				".outE('"+typeof(RootContainsDirector).Name+"').inV"+
					".as('step3')"+
				".outE('"+typeof(DirectorUsesDirectorType).Name+"').inV"+
					".has('"+typeof(DirectorType).Name+"Id',Tokens.T.eq,{{DirTypeId}}L)"+
				".back('step3')"+
				".outE('"+typeof(DirectorUsesPrimaryDirectorAction).Name+"').inV"+
					".has('"+typeof(DirectorAction).Name+"Id',Tokens.T.eq,{{PrimActId}}L)"+
				".back('step3')"+
				".outE('"+typeof(DirectorUsesRelatedDirectorAction).Name+"').inV"+
					".has('"+typeof(DirectorAction).Name+"Id',Tokens.T.eq,{{RelActId}}L)"+
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

			string expect = Query
				.Replace("{{DirTypeId}}", vDirTypeId+"")
				.Replace("{{PrimActId}}", vPrimActId+"")
				.Replace("{{RelActId}}", vRelActId+"");

			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");

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