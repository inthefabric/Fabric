using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetClassByNameDisamb : TModifyTasks {

		private readonly static string QueryStart =
			"g.V('"+typeof(Class).Name+"Id',_TP0)[0].each{_V0=g.v(it)};"+
			"g.V('"+typeof(Class).Name+"Id',_TP1)[0].each{_V1=g.v(it)};"+
			"g.V('"+typeof(Class).Name+"Id',_TP2)[0].each{_V2=g.v(it)};"+
			"_V3=[_V0,_V1,_V2];"+
			"g.V('"+typeof(Root).Name+"Id',_TP3)[0]"+
			".outE('"+typeof(RootContainsClass).Name+"').inV"+
				".retain(_V3)";

		private readonly static string QueryNoDisamb = QueryStart+
				".filter{it.getProperty('Name').toLowerCase()==_TP4};";

		private readonly static string Query = QueryStart+
				".filter{(it.getProperty('Name')+'|'+it.getProperty('Disamb')).toLowerCase()==_TP4};";

		private string vName;
		private string vDisamb;
		private Mock<ICacheManager> vMockClassCache;
		private Class vClassResult;
		private IList<long> vClassIds;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "My Class";
			vDisamb = "The awesome version";
			vClassResult = new Class();
			vClassIds = new List<long>(new [] { 2451235238523525, 122352355126236, 2352351312612335 });

			vMockClassCache = new Mock<ICacheManager>();
			/*vMockClassCache
				.Setup(x => x.GetClassIds(MockApiCtx.Object, vName, vDisamb))
				.Returns(vClassIds);*/

			MockApiCtx.SetupGet(x => x.Cache).Returns(vMockClassCache.Object);
			MockApiCtx
				.Setup(x => x.DbSingle<Class>("GetClassByNameDisambTx", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction tx) => GetClass(tx));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Class GetClass(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			UsageMap.Increment("GetClassByNameDisamb");

			string expect = (vDisamb != null ? Query : QueryNoDisamb);

			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", vClassIds[0]);
			TestUtil.CheckParam(pTx.Params, "_TP1", vClassIds[1]);
			TestUtil.CheckParam(pTx.Params, "_TP2", vClassIds[2]);
			TestUtil.CheckParam(pTx.Params, "_TP3", 0);

			if ( vDisamb == null ) {
				TestUtil.CheckParam(pTx.Params, "_TP4", vName.ToLower());
			}
			else {
				TestUtil.CheckParam(pTx.Params, "_TP4", (vName+"|"+vDisamb).ToLower());
			}

			return vClassResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Class result = Tasks.GetClassByNameDisamb(MockApiCtx.Object, vName, vDisamb);

			UsageMap.AssertUses("GetClassByNameDisamb", 1);
			Assert.AreEqual(vClassResult, result, "Incorrect Result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SuccessNoDisamb() {
			vDisamb = null;

			/*vMockClassCache
				.Setup(x => x.GetClassIds(MockApiCtx.Object, vName, vDisamb))
				.Returns(vClassIds);*/

			Class result = Tasks.GetClassByNameDisamb(MockApiCtx.Object, vName, vDisamb);

			UsageMap.AssertUses("GetClassByNameDisamb", 1);
			Assert.AreEqual(vClassResult, result, "Incorrect Result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void SuccessNoMatches(bool pIsNull) {
			/*vMockClassCache
				.Setup(x => x.GetClassIds(MockApiCtx.Object, vName, vDisamb))
				.Returns(pIsNull ? null : new List<long>());*/

			Class result = Tasks.GetClassByNameDisamb(MockApiCtx.Object, vName, vDisamb);

			UsageMap.AssertUses("GetClassByNameDisamb", 0);
			Assert.Null(result, "Incorrect Result.");
		}

	}

}