using Fabric.New.Infrastructure.Faults;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepHas<TFrom, TVal> : TravStep<TFrom, TFrom> {

		private readonly bool vExact;
		private readonly string vPropDbName;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepHas(string pName, string pPropDbName, bool pExact) : base(pName) {
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
		public override void ConsumePath(ITravPath pPath) {
			ITravPathItem item = ConsumeFirstPathItem(pPath);
			string op = GremlinUtil.Equal;
			int pi = 0;

			if ( !vExact ) {
				op = item.ParamAt<string>(pi);

				if ( !Params[pi].AcceptedStrings.Contains(op) ) {
					throw item.NewStepFault(FabFault.Code.IncorrectParamValue,
						"Invalid "+Params[pi].Name+" value.", pi);
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