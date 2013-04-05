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
			"g.V('FabType',_P)[0]"+
				".as('step1')"+
			".outE('"+typeof(DirectorUsesDirectorType).Name+"').inV"+
				".has('"+typeof(DirectorType).Name+"Id',Tokens.T.eq,_P)"+
			".back('step1')"+
			".outE('"+typeof(DirectorUsesPrimaryDirectorAction).Name+"').inV"+
				".has('"+typeof(DirectorAction).Name+"Id',Tokens.T.eq,_P)"+
			".back('step1')"+
			".outE('"+typeof(DirectorUsesRelatedDirectorAction).Name+"').inV"+
				".has('"+typeof(DirectorAction).Name+"Id',Tokens.T.eq,_P)"+
			".back('step1');";

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
			
			string expect = TestUtil.InsertParamIndexes(Query, "_P");
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");
			
			TestUtil.CheckParams(pQuery.Params, "_P", new object[] {
				(int)NodeFabType.Director,
				vDirTypeId,
				vPrimActId,
				vRelActId
			});

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