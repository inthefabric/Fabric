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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SchemaHelperNode(WeaverNodeSchema pNode) {
			NodeSchema = pNode;

			HasParentClass = (NodeSchema.BaseNode != null);

			vProps = new List<SchemaHelperProp>();
			vRels = new List<SchemaHelperNodeRel>();

			foreach ( WeaverPropSchema ps in NodeSchema.Props ) {
				vProps.Add(new SchemaHelperProp(ps));
			}

			foreach ( WeaverRelSchema pr in SchemaHelper.SchemaInstance.Rels ) {
				if ( pr.FromNode != NodeSchema && pr.ToNode != NodeSchema ) { continue; }
				vRels.Add(new SchemaHelperNodeRel(this, pr));
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<SchemaHelperProp> GetProps(bool pSkipInternal=false) {
			return vProps
				.Where(p => (!pSkipInternal || p.PropSchema.IsInternal != true))
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
		public SchemaHelperProp GetPrimaryKeyProp() {
			IList<SchemaHelperProp> props = GetProps();
			
			foreach ( SchemaHelperProp hp in props ) {
				if ( hp.PropSchema.IsPrimaryKey == true ) {
					return hp;
				}
			}
			
			return null;
		}
		
	}

}