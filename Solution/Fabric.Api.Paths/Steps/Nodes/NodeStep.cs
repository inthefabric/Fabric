using System;
using Fabric.Api.Dto;

namespace Fabric.Api.Paths.Steps.Nodes {
	
	/*================================================================================================*/
	public abstract class NodeStep<T> : Step<T> where T : FabNode, new() {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected NodeStep(Path pPath) : base(pPath) {}

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

				Path.AppendToCurrentSegment(
					"has('"+TypeIdName+"',Tokens.T.eq,"+TypeId+(TypeIdIsLong ? "L" : "")+")");
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void AddPathSegment(string pScript) {
			Path.AddSegment(this, pScript);
			AppendPathSegmentDetails();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void AppendPathSegmentDetails() { }

		/*--------------------------------------------------------------------------------------------* /
		public T NewFabDto(DbDto pDbDto) {
			T dto = new T();
			dto.Fill(pDbDto);
			return dto;
		}

		/*--------------------------------------------------------------------------------------------* /
		public T NewFabDto() {
			return new T();
		}*/

	}

}