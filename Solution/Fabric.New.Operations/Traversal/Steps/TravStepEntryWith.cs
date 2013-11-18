using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Operations.Traversal.Util;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepEntryWith<TFrom, TVal, TTo> : TravStepWith<TFrom, TVal, TTo> 
												where TFrom : FabTravTypedRoot where TTo : FabVertex {

		private readonly bool vToLower;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepEntryWith(string pCmd, string pPropDbName, bool pToLower) : 
																			base(pCmd, pPropDbName) {
			vToLower = pToLower;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override TVal UpdateValue(TVal pVal) {
			if ( vToLower ) {
				var valStr = (pVal as string);

				if ( valStr != null ) {
					pVal = (TVal)(object)valStr.ToLower();
				}
			}
			
			return pVal;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override string GetGremlinOp(string pOp) {
			return GremlinUtil.GetElasticCompareOperation(pOp);
		}

	}

}