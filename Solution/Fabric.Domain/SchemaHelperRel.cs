using Weaver.Items;
using Weaver.Schema;

namespace Fabric.Domain {

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

	}

}