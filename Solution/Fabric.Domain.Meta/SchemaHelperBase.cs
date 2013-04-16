namespace Fabric.Domain.Meta {

	/*================================================================================================*/
	public static partial class SchemaHelper {
		
		private static Schema SchemaInner;
		//private static IList<WeaverNodeSchema> WeaverNodeSchemaList;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Schema SchemaInstance {
			get { 
				if ( SchemaInner == null ) { SchemaInner = new Schema(); }
				return SchemaInner;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		public static IList<FabricPropSchema> GetSubPropsForWeaver(WeaverNodeSchema pBaseNode) {
			if ( !pBaseNode.IsBaseClass ) {
				return pBaseNode.Props.Cast<FabricPropSchema>().ToList();
			}

			var list = new List<FabricPropSchema>();

			foreach ( string nodeName in GetNodes() ) {
				WeaverNodeSchema ns = GetNodeSchemaForWeaver(nodeName);

				if ( ns.BaseNode == null || ns.BaseNode.Name != pBaseNode.Name ) {
					continue;
				}

				list.AddRange(GetSubPropsForWeaver(ns));
			}

			return list;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		private static WeaverNodeSchema GetNodeSchemaForWeaver(string pNodeName) {
			WeaverNodeSchema ns = GetNode(pNodeName).NodeSchema;

			var newNs = new WeaverNodeSchema(ns.Name, ns.DbName);
			newNs.BaseNode = ns.BaseNode;

			foreach ( WeaverPropSchema ps in ns.Props ) {
				newNs.Props.Add(ps);
			}

			FillBaseNodeProps(newNs, newNs.BaseNode);
			return newNs;
		}

		/*--------------------------------------------------------------------------------------------* /
		private static void FillBaseNodeProps(WeaverNodeSchema pNode, WeaverNodeSchema pBase) {
			if ( pBase == null ) {
				return;
			}

			foreach ( WeaverPropSchema ps in pBase.Props ) {
				string db = pNode.DbName+'_'+ps.DbName.Split('_')[1];

				var psNew = new FabricPropSchema(ps.Name, db, ps.Type);
				psNew.EnumName = ((FabricPropSchema)ps).EnumName;
				pNode.Props.Add(psNew);
			}

			FillBaseNodeProps(pNode, pBase.BaseNode);
		}*/

	}

}