﻿using System;
using Fabric.Api.Objects;
using Fabric.Infrastructure.Spec;
using Fabric.Operations.Traversal.Routing;
using Fabric.Operations.Traversal.Util;

namespace Fabric.Operations.Traversal.Steps {

	/*================================================================================================*/
	[SpecStep("Where")]
	public class TravStepWhere<TFrom, TVal, TTo> : TravStep<TFrom, TTo>
													where TFrom : FabObject where TTo : FabElement {

		public Func<TVal, TVal> UpdateValue { get; set; }

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
			string op = ParamAt<string>(item, 0);
			TVal val = ParamAt<TVal>(item, 1);

			if ( UpdateValue != null ) {
				val = UpdateValue(val);
			}

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