using System.Collections.Generic;
using Weaver.Core.Elements;

namespace Fabric.New.Domain {

	/*================================================================================================*/
	public abstract class EdgeBase<TOut, TType, TIn> : WeaverEdge<TOut, TType, TIn>, IEdge
																	where TOut : IWeaverVertex, new()
																	where TType : IWeaverEdgeType, new()
																	where TIn : IWeaverVertex, new() {

		public string InVertexId { get; set; }
		public string OutVertexId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Fill(IDictionary<string, string> pData) {}

	}

}