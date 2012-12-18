using Weaver.Items;
using Weaver.Schema;

namespace Fabric.Domain {

	/*================================================================================================*/
	public class SchemaHelperNodeRel : SchemaHelperRel {

		public bool IsOutgoing { get; private set; }
		public WeaverRelConn Conn { get; private set; }
		public bool IsMany { get; private set; }
		public bool IsTargetNodeInternal { get; private set; }
		public string RelPropName { get; private set; }
		public string RelDtoPropName { get; private set; }
		public string TargetNodeType { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SchemaHelperNodeRel(SchemaHelperNode pHelpNode, WeaverRelSchema pRel) : base(pRel) {
			IsOutgoing = (pRel.FromNode == pHelpNode.NodeSchema);
			Conn = (IsOutgoing ? pRel.FromNodeConn : pRel.ToNodeConn);

			IsMany = GetRelHasMany(IsOutgoing);
			IsTargetNodeInternal = GetRelNodeIsInternal(IsOutgoing);
			RelPropName = GetRelPropName(IsOutgoing);
			RelDtoPropName = GetRelDtoPropName(IsOutgoing);
			TargetNodeType = GetRelNodeType(IsOutgoing);
		}

	}

}