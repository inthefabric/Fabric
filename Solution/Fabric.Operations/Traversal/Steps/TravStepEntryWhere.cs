using System;
using Fabric.Api.Objects;
using Fabric.Api.Objects.Traversal;
using Fabric.Operations.Traversal.Routing;
using Fabric.Operations.Traversal.Util;

namespace Fabric.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepEntryWhere<TFrom, TVal, TTo> : TravStepWhere<TFrom, TVal, TTo> 
												where TFrom : FabTravTypedRoot where TTo : FabVertex {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepEntryWhere(string pCmd, string pPropDbName) : base(pCmd, pPropDbName) {}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath, Type pToType) {
			base.ConsumePath(pPath, pToType);
			TravStepEntry.AddTypeFilterIfNecessary(pPath, ToType, pToType);
			TravStepEntry.AddLimit(pPath);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override string GetGremlinOp(string pOp) {
			return GremlinUtil.GetElasticCompareOperation(pOp);
		}

	}

}