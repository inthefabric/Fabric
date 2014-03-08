using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Operations.Traversal.Util;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepEntryWith<TFrom, TVal, TTo> : TravStepWith<TFrom, TVal, TTo> 
												where TFrom : FabTravTypedRoot where TTo : FabVertex {

		private readonly bool vToLower;

		//TODO: in all entry steps, also check for VERTEX TYPE when searching via a 
		//a property defined at the vertex or artifact level. Otherwise, a traversal like 
		//"Apps/WithId(2)" could return a User.


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
		protected override string GetGremlinEqualOp() {
			return GremlinUtil.GetElasticCompareOperation(GremlinUtil.Equal);
		}

	}

}