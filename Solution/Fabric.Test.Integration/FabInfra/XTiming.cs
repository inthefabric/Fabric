using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Db;
using NUnit.Framework;
using Rexster;
using Rexster.Messages;
using ServiceStack.Text;

namespace Fabric.Test.Integration.FabInfra {

	/*================================================================================================*/
	[TestFixture]
	public class XTiming : IntegTestBase {

		private const string RexProDataPattern =
			@"Result: ""titangraph\[\nlocal: data/FabricTest\]"",";

		private const string RexConnDataPattern =
			@"{""reqId"":""1234"",""timer"":\d+,""cmdList"":\[{""timer"":\d+,""results"":\[""titangraph\[local:data/FabricTest\]""\]}\]}";

		private const string RestApiDataPattern =
			@"{""results"":\[""titangraph\[local:data\\/FabricTest\]""\],""success"":true,""version"":""2.4.0-SNAPSHOT"",""queryTime"":\d+.?\d*}";

		private string vResults;
		private double vTimeSum;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			IsReadOnlyTest = true;
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
			var sw = new Stopwatch();
			sw.Start();

			var rexPro = new RexProClient("rexster", 8184);
			double t0 = sw.Elapsed.TotalMilliseconds;

			var sr = new ScriptRequest { Script = "g" };
			double t1 = sw.Elapsed.TotalMilliseconds;

			ScriptResponse resp = rexPro.ExecuteScript(sr);
			double t2 = sw.Elapsed.TotalMilliseconds;

			string json = resp.Dump();
			sw.Stop();
			double t3 = sw.Elapsed.TotalMilliseconds;

			vResults += String.Format("RunRexPro:"+
				"  {0,8:#0.0000}ms,"+
				"  {1,8:#0.0000}ms,"+
				"  {2,8:#0.0000}ms,"+
				"  {3,8:#0.0000}ms\n",
				t0, t1, t2, t3
			);

			vTimeSum += sw.Elapsed.TotalMilliseconds;

			Log.Debug("JSON: "+json);
			Log.Debug("PATT: "+RexProDataPattern);
			//Assert.True(Regex.IsMatch(resp, RexProDataPattern), "Incorrect data.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void RunRexConn(int pIndex) {
			var sw = new Stopwatch();
			sw.Start();

			var req = new RexConnTcpRequest { ReqId = "1234" };
			var cmd = new RexConnTcpRequestCommand { Cmd = "query", Args = new[] { "g", "" }};
			req.CmdList = new List<RexConnTcpRequestCommand>(new[] { cmd });
			double t0 = sw.Elapsed.TotalMilliseconds;

			string script = JsonSerializer.SerializeToString(req);
			byte[] dataLen = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(script.Length));
			byte[] data = Encoding.ASCII.GetBytes(script);
			double t1 = sw.Elapsed.TotalMilliseconds;

			var tcp = new TcpClient("rexster", 8185);
			NetworkStream stream = tcp.GetStream();
			stream.Write(dataLen, 0, dataLen.Length); //begin with the request's string length
			stream.Write(data, 0, data.Length);
			double t2 = sw.Elapsed.TotalMilliseconds;

			data = new byte[tcp.ReceiveBufferSize];
			int bytes = stream.Read(data, 0, data.Length);
			string json = Encoding.ASCII.GetString(data, 4, bytes-4);
			sw.Stop();
			double t3 = sw.Elapsed.TotalMilliseconds;

			vResults += String.Format("RunRexConn:"+
				"  {0,8:#0.0000}ms,"+
				"  {1,8:#0.0000}ms,"+
				"  {2,8:#0.0000}ms,"+
				"  {3,8:#0.0000}ms\n",
				t0, t1, t2, t3
			);

			vTimeSum += sw.Elapsed.TotalMilliseconds;

			Log.Debug("JSON: "+json);
			Assert.True(Regex.IsMatch(json, RexConnDataPattern), "Incorrect data.");
		}

		/*--------------------------------------------------------------------------------------------*/
		private void RunRestApi(int pIndex) {
			var sw = new Stopwatch();
			sw.Start();

			var req = HttpWebRequest.Create("http://rexster:8182/graphs/graph/tp/gremlin?script=g");
			double t0 = sw.Elapsed.TotalMilliseconds;

			WebResponse resp = req.GetResponse();
			double t1 = sw.Elapsed.TotalMilliseconds;

			var sr = new StreamReader(resp.GetResponseStream());
			double t2 = sw.Elapsed.TotalMilliseconds;

			string json = sr.ReadToEnd();
			sw.Stop();
			double t3 = sw.Elapsed.TotalMilliseconds;

			vResults += String.Format("RunRestApi:"+
				"  {0,8:#0.0000}ms,"+
				"  {1,8:#0.0000}ms,"+
				"  {2,8:#0.0000}ms,"+
				"  {3,8:#0.0000}ms\n",
				t0, t1, t2, t3
			);

			vTimeSum += sw.Elapsed.TotalMilliseconds;

			Log.Debug("JSON: "+json);
			Assert.True(Regex.IsMatch(json, RestApiDataPattern), "Incorrect data.");
		}
		
	}

}