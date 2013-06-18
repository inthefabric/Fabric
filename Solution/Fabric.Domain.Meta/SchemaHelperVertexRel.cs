using Weaver.Core.Elements;
using Weaver.Core.Schema;

namespace Fabric.Domain.Meta {

	/*================================================================================================*/
	public class SchemaHelperVertexEdge : SchemaHelperEdge {

		public bool IsOutgoing { get; private set; }
		public WeaverEdgeConn Conn { get; private set; }
		public bool IsMany { get; private set; }
		public bool IsTargetVertexInternal { get; private set; }
		public string EdgePropName { get; private set; }
		public string TargetVertexType { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SchemaHelperVertexEdge(SchemaHelperVertex pHelpVertex, WeaverEdgeSchema pEdge) : base(pEdge) {
			IsOutgoing = (pEdge.OutVertex == pHelpVertex.VertexSchema);
			Conn = (IsOutgoing ? pEdge.OutVertexConn : pEdge.InVertexConn);

			IsMany = GetEdgeHasMany(IsOutgoing);
			IsTargetVertexInternal = GetEdgeVertexIsInternal(IsOutgoing);
			EdgePropName = GetEdgePropName(IsOutgoing);
			TargetVertexType = GetEdgeVertexType(IsOutgoing);
		}

	}

}