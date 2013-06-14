using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	public abstract class TModifyTasks {

		protected ModifyTasks Tasks { get; private set; }
		protected Mock<IApiContext> MockApiCtx { get; private set; }
		protected Mock<ICacheManager> MockCacheManager { get; private set; }
		protected Mock<IClassDiskCache> MockClassCache { get; private set; }
		protected Mock<IMemCache> MockMemCache { get; private set; }
		protected UsageMap UsageMap { get; private set; }
		protected TxBuilder TxBuild { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			Tasks = new ModifyTasks();
			UsageMap = new UsageMap();
			TxBuild = new TxBuilder();

			MockApiCtx = new Mock<IApiContext>();

			MockCacheManager = new Mock<ICacheManager>();
			MockApiCtx.SetupGet(x => x.Cache).Returns(MockCacheManager.Object);

			MockClassCache = new Mock<IClassDiskCache>();
			MockMemCache = new Mock<IMemCache>();
			MockCacheManager.SetupGet(x => x.Memory).Returns(MockMemCache.Object);

			TestSetUp();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected abstract void TestSetUp();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void FinishTx() {
			TxBuild.Finish();
			TestUtil.LogWeaverScript(TxBuild.Transaction);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected IWeaverVarAlias<T> GetTxVar<T>() where T : INode {
			IWeaverVarAlias v;
			TxBuild.Transaction.AddQuery(WeaverQuery.InitListVar(TxBuild.Transaction, out v));

			var tv = new Mock<IWeaverVarAlias<T>>();
			tv.SetupGet(x => x.Name).Returns(v.Name);
			tv.SetupGet(x => x.VarType).Returns(typeof(T));
			TxBuild.RegisterVarWithTxBuilder(tv.Object);
			return tv.Object;
		}

	}

}