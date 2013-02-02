﻿using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TAttachExistingElement : TModifyTasks {

		private readonly string Query =
			"g.V('"+typeof(Factor).Name+"Id',{{FactorId}}L)[0].each{_V0=g.v(it)};"+
			"g.V('{{ElementType}}Id',{{ElementId}}L)[0].each{_V1=g.v(it)};"+
			"g.addEdge(_V0,_V1,_TP0);";

		private long vFactorId;
		private long vElemId;

		private string vElemType;
		private string vFuncName;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vFactorId = 3456;
			vElemId = 49354;
		}

		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess FactorHasElement(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			UsageMap.Increment(vFuncName);

			string expect = Query
				.Replace("{{FactorId}}", vFactorId+"")
				.Replace("{{ElementType}}", vElemType+"")
				.Replace("{{ElementId}}", vElemId+"");

			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", "FactorUses"+vElemType);

			return new Mock<IApiDataAccess>().Object;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("Descriptor")]
		[TestCase("Director")]
		[TestCase("Eventor")]
		[TestCase("Identor")]
		[TestCase("Locator")]
		[TestCase("Vector")]
		public void Success(string pElemType) {
			vElemType = pElemType;
			vFuncName = "AttachExisting"+pElemType;

			MockApiCtx
				.Setup(x => x.DbData(vFuncName, It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction tx) => FactorHasElement(tx));

			var ac = MockApiCtx.Object;
			var f = new Factor { FactorId = vFactorId };

			switch ( pElemType ) {
				case "Descriptor":
					var desc = new Descriptor { DescriptorId = vElemId };
					Tasks.AttachExistingElement<Descriptor, FactorUsesDescriptor>(ac, f, desc);
					break;

				case "Director":
					var dir = new Director { DirectorId = vElemId };
					Tasks.AttachExistingElement<Director, FactorUsesDirector>(ac, f, dir);
					break;

				case "Eventor":
					var eve = new Eventor { EventorId = vElemId };
					Tasks.AttachExistingElement<Eventor, FactorUsesEventor>(ac, f, eve);
					break;

				case "Identor":
					var iden = new Identor { IdentorId = vElemId };
					Tasks.AttachExistingElement<Identor, FactorUsesIdentor>(ac, f, iden);
					break;

				case "Locator":
					var loc = new Locator { LocatorId = vElemId };
					Tasks.AttachExistingElement<Locator, FactorUsesLocator>(ac, f, loc);
					break;

				case "Vector":
					var vec = new Vector { VectorId = vElemId };
					Tasks.AttachExistingElement<Vector, FactorUsesVector>(ac, f, vec);
					break;
			}

			UsageMap.AssertUses(vFuncName, 1);
		}

	}

}