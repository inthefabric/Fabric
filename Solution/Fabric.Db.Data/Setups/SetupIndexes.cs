using System.Collections.Generic;
using Fabric.Domain.Meta;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Query;
using Weaver.Core.Schema;
using Weaver.Titan;
using Weaver.Titan.Schema;

namespace Fabric.Db.Data.Setups {

	/*================================================================================================*/
	public class SetupIndexes {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void SetupAll(DataSet pSet) {
			var su = new SetupIndexes(pSet);
		}
			

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private SetupIndexes(DataSet pSet) {
			IList<string> vertNames = SchemaHelper.GetVertices();
			IList<string> edgeNames = SchemaHelper.GetEdges();
			var propMap = new Dictionary<WeaverTitanPropSchema, IWeaverVarAlias>();
			int groupId = 2;

			foreach ( string name in vertNames ) {
				WeaverVertexSchema v = SchemaHelper.GetVertex(name).VertexSchema;

				IWeaverQuery q = Weave.Inst.TitanGraph().TypeGroupOf(v, groupId++);
				IWeaverVarAlias g;
				q = WeaverQuery.StoreResultAsVar(v.DbName, q, out g);
				pSet.AddIndexQuery(q);

				foreach ( FabricPropSchema p in v.Props ) {
					q = Weave.Inst.TitanGraph().MakePropertyKey(v, p, g).ToQuery();
					IWeaverVarAlias pv;
					q = WeaverQuery.StoreResultAsVar(p.DbName, q, out pv);
					pSet.AddIndexQuery(q);

					propMap.Add(p, pv);
				}
			}

			foreach ( string name in edgeNames ) {
				WeaverEdgeSchema e = SchemaHelper.GetEdge(name).EdgeSchema;
				IWeaverQuery q = Weave.Inst.TitanGraph().BuildEdgeLabel(e, p => propMap[p]).ToQuery();
				pSet.AddIndexQuery(q);
			}
		}

	}

}