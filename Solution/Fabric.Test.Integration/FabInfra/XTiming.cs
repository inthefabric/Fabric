using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Fabric.Infrastructure;
using NUnit.Framework;
using Rexster;
using Rexster.Messages;
using ServiceStack.Text;
using Weaver.Exec.RexConnect;

namespace Fabric.Test.Integration.FabInfra {

	/*================================================================================================*/
	[TestFixture]
	public class XTiming : IntegTestBase {

		private const string TestScript = "g";
		private const string VerifyJsonPatternA = "titangraph";
		private const string VerifyJsonPatternB = "FabricTest";
		private const bool VerifyGraphJson = true;

		/*
		private const string TestScript = "g.v(4)";
		private const string VerifyJsonPatternA = @"""E_Ad"":""dataprov@inthefabric.com""";
		private const string VerifyJsonPatternB = @"""E_Co"":""274bbd733ecc46f3a27b7c189ee091f4""";
		private const bool VerifyGraphJson = false;
		*/

		/*
		private const string TestScript = "g.V.both.both.count()";
		private const string VerifyJsonPatternA = @"16942";
		private const string VerifyJsonPatternB = @"";
		private const bool VerifyGraphJson = false;
		*/

		/*
		private const string TestScript = "g.V[0..30]";
		private const string VerifyJsonPatternA = @"""E_Co"":""e3d6522a5c3d4f609ed9e3c4ba9eb145""";
		private const string VerifyJsonPatternB = @"""Ap_Na"":""Fabric System""";
		private const bool VerifyGraphJson = false;
		*/
		 
