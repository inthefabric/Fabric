using System;
using Fabric.New.Api.Objects;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Infrastructure.Spec;
using Fabric.New.Operations.Traversal.Routing;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	[SpecStep("As")]
	public class TravStepAs : TravStep<FabElement, FabElement> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepAs() : base("As") {
			Params.Add(GetAliasParam());
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath, Type pToType) {
			ITravPathItem item = ConsumeFirstPathItem(pPath, pToType);
			string alias = ParamAt<string>(item, 0);
			ITravStepParam p = Params[0];

			if ( pPath.HasAlias(alias) ) {
				throw item.NewStepFault(FabFault.Code.IncorrectParamValue, 
					p.Name+" '"+alias+"' is already in use.", 0);
			}

			pPath.AddAlias(alias);
			pPath.AddScript(".as("+pPath.AddParam(alias)+")");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal static ITravStepParam GetAliasParam() {
			var p = new TravStepParam(0, "Alias", typeof(string));
			p.LenMax = 8;
			p.ValidRegex = "^[a-zA-Z]+[a-zA-Z0-9]*$";
			return p;
		}

	}

}