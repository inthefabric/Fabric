using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Traversal;
using Weaver.Core.Query;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public abstract partial class ExactIndexFunc : IndexFunc { //TEST: ExactIndexFunc


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected ExactIndexFunc(IPath pPath) : base(pPath) {
			Path.AddSegment(this, "V");
		}

		/*--------------------------------------------------------------------------------------------*/
		private static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabRoot));
		}

	}


	/*================================================================================================*/
	public abstract partial class ExactIndexFunc<T> : ExactIndexFunc {

		[FuncParam(0)]
		protected T Value { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected ExactIndexFunc(IPath pPath) : base(pPath) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void AppendPathSegment() {
			string pp = Path.AddParam(new WeaverQueryVal(PropName));
			string ip = Path.AddParam(new WeaverQueryVal(Value));
			Path.AppendToCurrentSegment("("+pp+","+ip+")", false);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void GetValue() {
			ExpectParamCount(1);
			Value = ParamAt<T>(0);
		}

	}

}