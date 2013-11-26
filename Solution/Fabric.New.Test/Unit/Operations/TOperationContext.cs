﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Cache;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Operations;
using Fabric.New.Test.Unit.Infrastructure.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations {

	/*================================================================================================*/
	[TestFixture]
	public class TOperationContext {

		private static readonly Logger Log = Logger.Build<TOperationContext>();

		private Mock<IDataAccessFactory> vMockAccFac;
		private Mock<ICacheManager> vMockCache;
		private Mock<IMetricsManager> vMockMet;
		private Mock<IAnalyticsManager> vMockAna;
		private OperationContext vOpCtx;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMockAccFac = new Mock<IDataAccessFactory>();
			vMockCache = new Mock<ICacheManager>();
			vMockMet = new Mock<IMetricsManager>();
			vMockAna = new Mock<IAnalyticsManager>();

			vOpCtx = new OperationContext(vMockAccFac.Object,
				vMockCache.Object, vMockMet.Object, (x => vMockAna.Object));
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			Assert.NotNull(vOpCtx.ContextId, "ContextId should be filled.");
			Assert.NotNull(vOpCtx.Access, "Access should be filled.");
			Assert.AreEqual(vMockAna.Object, vOpCtx.Analytics, "Analytics should be filled.");
			Assert.AreEqual(vMockMet.Object, vOpCtx.Metrics, "Metrics should be filled.");
			Assert.AreEqual(vMockCache.Object, vOpCtx.Cache, "Cache should be filled.");
			Assert.AreEqual(0, vOpCtx.DbQueryExecutionCount, "Incorrect DbQueryExecutionCount.");
			Assert.AreEqual(0, vOpCtx.DbQueryMillis, "Incorrect DbQueryMillis.");
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void UtcNow() {
			DateTime now0 = vOpCtx.UtcNow;
			Thread.Sleep(10);
			DateTime now1 = vOpCtx.UtcNow;

			Assert.NotNull(now0, "UtcNow 0 should be filled.");
			Assert.NotNull(now1, "UtcNow 1 should be filled.");
			Assert.LessOrEqual(10, (now1-now0).TotalMilliseconds, "Incorrect time difference.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Code32() {
			var map = new HashSet<string>();

			for ( int i = 0 ; i < 1000 ; ++i ) {
				string code = vOpCtx.Code32;

				Assert.NotNull(code, "Code should be filled.");
				Assert.AreEqual(32, code.Length, "Incorrect Code length.");
				Assert.False(map.Contains(code), "Code must be unique.");
				Assert.True(Regex.IsMatch(code, TDataUtil.AlphaNum32Pattern), "Incorrect code format.");

				map.Add(code);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetSharpflakeId() {
			var map = new HashSet<long>();

			for ( int i = 0 ; i < 1000 ; ++i ) {
				long id = vOpCtx.GetSharpflakeId<App>();
				Assert.False(map.Contains(id), "Result must be unique.");
				map.Add(id);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("sess", false, false)]
		[TestCase(null, true, true)]
		public void NewData(string pSessId, bool pCmdId, bool pCmdTimers) {
			var mockAcc = new Mock<IDataAccess>();
			vMockAccFac.Setup(x => x.Create(pSessId, pCmdId, pCmdTimers)).Returns(mockAcc.Object);

			IDataAccess result = vOpCtx.NewData(pSessId, pCmdId, pCmdTimers);
			Assert.AreEqual(mockAcc.Object, result, "Incorrect result.");
		}

	}

}