using System;
using System.Collections.Generic;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Traversal;
using Weaver.Core.Query;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public abstract partial class ElasticIndexFunc : IndexFunc {

		public const string CompareNamespace = "com.tinkerpop.blueprints.Query.Compare.";
		public const string TextNamespace = "com.thinkaurelius.titan.core.attribute.Text.";

		protected static readonly IDictionary<string, string> OperationMap = BuildOperationMap();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected ElasticIndexFunc(IPath pPath) : base(pPath) {
			Path.AddSegment(this, "query()"); //TODO: once it's available, update to "V" notation
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void FinishIndexStep() {
			Path.AddSegment(this, "vertices()");
			Path.AddSegment(this, "_()");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabRoot));
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IDictionary<string, string> BuildOperationMap() {
			var map = new Dictionary<string, string>();
			map.Add("gt", CompareNamespace+"GREATER_THAN");
			map.Add("gte", CompareNamespace+"GREATER_THAN_EQUAL");
			map.Add("lt", CompareNamespace+"LESS_THAN");
			map.Add("lte", CompareNamespace+"LESS_THAN_EQUAL");
			map.Add("eq", CompareNamespace+"EQUAL");
			map.Add("neq", CompareNamespace+"NOT_EQUAL");
			return map;
		}

	}


	/*================================================================================================*/
	public abstract partial class ElasticIndexHasFunc<T> : ElasticIndexFunc {

		[FuncParam(0)]
		public string Operation { get; set; }

		[FuncParam(1)]
		public T Value { get; set; }

		private string vGremlinOp { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected ElasticIndexHasFunc(IPath pPath) : base(pPath) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void  AppendPathSegment() {
			string pp = Path.AddParam(new WeaverQueryVal(PropName));
			string vp = Path.AddParam(new WeaverQueryVal(Value));
			Path.AddSegment(this, "has("+pp+","+vGremlinOp+","+vp+")");
			FinishIndexStep();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void GetValue() {
			ExpectParamCount(2);
			Operation = ParamAt<string>(0);
			Value = ParamAt<T>(1);

			string op = Operation.ToLower();

			if ( !OperationMap.ContainsKey(op) ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamValue, this, "Invalid operation "+
					"argument: "+Operation+". Valid operations: "+
					String.Join(", ", OperationMap.Keys), 0);
			}

			vGremlinOp = OperationMap[op];
		}

	}
	

	/*================================================================================================*/
	public abstract partial class ElasticIndexContainsFunc : ElasticIndexFunc { //TEST: ElasticIndexContainsFunc

		[FuncParam(0)]
		public string Tokens { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected ElasticIndexContainsFunc(IPath pPath) : base(pPath) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void  AppendPathSegment() {
			string[] tokenList = Tokens.Replace('-', ' ').Split(' ');
			string pp = Path.AddParam(new WeaverQueryVal(PropName));

			foreach ( string t in tokenList ) {
				string tp = Path.AddParam(new WeaverQueryVal(t));
				Path.AddSegment(this, "has("+pp+","+TextNamespace+"CONTAINS,"+tp+")");
			}

			FinishIndexStep();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void GetValue() {
			ExpectParamCount(1);
			Tokens = ParamAt<string>(0);
		}

	}

}