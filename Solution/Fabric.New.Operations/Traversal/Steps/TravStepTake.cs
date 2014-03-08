using System;
using Fabric.New.Api.Objects;
using Fabric.New.Infrastructure.Spec;
using Fabric.New.Operations.Traversal.Routing;

namespace Fabric.New.Operations.Traversal.Steps {
	
	/*================================================================================================*/
	public static class TravStepTake {

		public const int Maximum = 100;

	}


	/*================================================================================================*/
	[SpecStep("Take")]
	public class TravStepTake<TFrom, TTo> : TravStep<TFrom, TTo> 
													where TFrom : FabElement where TTo : FabElement {

		private readonly bool vInVertex;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepTake(string pCmd, bool pInVertex) : base(pCmd) {
			vInVertex = pInVertex;

			var p = new TravStepParam(0, "Count", typeof(int));
			p.Min = 1;
			p.Max = TravStepTake.Maximum;
			Params.Add(p);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath, Type pToType) {
			ITravPathItem item = ConsumeFirstPathItem(pPath, pToType);
			int count = ParamAt<int>(item, 0);

			pPath.AddScript(
				"[0.."+(count-1)+"]"+ //range is inclusive
				(vInVertex ? ".inV" : "")
			);
		}

	}

}