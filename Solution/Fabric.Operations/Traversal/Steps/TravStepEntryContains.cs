using System;
using Fabric.Api.Objects;
using Fabric.Api.Objects.Traversal;
using Fabric.Infrastructure.Spec;
using Fabric.Operations.Traversal.Routing;
using Fabric.Operations.Traversal.Util;

namespace Fabric.Operations.Traversal.Steps {

	/*================================================================================================*/
	[SpecStep("WhereContains")]
	public class TravStepEntryContains<TFrom, TTo> : TravStep<TFrom, TTo>
												where TFrom : FabTravTypedRoot where TTo : FabVertex {

		private readonly string vPropDbName;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepEntryContains(string pCmd, string pPropDbName) : base(pCmd) {
			vPropDbName = pPropDbName;
			Params.Add(new TravStepParam(0, "Tokens", typeof(string)));
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath, Type pToType) {
			ITravPathItem item = ConsumeFirstPathItem(pPath, pToType);
			string val = ParamAt<string>(item, 0);

			pPath.AddScript(
				".has("+
					pPath.AddParam(vPropDbName)+", "+
					GremlinUtil.GetElasticContainsOperation()+", "+
					pPath.AddParam(val)+
				")"
			);

			TravStepEntry.AddLimit(pPath);
		}

	}

}