		//private const string RexProDataPattern =
		//	@"Result: ""titangraph\[\n\s*local: data/FabricTest\n\s*\]"",";
		private const string RexProDataPatternA =
			@"""titangraph\[";
		private const string RexProDataPatternB =
			@"local: data/FabricTest";

		private const string RexConnDataPattern =
			@"{""reqId"":""1234"",""timer"":\d+,""cmdList"":\[{""timer"":\d+,""results"":\[""titangraph\[local:data/FabricTest\]""\]}\]}";

		private const string RestApiDataPattern =
			@"{""results"":\[""titangraph\[local:data\\/FabricTest\]""\],""success"":true,""version"":""2.4.0-SNAPSHOT"",""queryTime"":\d+.?\d*}";

		private string vResults;
		private double vTimeSum;
		private int vRunCount;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			IsReadOnlyTest = true;
			vRunCount = 10;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestPostTearDown() {
			Log.Debug("------------------------------\n");
			Log.Debug("Results:\n"+vResults+"AVG: "+vTimeSum/vRunCount+"ms");
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void Prepare(Action<int> pRunAction) {
			vResults = "";
			pRunAction(-1);
			pRunAction(-1);
			vResults = "";
			vTimeSum = 0;
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RexProSerial() {
			Prepare(RunRexPro);

			for ( int i = 0 ; i < vRunCount ; ++i ) {
				RunRexPro(i);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RexConnTcpSerial() {
			Prepare(RunRexConnTcp);

			for ( int i = 0 ; i < vRunCount ; ++i ) {
				RunRexConnTcp(i);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RexConnHttpSerial() {
			Prepare(RunRexConnHttp);

			for ( int i = 0 ; i < vRunCount ; ++i ) {
				RunRexConnHttp(i);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RestApiSerial() {
			Prepare(RunRestApi);

			for ( int i = 0 ; i < vRunCount ; ++i ) {
				RunRestApi(i);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RexProParallel() {
			Prepare(RunRexPro);
			vRunCount = 20;
			Parallel.For(0, vRunCount, RunRexPro);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RexConnTcpParallel() {
			Prepare(RunRexConnTcp);
			vRunCount = 20;
			Parallel.For(0, vRunCount, RunRexConnTcp);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RexConnHttpParallel() {
			Prepare(RunRexConnHttp);
			vRunCount = 20;
			Parallel.For(0, vRunCount, RunRexConnHttp);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RestApiParallel() {
			Prepare(RunRestApi);
			vRunCount = 20;
			Parallel.For(0, vRunCount, RunRestApi);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void RunRexPro(int pIndex) {
			var sw = new Stopwatch();
			sw.Start();

			var rexPro = new RexProClient("rexster", 8184);
			double t0 = sw.Elapsed.TotalMilliseconds;

			var sr = new ScriptRequest { Script = TestScript };
			double t1 = sw.Elapsed.TotalMilliseconds;

			ScriptResponse resp = rexPro.ExecuteScript(sr);
			double t2 = sw.Elapsed.TotalMilliseconds;

			string json = resp.Dump();
			sw.Stop();
			double t3 = sw.Elapsed.TotalMilliseconds;

			lock ( this ) {
				vTimeSum += sw.Elapsed.TotalMilliseconds;

				vResults += String.Format("RunRexPro:"+
					"  {0,8:#0.0000}ms,"+
					"  {1,8:#0.0000}ms,"+
					"  {2,8:#0.0000}ms,"+
					"  {3,8:#0.0000}ms\n",
					t0, t1, t2, t3
				);
			}

			//VerifyJson(json);

			if ( VerifyGraphJson ) {
				Assert.True(Regex.IsMatch(json, RexProDataPatternA), "Incorrect data A.");
				Assert.True(Regex.IsMatch(json, RexProDataPatternB), "Incorrect data B.");
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void RunRexConnTcp(int pIndex) {
			var sw = new Stopwatch();
			sw.Start();

			var req = new WeaverRequest("1234");
			req.AddQuery(TestScript);
			double t0 = sw.Elapsed.TotalMilliseconds;

			JsConfig.EmitCamelCaseNames = true;
			string script = JsonSerializer.SerializeToString(req);
			JsConfig.EmitCamelCaseNames = false;

			byte[] dataLen = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(script.Length));
			byte[] data = Encoding.ASCII.GetBytes(script);
			double t1 = sw.Elapsed.TotalMilliseconds;

			var tcp = new TcpClient("rexster", 8185);
			NetworkStream stream = tcp.GetStream();
			stream.Write(dataLen, 0, dataLen.Length); //begin with the request's string length
			stream.Write(data, 0, data.Length);
			double t2 = sw.Elapsed.TotalMilliseconds;

			data = new byte[4];
			stream.Read(data, 0, data.Length);
			Array.Reverse(data);
			int respLen = BitConverter.ToInt32(data, 0);

			//Get response string using the string length

			var sb = new StringBuilder(respLen);

			while ( sb.Length < respLen ) {
				data = new byte[respLen];
				int bytes = stream.Read(data, 0, data.Length);
				sb.Append(Encoding.ASCII.GetString(data, 0, bytes));
			}

			string json = sb.ToString();
			sw.Stop();
			double t3 = sw.Elapsed.TotalMilliseconds;

			lock ( this ) {
				vTimeSum += sw.Elapsed.TotalMilliseconds;

				vResults += String.Format("RunRexConnTcp:"+
					"  {0,8:#0.0000}ms,"+
					"  {1,8:#0.0000}ms,"+
					"  {2,8:#0.0000}ms,"+
					"  {3,8:#0.0000}ms\n",
					t0, t1, t2, t3
				);
			}

			VerifyJson(json);

			if ( VerifyGraphJson ) {
				Assert.True(Regex.IsMatch(json, RexConnDataPattern), "Incorrect data.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void RunRexConnHttp(int pIndex) {
			var sw = new Stopwatch();
			sw.Start();

			var wr = new WeaverRequest("1234");
			wr.AddQuery(TestScript);

			JsConfig.EmitCamelCaseNames = true;
			string script = JsonSerializer.SerializeToString(wr);
			JsConfig.EmitCamelCaseNames = false;

			var req = HttpWebRequest.Create(
				"http://rexster:8182/graphs/graph/fab/rexconn?req="+script);
			double t0 = sw.Elapsed.TotalMilliseconds;

			WebResponse resp = req.GetResponse();
			double t1 = sw.Elapsed.TotalMilliseconds;

			var sr = new StreamReader(resp.GetResponseStream());
			double t2 = sw.Elapsed.TotalMilliseconds;

			string json = sr.ReadToEnd();
			sw.Stop();
			double t3 = sw.Elapsed.TotalMilliseconds;

			lock ( this ) {
				vTimeSum += sw.Elapsed.TotalMilliseconds;

				vResults += String.Format("RunRexConnHttp:"+
					"  {0,8:#0.0000}ms,"+
					"  {1,8:#0.0000}ms,"+
					"  {2,8:#0.0000}ms,"+
					"  {3,8:#0.0000}ms\n",
					t0, t1, t2, t3
				);
			}

			VerifyJson(json);

			if ( VerifyGraphJson ) {
				Assert.True(Regex.IsMatch(json, RexConnDataPattern), "Incorrect data.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void RunRestApi(int pIndex) {
			var sw = new Stopwatch();
			sw.Start();

			var req = HttpWebRequest.Create(
				"http://rexster:8182/graphs/graph/tp/gremlin?script="+TestScript);
			double t0 = sw.Elapsed.TotalMilliseconds;

			WebResponse resp = req.GetResponse();
			double t1 = sw.Elapsed.TotalMilliseconds;

			var sr = new StreamReader(resp.GetResponseStream());
			double t2 = sw.Elapsed.TotalMilliseconds;

			string json = sr.ReadToEnd();
			sw.Stop();
			double t3 = sw.Elapsed.TotalMilliseconds;

			lock ( this ) {
				vTimeSum += sw.Elapsed.TotalMilliseconds;

				vResults += String.Format("RunRestApi:"+
					"  {0,8:#0.0000}ms,"+
					"  {1,8:#0.0000}ms,"+
					"  {2,8:#0.0000}ms,"+
					"  {3,8:#0.0000}ms\n",
					t0, t1, t2, t3
				);
			}

			VerifyJson(json);

			if ( VerifyGraphJson ) {
				Assert.True(Regex.IsMatch(json, RestApiDataPattern), "Incorrect data.");
			}
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void VerifyJson(string pJson) {
			//Log.Debug("JSON: "+pJson);
			//Log.Debug("SIZE: "+pJson.Length);
			Assert.True(Regex.IsMatch(pJson, VerifyJsonPatternA), "Incorrect data A.");
			Assert.True(Regex.IsMatch(pJson, VerifyJsonPatternB), "Incorrect data B.");
		}
		
	}

}