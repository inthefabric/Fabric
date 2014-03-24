using System;
using Fabric.New.Api.Objects;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Infrastructure.Spec;
using Fabric.New.Operations.Traversal.Routing;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	[SpecStep("Back")]
	public class TravStepBack : TravStep<FabElement, FabElement> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepBack() : base("Back") {
			ToAliasType = true;
			Params.Add(TravStepAs.GetAliasParam());
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath, Type pIgnoredToType) {
			ITravPathItem item = ConsumeFirstPathItem(pPath, ToType);
			string alias = ParamAt<string>(item, 0);
			ITravStepParam p = Params[0];
			string conflictAlias;

			if ( !pPath.HasAlias(alias) ) {
				throw item.NewStepFault(FabFault.Code.IncorrectParamValue, 
					p.Name+" '"+alias+"' could not be found.", 0);
			}

			if ( pPath.DoesBackTouchAs(alias) ) {
				throw item.NewStepFault(FabFault.Code.InvalidStep,
					"Back('"+alias+"') cannot occur directly after the As("+alias+").", 0);
			}

			if ( !pPath.AllowBackToAlias(alias, out conflictAlias) ) {
				throw item.NewStepFault(FabFault.Code.InvalidStep, "Cannot traverse back to "+
					"the As("+alias+") step; it exists within the As("+conflictAlias+") and "+
					"Back("+conflictAlias+") traversal path.", 0);
			}

			pPath.AddBackToAlias(alias);
			pPath.AddScript(".back("+pPath.AddParam(alias)+")");
		}

	}

}