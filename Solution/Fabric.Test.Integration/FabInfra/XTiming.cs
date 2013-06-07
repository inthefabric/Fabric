using System.Diagnostics;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using NUnit.Framework;
using Rexster;
using Weaver;

namespace Fabric.Test.Integration.FabInfra {

	/*================================================================================================*/
	[TestFixture]
	public class XTiming : IntegTestBase {

		private TcpClientPool vRexProTcpPool;
		private string vResults;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vRexProTcpPool = TcpClientPool.GetPool(ApiCtx.RexConnUrl, 8184);
			vResults = "";
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestPostTearDown() {
			Log.Debug("Results:\n"+vResults);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RexProSerial() {
			for ( int i = 0 ; i < 10 ; ++i ) {
				RunRexPro(i);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RexConnSerial() {
			for ( int i = 0 ; i < 10 ; ++i ) {
				RunRexConn(i);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void RunRexPro(int pIndex) {
			TimedTcpClient tcp = vRexProTcpPool.TakeClient();

			var sw = new Stopwatch();
			sw.Start();

			var rexPro = new RexProClient(() => tcp);
			rexPro.Query("g");
			vResults += "RunRexPro: "+sw.Elapsed.TotalMilliseconds+"ms\n";

			vRexProTcpPool.ReturnClient(tcp);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void RunRexConn(int pIndex) {
			var wq = new WeaverQuery();
			wq.FinalizeQuery("g");

			var sw = new Stopwatch();
			sw.Start();

			ApiCtx.DbData("G", wq);
			vResults += "RunRexConn: "+sw.Elapsed.TotalMilliseconds+"ms\n";
		}
		
	}

}