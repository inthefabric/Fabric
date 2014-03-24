using System;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Traversal.Routing;
using Fabric.New.Test.Unit.Shared;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Traversal.Routing {

	/*================================================================================================*/
	[TestFixture]
	public class TTravPathItem {

		private static readonly Logger Log = Logger.Build<TTravPathItem>();

		private const string Raw = "MyPath";
		private const string RawParams0 = "MyPath()";
		private const string RawParams1 = "MyPath(1)";
		private const string RawParams4 = "MyPath(1,ab,cd,4)";
		private const string RawParamTypes = 
			"MyPath(MyText, 123, 1234123412341234, 9.876, 12345678.876543210123456, false)";

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(Raw, "mypath")]
		[TestCase(RawParams0, "mypath")]
		[TestCase(RawParams4, "mypath")]
		public void New(string pRaw, string pExpectCommmand) {
			const int stepIndex = 123;

			var pi = new TravPathItem(stepIndex, pRaw);

			Assert.AreEqual(stepIndex, pi.StepIndex, "Incorrect StepIndex.");
			Assert.AreEqual(pRaw, pi.RawText, "Incorrect RawText.");
			Assert.AreEqual(pExpectCommmand, pi.Command, "Incorrect Command.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("")]
		[TestCase("   ")]
		[TestCase("()")]
		[TestCase("()  ")]
		[TestCase("  ()")]
		[TestCase("(1,2,3)")]
		[TestCase("  (1,2,3)  ")]
		public void NewErrorCommand(string pRaw) {
			FabStepFault f = TestUtil.Throws<FabStepFault>(() => new TravPathItem(123, pRaw));
			Assert.AreEqual(FabFault.Code.InvalidStep, f.ErrCode, "Incorrect ErrCode.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("x(")]
		[TestCase("x()x")]
		[TestCase("x(x)x")]
		public void NewErrorParamFormat(string pRaw) {
			FabStepFault f = TestUtil.Throws<FabStepFault>(() => new TravPathItem(123, pRaw));
			Assert.AreEqual(FabFault.Code.InvalidParamSyntax, f.ErrCode, "Incorrect ErrCode.");
			Assert.AreNotEqual(-1, f.Message.IndexOf("format"), "Incorrect message.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("x(1,)")]
		[TestCase("x(1,2,)")]
		[TestCase("x(1,,3)")]
		public void NewErrorParamEmpty(string pRaw) {
			FabStepFault f = TestUtil.Throws<FabStepFault>(() => new TravPathItem(123, pRaw));
			Assert.AreEqual(FabFault.Code.InvalidParamSyntax, f.ErrCode, "Incorrect ErrCode.");
			Assert.AreNotEqual(-1, f.Message.IndexOf("empty"), "Incorrect message.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(Raw, 0)]
		[TestCase(RawParams0, 0)]
		[TestCase(RawParams1, 1)]
		[TestCase(RawParams4, 4)]
		public void GetParamCount(string pRaw, int pExpectCount) {
			const int stepIndex = 123;

			var pi = new TravPathItem(stepIndex, pRaw);
			int result = pi.GetParamCount();

			Assert.AreEqual(pExpectCount, result, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(Raw, 0, 0, false)]
		[TestCase(Raw, 0, 1, false)]
		[TestCase(Raw, 0, -1, false)]
		[TestCase(Raw, 1, 2, true)]
		[TestCase(RawParams1, 1, 1, false)]
		[TestCase(RawParams1, 0, 1, false)]
		[TestCase(RawParams1, 1, 2, false)]
		[TestCase(RawParams1, 0, 2, false)]
		[TestCase(RawParams1, 1, -1, false)]
		[TestCase(RawParams1, 0, -1, true)]
		[TestCase(RawParams1, 2, 2, true)]
		[TestCase(RawParams1, 2, -1, true)]
		[TestCase(RawParams4, 4, 4, false)]
		[TestCase(RawParams4, 2, 6, false)]
		[TestCase(RawParams4, 6, 10, true)]
		[TestCase(RawParams4, 6, -1, true)]
		[TestCase(RawParams4, 0, 3, true)]
		public void VerifyParamCount(string pRaw, int pMin, int pMax, bool pError) {
			var pi = new TravPathItem(123, pRaw);
			FabStepFault f = TestUtil.CheckThrows<FabStepFault>(
				pError, () => pi.VerifyParamCount(pMin, pMax));

			if ( f != null ) {
				Assert.AreEqual(FabFault.Code.IncorrectParamCount, f.ErrCode, "Incorrect ErrCode.");
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0, "MyText")]
		[TestCase(1, "123")]
		[TestCase(2, "1234123412341234")]
		[TestCase(3, "9.876")]
		[TestCase(4, "12345678.876543210123456")]
		[TestCase(5, "false")]
		public void GetParamAtString(int pIndex, string pExpectResult) {
			var pi = new TravPathItem(123, RawParamTypes);
			string result = pi.GetParamAt<string>(pIndex);
			Assert.AreEqual(pExpectResult, result, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CheckGetParamAt<T>(int pIndex, T pExpectResult, bool pExpectError) {
			var pi = new TravPathItem(123, RawParamTypes);
			T result = default(T);

			FabStepFault f = TestUtil.CheckThrows<FabStepFault>(pExpectError, () => {
				result = pi.GetParamAt<T>(pIndex);
			});

			if ( pExpectError ) {
				Assert.AreEqual(FabFault.Code.IncorrectParamType, f.ErrCode, "Incorrect ErrCode.");
			}
			else {
				Log.Debug("Result: "+result);
				Assert.AreEqual(pExpectResult, result, "Incorrect result.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0, null)]
		[TestCase(1, 123)]
		[TestCase(2, null)]
		[TestCase(3, null)]
		[TestCase(4, null)]
		[TestCase(5, null)]
		public void GetParamAtInt(int pIndex, int? pExpectResult) {
			CheckGetParamAt(pIndex, (pExpectResult ?? -1), (pExpectResult == null));
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0, null)]
		[TestCase(1, 123L)]
		[TestCase(2, 1234123412341234)]
		[TestCase(3, null)]
		[TestCase(4, null)]
		[TestCase(5, null)]
		public void GetParamAtLong(int pIndex, long? pExpectResult) {
			CheckGetParamAt(pIndex, (pExpectResult ?? -1), (pExpectResult == null));
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0, null)]
		[TestCase(1, 123.0f)]
		[TestCase(2, 1234123412341234.0f)]
		[TestCase(3, 9.876f)]
		[TestCase(4, 12345679.0f)]
		[TestCase(5, null)]
		public void GetParamAtFloat(int pIndex, float? pExpectResult) {
			CheckGetParamAt(pIndex, (pExpectResult ?? -1), (pExpectResult == null));
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0, null)]
		[TestCase(1, 123.0d)]
		[TestCase(2, 1234123412341234.0d)]
		[TestCase(3, 9.876d)]
		[TestCase(4, 12345678.87654321d)]
		[TestCase(5, null)]
		public void GetParamAtDouble(int pIndex, double? pExpectResult) {
			CheckGetParamAt(pIndex, (pExpectResult ?? -1), (pExpectResult == null));
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0, null)]
		[TestCase(1, null)]
		[TestCase(2, null)]
		[TestCase(3, null)]
		[TestCase(4, null)]
		[TestCase(5, false)]
		public void GetParamAtBool(int pIndex, bool? pExpectResult) {
			CheckGetParamAt(pIndex, (pExpectResult ?? false), (pExpectResult == null));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(-1, null)]
		[TestCase(1, "123")]
		public void NewStepFault(int pParamI, string pExpectRawParam) {
			const FabFault.Code code = FabFault.Code.InvalidStep;
			const string msg = "My Error Message.";
			var innerEx = new Exception("Inner!");
			const int stepIndex = 4;

			var pi = new TravPathItem(stepIndex, RawParamTypes);
			FabStepFault result = pi.NewStepFault(code, msg, pParamI, innerEx);

			Log.Debug("Message:\n\n"+result.Message);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(code, result.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(0, result.Message.IndexOf(msg), "Incorrect Message.");
			Assert.AreEqual(stepIndex, result.StepIndex, "Incorrect StepIndex.");
			Assert.AreEqual(RawParamTypes, result.StepText, "Incorrect StepText.");
			Assert.AreEqual(pParamI, result.ParamIndex, "Incorrect ParamIndex.");
			Assert.AreEqual(pExpectRawParam, result.ParamText, "Incorrect ParamText.");
		}

	}

}