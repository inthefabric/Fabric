using System;
using Fabric.New.Api.Objects;
using Fabric.New.Infrastructure.Faults;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepHas<TFrom, TVal> : TravStep<TFrom, TFrom> where TFrom : FabElement {

		private readonly bool vExact;
		private readonly string vPropDbName;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepHas(string pCmd, string pPropDbName, bool pExact) : base(pCmd) {
			vExact = pExact;
			vPropDbName = pPropDbName;
			int pi = 0;

			if ( !vExact ) {
				var op = new TravStepParam(pi++, "Operation", typeof(string));
				op.AcceptedStrings = GremlinUtil.GetOperationCodes();
				Params.Add(op);
			}

			Params.Add(new TravStepParam(pi, "Value", typeof(TVal)));
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath, Type pToType) {
			ITravPathItem item = ConsumeFirstPathItem(pPath, pToType);
			string op = GremlinUtil.Equal;
			int pi = 0;

			if ( !vExact ) {
				op = item.ParamAt<string>(pi);

				if ( !Params[pi].AcceptedStrings.Contains(op) ) {
					throw item.NewStepFault(FabFault.Code.IncorrectParamValue,
						"Invalid "+Params[pi].Name+" value. Accepted values: "+
						string.Join(", ", Params[pi].AcceptedStrings)+".", pi);
				}

				pi++;
			}

			TVal val = item.ParamAt<TVal>(pi);

			pPath.AddScript(
				".has("+
					pPath.AddParam(vPropDbName)+", "+
					GremlinUtil.GetStandardCompareOperation(op)+", "+
					pPath.AddParam(val)+
				")"
			);
		}

	}

}