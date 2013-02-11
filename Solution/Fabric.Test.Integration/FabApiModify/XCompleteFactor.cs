﻿using Fabric.Api.Modify;
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
		protected void TestGo() {
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
			var facVar =  new WeaverVarAlias<Factor>(tx);
			var descVar = new WeaverVarAlias<Descriptor>(tx);
			const long isA = (long)SetupFactors.DescriptorId.IsA;

			tx.AddQuery(
				WeaverTasks.BeginPath<Factor>(x => x.FactorId, vFactorId).BaseNode
					.ToNodeVar(facVar)
				.End()
			);

			tx.AddQuery(
				WeaverTasks.BeginPath<Descriptor>(x => x.DescriptorId, isA).BaseNode
					.ToNodeVar(descVar)
				.End()
			);

			tx.AddQuery(
				WeaverTasks.AddRel<FactorUsesDescriptor>(facVar, new FactorUsesDescriptor(), descVar)
			);

			tx.FinishWithoutStartStop();
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