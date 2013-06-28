using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Domain;
using Fabric.Test.Common;
using Moq;
using NUnit.Framework;

namespace Fabric.Test {

	/*================================================================================================*/
	public abstract class TTestBase {

		protected Mock<IApiContext> MockApiCtx { get; private set; }
		protected Mock<IDomainValidator> MockValidator { get; private set; }
		protected Mock<ICacheManager> MockCacheManager { get; private set; }
		protected Mock<IMemCache> MockMemCache { get; private set; }

		protected long ApiCtxAppId { get; private set; }
		protected long ApiCtxUserId { get; private set; }
		protected Member ApiCtxMember { get; private set; }

		protected int MockDataIndex { get; private set; }
		protected IList<MockDataAccess> MockDataList { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public virtual void SetUp() {
			MockDataIndex = -1;
			MockDataList = new List<MockDataAccess>();

			MockApiCtx = new Mock<IApiContext>();
			MockApiCtx
				.Setup(x => x.NewData(null))
				.Callback(OnNewData)
				.Returns(() => MockDataList[MockDataIndex].Object);

			MockValidator = new Mock<IDomainValidator>();

			MockCacheManager = new Mock<ICacheManager>();
			MockApiCtx.SetupGet(x => x.Cache).Returns(MockCacheManager.Object);

			MockMemCache = new Mock<IMemCache>();
			MockCacheManager.SetupGet(x => x.Memory).Returns(MockMemCache.Object);

			TestSetUp();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void SetUpMember(long pAppId, long pUserId, Member pMember) {
			ApiCtxAppId = pAppId;
			ApiCtxUserId = pUserId;
			ApiCtxMember = pMember;

			MockApiCtx.SetupGet(x => x.AppId).Returns(pAppId);
			MockApiCtx.SetupGet(x => x.UserId).Returns(pUserId);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void TestSetUp() {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected virtual void OnNewData() {
			MockDataIndex++;

			if ( MockDataIndex >= MockDataList.Count ) {
				throw new Exception("Not enough Mock<IDataAccess> items.");
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected void AssertDataExecution() {
			var counts = new int[MockDataList.Count];

			for ( int i = 0 ; i < MockDataList.Count ; ++i ) {
				counts[i] = 1;
			}

			AssertDataExecution(counts);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void AssertDataExecution(int[] pCounts) {
			for ( int i = 0 ; i < MockDataList.Count ; ++i ) {
				Assert.AreEqual(pCounts[i], MockDataList[i].ExecuteCount,
					"Incorrect MockDataList["+i+"]ExecuteCount.");
			}
		}

	}

}