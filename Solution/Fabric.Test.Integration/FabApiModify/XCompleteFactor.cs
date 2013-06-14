using Fabric.Api.Modify;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
using NUnit.Framework;
using Weaver.Core.Query;
using Weaver.Core.Steps.Statements;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XCompleteFactor : XUpdateFactor {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			vCompleted = true;
			vDeleted = false;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			var func = new CompleteFactor(Tasks, vFactorId, vCompleted);
			vResult = func.Go(ApiCtx);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Completed() {
			IsReadOnlyTest = false;
			vFactorId = (long)SetupFactors.FactorId.FZ_Art_Music_Incomplete;
			vCompleted = true;

			Factor newFac = GetNode<Factor>(vFactorId);
			Assert.NotNull(newFac, "Target Factor is missing.");
			Assert.Null(newFac.Completed, "Completed should be null.");

			int compCount = CountCompleted();
			AttachTestDescriptor(); //A completed Factor must have a Descriptor

			////

			TestGo();

			////

			Assert.NotNull(vResult, "Result should not be null.");
			Assert.AreEqual(vFactorId, vResult.FactorId, "Incorrect Result.FactorId.");

			Factor updateFac = GetNode<Factor>(vFactorId);
			Assert.NotNull(newFac, "Target Factor was deleted.");
			Assert.NotNull(updateFac.Completed, "Completed should be filled.");

			int updatedCompCount = CountCompleted();
			Assert.AreEqual(compCount+1, updatedCompCount, "Incorrect updated Completed count.");
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AttachTestDescriptor() {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<Factor>(x => x.FactorId, vFactorId)
				.SideEffect(
					new WeaverStatementSetProperty<Factor>(
						x => x.Descriptor_TypeId, (byte)DescriptorTypeId.IsA)
				)
				.ToQuery();

			ApiCtx.DbData("TEST.AttachDescriptor", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		private int CountCompleted() {
			IWeaverQuery q = GetNodeByPropQuery<Factor>(
				".has('"+PropDbName.Factor_Completed+"').count()");
			IApiDataAccess data = ApiCtx.DbData("TEST.CountCompleted", q);
			return int.Parse(data.Result.TextList[0]);
		}

	}

}