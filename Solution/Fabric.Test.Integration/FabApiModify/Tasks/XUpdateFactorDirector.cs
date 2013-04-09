using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XUpdateFactorDirector : XModifyTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(DirectorTypeId.DefinedPath, DirectorActionId.Read, DirectorActionId.Listen)]
		public void Success(DirectorTypeId pDirTypeId, DirectorActionId pPrimActId,
																		DirectorActionId pRelActId) {
			var f = new Factor { FactorId = (long)SetupFactors.FactorId.FZ_Art_Music_Incomplete };

			Tasks.UpdateFactorDirector(ApiCtx, f, (byte)pDirTypeId, (byte)pPrimActId, (byte)pRelActId);

			Factor fac = GetNode<Factor>(f.FactorId);
			Assert.NotNull(fac, "Updated Factor was deleted.");
			Assert.AreEqual((byte)pDirTypeId, fac.Director_TypeId, "Incorrect Director_TypeId.");
		}

	}

}