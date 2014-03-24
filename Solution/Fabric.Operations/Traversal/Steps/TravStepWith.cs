using System;
using Fabric.Api.Objects;
using Fabric.Infrastructure.Spec;
using Fabric.Operations.Traversal.Routing;
using Fabric.Operations.Traversal.Util;

namespace Fabric.Operations.Traversal.Steps {

	/*================================================================================================*/
	[SpecStep("With")]
	public class TravStepWith<TFrom, TVal, TTo> : TravStep<TFrom, TTo> 
														where TFrom : FabObject where TTo : FabElement {
		
		public Func<TVal, TVal> UpdateValue { get; set; }

		private readonly string vPropDbName;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepWith(string pCmd, string pPropDbName) : base(pCmd) {
			vPropDbName = pPropDbName;
			ParamValueType = typeof(TVal);
			Params.Add(new TravStepParam(0, "Value", ParamValueType) { IsGenericDataType = true });
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath, Type pToType) {
			ITravPathItem item = ConsumeFirstPathItem(pPath, pToType);
			TVal val = ParamAt<TVal>(item, 0);

			if ( UpdateValue != null ) {
				val = UpdateValue(val);
			}

			pPath.AddScript(
				".has("+
					pPath.AddParam(vPropDbName)+", "+
					GetGremlinEqualOp()+", "+
					pPath.AddParam(val)+
				")"
			);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected virtual string GetGremlinEqualOp() {
			return GremlinUtil.GetStandardCompareOperation(GremlinUtil.Equal);
		}

	}

}