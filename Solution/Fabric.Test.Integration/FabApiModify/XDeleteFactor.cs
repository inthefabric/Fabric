using Fabric.Api.Modify;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using NUnit.Framework;
using Weaver;
using Weaver.Functions;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XDeleteFactor : XUpdateFactor {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			vCompleted = false;
			vDeleted = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			var func = new DeleteFactor(Tasks, vFactorId, vDeleted);
			vResult = func.Go(ApiCtx);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Deleted() {
			IsReadOnlyTest = false;
			vDeleted = true;

			Factor newFac = GetNode<Factor>(vFactorId);
			Assert.NotNull(newFac, "Target Factor is missing.");
			Assert.Null(newFac.Deleted, "Deleted should be null.");

			int compCount = CountDeleted();

			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");
			Assert.AreEqual(vFactorId, vResult.FactorId, "Incorrect Result.FactorId.");

			Factor updateFac = GetNode<Factor>(vFactorId);
			Assert.NotNull(newFac, "Target Factor was deleted.");
			Assert.NotNull(updateFac.Deleted, "Deleted should be filled.");

			int updatedCompCount = CountDeleted();
			Assert.AreEqual(compCount+1, updatedCompCount, "Incorrect updated Deleted count.");

			NewNodeCount = 0;
			NewRelCount = 0;
		}

		/*--------------------------------------------------------------------------------------------*/
		private int CountDeleted() {
			IWeaverQuery q = WeaverTasks.BeginPath<Root>(x => x.RootId, 0).BaseNode
				.ContainsFactorList.ToFactor
					.Has(x => x.Deleted, WeaverFuncHasOp.NotEqualTo, null)
					.Count()
				.End();

			IApiDataAccess data = ApiCtx.DbData("TEST.CountDeleted", q);
			return int.Parse(data.Result.Text);
		}

	}

}