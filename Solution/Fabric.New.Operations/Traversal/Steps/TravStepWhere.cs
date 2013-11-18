﻿using System;
using Fabric.New.Api.Objects;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Infrastructure.Spec;
using Fabric.New.Operations.Traversal.Routing;
using Fabric.New.Operations.Traversal.Util;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	[SpecStep("Where")]
	public class TravStepWhere<TFrom, TVal, TTo> : TravStep<TFrom, TTo>
													where TFrom : FabObject where TTo : FabElement {

		private readonly string vPropDbName;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepWhere(string pCmd, string pPropDbName) : base(pCmd) {
			vPropDbName = pPropDbName;

			var op = new TravStepParam(0, "Operation", typeof(string));
			op.AcceptedStrings = GremlinUtil.GetOperationCodes();
			Params.Add(op);

			ParamValueType = typeof(TVal);
			Params.Add(new TravStepParam(1, "Value", ParamValueType) { IsGenericDataType = true });
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath, Type pToType) {
			ITravPathItem item = ConsumeFirstPathItem(pPath, pToType);
			ITravStepParam p0 = Params[0];
			string op = item.ParamAt<string>(0);

			if ( !p0.AcceptedStrings.Contains(op) ) {
				throw item.NewStepFault(FabFault.Code.IncorrectParamValue,
					"Invalid "+p0.Name+" value. Accepted values: "+
					string.Join(", ", p0.AcceptedStrings)+".", 0);
			}

			TVal val = item.ParamAt<TVal>(1);

			pPath.AddScript(
				".has("+
					pPath.AddParam(vPropDbName)+", "+
					GetGremlinOp(op)+", "+
					pPath.AddParam(val)+
				")"
			);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected virtual string GetGremlinOp(string pOp) {
			return GremlinUtil.GetStandardCompareOperation(pOp);
		}

	}

}