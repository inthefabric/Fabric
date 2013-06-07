using System.Diagnostics;
using System.IO;
using System.Net;
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
		private double vTimeSum;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vRexProTcpPool = TcpClientPool.GetPool(ApiCtx.RexConnUrl, 8184);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestPostTearDown() {
			Log.Debug("Results:\n"+vResults+"AVG: "+vTimeSum/10.0+"ms");
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RexProSerial() {
			RunRexPro(-1);
			vResults = "";
			vTimeSum = 0;

			for ( int i = 0 ; i < 10 ; ++i ) {
				RunRexPro(i);
			}

		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RexConnSerial() {
			RunRexConn(-1);
			vResults = "";
			vTimeSum = 0;

			for ( int i = 0 ; i < 10 ; ++i ) {
				RunRexConn(i);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RestApiSerial() {
			RunRestApi(-1);
			vResults = "";
			vTimeSum = 0;

			for ( int i = 0 ; i < 10 ; ++i ) {
				RunRestApi(i);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void RunRexPro(int pIndex) {
			TimedTcpClient tcp = vRexProTcpPool.TakeClient();

			var sw = new Stopwatch();
			sw.Start();

			var rexPro = new RexProClient(() => tcp);
			dynamic data = rexPro.Query("g");

			vResults += "RunRexPro: "+sw.Elapsed.TotalMilliseconds+"ms\n";
			vTimeSum += sw.Elapsed.TotalMilliseconds;

			vRexProTcpPool.ReturnClient(tcp);
			Log.Debug("DATA: "+data);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void RunRexConn(int pIndex) {
			var wq = new WeaverQuery();
			wq.FinalizeQuery("g");

			var sw = new Stopwatch();
			sw.Start();

			var data = ApiCtx.DbData("G", wq);

			vResults += "RunRexConn: "+sw.Elapsed.TotalMilliseconds+"ms\n";
			vTimeSum += sw.Elapsed.TotalMilliseconds;
			Log.Debug("DATA: "+data.ResponseJson);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void RunRestApi(int pIndex) {
			var req = HttpWebRequest.Create("http://rexster:8182/graphs/graph/tp/gremlin?script=g");

			var sw = new Stopwatch();
			sw.Start();

			WebResponse data = req.GetResponse();

			vResults += "RunRestApi: "+sw.Elapsed.TotalMilliseconds+"ms\n";
			vTimeSum += sw.Elapsed.TotalMilliseconds;
			var sr = new StreamReader(data.GetResponseStream());
			Log.Debug("DATA: "+sr.ReadToEnd());
		}
		
	}

}