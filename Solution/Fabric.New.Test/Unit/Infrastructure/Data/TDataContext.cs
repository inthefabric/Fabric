using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Data;
using Moq;
using NUnit.Framework;
using RexConnectClient.Core.Cache;

namespace Fabric.New.Test.Unit.Infrastructure.Data {

	/*================================================================================================*/
	[TestFixture]
	public class TDataContext {

		private static readonly Logger Log = Logger.Build<TDataContext>();

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			const string url = "url";
			const int port = 1234;
			IRexConnCacheProvider cache = new Mock<IRexConnCacheProvider>(MockBehavior.Strict).Object;
			const string sessId = "mysess";
			const bool cmdId = true;
			const bool cmdTime = true;

			var dc = new DataContext(url, port, cache, sessId, cmdId, cmdTime);

			Assert.AreEqual(url, dc.RexConnUrl, "Incorrect RexConnUrl.");
			Assert.AreEqual(port, dc.RexConnPort, "Incorrect RexConnPort.");
			Assert.AreEqual(cache, dc.RexConnCacheProv, "Incorrect RexConnCacheProv.");
			Assert.AreEqual(sessId, dc.ResumeSessionId, "Incorrect ResumeSessionId.");
			Assert.AreEqual(cmdId, dc.SetCommandIds, "Incorrect SetCommandIds.");
			Assert.AreEqual(cmdTime, dc.OmitCommandTimers, "Incorrect OmitCommandTimers.");
		}

	}

}