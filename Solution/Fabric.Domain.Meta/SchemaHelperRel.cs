using Weaver.Core.Elements;
using Weaver.Core.Schema;

namespace Fabric.Domain.Meta {

	/*================================================================================================*/
	public class SchemaHelperRel {

		public WeaverEdgeSchema RelSchema { get; private set; }

		public string OutVertexName { get; private set; }
		public string EdgeTypeName { get; private set; }
		public string InVertexName { get; private set; }
		public string EdgeName { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SchemaHelperRel(WeaverEdgeSchema pRel) {
			RelSchema = pRel;
			
			OutVertexName = RelSchema.OutVertex.Name;
			EdgeTypeName = RelSchema.EdgeType;
			InVertexName = RelSchema.InVertex.Name;
			EdgeName = RelSchema.Name;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public string GetEdgeVertexType(bool pIsOut) {
			return (pIsOut ? InVertexName : OutVertexName);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public bool GetEdgeVertexIsInternal(bool pIsOut) {
			return (pIsOut ? RelSchema.InVertex.IsInternal : RelSchema.OutVertex.IsInternal);
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool GetEdgeHasMany(bool pIsOut) {
			WeaverEdgeConn c = (pIsOut ? RelSchema.OutVertexConn : RelSchema.InVertexConn);

			return (pIsOut ?
				(c == WeaverEdgeConn.OutToOneOrMore || c ==WeaverEdgeConn.OutToZeroOrMore) :
				(c == WeaverEdgeConn.InFromOneOrMore || c ==WeaverEdgeConn.InFromZeroOrMore)
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetEdgePropName(bool pIsOut) {
			var useS = (GetEdgeHasMany(pIsOut) ? "List" : "");

			return (pIsOut ?
				EdgeTypeName+InVertexName+useS :
				"In"+OutVertexName+useS+EdgeTypeName
			);
		}

	}

}