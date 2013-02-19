using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Db;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetIdentorMatch : XModifyTasks {

		private long vIdenTypeId;
		private string vValue;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private Identor TestGo() {
			return Tasks.GetIdentorMatch(ApiCtx, vIdenTypeId, vValue);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(IdentorTypeId.Key, "4165", SetupFactors.IdentorId.Key_4165)]
		[TestCase(IdentorTypeId.Text, "IMG_9203.JPG", SetupFactors.IdentorId.Text_Img9023Jpg)]
		public void Found(IdentorTypeId pEveTypeId, string pValue,SetupFactors.IdentorId pExpectEveId) {	
			vIdenTypeId = (long)pEveTypeId;
			vValue = pValue;

			Identor result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual((long)pExpectEveId, result.IdentorId, "Incorrect IdentorId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(IdentorTypeId.Key, "4166")]
		[TestCase(IdentorTypeId.Text, "IMG_9203.jpg")]
		public void NotFound(IdentorTypeId pEveTypeId, string pValue) {	
			vIdenTypeId = (long)pEveTypeId;
			vValue = pValue;

			Identor result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}