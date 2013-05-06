using System.Collections.Generic;
using System.Linq;
using Weaver.Schema;

namespace Fabric.Domain.Meta {

	/*================================================================================================*/
	public class SchemaHelperNode {

		public WeaverNodeSchema NodeSchema { get; private set; }

		public bool HasParentClass { get; private set; }

		private readonly IList<SchemaHelperProp> vProps;
		private readonly IList<SchemaHelperNodeRel> vRels;
		private readonly IDictionary<string, IList<SchemaHelperProp>> vSubMap;
		private readonly IDictionary<string, bool> vSubOptMap;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SchemaHelperNode(WeaverNodeSchema pNode) {
			NodeSchema = pNode;

			HasParentClass = (NodeSchema.BaseNode != null);

			vProps = new List<SchemaHelperProp>();
			vRels = new List<SchemaHelperNodeRel>();
			vSubMap = new Dictionary<string, IList<SchemaHelperProp>>();
			vSubOptMap = new Dictionary<string, bool>();

			foreach ( FabricPropSchema ps in NodeSchema.Props ) {
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

			foreach ( WeaverRelSchema pr in SchemaHelper.SchemaInstance.Rels ) {
				if ( pr.FromNode != NodeSchema && pr.ToNode != NodeSchema ) { continue; }
				vRels.Add(new SchemaHelperNodeRel(this, pr));
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
		public IList<SchemaHelperNodeRel> GetRels(bool pSkipInternal=false) {
			return vRels
				.Where(r => (!pSkipInternal || !r.IsTargetNodeInternal))
				.ToList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<SchemaHelperNodeRel> GetNestedRels(bool pSkipInternal=false) {
			if ( NodeSchema.BaseNode == null ) {
				return GetRels(pSkipInternal);
			}

			var parent = new SchemaHelperNode(NodeSchema.BaseNode);
			List<SchemaHelperNodeRel> rels = parent.GetNestedRels(pSkipInternal).ToList();
			rels.AddRange(GetRels(pSkipInternal));
			return rels;
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

			if ( NodeSchema.BaseNode != null ) {
				return new SchemaHelperNode(NodeSchema.BaseNode).GetPrimaryKeyProp();
			}
			
			return null;
		}
		
	}

}