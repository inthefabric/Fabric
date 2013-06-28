using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	public abstract class TModifyTasks : TTestBase {

		protected ModifyTasks Tasks { get; private set; }
		protected UsageMap UsageMap { get; private set; }
		protected TxBuilder TxBuild { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public override void SetUp() {
			Tasks = new ModifyTasks();
			UsageMap = new UsageMap();
			TxBuild = new TxBuilder();

			base.SetUp();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void FinishTx() {
			TxBuild.Finish();
			TestUtil.LogWeaverScript(TxBuild.Transaction);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected IWeaverVarAlias<T> GetTxVar<T>(string pName) where T : IVertex {
			IWeaverVarAlias v;
			TxBuild.Transaction.AddQuery(WeaverQuery.InitListVar(pName, out v));

			var tv = TestUtil.GetTxVar<T>(v.Name);
			TxBuild.RegisterVarWithTxBuilder(tv);
			return tv;
		}

	}

}