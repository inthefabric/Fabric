using Fabric.Api.Web.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Domain;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiWeb {

	/*================================================================================================*/
	public abstract class TBaseWebFunc {

		protected Mock<IApiContext> MockApiCtx { get; private set; }
		protected Mock<IDomainValidator> MockValidator { get; private set; }
		protected Mock<IWebTasks> MockTasks { get; private set; }
		protected Mock<ICacheManager> MockCacheManager { get; private set; }
		protected Mock<IMemCache> MockMemCache { get; private set; }

		protected long ApiCtxAppId { get; private set; }
		protected long ApiCtxUserId { get; private set; }
		protected Member ApiCtxMember { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			MockApiCtx = new Mock<IApiContext>();
			MockValidator = new Mock<IDomainValidator>();

			MockTasks = new Mock<IWebTasks>();
			MockTasks.SetupGet(x => x.Validator).Returns(MockValidator.Object);

			MockCacheManager = new Mock<ICacheManager>();
			MockApiCtx.SetupGet(x => x.Cache).Returns(MockCacheManager.Object);

			MockMemCache = new Mock<IMemCache>();
			MockCacheManager.SetupGet(x => x.Memory).Returns(MockMemCache.Object);

			TestSetUp();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void TestSetUp();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected IWeaverVarAlias<T> GetTxVar<T>(string pName) where T : IVertex {
			var tv = new Mock<IWeaverVarAlias<T>>();
			tv.SetupGet(x => x.Name).Returns(pName);
			tv.SetupGet(x => x.VarType).Returns(typeof(T));
			return tv.Object;
		}

	}

}