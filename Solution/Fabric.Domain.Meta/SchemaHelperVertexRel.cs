using Weaver.Core.Elements;
using Weaver.Core.Schema;

namespace Fabric.Domain.Meta {

	/*================================================================================================*/
	public class SchemaHelperVertexRel : SchemaHelperRel {

		public bool IsOutgoing { get; private set; }
		public WeaverEdgeConn Conn { get; private set; }
		public bool IsMany { get; private set; }
		public bool IsTargetVertexInternal { get; private set; }
		public string RelPropName { get; private set; }
		public string TargetVertexType { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SchemaHelperVertexRel(SchemaHelperVertex pHelpVertex, WeaverEdgeSchema pRel) : base(pRel) {
			IsOutgoing = (pRel.OutVertex == pHelpVertex.VertexSchema);
			Conn = (IsOutgoing ? pRel.OutVertexConn : pRel.InVertexConn);

			IsMany = GetEdgeHasMany(IsOutgoing);
			IsTargetVertexInternal = GetEdgeVertexIsInternal(IsOutgoing);
			RelPropName = GetEdgePropName(IsOutgoing);
			TargetVertexType = GetEdgeVertexType(IsOutgoing);
		}

	}

}