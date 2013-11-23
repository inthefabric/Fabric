﻿using System;
using Fabric.New.Api.Objects;
using Fabric.New.Infrastructure.Spec;
using Fabric.New.Operations.Traversal.Routing;
using Fabric.New.Operations.Traversal.Util;

namespace Fabric.New.Operations.Traversal.Steps {

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
				UpdateValue(val);
			}

			pPath.AddScript(
				".has("+
					pPath.AddParam(vPropDbName)+", "+
					GetGremlinOp(GremlinUtil.Equal)+", "+
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