using Weaver.Core.Elements;
using Weaver.Core.Schema;

namespace Fabric.Domain.Meta {

	/*================================================================================================*/
	public class SchemaHelperEdge {

		public WeaverEdgeSchema EdgeSchema { get; private set; }

		public string OutVertexName { get; private set; }
		public string EdgeTypeName { get; private set; }
		public string InVertexName { get; private set; }
		public string EdgeName { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SchemaHelperEdge(WeaverEdgeSchema pEdge) {
			EdgeSchema = pEdge;
			
			OutVertexName = EdgeSchema.OutVertex.Name;
			EdgeTypeName = EdgeSchema.EdgeType;
			InVertexName = EdgeSchema.InVertex.Name;
			EdgeName = EdgeSchema.Name;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public string GetEdgeVertexType(bool pIsOut) {
			return (pIsOut ? InVertexName : OutVertexName);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public bool GetEdgeVertexIsInternal(bool pIsOut) {
			return (pIsOut ? EdgeSchema.InVertex.IsInternal : EdgeSchema.OutVertex.IsInternal);
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool GetEdgeHasMany(bool pIsOut) {
			WeaverEdgeConn c = (pIsOut ? EdgeSchema.OutVertexConn : EdgeSchema.InVertexConn);

			return (pIsOut ?
				(c == WeaverEdgeConn.OutOneOrMore || c ==WeaverEdgeConn.OutZeroOrMore) :
				(c == WeaverEdgeConn.InOneOrMore || c ==WeaverEdgeConn.InZeroOrMore)
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