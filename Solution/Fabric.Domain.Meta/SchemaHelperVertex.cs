using System.Collections.Generic;
using System.Linq;
using Weaver.Core.Schema;

namespace Fabric.Domain.Meta {

	/*================================================================================================*/
	public class SchemaHelperVertex {

		public WeaverVertexSchema VertexSchema { get; private set; }

		public bool HasParentClass { get; private set; }
		public string PluralName { get; private set; }

		private readonly IList<SchemaHelperProp> vProps;
		private readonly IList<SchemaHelperVertexEdge> vEdges;
		private readonly IDictionary<string, IList<SchemaHelperProp>> vSubMap;
		private readonly IDictionary<string, bool> vSubOptMap;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SchemaHelperVertex(WeaverVertexSchema pVertex) {
			VertexSchema = pVertex;

			HasParentClass = (VertexSchema.BaseVertex != null);
			PluralName = pVertex.Name+(pVertex.Name[pVertex.Name.Length-1] == 's' ? "es" : "s");

			vProps = new List<SchemaHelperProp>();
			vEdges = new List<SchemaHelperVertexEdge>();
			vSubMap = new Dictionary<string, IList<SchemaHelperProp>>();
			vSubOptMap = new Dictionary<string, bool>();

			foreach ( FabricPropSchema ps in VertexSchema.Props ) {
				var hp = new SchemaHelperProp(ps);
				vProps.Add(hp);

				string name = ps.Name;
				int underI = name.IndexOf('_');

				if ( underI == -1 ) {
					continue;
				}

				string sub = name.Substring(0, underI);

				if ( !vSubMap.ContainsKey(sub) ) {
					vSubMap.Add(sub, new List<SchemaHelperProp>());
					vSubOptMap.Add(sub, true);
				}

				vSubMap[sub].Add(hp);

				if ( ps.SubObjIsOptional == false ) {
					vSubOptMap[sub] = false;
				}
			}

			foreach ( WeaverEdgeSchema pr in SchemaHelper.SchemaInstance.Edges ) {
				if ( pr.OutVertex != VertexSchema && pr.InVertex != VertexSchema ) { continue; }
				vEdges.Add(new SchemaHelperVertexEdge(this, pr));
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<SchemaHelperProp> GetProps(bool pSkipInternal=false, bool pSkipSubs=false) {
			return vProps
				.Where(p => (!pSkipInternal || p.PropSchema.IsInternal != true))
				.Where(p => (!pSkipSubs || !p.IsSubProp() ))
				.ToList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<SchemaHelperProp> GetNestedProps(bool pSkipInternal=false, bool pSkipSubs=false) {
			if ( VertexSchema.BaseVertex == null ) {
				return GetProps(pSkipInternal, pSkipSubs);
			}

			var parent = new SchemaHelperVertex(VertexSchema.BaseVertex);
			List<SchemaHelperProp> props = parent.GetNestedProps(pSkipInternal, pSkipSubs).ToList();
			props.AddRange(GetProps(pSkipInternal, pSkipSubs));
			return props;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<SchemaHelperVertexEdge> GetEdges(bool pSkipInternal=false) {
			return vEdges
				.Where(r => (!pSkipInternal || !r.IsTargetVertexInternal))
				.ToList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<SchemaHelperVertexEdge> GetNestedEdges(bool pSkipInternal=false) {
			if ( VertexSchema.BaseVertex == null ) {
				return GetEdges(pSkipInternal);
			}

			var parent = new SchemaHelperVertex(VertexSchema.BaseVertex);
			List<SchemaHelperVertexEdge> edges = parent.GetNestedEdges(pSkipInternal).ToList();
			edges.AddRange(GetEdges(pSkipInternal));
			return edges;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<string> GetSubNames() {
			return vSubMap.Keys.ToList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool GetSubPropIsOptional(string pSubName) {
			return vSubOptMap[pSubName];
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<SchemaHelperProp> GetSubProps(string pSubName) {
			return vSubMap[pSubName];
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public SchemaHelperProp GetPrimaryKeyProp() {
			IList<SchemaHelperProp> props = GetProps();
			
			foreach ( SchemaHelperProp hp in props ) {
				if ( hp.PropSchema.IsPrimaryKey == true ) {
					return hp;
				}
			}

			if ( VertexSchema.BaseVertex != null ) {
				return new SchemaHelperVertex(VertexSchema.BaseVertex).GetPrimaryKeyProp();
			}
			
			return null;
		}
		
	}

}