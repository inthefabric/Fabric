using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Domain;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	public abstract class TBaseModifyFunc {

		protected Mock<IApiContext> MockApiCtx { get; private set; }
		protected Mock<IDomainValidator> MockValidator { get; private set; }
		protected Mock<ICacheManager> MockCacheManager { get; private set; }
		protected Mock<IClassDiskCache> MockClassCache { get; private set; }
		protected Mock<IMemCache> MockMemCache { get; private set; }
		protected Mock<IModifyTasks> MockTasks { get; private set; }

		protected long ApiCtxAppId { get; private set; }
		protected long ApiCtxUserId { get; private set; }
		protected Member ApiCtxMember { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			MockApiCtx = new Mock<IApiContext>();
			MockValidator = new Mock<IDomainValidator>();

			MockTasks = new Mock<IModifyTasks>();
			MockTasks.SetupGet(x => x.Validator).Returns(MockValidator.Object);

			MockCacheManager = new Mock<ICacheManager>();
			MockApiCtx.SetupGet(x => x.Cache).Returns(MockCacheManager.Object);

			MockClassCache = new Mock<IClassDiskCache>();
			MockMemCache = new Mock<IMemCache>();
			MockCacheManager.SetupGet(x => x.UniqueClasses).Returns(MockClassCache.Object);
			MockCacheManager.SetupGet(x => x.Memory).Returns(MockMemCache.Object);

			TestSetUp();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void SetUpMember(long pAppId, long pUserId, Member pMember) {
			ApiCtxAppId = pAppId;
			ApiCtxUserId = pUserId;
			ApiCtxMember = pMember;

			MockApiCtx.SetupGet(x => x.AppId).Returns(pAppId);
			MockApiCtx.SetupGet(x => x.UserId).Returns(pUserId);
			MockTasks.Setup(x => x.GetValidMemberByContext(MockApiCtx.Object)).Returns(ApiCtxMember);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void TestSetUp();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected IWeaverVarAlias<T> GetTxVar<T>(string pName) where T : INode {
			var tv = new Mock<IWeaverVarAlias<T>>();
			tv.SetupGet(x => x.Name).Returns(pName);
			tv.SetupGet(x => x.VarType).Returns(typeof(T));
			return tv.Object;
		}

	}

}