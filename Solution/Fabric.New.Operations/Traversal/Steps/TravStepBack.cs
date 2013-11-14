using System;
using Fabric.New.Api.Objects;
using Fabric.New.Infrastructure.Faults;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepBack : TravStep<FabElement, FabElement> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepBack() : base("Back") {
			ToAliasType = true;
			Params.Add(TravStepAs.GetParam());
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath, Type pToType) {
			ITravPathItem item = ConsumeFirstPathItem(pPath, pToType);
			string alias = item.ParamAt<string>(0);
			ITravStepParam p = Params[0];
			string conflictAlias;

			TravStepAs.ValidateAlias(item, p, alias);

			if ( !pPath.HasAlias(alias) ) {
				throw item.NewStepFault(FabFault.Code.IncorrectParamValue, 
					p.Name+" '"+alias+"' could not be found.", 0);
			}

			if ( pPath.AllowBackToAlias(alias, out conflictAlias) ) {
				throw item.NewStepFault(FabFault.Code.IncorrectParamValue, "Cannot traverse back to "+
					"the As("+alias+") step; it exists within the As("+conflictAlias+") and "+
					"Back("+conflictAlias+") traversal path.", 0);
			}

			pPath.AddBackToAlias(alias);
			pPath.AddScript(".back("+pPath.AddParam(alias)+")");
		}

	}

}