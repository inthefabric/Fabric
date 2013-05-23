﻿using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	//TEST: enable this [TestFixture]
	public class XGetClassByNameDisamb : XModifyTasks {

		private string vName;
		private string vDisamb;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private Class TestGo() {
			return Tasks.GetClassByNameDisamb(ApiCtx, vName, vDisamb);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		//TEST: enable this [TestCase("MUSKEGON", "MI, Usa")]
		//TEST: enable this [TestCase("human", null)]
		public void Found(string pName, string pDisamb) {
			vName = pName;
			vDisamb = pDisamb;

			Class result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vName.ToLower(), result.Name.ToLower(), "Incorrect Name.");
		}

		/*--------------------------------------------------------------------------------------------*/
		//TEST: enable this [TestCase("Muskegon", "test")]
		//TEST: enable this [TestCase("human", "bean")]
		//TEST: enable this [TestCase("test", null)]
		//TEST: enable this [TestCase("MUSKEGON", null)]
		public void NotFound(string pName, string pDisamb) {
			vName = pName;
			vDisamb = pDisamb;

			Class result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}