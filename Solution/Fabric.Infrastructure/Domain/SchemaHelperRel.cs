using Weaver.Items;
using Weaver.Schema;

namespace Fabric.Infrastructure.Domain {

	/*================================================================================================*/
	public class SchemaHelperRel {

		public WeaverRelSchema RelSchema { get; private set; }

		public string FromNodeName { get; private set; }
		public string RelTypeName { get; private set; }
		public string ToNodeName { get; private set; }
		public string RelName { get; private set; }

		public string WeaverBaseClass { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SchemaHelperRel(WeaverRelSchema pRel) {
			RelSchema = pRel;
			
			FromNodeName = RelSchema.FromNode.Name;
			RelTypeName = RelSchema.Name;
			ToNodeName = RelSchema.ToNode.Name;
			RelName = FromNodeName+RelSchema.Name+ToNodeName;

			WeaverBaseClass = typeof(WeaverRel).Name+
				"<"+FromNodeName+", "+RelTypeName+", "+ToNodeName+">";
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public string GetRelNodeType(bool pIsOut) {
			return (pIsOut ? ToNodeName : FromNodeName);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public bool GetRelNodeIsInternal(bool pIsOut) {
			return (pIsOut ? RelSchema.ToNode.IsInternal : RelSchema.FromNode.IsInternal);
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool GetRelHasMany(bool pIsOut) {
			WeaverRelConn c = (pIsOut ? RelSchema.FromNodeConn : RelSchema.ToNodeConn);

			return (pIsOut ?
				(c == WeaverRelConn.OutToOneOrMore || c ==WeaverRelConn.OutToZeroOrMore) :
				(c == WeaverRelConn.InFromOneOrMore || c ==WeaverRelConn.InFromZeroOrMore)
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetRelPropName(bool pIsOut) {
			var useS = (GetRelHasMany(pIsOut) ? "List" : "");

			return (pIsOut ?
				RelTypeName+ToNodeName+useS :
				"In"+FromNodeName+useS+RelTypeName
			);
		}

	}

}