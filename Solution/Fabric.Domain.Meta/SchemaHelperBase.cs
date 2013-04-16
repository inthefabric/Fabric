using System.Collections.Generic;
using Weaver.Schema;

namespace Fabric.Domain.Meta {

	/*================================================================================================*/
	public static partial class SchemaHelper {
		
		private static Schema SchemaInner;
		private static IList<WeaverNodeSchema> WeaverNodeSchemaList;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Schema SchemaInstance {
			get { 
				if ( SchemaInner == null ) { SchemaInner = new Schema(); }
				return SchemaInner;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static WeaverNodeSchema BuildNodeForWeaver(string pNodeName) {
			WeaverNodeSchema ns = GetNode(pNodeName).NodeSchema;

			var newNs = new WeaverNodeSchema(ns.Name, ns.DbName);
			newNs.BaseNode = ns.BaseNode;

			foreach ( WeaverPropSchema ps in ns.Props ) {
				newNs.Props.Add(ps);
			}

			FillBaseNodeProps(newNs, newNs.BaseNode);

			var psType = new WeaverPropSchema("FabType", newNs.DbName+".FT", typeof(int));
			newNs.Props.Add(psType);
			
			return newNs;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FillBaseNodeProps(WeaverNodeSchema pNode, WeaverNodeSchema pBase) {
			if ( pBase == null ) {
				return;
			}

			foreach ( WeaverPropSchema ps in pBase.Props ) {
				string db = pNode.DbName+'.'+ps.DbName.Split('.')[1];

				var psNew = new WeaverPropSchema(ps.Name, db, ps.Type);
				psNew.IsNullable = ps.IsNullable; //probably not necessary
				pNode.Props.Add(psNew);
			}

			FillBaseNodeProps(pNode, pBase.BaseNode);
		}

	}

}