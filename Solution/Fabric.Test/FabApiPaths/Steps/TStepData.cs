using System;
using Fabric.Api.Paths.Steps;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiPaths.Steps {

	/*================================================================================================*/
	[TestFixture]
	public class TStepData {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("test", "test", null)]
		[TestCase("A12_34B-c( 1 )", "a12_34b-c", new[] { "1" })]
		[TestCase("abcdEFG(hijkLMNOP)", "abcdefg", new[] { "hijkLMNOP" })]
		[TestCase("ABCDefg(hijklmnop,  QRS,   tuv,W,x			 y, z)", "abcdefg", 
			new[] { "hijklmnop", "QRS", "tuv", "W", "xy", "z" })]
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
			TestUtil.CheckThrows<Exception>(true, () => new StepData(pRawString));
		}

	}

}