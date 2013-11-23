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
		protected override string GetGremlinOp(string pOp) {
			return GremlinUtil.GetElasticCompareOperation(pOp);
		}

	}

}