using Fabric.Api.Modify;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using NUnit.Framework;
using Weaver;
using Weaver.Functions;
using Weaver.Interfaces;

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

			//A completed Factor must have a Descriptor
			AttachTestDescriptor();
			NewNodeCount = 0;
			NewRelCount = 1;

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
			var tx = new WeaverTransaction();
			IWeaverVarAlias<Factor> facVar;
			IWeaverVarAlias<Descriptor> descVar;
			const long isA = (long)SetupFactors.DescriptorId.IsA;

			IWeaverQuery q = WeaverTasks.BeginPath<Factor>(x => x.FactorId, vFactorId).BaseNode
				.Next().End();
			q = WeaverTasks.StoreQueryResultAsVar(tx, q, out facVar);
			tx.AddQuery(q);

			q = WeaverTasks.BeginPath<Descriptor>(x => x.DescriptorId, isA).BaseNode.Next().End();
			q = WeaverTasks.StoreQueryResultAsVar(tx, q, out descVar);
			tx.AddQuery(q);

			q = WeaverTasks.AddRel<FactorUsesDescriptor>(facVar, new FactorUsesDescriptor(), descVar);
			tx.AddQuery(q);

			tx.Finish();
			ApiCtx.DbData("TEST.AttachDescriptor", tx);
		}

		/*--------------------------------------------------------------------------------------------*/
		private int CountCompleted() {
			IWeaverQuery q = WeaverTasks.BeginPath<Root>(x => x.RootId, 0).BaseNode
				.ContainsFactorList.ToFactor
					.Has(x => x.Completed, WeaverFuncHasOp.NotEqualTo, null)
					.Count()
				.End();

			IApiDataAccess data = ApiCtx.DbData("TEST.CountCompleted", q);
			return int.Parse(data.Result.Text);
		}

	}

}