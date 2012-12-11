using System;
using Fabric.Api.Dto;

namespace Fabric.Api.Paths {
	
	/*================================================================================================*/
	public abstract class PathDomainStep<T> : PathStep<T> where T : FabNode, new() {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetParams(string pParams) {
			if ( TypeId != null ) {
				throw new Exception("TypeId already set.");
			}

			long tid;

			if ( long.TryParse(pParams, out tid) ) {
				TypeId = tid;
			}
			else {
				throw new Exception("Cannot convert value '"+pParams+"' to type 'long'.");
			}

			Path.Add("has('"+TypeIdName+"',Tokens.T.eq,"+TypeId+(TypeIdIsLong ? "L" : "")+")");
		}

	}

}