using System.Collections.Generic;

namespace Fabric.New.Operations.Traversal.Util {

	/*================================================================================================*/
	public static class GremlinUtil {

		public const string GreaterThan = "gt";
		public const string GreaterThanOrEqual = "gte";
		public const string LessThan = "lt";
		public const string LessThanOrEqual = "lte";
		public const string Equal = "eq";
		public const string NotEqual = "neq";

		//private const string CompareNamespace = "com.tinkerpop.blueprints.Query.Compare.";
		//private const string TextNamespace = "com.thinkaurelius.titan.core.attribute.Text.";

		private static readonly IDictionary<string, string> ElasticComp = NewElasticCompareMap();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IList<string> GetOperationCodes() {
			return new List<string> {
				GreaterThan,
				GreaterThanOrEqual,
				LessThan,
				LessThanOrEqual,
				Equal,
				NotEqual,
			};
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static string GetStandardCompareOperation(string pCode) {
			return "Tokens.T."+pCode;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string GetElasticCompareOperation(string pCode) {
			return ElasticComp[pCode];
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string GetElasticContainsOperation() {
			return "CONTAINS";
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IDictionary<string, string> NewElasticCompareMap() {
			var map = new Dictionary<string, string>();
			map.Add(GreaterThan, "GREATER_THAN");
			map.Add(GreaterThanOrEqual, "GREATER_THAN_EQUAL");
			map.Add(LessThan, "LESS_THAN");
			map.Add(LessThanOrEqual, "LESS_THAN_EQUAL");
			map.Add(Equal, "EQUAL");
			map.Add(NotEqual, "NOT_EQUAL");
			return map;
		}

	}

}