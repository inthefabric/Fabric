using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetClassByNameDisamb : TModifyTasks {

		private readonly static string QueryStart =
			"g.V('"+typeof(Class).Name+"Id',{{ClassId0}}L)[0].each{_V0=g.v(it)};"+
			"g.V('"+typeof(Class).Name+"Id',{{ClassId1}}L)[0].each{_V1=g.v(it)};"+
			"g.V('"+typeof(Class).Name+"Id',{{ClassId2}}L)[0].each{_V2=g.v(it)};"+
			"_V3=[_V0,_V1,_V2];"+
			"g.V('"+typeof(Root).Name+"Id',0)[0]"+
			".outE('"+typeof(RootContainsClass).Name+"').inV"+
				".retain(_V3)"+
				".filter{it.getProperty('Name').toLowerCase()==_TP0}";

		private readonly static string QueryNoDisamb = QueryStart+";";

		private readonly static string Query = QueryStart+
				".filter{it.getProperty('Disamb').toLowerCase()==_TP1};";

		private string vName;
		private string vDisamb;
		private Class vClassResult;
		private IList<long> vClassIds;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "My Class";
			vDisamb = "The awesome version";
			vClassResult = new Class();
			vClassIds = new List<long>(new [] { 2451235238523525, 122352355126236, 2352351312612335 });

			MockApiCtx
				.Setup(x => x.GetClassIdsFromClassNameCache(vName, vDisamb))
				.Returns(vClassIds);

			MockApiCtx
				.Setup(x => x.DbSingle<Class>("GetClassByNameDisambTx", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction tx) => GetClass(tx));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Class GetClass(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			UsageMap.Increment("GetClassByNameDisamb");

			string expect = (vDisamb != null ? Query : QueryNoDisamb)
				.Replace("{{ClassId0}}", vClassIds[0]+"")
				.Replace("{{ClassId1}}", vClassIds[1]+"")
				.Replace("{{ClassId2}}", vClassIds[2]+"");

			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", vName.ToLower());

			if ( vDisamb != null ) {
				TestUtil.CheckParam(pTx.Params, "_TP1", vDisamb.ToLower());
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

			MockApiCtx
				.Setup(x => x.GetClassIdsFromClassNameCache(vName, vDisamb))
				.Returns(vClassIds);

			Class result = Tasks.GetClassByNameDisamb(MockApiCtx.Object, vName, vDisamb);

			UsageMap.AssertUses("GetClassByNameDisamb", 1);
			Assert.AreEqual(vClassResult, result, "Incorrect Result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void SuccessNoMatches(bool pIsNull) {
			MockApiCtx
				.Setup(x => x.GetClassIdsFromClassNameCache(vName, vDisamb))
				.Returns(pIsNull ? null : new List<long>());

			Class result = Tasks.GetClassByNameDisamb(MockApiCtx.Object, vName, vDisamb);

			UsageMap.AssertUses("GetClassByNameDisamb", 0);
			Assert.Null(result, "Incorrect Result.");
		}

	}

}