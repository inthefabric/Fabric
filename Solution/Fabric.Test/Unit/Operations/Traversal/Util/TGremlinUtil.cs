using System.Collections.Generic;
using Fabric.Operations.Traversal.Util;
using NUnit.Framework;

namespace Fabric.Test.Unit.Operations.Traversal.Util {

	/*================================================================================================*/
	[TestFixture]
	public class TGremlinUtil {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetOperationCodes() {
			IList<string> result = GremlinUtil.GetOperationCodes();
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(6, result.Count, "Incorrect result count.");

			for ( int i = 0 ; i < result.Count ; i++ ) {
				Assert.NotNull(result[i], "Result["+i+"] should be filled.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(GremlinUtil.GreaterThanOrEqual)]
		[TestCase(GremlinUtil.NotEqual)]
		public void GetStandardCompareOperation(string pCode) {
			string result = GremlinUtil.GetStandardCompareOperation(pCode);
			Assert.AreEqual("Tokens.T."+pCode, result, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(GremlinUtil.GreaterThanOrEqual, "GREATER_THAN_EQUAL")]
		[TestCase(GremlinUtil.NotEqual, "NOT_EQUAL")]
		public void GetElasticCompareOperation(string pCode, string pExpect) {
			string result = GremlinUtil.GetElasticCompareOperation(pCode);
			Assert.AreEqual(pExpect, result, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetElasticContainsOperation() {
			string result = GremlinUtil.GetElasticContainsOperation();
			Assert.AreEqual("CONTAINS", result, "Incorrect result.");
		}

	}

}