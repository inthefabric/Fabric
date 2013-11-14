using System;
using Fabric.New.Api.Objects;
using Fabric.New.Infrastructure.Faults;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepTake<TFrom, TTo> : TravStep<TFrom, TTo> 
													where TFrom : FabElement where TTo : FabElement {

		private readonly bool vInVertex;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepTake(string pName, bool pInVertex) : base(pName) {
			vInVertex = pInVertex;

			var p = new TravStepParam(0, "Count", typeof(int));
			p.Min = 1;
			p.Max = 100;
			Params.Add(p);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath, Type pToType) {
			ITravPathItem item = ConsumeFirstPathItem(pPath, pToType);
			int count = item.ParamAt<int>(0);
			ITravStepParam p = Params[0];
			
			if ( count < p.Min || count > p.Max ) {
				throw item.NewStepFault(FabFault.Code.IncorrectParamValue,
					p.Name+" cannot be less than "+p.Min+" or greater than "+p.Max+".", 0);
			}

			pPath.AddScript("["+count+"]"+(vInVertex ? ".inV" : ""));
		}

	}

}