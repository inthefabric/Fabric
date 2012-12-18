using Weaver.Items;
using Weaver.Schema;

namespace Fabric.Domain {

	/*================================================================================================*/
	public class SchemaHelperNodeRel : SchemaHelperRel {

		public bool IsOutgoing { get; private set; }
		public bool IsTargetNodeInternal { get; private set; }
		public WeaverRelConn Conn { get; private set; }
		public bool IsMany { get; private set; }
		public string RelPropName { get; private set; }
		public string RelDtoPropName { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SchemaHelperNodeRel(SchemaHelperNode pHelpNode, WeaverRelSchema pRel) : base(pRel) {
			IsOutgoing = (pRel.FromNode == pHelpNode.NodeSchema);
			IsTargetNodeInternal = (IsOutgoing ? pRel.ToNode.IsInternal : pRel.FromNode.IsInternal);
			Conn = (IsOutgoing ? pRel.FromNodeConn : pRel.ToNodeConn);
			
			IsMany = (IsOutgoing ?
				(Conn == WeaverRelConn.OutToOneOrMore || Conn ==WeaverRelConn.OutToZeroOrMore) :
				(Conn == WeaverRelConn.InFromOneOrMore || Conn ==WeaverRelConn.InFromZeroOrMore)
			);

			var useS = (IsMany ? "s" : "");

			RelPropName = (IsOutgoing ?
				"Out"+RelTypeName+ToNodeName+useS :
				"In"+FromNodeName+useS+RelTypeName
			);

			useS = (IsMany ? "List" : "");

			RelDtoPropName = (IsOutgoing ?
				RelTypeName+ToNodeName+useS :
				"In"+FromNodeName+useS+RelTypeName
			);
		}

	}

}