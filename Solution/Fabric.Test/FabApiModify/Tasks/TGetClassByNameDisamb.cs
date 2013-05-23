using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	//TEST: enable this [TestFixture]
	public class TGetClassByNameDisamb : TModifyTasks {

		private string vName;
		private string vDisamb;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "My Class";
			vDisamb = "The awesome version";
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		//TEST: enable this [Test]
		public void Unique() {
			Class result = Tasks.GetClassByNameDisamb(MockApiCtx.Object, vName, vDisamb);

			Assert.Null(result, "Result should be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		//TEST: enable this [Test]
		public void Duplicate() {
			const long classId = 34623946823;
			Class result = Tasks.GetClassByNameDisamb(MockApiCtx.Object, vName, vDisamb);

			Assert.NotNull(result, "Result should not be null.");
			Assert.AreEqual(classId, result.ArtifactId, "Incorrect Result.ArtifactId.");
			Assert.AreEqual(vName, result.Name, "Incorrect Result.Name.");
			Assert.AreEqual(vDisamb, result.Disamb, "Incorrect Result.Disamb.");
		}

	}

}