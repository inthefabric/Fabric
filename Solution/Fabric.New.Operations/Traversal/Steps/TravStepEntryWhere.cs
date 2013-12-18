using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Operations.Traversal.Util;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepEntryWhere<TFrom, TVal, TTo> : TravStepWhere<TFrom, TVal, TTo> 
												where TFrom : FabTravTypedRoot where TTo : FabVertex {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepEntryWhere(string pCmd, string pPropDbName) : base(pCmd, pPropDbName) {}

		/*--------------------------------------------------------------------------------------------*/
		protected override string GetGremlinOp(string pOp) {
			return GremlinUtil.GetElasticCompareOperation(pOp);
		}

	}

}