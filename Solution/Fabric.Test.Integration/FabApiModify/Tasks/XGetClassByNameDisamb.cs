using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
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
		[TestCase("MUSKEGON", "MI, Usa")]
		[TestCase("MUSKEGON", null)]
		[TestCase("human", null)]
		public void Found(string pName, string pDisamb) {
			vName = pName;
			vDisamb = pDisamb;

			Class result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vName.ToLower(), result.Name.ToLower(), "Incorrect Name.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("Muskegon", "test")]
		[TestCase("human", "bean")]
		[TestCase("test", null)]
		public void NotFound(string pName, string pDisamb) {
			vName = pName;
			vDisamb = pDisamb;

			Class result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}