using System.Collections.Generic;
using Weaver.Core.Elements;

namespace Fabric.Domain {

	/*================================================================================================*/
	public abstract class Edge<TOut, TType, TIn> : WeaverEdge<TOut,TType,TIn>, IEdge
																	where TOut : IWeaverVertex, new()
																	where TType : IWeaverEdgeType, new()
																	where TIn : IWeaverVertex, new() {

		public string InVertexId { get; set; }
		public string OutVertexId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithData(IDictionary<string, string> pData) {}

	}

}