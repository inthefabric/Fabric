using System;
using Fabric.Api.Dto;

namespace Fabric.Api.Paths.Steps.Nodes {
	
	/*================================================================================================*/
	public abstract class NodeStep<T> : Step<T> where T : FabNode, new() {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override StepData Data {
			set {
				base.Data = value;

				string p = Data.Params[0];
				long tid;

				if ( long.TryParse(p, out tid) ) {
					TypeId = tid;
				}
				else {
					throw new Exception("Cannot convert parameter '"+p+"' to 'long'.");
				}

				Path.Add("has('"+TypeIdName+"',Tokens.T.eq,"+TypeId+(TypeIdIsLong ? "L" : "")+")");
			}
		}

	}

}