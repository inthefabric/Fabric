using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepEntryContains<TFrom, TTo> : TravStep<TFrom, TTo>
												where TFrom : FabTravTypedRoot where TTo : FabVertex {

		private readonly string vPropDbName;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepEntryContains(string pName, string pPropDbName) : base(pName) {
			vPropDbName = pPropDbName;
			Params.Add(new TravStepParam(0, "Tokens", typeof(string)));
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath) {
			ITravPathItem item = ConsumeFirstPathItem(pPath);
			string val = item.ParamAt<string>(0);

			pPath.AddScript(
				".has("+
					pPath.AddParam(vPropDbName)+", "+
					GremlinUtil.GetElasticContainsOperation()+", "+
					pPath.AddParam(val)+
				")"
			);
		}

	}

}