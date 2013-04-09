using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XUpdateFactorIdentor : XModifyTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(IdentorTypeId.Key, "this is my value")]
		public void Success(IdentorTypeId pIdenTypeId, string pValue) {
			var f = new Factor { FactorId = (long)SetupFactors.FactorId.FZ_Art_Music_Incomplete };

			Tasks.UpdateFactorIdentor(ApiCtx, f, (byte)pIdenTypeId, pValue);

			Factor fac = GetNode<Factor>(f.FactorId);
			Assert.NotNull(fac, "Updated Factor was deleted.");
			Assert.AreEqual((byte)pIdenTypeId, fac.Identor_TypeId, "Incorrect Identor_TypeId.");
		}

	}

}