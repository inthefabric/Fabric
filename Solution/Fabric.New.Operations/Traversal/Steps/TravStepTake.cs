﻿using Fabric.New.Infrastructure.Faults;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepTake<TFrom> : TravStep<TFrom, TFrom> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepTake() : base("Take") {
			var p = new TravStepParam(0, "Count", typeof(int));
			p.Min = 1;
			p.Max = 100;
			Params.Add(p);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath) {
			ITravPathItem item = ConsumeFirstPathItem(pPath);
			int count = item.ParamAt<int>(0);
			ITravStepParam p = Params[0];
			
			if ( count < p.Min || count > p.Max ) {
				throw item.NewStepFault(FabFault.Code.IncorrectParamValue,
					p.Name+" cannot be less than "+p.Min+" or greater than "+p.Max+".", 0);
			}

			pPath.AddScript("["+count+"]");
		}

	}

}