using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetVectorType : TModifyTasks {

		private static readonly string Query = 
			"g.V('"+typeof(VectorType).Name+"Id',{{VectorTypeId}}L)[0];";

		private long vVectorTypeId;
		private VectorType vVectorTypeResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vVectorTypeId = 3456;
			vVectorTypeResult = new VectorType();

			MockApiCtx
				.Setup(x => x.DbSingle<VectorType>("GetVectorType", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetVectorType(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private VectorType GetVectorType(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("GetVectorType");

			string expect = Query.Replace("{{VectorTypeId}}", vVectorTypeId+"");
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");

			return vVectorTypeResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			VectorType result = Tasks.GetVectorType(MockApiCtx.Object, vVectorTypeId);

			UsageMap.AssertUses("GetVectorType", 1);
			Assert.AreEqual(vVectorTypeResult, result, "Incorrect Result.");
		}

	}

}