using System;
using System.IO;
using Fabric.Api.Traversal.Steps;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiTraversal.Steps {

	/*================================================================================================*/
	[TestFixture]
	public class TStepData {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("test", "test", null)]
		[TestCase("A12_34B-c( 1 )", "a12_34b-c", new[] { "1" })]
		[TestCase("abcdEFG(hijkLMNOP)", "abcdefg", new[] { "hijkLMNOP" })]
		[TestCase("ABCDefg(hijklmnop,  QRS,   tuv,W,x    y, z)", "abcdefg", 
			new[] { "hijklmnop", "QRS", "tuv", "W", "x    y", "z" })]
		public void New(string pRawString, string pCommand, string[] pParams) {
			var sd = new StepData(pRawString);

			Assert.AreEqual(pRawString, sd.RawString, "Incorrect RawString.");
			Assert.AreEqual(pCommand, sd.Command, "Incorrect Command.");
			Assert.AreEqual(pParams, sd.Params, "Incorrect Params.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("(")]
		[TestCase(")")]
		[TestCase("()")]
		[TestCase("))")]
		[TestCase("((")]
		[TestCase(")(")]
		[TestCase("x(")]
		[TestCase("x)")]
		[TestCase("x((")]
		[TestCase("x))")]
		[TestCase("x()")]
		[TestCase("x()x")]
		[TestCase("x(2)x")]
		[TestCase("x)2)")]
		[TestCase("x(2(")]
		[TestCase("x)2(")]
		public void NewInvalidParam(string pRawString) {
			TestUtil.CheckThrows<FabStepDataFault>(true, () => new StepData(pRawString));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("x(123, abc)", 0, 123)]
		[TestCase("x(abcdefg, 1234567890)", 1, 1234567890)]
		public void ParamAtLong(string pRawString, int pIndex, long pExpectValue) {
			var sd = new StepData(pRawString);
			Assert.AreEqual(pExpectValue, sd.ParamAt<long>(pIndex), "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("x(123, abc)", 0, 123)]
		[TestCase("x(abcdefg, 1234567890)", 1, 1234567890)]
		public void ParamAtInt(string pRawString, int pIndex, int pExpectValue) {
			var sd = new StepData(pRawString);
			Assert.AreEqual(pExpectValue, sd.ParamAt<int>(pIndex), "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("x(123, abc)", 0, 123)]
		[TestCase("x(abcdefg, 9)", 1, 9)]
		public void ParamAtint(string pRawString, int pIndex, int pExpectValue) {
			var sd = new StepData(pRawString);
			Assert.AreEqual(pExpectValue, sd.ParamAt<int>(pIndex), "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("x(123, abc)", 1, "abc")]
		[TestCase("x(aBcdefg, 9)", 0, "aBcdefg")]
		public void ParamAtString(string pRawString, int pIndex, string pExpectValue) {
			var sd = new StepData(pRawString);
			Assert.AreEqual(pExpectValue, sd.ParamAt<string>(pIndex), "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("x(true, abc)", 0, true)]
		[TestCase("x(True, abc)", 0, true)]
		[TestCase("x(TRUE, abc)", 0, true)]
		[TestCase("x(abcdefg, false)", 1, false)]
		[TestCase("x(abcdefg, False)", 1, false)]
		[TestCase("x(abcdefg, FALSE)", 1, false)]
		public void ParamAtBool(string pRawString, int pIndex, bool pExpectValue) {
			var sd = new StepData(pRawString);
			Assert.AreEqual(pExpectValue, sd.ParamAt<bool>(pIndex), "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("x(123.456, abc)", 0, 123.456f)]
		[TestCase("x(abcdefg, 12345.67890)", 1, 12345.67890f)]
		public void ParamAtFloat(string pRawString, int pIndex, float pExpectValue) {
			var sd = new StepData(pRawString);
			Assert.AreEqual(pExpectValue, sd.ParamAt<float>(pIndex), "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("x(123.4567890123456789, abc)", 0, 123.4567890123456789)]
		[TestCase("x(abcdefg, 12345.67890)", 1, 12345.67890)]
		public void ParamAtDouble(string pRawString, int pIndex, double pExpectValue) {
			var sd = new StepData(pRawString);
			Assert.AreEqual(pExpectValue, sd.ParamAt<double>(pIndex), "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0, "a")]
		[TestCase(1, "b")]
		[TestCase(2, "c")]
		[TestCase(3, "d")]
		[TestCase(4, "e")]
		[TestCase(5, "f")]
		[TestCase(6, "g")]
		public void ParamAtIndex(int pIndex, string pExpectValue) {
			var sd = new StepData("x(a,b,c,d,e,f,g)");
			Assert.AreEqual(pExpectValue, sd.ParamAt<string>(pIndex), "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(-1)]
		[TestCase(7)]
		public void ParamAtIndexRangeFail(int pIndex) {
			var sd = new StepData("x(a,b,c,d,e,f,g)");
			TestUtil.CheckThrows<ArgumentOutOfRangeException>(true, () => sd.ParamAt<string>(pIndex));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ParamAtNoParams() {
			var sd = new StepData("test");
			TestUtil.CheckThrows<InvalidDataException>(true, () => sd.ParamAt<string>(0));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ParamAtConvertFail() {
			var sd = new StepData("x(text)");
			TestUtil.CheckThrows<InvalidCastException>(true, () => sd.ParamAt<int>(0));
		}

	}

}