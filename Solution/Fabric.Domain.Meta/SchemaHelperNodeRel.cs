using Weaver.Core.Elements;
using Weaver.Core.Schema;

namespace Fabric.Domain.Meta {

	/*================================================================================================*/
	public class SchemaHelperNodeRel : SchemaHelperRel {

		public bool IsOutgoing { get; private set; }
		public WeaverEdgeConn Conn { get; private set; }
		public bool IsMany { get; private set; }
		public bool IsTargetNodeInternal { get; private set; }
		public string RelPropName { get; private set; }
		public string TargetNodeType { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SchemaHelperNodeRel(SchemaHelperNode pHelpNode, WeaverEdgeSchema pRel) : base(pRel) {
			IsOutgoing = (pRel.OutVertex == pHelpNode.NodeSchema);
			Conn = (IsOutgoing ? pRel.OutVertexConn : pRel.InVertexConn);

			IsMany = GetEdgeHasMany(IsOutgoing);
			IsTargetNodeInternal = GetEdgeNodeIsInternal(IsOutgoing);
			RelPropName = GetEdgePropName(IsOutgoing);
			TargetNodeType = GetEdgeNodeType(IsOutgoing);
		}

	}

}