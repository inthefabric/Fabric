using System;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Operations.Traversal.Routing;
using Fabric.New.Operations.Traversal.Util;

namespace Fabric.New.Operations.Traversal.Steps {

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