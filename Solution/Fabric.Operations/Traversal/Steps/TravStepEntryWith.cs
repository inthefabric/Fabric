using System;
using Fabric.Api.Objects;
using Fabric.Api.Objects.Traversal;
using Fabric.Operations.Traversal.Routing;
using Fabric.Operations.Traversal.Util;

namespace Fabric.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepEntryWith<TFrom, TVal, TTo> : TravStepWith<TFrom, TVal, TTo> 
												where TFrom : FabTravTypedRoot where TTo : FabVertex {

		private readonly bool vToLower;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepEntryWith(string pCmd, string pPropDbName, bool pToLower) : 
																			base(pCmd, pPropDbName) {
			vToLower = pToLower;

			UpdateValue = (val => {
				if ( vToLower ) {
					var valStr = (val as string);

					if ( valStr != null ) {
						val = (TVal)(object)valStr.ToLower();
					}
				}
			
				return val;
			});
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath, Type pToType) {
			base.ConsumePath(pPath, pToType);
			TravStepEntry.AddTypeFilterIfNecessary(pPath, ToType, pToType);
			TravStepEntry.AddLimit(pPath);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override string GetGremlinEqualOp() {
			return GremlinUtil.GetStandardCompareOperation(GremlinUtil.Equal);
		}

	}

}