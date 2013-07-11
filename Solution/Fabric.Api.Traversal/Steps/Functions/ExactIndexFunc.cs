using System;
using Fabric.Api.Dto.Traversal;
using Weaver.Core.Query;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public abstract partial class ExactIndexFunc : IndexFunc { //TEST: ExactIndexFunc


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected ExactIndexFunc(IPath pPath) : base(pPath) {}

		/*--------------------------------------------------------------------------------------------*/
		private static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabRoot));
		}

	}


	/*================================================================================================*/
	public abstract partial class ExactIndexFunc<T> : ExactIndexFunc {

		protected T IdParam { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected ExactIndexFunc(IPath pPath) : base(pPath) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void  AppendPathSegment() {
			string pp = Path.AddParam(new WeaverQueryVal(PropName));
			string ip = Path.AddParam(new WeaverQueryVal(IdParam));
			Path.AppendToCurrentSegment("("+pp+","+ip+")", false);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void GetValue() {
			ExpectParamCount(1);
			IdParam = Data.ParamAt<T>(0);
		}

	}

}