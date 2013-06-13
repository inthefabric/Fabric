namespace Fabric.Domain.Meta {

	/*================================================================================================*/
	public static partial class SchemaHelper {
		
		private static Schema SchemaInner;
		//private static IList<WeaverVertexSchema> WeaverVertexSchemaList;


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
		public static IList<FabricPropSchema> GetSubPropsForWeaver(WeaverVertexSchema pBaseVertex) {
			if ( !pBaseVertex.IsBaseClass ) {
				return pBaseVertex.Props.Cast<FabricPropSchema>().ToList();
			}

			var list = new List<FabricPropSchema>();

			foreach ( string nodeName in GetVertices() ) {
				WeaverVertexSchema ns = GetNodeSchemaForWeaver(nodeName);

				if ( ns.BaseVertex == null || ns.BaseVertex.Name != pBaseVertex.Name ) {
					continue;
				}

				list.AddRange(GetSubPropsForWeaver(ns));
			}

			return list;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		private static WeaverVertexSchema GetNodeSchemaForWeaver(string pNodeName) {
			WeaverVertexSchema ns = GetNode(pNodeName).NodeSchema;

			var newNs = new WeaverVertexSchema(ns.Name, ns.DbName);
			newNs.BaseVertex = ns.BaseVertex;

			foreach ( WeaverPropSchema ps in ns.Props ) {
				newNs.Props.Add(ps);
			}

			FillBaseVertexProps(newNs, newNs.BaseVertex);
			return newNs;
		}

		/*--------------------------------------------------------------------------------------------* /
		private static void FillBaseVertexProps(WeaverVertexSchema pNode, WeaverVertexSchema pBase) {
			if ( pBase == null ) {
				return;
			}

			foreach ( WeaverPropSchema ps in pBase.Props ) {
				string db = pNode.DbName+'_'+ps.DbName.Split('_')[1];

				var psNew = new FabricPropSchema(ps.Name, db, ps.Type);
				psNew.EnumName = ((FabricPropSchema)ps).EnumName;
				pNode.Props.Add(psNew);
			}

			FillBaseVertexProps(pNode, pBase.BaseVertex);
		}*/

	}

}