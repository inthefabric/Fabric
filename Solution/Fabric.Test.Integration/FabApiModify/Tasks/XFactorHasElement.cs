using Fabric.Domain;
using Fabric.Infrastructure.Api;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	public abstract class XFactorHasElement<T, TRel> : XModifyTasks where T : FactorElementNode {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected abstract bool ExecuteTask(IApiContext pApiCtx, Factor pFactor);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Found(long pFactorId) {
			bool result = ExecuteTask(ApiCtx, new Factor { FactorId = pFactorId });
			Assert.True(result, "Incorrect Result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void NotFound(long pFactorId) {
			bool result = ExecuteTask(ApiCtx, new Factor { FactorId = pFactorId });
			Assert.False(result, "Incorrect Result.");
		}

	}

}