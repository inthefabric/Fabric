using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
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
		[Test]
		public void Unique() {
			MockClassCache.Setup(x => x.FindClassId(vName, vDisamb)).Returns((long?)null);

			Class result = Tasks.GetClassByNameDisamb(MockApiCtx.Object, vName, vDisamb);

			Assert.Null(result, "Result should be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Duplicate() {
			const long classId = 34623946823;
			MockClassCache.Setup(x => x.FindClassId(vName, vDisamb)).Returns(classId);

			Class result = Tasks.GetClassByNameDisamb(MockApiCtx.Object, vName, vDisamb);

			Assert.NotNull(result, "Result should not be null.");
			Assert.AreEqual(classId, result.ClassId, "Incorrect Result.ClassId.");
			Assert.AreEqual(vName, result.Name, "Incorrect Result.Name.");
			Assert.AreEqual(vDisamb, result.Disamb, "Incorrect Result.Disamb.");
		}

	}

}